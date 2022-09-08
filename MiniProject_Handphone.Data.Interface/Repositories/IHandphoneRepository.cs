using MiniProject_Handphone.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_Handphone.Data.Interface.Repositories
{
    public interface IHandphoneRepository
    {
        public Task<bool> CreateNewDevice(string brand, string name, string os, string procie, int price);
        public Task<List<HandphoneData>> GetAll();

        public Task<bool> DeleteData(int id);
        public Task<List<HandphoneData>> GetDataByNetwork(string Network);
        public Task<bool> CheckDevice(string name);
        public Task<bool> CheckRelation(int IdDevice, int IdNetwork);
        public Task<int> GetIdByName(string variableName, string name);
        public Task<bool> RelateNetworkWithDevice(int DeviceId, int NetworkId);
        public Task<bool> UpdateDeviceById(int id,string brand, string name, string os, string procie, int price);
        public Task<List<string>> GetAllNetworks(int id);
    }
}
