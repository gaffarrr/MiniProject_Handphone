using MiniProject_Handphone.Data.Interface.Repositories;
using MiniProject_Handphone.Model.Entities;
using MiniProject_Handphone.Service.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_Handphone.Service.Services
{
    public class HandphoneService : IHandphoneService
    {
        private readonly IHandphoneRepository handphoneRepository;
        public HandphoneService(IHandphoneRepository handphoneRepository)
        {
            this.handphoneRepository = handphoneRepository;
        }

        public async Task<bool> CreateNewDevice(string brand, string name, string os, string procie, int price, string[] network)
        {
            if (await handphoneRepository.CheckDevice(name) == true)
            {
                return false;
            }
            var result = await handphoneRepository.CreateNewDevice(brand, name, os, procie, price);
            int DeviceId = await handphoneRepository.GetIdByName("devices", name);
            foreach(string x in network)
            {
                int NetworkId = await handphoneRepository.GetIdByName("networks", x);
                await handphoneRepository.RelateNetworkWithDevice(DeviceId, NetworkId);
            }
            return result;
        }

        public async Task<bool> DeleteData(int id)
        {
            var result = await handphoneRepository.DeleteData(id);
            return result;
        }

        public async Task<List<HandphoneData>> GetAll(int num)
        {
            int Page = (num - 1) * 10;
            if (Page < 0)
            {
                Page = 0;
            }
            var result = await handphoneRepository.GetAll(Page);
            foreach(var x in result)
            {
                x.Network = await handphoneRepository.GetAllNetworks(await handphoneRepository.GetIdByName("devices", x.Name));
            }
            return result;
        }

        public async Task<List<HandphoneData>> GetDataByNetwork(string Network)
        {
            var result = await handphoneRepository.GetDataByNetwork(Network);
            foreach (var x in result)
            {
                x.Network = await handphoneRepository.GetAllNetworks(await handphoneRepository.GetIdByName("devices", x.Name));
            }
            return result;
        }

        public async Task<bool> UpdateByDeviceId(HandphoneData model, int id)
        {
            var result = await handphoneRepository.UpdateDeviceById(id, model.Brand, model.Name, model.Os, model.Procie, model.Price);
            foreach(string x in model.Network)
            {
                int NetworkId = await handphoneRepository.GetIdByName("networks", x);
                if(await handphoneRepository.CheckRelation(id, NetworkId))
                {
                    continue;
                }
                else
                {
                    await handphoneRepository.RelateNetworkWithDevice(id, NetworkId);
                }
            }
            return true;
        }
    }
}
