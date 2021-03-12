using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=OOkVADKo0IM
public class PieceSelector : MonoBehaviour
{
  TileSelector ts;

  // Start is called before the first frame update
  void Start()
  {
    ts = GameObject.FindObjectOfType<TileSelector>();
  }

  // Update is called once per frame
  void Update()
  {
    if (ts.selectedObject != null)
    {
      this.transform.position = ts.selectedObject.transform.position;

      if (Input.GetKey(KeyCode.W))
      {
        ts.selectedObject.transform.position += new Vector3(-1, 0, -1);
      }
      if (Input.GetKey(KeyCode.A))
      {
        ts.selectedObject.transform.position += new Vector3(1, 0, -1);
      }
      if (Input.GetKey(KeyCode.S))
      {
        ts.selectedObject.transform.position += new Vector3(1, 0, 1);
      }
      if (Input.GetKey(KeyCode.D))
      {
        ts.selectedObject.transform.position += new Vector3(-1, 0, 1);
      }

      if(Input.GetMouseButtonDown(1))
      {
        ts.selectedObject.SetActive(false);
      }
    }
    else
    {
    }
  }
}
