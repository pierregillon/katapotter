using KataPotter.Test.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace KataPotter.Test
{
    [Binding]
    public class BasketPriceCalculationFeatureSteps
    {
        private Book _book;
        private Basket _basket;

        [Given(@"A book")]
        public void GivenABook()
        {
            _book = new Book();
        }

        [Then(@"The book price is (.*) euros")]
        public void ThenTheBookPriceIsEuros(decimal expectedPrice)
        {
            Assert.AreEqual(expectedPrice, _book.Price, "Le prix du livre est incorrect.");
        }

        // ----------

        [Given(@"A basket")]
        public void GivenABasket()
        {
            _basket = new Basket();
        }

        [When(@"I add a book to basket")]
        public void WhenIAddABookToBasket()
        {
            var book = new Book();
            _basket.AddBook(book);
        }

        [When(@"I add a book of volume (.*) to basket")]
        public void WhenIAddABookOfVolumeToBasket(int volumeNumber)
        {
            var book = new Book { VolumeNumber = volumeNumber };
            _basket.AddBook(book);
        }

        [When(@"I add (.*) book\(s\) of volume (.*) to basket")]
        public void WhenIAddBookSOfVolumeToBasket(int bookCount, int volumeNumber)
        {
            for (int i = 0; i < bookCount; i++)
            {
                WhenIAddABookOfVolumeToBasket(volumeNumber);
            }
        }

        [Then(@"The basket price is (.*) euros")]
        public void ThenTheBasketPriceIsEuros(decimal expectedBasketPrice)
        {
            Assert.AreEqual(expectedBasketPrice, _basket.Price, "Le prix du panier est incorrect.");
        }
    }
}