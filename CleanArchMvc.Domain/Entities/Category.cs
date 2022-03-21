using CleanArchMvc.Domain.Validation;
using System.Collections.Generic;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category // O modificador sealed define que a classe em questão não pode ser herdada.
    {

        public int Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<Product> Products{ get; set; }  // No projeto, uma categoria podera ter mais de um produto. Vamos setar a seguinte propriedade.

        public Category(string name)
        {
            ValidateDomain(name);
        }
        
        public Category(int id, string name) // Adicionamos mais um construtor pois será necessário no momento de popular o bd.
        {
            DomainExceptionValidation.When(id < Constants.Constants.ZERO_VALUE, Constants.Constants.ERROR_MINIMUM_ID_VALUE);
            Id = id;
            ValidateDomain(name);
        }
        
        public void Update(string name)
        {
            ValidateDomain(name);
        }


        private void ValidateDomain(string name) // Adicionando validadores no dominio de categoria.
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), Constants.Constants.ERROR_INVALID_NAME);
            DomainExceptionValidation.When(name.Length < 
                Constants.Constants.MINIMUM_CHAR_NAME_VALUE, Constants.Constants.ERROR_MINIMUM_CHAR_NAME
            );

            Name = name;
        }
    }
}
