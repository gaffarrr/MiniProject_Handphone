using Dapper;
using Microsoft.Extensions.Configuration;
using MiniProject_Handphone.Service.Interface.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_Handphone.Service.Services
{
    public class DbService : IDbService
    {
        private readonly IDbConnection _db;
        public DbService(IConfiguration configuration)
        {
            _db = new MySqlConnection(configuration.GetConnectionString("ConnectHandphonedb"));
        }

        public async Task<bool> Check(string command, object param)
        {
            var result = await _db.ExecuteScalarAsync<bool>(command, param);
            return result;
        }

        public async Task<T> Get<T>(string command, object param)
        {
            T result = await _db.QuerySingleAsync<T>(command, param);
            return result;
        }

        public async Task<List<T>> GetList<T>(string command, object param)
        {
            List<T> result = (await _db.QueryAsync<T>(command, param)).ToList();
            return result;
        }

        public async Task<int> ModifyData(string command, object param)
        {
            var result = await _db.ExecuteAsync(command, param);
            return result;
        }
    }
}
