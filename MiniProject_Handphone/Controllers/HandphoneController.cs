using Microsoft.AspNetCore.Mvc;
using MiniProject_Handphone.Model.Entities;
using MiniProject_Handphone.Service.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProject_Handphone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HandphoneController : Controller
    {
        private readonly IHandphoneService handphoneService;

        public HandphoneController(IHandphoneService handphoneService)
        {
            this.handphoneService = handphoneService;
        }

        [HttpPost]
        /*public async Task<IActionResult> Create([FromBody] Handphone model)
        {
            *//*var result = await handphoneService.Create(model);
            return Ok(result);*//*
        }*/

        [HttpGet]
        public async Task<List<HandphoneData>> GetAll()
        {
            var result = await handphoneService.GetAll();
            return result;
        }

        [HttpGet("{input}")]
        public async Task<List<HandphoneData>> GetDataByNetwork(string input)
        {
            var result = await handphoneService.GetDataByNetwork(input);
            return result;
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            var result = await handphoneService.DeleteData(id);
            return Ok(result);
        }
    }
}
