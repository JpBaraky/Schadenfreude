using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTomatos : MonoBehaviour
{
    public GameObject objectPrefab;
    public BoxCollider boxCollider;
    public int maxNumberObjects = 4;
    private int numberOfObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTomato(){
          numberOfObjects = Random.Range(2, maxNumberObjects);
        if (boxCollider != null && objectPrefab != null)
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                yield return new WaitForSecondsRealtime(0.1f);
                // Randomly generate a point within the box collider
                Vector3 randomPoint = new Vector3(
                    Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x),
                    Random.Range(boxCollider.bounds.min.y, boxCollider.bounds.max.y),
                    Random.Range(boxCollider.bounds.min.z, boxCollider.bounds.max.z)
                );

                // Instantiate the object at the random point
                Instantiate(objectPrefab, randomPoint, Quaternion.identity);
            }
        }
        else
        {
            Debug.LogWarning("Box Collider or Object Prefab not assigned!");
        }
        
    }
    public void StartSpawnTomato(){
        StartCoroutine(SpawnTomato());
    }
 
}

