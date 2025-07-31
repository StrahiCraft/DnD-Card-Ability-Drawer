using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
public class CardData : ScriptableObject
{
    public int rollRating;
    public string cardName;
    public Sprite cardArt;
    public string cardDescription;
}
