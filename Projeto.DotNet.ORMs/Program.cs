using Projeto.DotNet.ORMs.Nhibernate.DataSource;
using Projeto.ORM.Test.Entities;
using System;
using System.Linq;

namespace Projeto.DotNet.ORMs
{
    class Program
    {
        static void Main(string[] args)
        {
            var session = new HibernateSessionFactory().GetSession();

            var produto = session.Query<Produto>().ToList();



        }
    }
}
