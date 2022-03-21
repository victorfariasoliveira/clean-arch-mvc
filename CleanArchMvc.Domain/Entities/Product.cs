using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product // o modificador sealed define que a classe em questão não pode ser herdada.
    {
        // PROPERTIES
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        // Adicionamos no modelo product uma referencia (chave estrangeira) a categoria
        // essas propriedades de navegação sao para que o ef core que crie uma tabela intermediaria entre Category e Product,
        // ja que há uma relação n:1.
    }
}
