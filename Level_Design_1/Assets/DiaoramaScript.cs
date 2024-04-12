using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaoramaScript : MonoBehaviour
{
    public GameObject originalPosition;
    public GameObject target;
    public Vector3 position;
    public GameObject Object;
    private float movementSpeed = 0.05f;
    private float movementTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Object.transform.position = Vector3.MoveTowards(target.transform.position, position, movementSpeed * movementTime);
    }
}


