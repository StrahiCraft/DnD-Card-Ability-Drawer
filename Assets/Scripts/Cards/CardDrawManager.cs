using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using System.Collections.Generic;
using TMPro;

public class CardDrawManager : MonoBehaviour
{
    [SerializeField] Card card;
    [SerializeField] List<CardData> cardsInDeck;

    [SerializeField] GameObject rollObject;
    [SerializeField] TMP_InputField rollInput;

    private State currentState = State.DRAW;
    int rolledNumber = 0;

    private void Start()
    {
        if(cardsInDeck == null)
        {
            Debug.LogWarning("Deck is empty!");
            return;
        }
    }

    public void HandleDoubleClick(CallbackContext context)
    {
        if(context.phase != InputActionPhase.Performed)
        {
            return;
        }

        switch (currentState)
        {
            case State.DRAW:
                rollObject.SetActive(true);
                currentState = State.ROLLING;
                break;
            case State.ROLLING:
                break;
            case State.CARD:
                card.DisableCard();
                currentState = State.DRAW;
                break;
        }
    }

    public void OnRollSubmited()
    {
        rollObject.SetActive(false);

        Debug.Log(rollInput.text.Trim());
        rolledNumber = int.Parse(rollInput.text.Trim());
        rollInput.text = "";

        currentState = State.CARD;
        card.SetCard(PickCardFromDeck());
        card.RenderCard();
    }

    private CardData PickCardFromDeck()
    {
        List<CardData> possibleCards = new List<CardData>();

        foreach(CardData card in cardsInDeck)
        {
            if(card.rollRating <= rolledNumber)
            {
                possibleCards.Add(card);
            }
        }

        return possibleCards[Random.Range(0, possibleCards.Count)];
    }
}

public enum State
{
    DRAW,
    ROLLING,
    CARD
}
