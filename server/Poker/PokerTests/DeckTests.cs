using System;
using System.Collections.Generic;
using App;
using Xunit;

namespace PokerTests
{
    public class DeckTests
    {
        private List<string> GetAllCards() {
            return new List<string> {
                "AH",
                "KH",
                "QH",
                "JH",
                "10H",
                "9H",
                "8H",
                "7H",
                "6H",
                "5H",
                "4H",
                "3H",
                "2H",
                "AC",
                "KC",
                "QC",
                "JC",
                "10C",
                "9C",
                "8C",
                "7C",
                "6C",
                "5C",
                "4C",
                "3C",
                "2C",
                "AD",
                "KD",
                "QD",
                "JD",
                "10D",
                "9D",
                "8D",
                "7D",
                "6D",
                "5D",
                "4D",
                "3D",
                "2D",
                "AS",
                "KS",
                "QS",
                "JS",
                "10S",
                "9S",
                "8S",
                "7S",
                "6S",
                "5S",
                "4S",
                "3S",
                "2S",

            };
        }

        [Fact]
        public void FirstAndSecondCardCanNotBeTheSame()
        {
            Deck deck = new Deck();
            string firstCard = deck.PickCard();
            string secondCard = deck.PickCard();

            Assert.NotEqual(firstCard, secondCard);
        }

        [Fact]
        public void DoNotThrowErrorWhenDraw52Cards()
        {
            var deck = new Deck();
            for (int i = 0; i <= 52; i++)
            {
                deck.PickCard();
            }

            Assert.True(true);
        }

        [Fact]
        public void ThrowErrorWhenDraw53Cards()
        {
            Deck deck = new Deck();
            for(int i = 0; i <= 52; i++)
            {
                deck.PickCard();
            }

            Assert.Throws<Exception>(() => {
                deck.PickCard();
            });
        }

        [Fact]
        public void WhenDrawAllTheCardYouCanNotHaveAnyRepeated()
        {
            var deck = new Deck();
            var cards = new List<string>();
            for (int i = 0; i <= 52; i++)
            {
                var card = deck.PickCard();
                cards.Add(card);
            }

            foreach (string card in cards)
            {
                var doesExists = cards.Exists(c => c == card);
                if (doesExists) {
                    Assert.True(false);
                }
            }
        }

        [Fact]
        public void DeckMustCointainAllEnglishCards()
        {
            var deck = new Deck();
            var cards = new List<string>();

            for (int i = 0; i <= 52; i++)
            {
                var card = deck.PickCard();
                cards.Add(card);
            }

            var allTheCards = GetAllCards();
            foreach (string card in cards)
            {
                allTheCards.Remove(card);
            }

            bool isEmpty = allTheCards.Count == 0;
            Assert.True(isEmpty);
        }

        [Fact]
        public void CanResetTheDeck()
        {
            var deck = new Deck();
            for (int i = 0; i <= 52; i++)
            {
                deck.PickCard();
            }

            deck.Reset();

            deck.PickCard();

            Assert.True(true);
        }

        [Fact]
        public void WhenResetTheDeckICanDrawEveryEnglishCardAgain()
        {
            var deck = new Deck();

            for (int i = 0; i <= 52; i++)
            {
                deck.PickCard();
            }

            deck.Reset();

            var cards = new List<string>();
            for (int i = 0; i <= 52; i++)
            {
                var card = deck.PickCard();
                cards.Add(card);
            }

            var allTheCards = GetAllCards();
            foreach (string card in cards)
            {
                allTheCards.Remove(card);
            }

            bool isEmpty = allTheCards.Count == 0;
            Assert.True(isEmpty);
        }
    }
}
