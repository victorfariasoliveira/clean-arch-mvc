using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            const string CATEGORY_NAME = "CategoryName";
            const int CATEGORY_ID = 1;

            Action action = () => new Category(CATEGORY_ID, CATEGORY_NAME);
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            const string CATEGORY_NAME = "CategoryName";
            const int CATEGORY_ID = -1;

            Action action = () => new Category(CATEGORY_ID, CATEGORY_NAME);
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(Constants.Constants.ERROR_MINIMUM_ID_VALUE);
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionMinimumCharName()
        {
            const string CATEGORY_NAME = "Ca";
            const int CATEGORY_ID = 1;

            Action action = () => new Category(CATEGORY_ID, CATEGORY_NAME);
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(Constants.Constants.ERROR_MINIMUM_CHAR_NAME);
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionInvalidName()
        {
            const string CATEGORY_NAME = "";
            const int CATEGORY_ID = 1;

            Action action = () => new Category(CATEGORY_ID, CATEGORY_NAME);
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(Constants.Constants.ERROR_INVALID_NAME);
        }

        [Fact]
        public void CreateCategory_NullNameValue_DomainExceptionInvalidName()
        {
            const string CATEGORY_NAME = null;
            const int CATEGORY_ID = 1;

            Action action = () => new Category(CATEGORY_ID, CATEGORY_NAME);
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage(Constants.Constants.ERROR_INVALID_NAME);
        }
    }
}
