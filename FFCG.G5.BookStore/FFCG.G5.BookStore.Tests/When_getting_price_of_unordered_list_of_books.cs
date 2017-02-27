using System.Collections.Generic;
using FFCG.G5.BookStore.Domain;
using FFCG.G5.BookStore.Domain.DiscountRules;
using FFCG.G5.BookStore.Domain.Domain;
using FFCG.G5.BookStore.Domain.PriceCalculation;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.BookStore.Tests
{
    [TestFixture]
    public class When_getting_price_of_unordered_list_of_books
    {

        private HarryPotterBooksPriceCalculator _harryPotterBooksPriceCalculator;
        private List<Book> _orderedBooks;
        private decimal _result;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var discountRules = new List<IDiscountRule>
            {
                new FiveBooksDiscount(),
                new FourBooksDiscount(),
                new ThreeBooksDiscount(),
                new TwoBooksDiscount()
            };

            _harryPotterBooksPriceCalculator = new HarryPotterBooksPriceCalculator(discountRules);
            _orderedBooks = new List<Book>
            {
                new Book("Harry Potter", 1, 8),
                new Book("Harry Potter", 1, 8),
                new Book("Harry Potter", 2, 8),
                new Book("Harry Potter", 5, 8),
                new Book("Harry Potter", 2, 8),
                new Book("Harry Potter", 4, 8),
                new Book("Harry Potter", 3, 8),
                new Book("Harry Potter", 3, 8)
            };
            _result = _harryPotterBooksPriceCalculator.GetPrice(_orderedBooks);
        }

        [Test]
        public void Should_return_the_correct_price()
        {
            _result.Should().Be(51.60M);
        }
    }
}