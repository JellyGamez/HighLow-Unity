namespace Core 
{
    class Card
    {
        public int Number { get; private set; } = 0;
        public string Symbol {get; private set; } = "";

        public Card()
        {
            
        }

        public Card(int number)
        {
            Number = number;
        }

        public static bool operator < (Card left, Card right)
        {
            return left.Number < right.Number;
        }

        public static bool operator > (Card left, Card right)
        {
            return left.Number > right.Number;
        }

        public static bool operator == (Card left, Card right)
        {
            return left.Number == right.Number;
        }

        public static bool operator != (Card left, Card right)
        {
            return left.Number != right.Number;
        }

        public override bool Equals(object? o)
        {
            return true;
        }
        
        public override int GetHashCode()
        {
            return 0;
        }

        public override string ToString()
        {
            switch (Number)
            {
                case 1:
                    return "Ace";
                case 11:
                    return "Jack";
                case 12:
                    return "Queen";
                case 13:
                    return "King";
                default:
                    return Number.ToString();
            }
        }
    }
}