using System.Collections.Generic;
namespace Core
{
    public class Betting
    {
        public int CurrentBet {get; private set;} = 0;
        public int DefaultBet {get; private set;}

        public Betting()
        {

        }

        public Betting(int defaultbet)
        {
            DefaultBet = defaultbet;
        }

        public void ResetBet()
        {
            CurrentBet = 0;
        }

        public void Bet(List<User> users, int modifier = 0)
        {
            CurrentBet += users.Count * DefaultBet + modifier;
            foreach (User user in users)
                user.Wallet.subtract(DefaultBet);
        }

        public void Split(List<User> users)
        {
            foreach (User user in users)
            {
                user.Wallet.add(CurrentBet / users.Count);
                user.Correct++;
            }
        }

        public void Won(User user)
        {
            user.Correct++;
            user.Wallet.add(CurrentBet);
        }

        public void Lost(User user)
        {
            user.Wrong++;
        }

        public void Raise(User user, int raise)
        {
            user.Wallet.subtract(raise);
            CurrentBet += raise;
        }
    }
}