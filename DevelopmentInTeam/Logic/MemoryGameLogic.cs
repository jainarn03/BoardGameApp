// ALEKS' PAGE

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
        private bool _gameOver; // indicates whether the game is over 
        private Dictionary<int, string> _gameStatus; // dictionary holding status of each card


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
        public Dictionary<int, string> GameStatus
        {
            get { return _gameStatus; }
            set { _gameStatus = value; }
        }

        /// <summary>
        /// class constructor
        /// </summary>
        public MemoryGame() 
        {
            // Initializing _cards observable collection field with 6 card objects
            _cards = new ObservableCollection<Card>()
            {
                new Card(1, "card_1.png", false),
                new Card(2, "card_2.png", false),
                new Card(3, "card_3.png", false),
                new Card(4, "card_4.png", false),
                new Card(5, "card_5.png", false),
                new Card(6, "card_6.png", false)
            };


        }

        /// <summary>
        /// Initializes the game status dict with default values
        /// </summary>
        public void InitializeGameStatus()
        {
            _gameStatus = _cards.ToDictionary(c => c.ID, c => "unflipped");
        }



        /// <summary>
        /// Method handling flipping cards: checks for a match with previously flipped card.
        /// If a match exists, the cards remain flipped. If no match, the cards are flipped back
        /// after delay of 1-2 seconds (may change). Game will end when all cards are paired
        /// </summary>
        /// <param name="card"></param>
        public void FlipCard(Card card)
        {
            // checks whether card can be flipped or not if: game is not over, card flipped is not same as previously flipped card, 
            if (!_gameOver && _flippedCard != card && !card.IsMatched)
            {
                // if no card previously flipped
                if (_flippedCard == null)
                {
                    _flippedCard = card;
                    UpdateGameStatus(card.ID, "flipped"); // updates game status for current card
                    _flippedCard.IsMatched = true; // changes the card state to flipped
                }
                // second card flipped
                else
                {
                    card.IsMatched = true; // change card state to flipped
                    UpdateGameStatus(card.ID, "flipped"); // updates game status for current card
                    if (_flippedCard.ID == card.ID) // if matching IDs
                    {
                        _flippedCard.IsMatched = true;
                        _matchedPairsCount++; // increments matched pairs by 1

                        if (_matchedPairsCount == _cards.Count / 2) // if all cards paired, game is complete
                            _gameOver = true;
                    }
                    // no matches
                    else
                    {
                        // milliseconds delay method found:
                        //https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.continuewith?view=net-8.0
                        Task.Delay(2000).ContinueWith(t =>
                        {
                            UpdateGameStatus(_flippedCard.ID, "unflipped"); // flip both cards back
                            UpdateGameStatus(card.ID, "unflipped");
                            _flippedCard.IsMatched = false;
                            card.IsMatched = false;
                            _flippedCard = null; // reset flipped card
                        });
                    }
                }
            }
        }

        /// <summary>
        /// Updates the game status for a given card ID with a new status
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="newStatus"></param>
        private void UpdateGameStatus(int cardId, string status)
        {
            _gameStatus[cardId] = status;
        }

        /// <summary>
        /// Shuffling method which uses Random and LINQ's OrderBy method to shuffle the observable collection
        /// by ordering the current _cards by a randomly generated integer for each car then assigning
        /// the new collection to _cards
        /// first link takes straight to example found:
        /// https://www.tutorialsteacher.com/linq/linq-sorting-operators-orderby-orderbydescending#:~:text=var%20studentsInAscOrder%20%3D%20studentList.OrderBy(s%20%3D%3E%20s.StudentName)%3B
        /// https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.orderby?view=net-8.0
        /// </summary>
        public void Shuffle()
        {
            Random rng = new Random();
            _cards = new ObservableCollection<Card>(_cards.OrderBy(card => rng.Next()));
        }
    }
}
