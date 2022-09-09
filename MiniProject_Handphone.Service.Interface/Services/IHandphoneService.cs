using MiniProject_Handphone.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_Handphone.Service.Interface.Services
{
    public interface IHandphoneService
    {
        public Task<bool> CreateNewDevice(string brand, string name, string os, string procie, int price, string[] network);
        public Task<List<HandphoneData>> GetAll(int num);
        public Task<List<HandphoneData>> GetDataByNetwork(string Network);
        public Task<bool> DeleteData(int id);
        public Task<bool> UpdateByDeviceId(HandphoneData model, int id);
    }
}
