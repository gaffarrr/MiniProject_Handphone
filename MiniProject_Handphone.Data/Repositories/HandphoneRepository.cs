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
            throw new NotImplementedException();
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

        public async Task<bool> IsDeviceThere(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsNetworkThere(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsRelationThere(int IdDevice, int IdNetwork)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RelateNetworkWithDevice(int IdDevice, int IdNetwork)
        {
            throw new NotImplementedException();
        }
    }
}
