namespace Core 
{
    public class User
    {
        public string Name {get; private set;}
        public Wallet Wallet {get; private set;}
        public int Correct, Wrong;
        
        public User(string name, Wallet wallet)
        {
            Name = name;
            Wallet = wallet;
        }
        
        public bool LoseCondition()
        {
            return Wallet.Balance <= 0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}