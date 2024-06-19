using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollision : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        ContactPoint contact = other.contacts[0];
        if (other.gameObject.CompareTag("Animal"))
        {
            Destroy(other.gameObject);
        }
    }
}
