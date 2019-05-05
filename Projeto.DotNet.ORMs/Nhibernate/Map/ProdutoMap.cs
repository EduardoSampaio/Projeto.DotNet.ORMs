using FluentNHibernate.Mapping;
using Projeto.ORM.Test.Entities;

namespace Projeto.DotNet.ORMs.Nhibernate
{
    public class ProdutoMap : ClassMap<Produto>
    {
        public ProdutoMap()
        {
            Id(b => b.Id);
            Map(b => b.Nome);
            Table("Produto");
        }
    }
}
