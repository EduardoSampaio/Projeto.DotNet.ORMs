using Projeto.ORM.Test.Datasource;
using Projeto.ORM.Test.Entities;

namespace Projeto.ORM.Test.Repositorio
{
    public class ProdutoRepositorio : Repositorio<Produto, int>, IProdutoRepositorio
    {
        public ProdutoRepositorio()
        {
        }
    }
}
