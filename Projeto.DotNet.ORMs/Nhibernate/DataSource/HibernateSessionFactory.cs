using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using NHibernate;
using System.IO;

namespace Projeto.DotNet.ORMs.Nhibernate.DataSource
{
    public class HibernateSessionFactory
    {
        private static IConfigurationRoot Configuration { get; set; }

        private static ISessionFactory _sessionFactory;

        private ISessionFactory GetFactory()
        {
            if (_sessionFactory == null)
            {
                var connection = GetConnectionString();

                _sessionFactory = Fluently.Configure()
                              .Database(MySQLConfiguration.Standard.ConnectionString(connection))
                              .Mappings(m => m.FluentMappings.AddFromAssembly(GetType().Assembly))
                              .BuildSessionFactory();
            }

            return _sessionFactory;
        }

        public ISession GetSession()
        {
            return GetFactory().OpenSession();
        }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            return Configuration["ConnectionStrings:DefaultConnection"];
        }
    }
}
