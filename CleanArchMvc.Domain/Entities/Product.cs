using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }

        // Adicionamos no modelo product uma referencia (chave estrangeira) a categoria, essas propriedades de navegação sao 
        // para que o ef core que crie uma tabela intermediaria entre Category e Product, ja que há uma relação n:1.
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
