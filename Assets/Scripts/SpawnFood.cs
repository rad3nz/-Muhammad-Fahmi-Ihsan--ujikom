using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform player;
    public float moveSpeed = 5f;
    public KeyCode spawnKey = KeyCode.Mouse0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(spawnKey))
        {
            SpawnandThrowFood();
        }
    }

    private void SpawnandThrowFood()
    {
        GameObject spawnedFood = Instantiate(objectPrefab, player.position, Quaternion.identity);
        spawnedFood.AddComponent<MoveForward>().moveSpeed = moveSpeed;
    }
}

public class MoveForward : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
