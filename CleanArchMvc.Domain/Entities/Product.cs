using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product: BaseEntity // o modificador sealed define que a classe em questão não pode ser herdada.
    {
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

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image); 
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < Constants.Constants.ZERO_VALUE, Constants.Constants.ERROR_MINIMUM_ID_VALUE);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image) // Adicionando validadores no dominio de produto.
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), Constants.Constants.ERROR_INVALID_NAME);
            DomainExceptionValidation.When(
                name.Length < Constants.Constants.MINIMUM_CHAR_NAME_VALUE, Constants.Constants.ERROR_MINIMUM_CHAR_NAME
            );

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), Constants.Constants.ERROR_INVALID_DESCRIPTION);
            DomainExceptionValidation.When(
                description.Length < Constants.Constants.MINIMUM_CHAR_DESCRIPTION_VALUE, Constants.Constants.ERROR_MINIMUM_CHAR_DESCRIPTION
            );

            DomainExceptionValidation.When(price < Constants.Constants.ZERO_VALUE, Constants.Constants.ERROR_MINIMUM_PRICE_VALUE);
            DomainExceptionValidation.When(stock < Constants.Constants.ZERO_VALUE, Constants.Constants.ERROR_MINIMUM_STOCK_VALUE);

            DomainExceptionValidation.When(
                image.Length > Constants.Constants.MAXIMUM_CHAR_IMAGE_VALUE, Constants.Constants.ERROR_MAXIMUM_CHAR_IMAGE
            );

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
}
