using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.UI;


public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    public Text CardText;
    public Button GenerateButton;
    private Deck deck;
    public int tries = 3;
    void Start()
    {
        deck = new Deck();
        GenerateCard();
    }

    public void GenerateCard()
    {
        deck.GenerateNextCard();
        CardText.text = deck.CurrentCard.ToString();
    }

    public void PickCard(string option)
    {
        Debug.Log(deck.NextCard);
        if (!deck.CheckGuess(option))
            tries--;
        if (tries <= 0)
        {
            Debug.Log("You lost");
            return;
        }
        deck.NextRound();
        GenerateCard();
    }
}
