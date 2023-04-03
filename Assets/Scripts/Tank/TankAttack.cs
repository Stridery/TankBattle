using UnityEngine;
using System.Collections;

public class TankAttack : MonoBehaviour {

    public GameObject shellPrefab;
	public static float timer = 0;
	public int tempTime;
	public int startTime;
	public int bonusDelay = 10;
	public KeyCode fireKey;
    public float shellSpeed;
    public AudioClip shotAudio;
	public bool bonusFlag = false;
	public bool notUp = false;
	private Transform firePosition;

    void GetBonus ()
    {
		bonusFlag = true;
    }

	// Use this for initialization
	void Start () {
	    firePosition = transform.Find("FirePosition");
	}


	void SetFireKey1()
    {
		fireKey = KeyCode.Space;
    }

	void SetFireKey2()
	{
		fireKey = KeyCode.KeypadEnter;
	}

	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		tempTime = (int)System.Math.Abs(timer);
		if (Input.GetKeyDown(fireKey)) {
            AudioSource.PlayClipAtPoint(shotAudio,transform.position);
	        GameObject go = GameObject.Instantiate(shellPrefab, firePosition.position, firePosition.rotation) as GameObject;
	        go.GetComponent<Rigidbody>().velocity = go.transform.forward*shellSpeed;
	    }
        if (bonusFlag)
		{
			shellSpeed *= 2;
			startTime = tempTime;
			bonusFlag = false;
			notUp = true;
		}
		if (tempTime == startTime + bonusDelay && notUp)
		{
			shellSpeed /= 2;
			notUp = false;
		}
	}
}
