using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update

    public Text CardText;
    public Text TriesText;
    public Button GenerateButton;
    public GameSetttings Settings;
    public TMP_Text FeedbackText, NameText, BalanceText, CurrentBetText;
    public TMP_InputField RaiseInput;
    private User User; 
    private Deck deck;
    private Betting betting;
    private int tries = 3;
    private List<User> players = new List<User>();
    void Awake()
    {
        if (!Settings)
            Settings = GetComponent<GameSetttings>();
    }
    void Start()
    {
        betting = new Betting(Settings.DefaultBet);
        tries = Settings.Tries;
        User = new User(Settings.PlayerName, new Wallet(Settings.Balance));
        players.Add(User);
        deck = new Deck();
        GenerateCard();
    }

    public void GenerateCard()
    {        
        betting.ResetBet();
        deck.GenerateNextCard();
        betting.Bet(players, 20);  
        
        CardText.text = deck.CurrentCard.ToString();
        NameText.text = User.ToString();
        BalanceText.text = "Balance: " + User.Wallet;
        TriesText.text = tries.ToString() + " tries";
        CurrentBetText.text = "Current bet: $" + betting.CurrentBet.ToString();
    }

    public void PickCard(string option)
    {
        if (tries <= 0)
        {
            FeedbackText.text = "You lost!";
            return;
        }
        if (!deck.CheckGuess(option))
        {
            betting.Lost(User);
            tries--;        
            TriesText.text = tries.ToString() + " tries";
            FeedbackText.text = "Wrong";
        }
        else
        {
            betting.Won(User);
            FeedbackText.text = "Correct";
        } 
        deck.NextRound();
        GenerateCard();
    }

    public void Raise()
    {
        betting.Raise(User, Int32.Parse(RaiseInput.text));
        RaiseInput.text = String.Empty;
        CurrentBetText.text = "Current bet: $" + betting.CurrentBet.ToString();
        BalanceText.text = "Balance: " + User.Wallet;
    }
}
