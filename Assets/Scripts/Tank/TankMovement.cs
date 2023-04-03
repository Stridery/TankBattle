using UnityEngine;
using System.Collections;
using UnityEditor;

public class TankMovement : MonoBehaviour {

    public float speed;
    public float angularSpeed;
    public AudioClip idleAudio;
    public AudioClip drivingAudio;
    private AudioSource audio;
    private Rigidbody rigidbody;
    public float timer = 0;
    public int tempTime;
    public int speedDelay = 10;
    public int number;
    public bool speedFlag = false;
    public bool notUp = false;
    public int startTime = int.MinValue;

    void SpeedUp()
    {
        speedFlag = true;
    }


    // Use this for initialization
    void Start () {
	    rigidbody = this.GetComponent<Rigidbody>();
	    audio = this.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        tempTime = (int)System.Math.Abs(timer);
        float v = Input.GetAxis("Vertical" + number);
        rigidbody.velocity = transform.right * (-v) * speed;

        float h = Input.GetAxis("Horizontal" + number);
        rigidbody.angularVelocity = transform.up * h * angularSpeed;

        if (Mathf.Abs(h) > 0.1 || Mathf.Abs(v) > 0.1)
        {
            audio.clip = drivingAudio;
            if (audio.isPlaying == false)
                audio.Play();
        }
        else
        {
            audio.clip = idleAudio;
            if (audio.isPlaying == false)
                audio.Play();
        }

        if (speedFlag)
        {
            speed += 5;
            startTime = tempTime;
            speedFlag = false;
            notUp = true;
        }
        if (tempTime == startTime + speedDelay && notUp)
        {
            speed -= 5;
            notUp = false;
        }
    }

    public void SetNumber1()
    {
        number = 1 ;
    }
        public void SetNumber2()
    {
        number = 2 ;
    }

}
