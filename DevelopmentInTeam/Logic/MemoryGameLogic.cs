using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentInTeam.Logic
{
    /// <summary>
    /// class representing a card in the Memory game
    /// </summary>
    public class Card
    {
        // declaring fields
        private int _id; 
        private string _imageFileName; // string representing image url
        private bool _isMatched; // a value indicating whether the card has been matched

        // corresponding getters/setters
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        } 

        public string ImageFileName
        {
            get { return _imageFileName; }
            set { _imageFileName = value; }
        }

        public bool IsMatched
        {
            get { return _isMatched; }
            set { _isMatched = value; }
        }
        /// <summary>
        /// class constructor, creating a card with an id, image source
        /// </summary>
        /// <param name="id"></param>
        /// <param name="imageFileName"></param>
        /// <param name="isMatched"></param>
        public Card(int id, string imageFileName, bool isMatched)
        {
            ID = id;
            ImageFileName = imageFileName;
            IsMatched = isMatched;
        }
    }

    public class MemoryGame
    {
        // declaring fields
        private ObservableCollection<Card> _cards; // observable collection of all the cards in the game
        private Card _flippedCard;
        private int _matchedPairsCount; // number of matched card pairs
        private bool _gameOver; // indicates whether the game is over //CHANGE

        // corresponding getters/setters
        public ObservableCollection<Card> Cards
        {
            get { return _cards; }
            set { _cards = value; }
        }

        public Card FlippedCard
        {
            get { return _flippedCard; }
            set { _flippedCard = value; }
        }

        public int MatchedPairsCount
        {
            get { return _matchedPairsCount; }
            set { _matchedPairsCount = value; }
        }

        public bool GameOver
        {
            get { return _gameOver; }
            set { _gameOver = value; }
        }

        /// <summary>
        /// class constructor
        /// </summary>
        public MemoryGame() { }
    }



}
