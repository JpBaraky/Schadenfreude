using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectsOnStageCount : MonoBehaviour
{
    public string objectTag = "PickUpObjects";
    public Collider boxCollider;
    public int objectCount;
    public TextMeshProUGUI numberText;
    // Start is called before the first frame update
      private void Start()
    {
        CountObjectsInsideCollider();
    }

    private void Update()
    {
        // Update the count continuously
        CountObjectsInsideCollider();
        numberText.text = objectCount.ToString();
    }

    private void CountObjectsInsideCollider()
    {
        Collider[] colliders = Physics.OverlapBox(boxCollider.bounds.center, boxCollider.bounds.extents, Quaternion.identity);

        objectCount = 0;

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(objectTag))
            {
                objectCount++;
            }
        }

    }
}