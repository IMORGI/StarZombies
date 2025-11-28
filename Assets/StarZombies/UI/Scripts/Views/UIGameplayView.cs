using UnityEngine;

public class UIGameplayView : UIView
{
    #region Fields

    [SerializeField]
    private UICardPanel uICardPanel;


    #endregion

    #region Properties
    #endregion

    #region PublicMethods
    public CardDataSO GetSelectedCard()
    {
        if(uICardPanel._currentSelect != null)
        {
            return uICardPanel._currentSelect.Card;
        }
        return null;
    }
    #endregion
}
