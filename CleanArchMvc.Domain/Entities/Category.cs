using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // No projeto, uma categoria podera ter mais de um produto. Vamos setar a seguinte propriedade.
        public ICollection<Product> Products{ get; set; }   
    }
}
