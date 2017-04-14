using UnityEngine;
using System.Collections;

public class ScrollBg : MonoBehaviour {

    SpriteRenderer sr;
    Transform playerReference;
    public Transform prevBackground;
    public Transform lastBackground;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        playerReference = GameObject.FindGameObjectWithTag("Player").transform;
    }

	void Start () {
	
	}
	
	void Update () {
	    if (playerReference.position.x>=transform.position.x)
        {
            prevBackground.position = new Vector3(lastBackground.position.x + sr.bounds.extents.x * 2, prevBackground.position.y, prevBackground.position.z);
        }
	}
}
