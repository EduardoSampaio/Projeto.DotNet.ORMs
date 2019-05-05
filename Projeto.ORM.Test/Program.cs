using Projeto.ORM.Test.Entities;
using Projeto.ORM.Test.Repositorio;
using System;

namespace Projeto.ORM.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new ProdutoRepositorio();
            var p = new Produto();
            p.Nome = "Produto1";

            repo.Add(p);
            repo.SaveChanges();
        }
    }
}
