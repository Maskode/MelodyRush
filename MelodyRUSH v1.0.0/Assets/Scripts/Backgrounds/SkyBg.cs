using UnityEngine;
using System.Collections;

public class SkyBg : MonoBehaviour {


    Camera cam;
	// Use this for initialization
    void Awake()
    {
        cam = GameObject.Find("Camera").GetComponent<Camera>();
    }
	void Start () {
        if (GetComponent<SpriteRenderer>() != null)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr == null) return;

            transform.localScale = new Vector3(1, 1, 1);

            float width = sr.sprite.bounds.size.x;
            float height = sr.sprite.bounds.size.y;

            float worldScreenHeight = cam.orthographicSize * 2.0f;
            float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

            transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height);
        }
    }
}
