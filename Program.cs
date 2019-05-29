using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using LinqToDB;
using LinqToDB.Common;
using LinqToDB.Mapping;
using LinqToDB.Configuration;
using System.Linq;
using LinqToDB.Data;

namespace Member
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Log: Start Connection");

            DataConnection.DefaultSettings = new MySettings();

            using (var db = new lab())
            {
                Console.WriteLine("Log: Before query");
                var members = from m in db.Member
                            orderby m.Id descending
                            select m;
                var result = members.ToList();
                
                Console.WriteLine("Log: After query");

                Console.WriteLine("Log: Count: " + result.Count);
                Console.WriteLine("Log: Result: " + JsonConvert.SerializeObject(result));
                
            }

        }
    }



    [Table(Name = "test_member")]
    public class Member
    {
        [PrimaryKey, Identity]
        [Column(Name = "id"), NotNull]
        public int Id { get; set; }

        [Column(Name = "firstname"), NotNull]
        public string Firstname { get; set; }

        [Column(Name = "lastname"), NotNull]
        public string Lastname { get; set; }

    }

    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }

    public class MySettings : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

        public string DefaultConfiguration => "MySQL";
        public string DefaultDataProvider => "MySQL";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "MySQL",
                        ProviderName = "MySQL",
                        ConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION")
                    };
            }
        }
    }

    public class lab : LinqToDB.Data.DataConnection
    {
        public lab() : base("lab") { }

        public ITable<Member> Member => GetTable<Member>();
    }
}
