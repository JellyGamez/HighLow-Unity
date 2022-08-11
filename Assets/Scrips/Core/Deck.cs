using System;
namespace Core 
{
    public class Deck
    {
        public Card CurrentCard {get; private set;}
        public Card NextCard {get; private set;}
            
        public Deck() 
        {
            CurrentCard = GenerateNewCard();
            NextCard = new Card();
        }

        public bool CheckGuess(string guess)
        {
            // -1 = lower, 0 = equal, 1 = greater;
            switch (guess)
            {
                case "l":
                    return NextCard < CurrentCard;
                case "e":
                    return NextCard == CurrentCard;
                case "h":
                    return NextCard > CurrentCard;
                default:
                    throw new Exception("Invalid guess");
            }
        }

        public Card GenerateNewCard()
        {
            Random random = new Random();
            return new Card(random.Next(1, 14));
        }

        public void GenerateNextCard()
        {
            NextCard = GenerateNewCard();
        }
        
        public void NextRound()
        {
            CurrentCard = NextCard;
        }
    }
}