using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Kaiji.Pages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Kaiji.Model.DB
{
    public class Repository
    {
        private readonly static IConfiguration configuration = new ConfigurationBuilder().SetBasePath(IndexModel.instance.Environment.ContentRootPath).AddJsonFile("appsettings.json").Build();

        public static void Create<T>(T item)
        {
            using (var conn = new SqlConnection(configuration.GetConnectionString("KaijiContextConnection")))
            {
                var SqlStr = $"EXEC Create_{typeof(T).Name}";
                var properties = item.GetType().GetProperties().ToList();
                foreach (var i in properties)
                {
                    if(i.Name != "Id")
                    {
                        if (properties.IndexOf(i) == properties.Count - 1)
                        {
                            SqlStr += $" @{i.Name}";
                        }
                        else
                        {
                            SqlStr += $" @{i.Name},";
                        }
                    }
                }
                conn.Query<T>(SqlStr,item);
            }
        }

        public static List<T> Read<T>()
        {
            using (var conn = new SqlConnection(configuration.GetConnectionString("KaijiContextConnection")))
            {
                return conn.Query<T>($"EXEC Read_{typeof(T).Name}").ToList();
            }
        }
    }
}
