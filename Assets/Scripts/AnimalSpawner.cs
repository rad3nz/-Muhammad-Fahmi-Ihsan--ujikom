using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{

    public GameObject objectPrefab;
    public GameObject spawnArea;
    public float spawnInterval = 2f;
    public float moveSpeed = 5f;
    private BoxCollider SpawnAreaCollider;
    // Start is called before the first frame update
    void Start()
    {
        SpawnAreaCollider = spawnArea.GetComponent<BoxCollider>();

        StartCoroutine(SpawnObjectsAtInterval());
    }

    // Update is called once per frame
    private IEnumerator SpawnObjectsAtInterval()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnObject()
    {
        Vector3 spawnPosition = GetRandomPosition();
        GameObject spawnedAnimal = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

        moveDown moveDown = spawnedAnimal.AddComponent<moveDown>();
        moveDown.Initialize(moveSpeed);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 center = SpawnAreaCollider.bounds.center;
        Vector3 size = SpawnAreaCollider.bounds.size;

        float randomX = Random.Range((center.x - size.x) / 2, (center.x + size.x) / 2);
        float randomZ = Random.Range((center.z - size.z) / 2, (center.z + size.z) / 2);
        return new Vector3(randomX, 10f, randomZ);
    }
}

public class moveDown : MonoBehaviour
{
    private float speed = 5f;

    public void Initialize(float moveSpeed)
    {
        speed = moveSpeed;
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
