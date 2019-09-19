using ApiSupport.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSupport.Services
{
    public class GetDataService : IDisposable
    {
        private readonly IConfiguration configuration;
        private readonly SqlConnection RawDbConnection;
        public GetDataService(IConfiguration configuration)
        {
            this.configuration = configuration;

            var constring = configuration.GetConnectionString("Azure");

            this.RawDbConnection = new SqlConnection(constring);
            this.RawDbConnection.Open();
        }

        public async Task<List<BenefitModel>> GetBenefits()
        {
            var benefits = new List<BenefitModel>();

            var command = this.RawDbConnection.CreateCommand();
            command.CommandText = "select Title, Description from CareerBenefit where rowstatus = 1 ";
            using (var read = await command.ExecuteReaderAsync())
            {
                while (await read.ReadAsync())
                {
                    var benefit = new BenefitModel
                    {
                        Title = read[0].ToString(),
                        Description = read[1].ToString()
                    };
                    benefits.Add(benefit);
                }
            }
            return benefits;
        }

        public void Dispose()
        {
            RawDbConnection.Dispose();
        }
    }
}
