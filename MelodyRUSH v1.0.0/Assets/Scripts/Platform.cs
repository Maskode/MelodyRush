using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

    public string label = "nada";
    public int index = 0;
    Pj personaje;
    bool visible = false;

    void Awake()
    {
        personaje = GameObject.FindGameObjectWithTag("Player").GetComponent<Pj>();
    }
    void Start()
    { 
        foreach (Transform t in this.transform)
        {
            t.gameObject.SetActive(false);
        }
    }
    void OnBecameVisible()
    {
        visible = true;
    }
	// Update is called once per frame
	public void Compare (string _label)
    {
        if (visible)
        {
            if (label == _label)
            {
                foreach (Transform t in this.transform)
                {
                    t.gameObject.SetActive(true);
                    if (t.name == "Trigger")
                        t.GetComponent<SpriteRenderer>().enabled = false;
                }
                personaje.addCounter();
            }
        }
	}
}
