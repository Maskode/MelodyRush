using UnityEngine;
using System.Collections;

public class LvlManager : MonoBehaviour {

    public Sprite backgroundSky;
    public Sprite backgroundMidLayer;
    public Sprite backgroundFrontLayer;

    private GameObject[] backgroundMidLayerObjects;
    private GameObject[] backgroundFrontLayerObjects;
    private GameObject backgroundSkyObject;
    void Awake()
    {
        backgroundFrontLayerObjects = GameObject.FindGameObjectsWithTag("BgFrontLayer");
        backgroundMidLayerObjects = GameObject.FindGameObjectsWithTag("BgMidLayer");
        backgroundSkyObject = GameObject.FindGameObjectWithTag("BgSky");
    }
    void Start () {
        for(int i =0;i<backgroundFrontLayerObjects.Length;i++)
        {
            backgroundFrontLayerObjects[i].GetComponent<SpriteRenderer>().sprite = backgroundFrontLayer;
        }
        for(int i = 0; i < backgroundMidLayerObjects.Length; i++)
        {
            backgroundMidLayerObjects[i].GetComponent<SpriteRenderer>().sprite = backgroundMidLayer;
        }
        backgroundSkyObject.GetComponent<SpriteRenderer>().sprite = backgroundSky;
    }
}
