using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryBox : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
        Destroy(other.gameObject);
        Debug.Log("An Object Enter");
   }
}
