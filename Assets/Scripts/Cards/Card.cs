using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] GameObject cardGraphics;

    [SerializeField] TMP_Text cardName;
    [SerializeField] TMP_Text cardLevel;
    [SerializeField] TMP_Text cardDescription;
    [SerializeField] Image cardArt;
    [SerializeField] Image cardBackground;

    [SerializeField] private CardData currentCardData;

    public void SetCard(CardData card)
    {
        currentCardData = card;
    }

    public void RenderCard()
    {
        if(currentCardData == null)
        {
            Debug.LogWarning("Card data not set!");
            return;
        }

        cardGraphics.SetActive(true);

        cardName.text = currentCardData.cardName;
        cardLevel.text = currentCardData.rollRating.ToString();
        cardArt.sprite = currentCardData.cardArt;
        cardDescription.text = currentCardData.cardDescription;
    }

    public void DisableCard()
    {
        cardGraphics.SetActive(false);
    }
}
