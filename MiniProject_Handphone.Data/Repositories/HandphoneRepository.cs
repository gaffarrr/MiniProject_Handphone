using MiniProject_Handphone.Data.Interface.Repositories;
using MiniProject_Handphone.Model.Entities;
using MiniProject_Handphone.Service.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using DocumentFormat.OpenXml.Bibliography;
using System.Text.Json;

namespace MiniProject_Handphone.Data.Repositories
{
    public class HandphoneRepository : IHandphoneRepository
    {
        public readonly IDbService _dbService;

        public HandphoneRepository(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> CreateNewDevice(string brand, string name, string os, string procie, int price)
        {
            await _dbService.ModifyData("INSERT INTO devices(brand, name, os, procie, price) " +
                "VALUES (@Brand, @Name, @Os, @Procie, @Price);", new {Brand = brand, Name = name, Os = os, Procie = procie, Price = price });
            return true;
        }

        public async Task<bool> DeleteData(int id)
        {
            await _dbService.ModifyData("DELETE FROM device_has_nets d where d.device_id=@Id", new { Id = id });
            await _dbService.ModifyData("DELETE FROM devices b where b.id=@Id", new { Id = id });
            return true;
        }

        public async Task<List<HandphoneData>> GetAll()
        {
            var result = await _dbService.GetList<HandphoneData>
                ("SELECT b.id, b.brand, b.name, b.os, b.procie, b.price " +
                "FROM devices b " +
                "LEFT JOIN device_has_nets d ON b.id=d.device_id " +
                "LEFT JOIN networks n ON d.net_id=n.id " +
                "GROUP BY b.id limit 10 offset 0;", new { });
            return result;
        }

        public async Task<List<string>> GetAllNetworks(int id)
        {
            var result = await _dbService.GetList<string>("SELECT n.name from devices b " +
                "JOIN device_has_nets d ON b.id=d.device_id " +
                "JOIN networks n ON d.net_id=n.id " +
                "WHERE b.id=@Id", new { Id = id});
            return result;
        }

        public async Task<List<HandphoneData>> GetDataByNetwork(string Network)
        {
            var result = await _dbService.GetList<HandphoneData>
                ("SELECT b.id, b.brand, b.name, b.os, b.procie, b.price " +
                "FROM devices b " +
                "LEFT JOIN device_has_nets d ON b.id=d.device_id " +
                "LEFT JOIN networks n ON d.net_id=n.id " +
                "WHERE n.name like @Name " +
                "GROUP BY b.id limit 10;", new { Name = Network });
            return result;
        }

        public async Task<int> GetIdByName(string variableName, string name)
        {
            int id = await _dbService.Get<int>("SELECT id from " + variableName + " where name=@Name", new { Name = name });
            return id;
        }

        public async Task<bool> CheckDevice(string name)
        {
            var result = await _dbService.Check("SELECT COUNT(1) FROM devices WHERE name=@Name", new { Name = name });
            return result;
        }

        public async Task<bool> CheckRelation(int IdDevice, int IdNetwork)
        {
            var result = await _dbService.Check("SELECT COUNT(1) FROM device_has_nets WHERE device_id=@Device_id AND net_id=@Network_id", new { Device_id = IdDevice, Network_id = IdNetwork });
            return result;
        }

        public async Task<bool> RelateNetworkWithDevice(int DeviceId, int NetworkId)
        {
            await _dbService.ModifyData("INSERT INTO device_has_nets " +
                "VALUES (@IdDevice,@IdNetwork);", new { IdDevice = DeviceId, IdNetwork = NetworkId });
            return true;
        }

        public async Task<bool> UpdateDeviceById(int id, string brand, string name, string os, string procie, int price)
        {
            await _dbService.ModifyData("UPDATE devices " +
                "set brand=@Brand, name=@Name, os=@Os, procie=@Procie, price=@Price " +
                "where id=@Id;", new {Id=id, Brand = brand, Name = name, Os = os, Procie = procie, Price = price });
            return true;
        }
    }
}
