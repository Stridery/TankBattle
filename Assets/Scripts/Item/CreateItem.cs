using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class CreateItem : MonoBehaviour
{
    public float timer;
    public int pos = 0;
    public int startTime;
    public int tempTime = 0;
    public int endTime;
    public int type = 0;
    public int delay = 5;
    private Transform DropPoint;
    public GameObject bonusPrefab;
    public GameObject speedPrefab;
    public GameObject shieldPrefab;
    public GameObject healthPrefab;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        startTime = (int)System.Math.Abs(timer);
        if(startTime == delay + tempTime)
        {
            tempTime = startTime;
            pos = Random.Range(1, 9);
            DropPoint = transform.Find("DropPoint").Find("DropPoint" + pos);
            type = (++type) % 4;
            switch (type) {
                case 0:
                    GameObject.Instantiate(bonusPrefab, DropPoint.position, DropPoint.rotation);
                    break;
                case 1:
                    GameObject.Instantiate(shieldPrefab, DropPoint.position, DropPoint.rotation);
                    break;
                case 2:
                    GameObject.Instantiate(speedPrefab, DropPoint.position, DropPoint.rotation);
                    break;
                case 3:
                    GameObject.Instantiate(healthPrefab, DropPoint.position, DropPoint.rotation);
                    break;
            }
            delay += 5;
        }
    }
}
