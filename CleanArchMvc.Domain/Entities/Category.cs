using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category // O modificador sealed define que a classe em questão não pode ser herdada.
    {
        public static readonly string ERROR_INVALID_NAME = "Invalid name.Name is required.";
        public static readonly string ERROR_MINIMUM_CHAR_NAME = "Invalid name, too short, minimum 3 charecters.";
        public static readonly string ERROR_MINIMUM_ID_VALUE = "Invalid Id value.";

        public static readonly int MINIMUM_CHAR_NAME = 3;
        public static readonly int MINIMUM_ID_VALUE = 0;

        // PROPERTIES
        public int Id { get; private set; }
        public string Name { get; private set; }

        // CONSTRUCTOR
        public Category(string name)
        {
            ValidateDomain(name);
        }
        
        public Category(int id, string name) // Adicionamos mais um construtor pois será necessário no momento de popular o bd.
        {
            DomainExceptionValidation.When(id < MINIMUM_ID_VALUE, ERROR_MINIMUM_ID_VALUE);
            Id = id;
            ValidateDomain(name);
        }
        
        // PUBLIC METHODS
        public ICollection<Product> Products{ get; set; }  // No projeto, uma categoria podera ter mais de um produto. Vamos setar a seguinte propriedade.

        // PRIVATE METHODS
        private void ValidateDomain(string name) // Adicionando validadores no dominio de categoria.
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), ERROR_INVALID_NAME);
            DomainExceptionValidation.When(name.Length < MINIMUM_CHAR_NAME, ERROR_MINIMUM_CHAR_NAME);

            Name = name;
        }
    }
}
