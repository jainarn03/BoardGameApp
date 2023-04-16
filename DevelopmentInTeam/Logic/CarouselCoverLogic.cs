using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentInTeam.Logic
{
    /// <summary>
    /// contents of the carousel view
    /// </summary>
    public class CarouselCover
    {
        /// <summary>
        /// read-only property returns a collection of image URLs  
        /// </summary>
        public IEnumerable<string> ImageURLs { get; } = new List<string>
        {
        "checkers_art.png",
        "connectfour_art.png",
        "tictactoe_art.png",
        "memory_art.png",
        //"wordle_art.png",  omitted per michael's request, as the game was unfinished
        "hangman_art.png"
        };
    }
}
