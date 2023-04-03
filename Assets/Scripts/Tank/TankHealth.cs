using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TankHealth : MonoBehaviour {

    public int hpTotal;
    public int damage;
    public float timer = 0;
    public int healthDelay = 10;
    public int shieldDelay = 10;
    private int tempTime;
    private int shieldStartTime;
    public GameObject tankExplosion;
    public AudioClip tankExplosionAudio;
    private bool shieldFlag = false;
    private bool shieldEquiped = false;
    private bool notUp = false;
    public Slider hpSlider;
    private int hp;
    public bool elseLive = true;
    public int deadTime = int.MinValue;
    private int duration = 3;
    private GameObject obj;
    void HealthCare()
    {
        if (hp + 30 > hpTotal)
        {
            hp = hpTotal;
        }
        else
        {
            hp += 30;
        }
        hpSlider.value = (float)hp / hpTotal;
    }

    void ShieldUp()
    {
        shieldFlag = true;
    }

    // Use this for initialization
    void Start () {
	    hp = hpTotal;
        obj = this.gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        tempTime = (int)System.Math.Abs(timer);
        if (shieldFlag)
        {
            shieldEquiped = true;
            shieldStartTime = tempTime;
            shieldFlag = false;
            notUp = true;
        }
        if (tempTime == shieldStartTime + shieldDelay && notUp)
        {
            shieldEquiped = false;
            notUp = false;
        }
        if (!elseLive)
        {
            for (int i = 0; i < obj.transform.childCount; i++)
            {
                Destroy(obj.transform.GetChild(i).gameObject);
            }
            deadTime = tempTime;
            elseLive = true;
        }
        if (tempTime == deadTime + duration)
        {
            SceneManager.LoadScene("End");
        }
    }



    void TakeDamage() {
        if (!shieldEquiped)
        {
            hp -= damage;
        }
        hpSlider.value = (float)hp / hpTotal;
        if (hp <= 0)
        {//收到伤害之后 血量为0 控制死亡效果
            elseLive = false;
            AudioSource.PlayClipAtPoint(tankExplosionAudio,transform.position);
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);
        }
    }
}
