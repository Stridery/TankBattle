using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trans : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Trans1")
        {
            this.gameObject.transform.position = new Vector3(250,195,800);
        }
        if (collider.tag == "Trans2")
        {
            this.gameObject.transform.position = new Vector3(20, 1.5f, 5);
        }
        if (collider.tag == "Trans3")
        {
            this.gameObject.transform.position = new Vector3(20, 0f, -30);
        }

    }
}
