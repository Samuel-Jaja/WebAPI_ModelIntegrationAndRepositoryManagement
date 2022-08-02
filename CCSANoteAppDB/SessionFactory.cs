using CCSANoteApp.DB.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSANoteApp.DB
{
    public class SessionFactory
    {
        public SessionFactory()
        {
            _sessionFactory = BuildSesssionFactory("");
        }
        public ISession GetSession() => _sessionFactory.OpenSession();
        private readonly ISessionFactory _sessionFactory;

        private ISessionFactory BuildSesssionFactory(string connectionString)
        {
            FluentConfiguration configuration = Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString
                (connectionString))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>()).ExposeConfiguration(cfg =>
            {
                new SchemaUpdate(cfg).Execute(true, true);

            });

            //.Mappings(m => m.FluentMappings.AddFromAssembly(typeof(UserMap).Assembly))()).ExposeConfiguration(cfg => {
            //     new SchemaUpdate(cfg).Execute(true, true);
            // });
            return configuration.BuildSessionFactory();

        }


        //private ISessionFactory _sessionFactory;

        //public ISessionFactory SessionFactory => _sessionFactory ??
        //    Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString
        //        (_connectionString))
        //    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
        //    .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
        //    .BuildSessionFactory();

        //public ISession OpenSession()
        //{
        //    return SessionFactory.OpenSession();
        //}


        //private string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MURPHY NNAMDI\source\repos\FashionLine\FashionDB.mdf;Integrated Security = True; Connect Timeout = 30";

    }
}
