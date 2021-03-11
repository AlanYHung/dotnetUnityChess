using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMove : MonoBehaviour
{
  [SerializeField] Rigidbody rigidBody;
  [SerializeField] private float moveSpeed;

  // Start is called before the first frame update
  void Start()
  {
    rigidBody = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update()
  {
    var forward = transform.forward;
    rigidBody.AddForce(forward * moveSpeed);
  }
}
