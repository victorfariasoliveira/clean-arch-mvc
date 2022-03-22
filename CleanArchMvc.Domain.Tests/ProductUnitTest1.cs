using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        const string PRODUCT_NAME = "ProductName";
        const int PRODUCT_ID = 1;
        const string PRODUCT_DESCRIPTION = "ProductDescription";
        const decimal PRODUCT_PRICE = 9.99m;
        const int PRODUCT_STOCK = 99;
        const string PRODUCT_IMAGE = "ProductImage";

        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(PRODUCT_ID, PRODUCT_NAME, PRODUCT_DESCRIPTION, PRODUCT_PRICE, PRODUCT_STOCK, PRODUCT_IMAGE);
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            const int PRODUCT_INVALID_ID = -1;

            Action action = () => new Product(
                PRODUCT_INVALID_ID, PRODUCT_NAME, PRODUCT_DESCRIPTION, PRODUCT_PRICE, PRODUCT_STOCK, PRODUCT_IMAGE);

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(Constants.Constants.ERROR_MINIMUM_ID_VALUE);
        }

        [Fact]
        public void CreateProduct_MissingNameValue_DomainExceptionInvalidName()
        {
            const string PRODUCT_MISSING_NAME = "";
            Action action = () => new Product(
                PRODUCT_ID, PRODUCT_MISSING_NAME, PRODUCT_DESCRIPTION, PRODUCT_PRICE, PRODUCT_STOCK, PRODUCT_IMAGE);
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(Constants.Constants.ERROR_INVALID_NAME);
        }

        [Fact]
        public void CreateProduct_NullableNameValue_DomainExceptionInvalidName()
        {
            const string PRODUCT_NULLABLE_NAME = null;
            Action action = () => new Product(
                PRODUCT_ID, PRODUCT_NULLABLE_NAME, PRODUCT_DESCRIPTION, PRODUCT_PRICE, PRODUCT_STOCK, PRODUCT_IMAGE);
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(Constants.Constants.ERROR_INVALID_NAME);
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            const string PRODUCT_SHORT_NAME = "Pr";
            Action action = () => new Product(
                PRODUCT_ID, PRODUCT_SHORT_NAME, PRODUCT_DESCRIPTION, PRODUCT_PRICE, PRODUCT_STOCK, PRODUCT_IMAGE);
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage(Constants.Constants.ERROR_MINIMUM_CHAR_NAME);
        }

        [Fact]
        public void CreateProduct_MissingDescriptionValue_DomainExceptionInvalidName()
        {
            const string PRODUCT_MISSING_DESCRIPTION = "";
            Action action = () => new Product(
                PRODUCT_ID, PRODUCT_NAME, PRODUCT_MISSING_DESCRIPTION, PRODUCT_PRICE, PRODUCT_STOCK, PRODUCT_IMAGE);
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(Constants.Constants.ERROR_INVALID_DESCRIPTION);
        }

        [Fact]
        public void CreateProduct_NullableDescriptionValue_DomainExceptionInvalidName()
        {
            const string PRODUCT_NULLABLE_DESCRIPTION = null;
            Action action = () => new Product(
                PRODUCT_ID, PRODUCT_NAME, PRODUCT_NULLABLE_DESCRIPTION, PRODUCT_PRICE, PRODUCT_STOCK, PRODUCT_IMAGE);
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(Constants.Constants.ERROR_INVALID_DESCRIPTION);
        }

        [Fact]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionShortName()
        {
            const string PRODUCT_SHORT_DESCRIPTION = "Desc";
            Action action = () => new Product(
                PRODUCT_ID, PRODUCT_NAME, PRODUCT_SHORT_DESCRIPTION, PRODUCT_PRICE, PRODUCT_STOCK, PRODUCT_IMAGE);
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage(Constants.Constants.ERROR_MINIMUM_CHAR_DESCRIPTION);
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            const string PRODUCT_LONG_IMAGE_NAME = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem.";
            Action action = () => new Product(
                PRODUCT_ID, PRODUCT_NAME, PRODUCT_DESCRIPTION, PRODUCT_PRICE, PRODUCT_STOCK, PRODUCT_LONG_IMAGE_NAME);

            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage(Constants.Constants.ERROR_MAXIMUM_CHAR_IMAGE);
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            const string PRODUCT_NULL_IMAGE_NAME = null;
            Action action = () => new Product(
                PRODUCT_ID, PRODUCT_NAME, PRODUCT_DESCRIPTION, PRODUCT_PRICE, PRODUCT_STOCK, PRODUCT_NULL_IMAGE_NAME);
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            const string PRODUCT_EMPTY_IMAGE_NAME = "";
            Action action = () => new Product(
                PRODUCT_ID, PRODUCT_NAME, PRODUCT_DESCRIPTION, PRODUCT_PRICE, PRODUCT_STOCK, PRODUCT_EMPTY_IMAGE_NAME);
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_DomainException()
        {
            const decimal PRODUCT_INVALID_PRICE = -9.99m;
            Action action = () => new Product(
                PRODUCT_ID, PRODUCT_NAME, PRODUCT_DESCRIPTION, PRODUCT_INVALID_PRICE, PRODUCT_STOCK, PRODUCT_IMAGE);
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage(Constants.Constants.ERROR_MINIMUM_PRICE_VALUE);
        }


        const int PRODUCT_INVALID_STOCK = -5;

        [Theory]
        [InlineData(PRODUCT_INVALID_STOCK)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(
                PRODUCT_ID, PRODUCT_NAME, PRODUCT_DESCRIPTION, PRODUCT_PRICE, value, PRODUCT_IMAGE);
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage(Constants.Constants.ERROR_MINIMUM_STOCK_VALUE);
        }
    }
}
