using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

    public GameObject target1;
    public GameObject target2;

    private Vector3 offset;
    private Camera camera;
	float hightArgument;
	public float minSize;

	public GameObject setting;

	// Use this for initialization
	void Start () {
		offset = transform.position - (target1.transform.position + target2.transform.position) /2;
	    camera = this.GetComponent<Camera>();
		hightArgument = camera.fieldOfView / Vector3.Distance(target1.transform.position, target2.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	    if (target1 == null || target2 == null) return;
	    transform.position = (target1.transform.position + target2.transform.position) /2 + offset;
	    float distance = Vector3.Distance(target1.transform.position, target2.transform.position);
	    float size = distance*hightArgument > minSize ? distance* hightArgument : minSize ;
	    camera.fieldOfView = size;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
			setting.SetActive(true);
        }
	}
}
