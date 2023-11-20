using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotAnimation : MonoBehaviour
{
    private float RotationSpeed = 60.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
