using UnityEngine;

public class MouseGridSelector : MonoBehaviour
{
    #region Fields
    [SerializeField] 
    private GridManager gridManager;
    [SerializeField] 
    private Camera mainCamera;

    private Cell lastHoveredCell;
    #endregion

    #region LifeCycle
    private void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        if (gridManager == null)
            gridManager = FindFirstObjectByType<GridManager>(); 
    }

    private void Update()
    {
        HandleMouseHover();
    }
    #endregion

    #region PrivateMethods
    private void HandleMouseHover()
    {
        if (gridManager == null || mainCamera == null)
            return;
                
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 worldPosition = ray.GetPoint(distance);

            if (lastHoveredCell != null)
            {
                lastHoveredCell.IsSelected = false;
            }

            if (gridManager.TryGetCellByWorldPostition(worldPosition, out Cell cell))
            {
                cell.IsSelected = true;
                lastHoveredCell = cell;
            }
            else
            {
                lastHoveredCell = null;
            }
        }
    }
    #endregion
}