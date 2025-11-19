using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Cards/CardsDeck")]
public class DeckSO : ScriptableObject
{
    [field: SerializeField]
    public CardDataSO[] Cards { get; private set; }

}
