using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
  public GameObject tileHighlightPrefab;
  private GameObject tileHighlight;
  public GameObject selectedObject = null;

  // Start is called before the first frame update
  void Start()
  {
    Vector2Int gridPoint = Geometry.GridPoint(0, 0);
    Vector3 point = Geometry.PointFromGrid(gridPoint);
    tileHighlight = Instantiate(tileHighlightPrefab, point, Quaternion.identity);
    tileHighlight.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    RaycastHit hit;
    if (Physics.Raycast(ray, out hit))
    {
      Vector3 point = hit.point;
      Vector2Int gridPoint = Geometry.GridFromPoint(point);

      tileHighlight.SetActive(true);
      tileHighlight.transform.position =
          Geometry.PointFromGrid(gridPoint);

      GameObject hitObject = hit.transform.root.gameObject;

      SelectObject(hitObject);
    }
    else
    {
      tileHighlight.SetActive(false);
    }
  }

  void SelectObject(GameObject hitObj)
  {
    if(selectedObject != null)
    {
      if(hitObj == selectedObject)
      {
        return;
      }

      ClearSelection();
    }

    selectedObject = hitObj;

    Renderer[] pieces = selectedObject.GetComponentsInChildren<Renderer>();

    foreach(Renderer r in pieces)
    {
      Material m = r.material;
      m.color = Color.yellow;
    }
  }

  void ClearSelection()
  {
    selectedObject = null;
  }

  public void EnterState()
  {
    enabled = true;
  }
}

public class Geometry
{
  public static Vector2Int GridPoint(int col, int row)
  {
    Vector2Int newGridPoint = new Vector2Int();
    newGridPoint.x = row;
    newGridPoint.y = col;

    return newGridPoint;
  }

  public static Vector3 PointFromGrid(Vector2Int gridPoint)
  {
    Vector3 threeDimensional = new Vector3();
    threeDimensional.x = gridPoint.x;
    threeDimensional.y = 0;
    threeDimensional.z = gridPoint.y;

    return threeDimensional;
  }

  public static Vector2Int GridFromPoint(Vector3 point)
  {
    Vector2Int newGridPoint = new Vector2Int();
    newGridPoint.x = (int)point.x;
    newGridPoint.y = (int)point.z;

    return newGridPoint;
  }
}