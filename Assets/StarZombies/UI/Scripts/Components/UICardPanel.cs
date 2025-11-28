using UnityEngine;

public class UICardPanel : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private UICard cardPrefab;

    [SerializeField]
    private Transform content;
    #region Properties
    [field: SerializeField]
    public UICard _currentSelect { get; private set; }
    #endregion

    #endregion

    #region LifeCycle

    private void Start()
    {
        Clear();
        FillPanel();
    }

    #endregion

    #region PublicMethods
    public void FillPanel()
    {
        for (int i = 0; i < GridWolrd.Instance.Deck.Cards.Length; i++)
        {
            var card = Instantiate(cardPrefab, content);
            card.Initialize(GridWolrd.Instance.Deck.Cards[i]);
            card.OnClick += Card_OnClick;
        }  
    }
    #endregion
    #region PrivateMethods

    private void Clear()
     {
         for (int i = 0; i < content.childCount; i++)
         {
             Destroy(content.GetChild(i).gameObject);
         }
     }

    private void Card_OnClick(UICard card)
    {
        if (_currentSelect == card)
        {
            return;
        }
        if (_currentSelect != null) 
        {
            _currentSelect.UnSelect();
        }
        _currentSelect = card;
        _currentSelect.Select();
    }

    #endregion
}
