using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusInteract : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        GameObject.Destroy(this.gameObject);

        if (collider.tag == "Tank")
        {
            collider.SendMessage("GetBonus");
        }
    }
}
