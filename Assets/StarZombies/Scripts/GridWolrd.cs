using UnityEngine;

public class GridWolrd : MonoBehaviour
{
    // Сделать вместо этого Сервис Локатор
    #region Fields
    [SerializeField]
    private GameObject cubePrefab;
    #endregion

    #region Properties
    [field: SerializeField]
    public GridManager gridManager { get; private set; }
    [field:SerializeField]
    public PlaceableSystem PlaceableSystem { get; private set; }
    public FactoryBuildings FactoryBuildings { get; private set; }

    #endregion

    #region LifeCycle

    private void Awake()
    {
        FactoryBuildings = new(cubePrefab);
        PlaceableSystem.Initialize(FactoryBuildings, gridManager);

    }

    #endregion
}
