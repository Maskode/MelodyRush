using UnityEngine;
using System.Collections;

public class LvlManager : MonoBehaviour {

    public Sprite backgroundSky;
    public Sprite backgroundMidLayer;
    public Sprite backgroundFrontLayer;

    private Vector3 bgSize = new Vector3 (2.5f, 2.5f,1);
    private int backgroundsLenght = 3;
    private Camera cam;
    private GameObject[] backgroundMidLayerObjects;
    private GameObject[] backgroundFrontLayerObjects;
    private GameObject backgroundSkyObject;
    private Vector3 targetPosition;
    void Awake()
    {
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        cam = GameObject.Find("Camera").GetComponent<Camera>();
        backgroundMidLayerObjects = new GameObject[backgroundsLenght];
        backgroundFrontLayerObjects = new GameObject[backgroundsLenght];
        backgroundSkyObject = new GameObject("Sky");
        backgroundSkyObject.AddComponent<SpriteRenderer>();
        backgroundSkyObject.AddComponent<SkyBg>();
        backgroundSkyObject.transform.SetParent(cam.transform);
        backgroundSkyObject.transform.localPosition = new Vector3(0, 0, 10);
        for (int i =0;i<backgroundsLenght;i++)
        {
            backgroundMidLayerObjects[i] = new GameObject("BgMid"+i);
            backgroundMidLayerObjects[i].AddComponent<SpriteRenderer>();
            backgroundMidLayerObjects[i].AddComponent<MidBg>();
            backgroundMidLayerObjects[i].AddComponent<Rigidbody2D>();
            backgroundMidLayerObjects[i].AddComponent<ScrollBg>();
        }
        for (int i = 0; i < backgroundsLenght; i++)
        {
            backgroundFrontLayerObjects[i] = new GameObject("BgFront" + i);
            backgroundFrontLayerObjects[i].AddComponent<SpriteRenderer>();
            backgroundFrontLayerObjects[i].AddComponent<BoxCollider2D>();
            backgroundFrontLayerObjects[i].AddComponent<ScrollBg>();
            backgroundFrontLayerObjects[i].layer = 8;
        }
        #region SetPositions
        backgroundFrontLayerObjects[1].transform.position = targetPosition - (Vector3.up*-5);
        backgroundFrontLayerObjects[0].transform.position = new Vector3(backgroundFrontLayerObjects[1].transform.position.x -
                                                                      backgroundFrontLayerObjects[1].GetComponent<SpriteRenderer>().bounds.extents.x*2,
                                                                      backgroundFrontLayerObjects[1].transform.position.y,
                                                                      backgroundFrontLayerObjects[1].transform.position.z);
        backgroundFrontLayerObjects[2].transform.position = new Vector3(backgroundFrontLayerObjects[1].transform.position.x +
                                                                      backgroundFrontLayerObjects[1].GetComponent<SpriteRenderer>().bounds.extents.x * 2,
                                                                      backgroundFrontLayerObjects[1].transform.position.y,
                                                                      backgroundFrontLayerObjects[1].transform.position.z);

        backgroundMidLayerObjects[1].transform.position = backgroundFrontLayerObjects[1].transform.position;
        backgroundMidLayerObjects[0].transform.position = new Vector3(backgroundMidLayerObjects[1].transform.position.x -
                                                                      backgroundMidLayerObjects[1].GetComponent<SpriteRenderer>().bounds.extents.x * 2,
                                                                      backgroundMidLayerObjects[1].transform.position.y,
                                                                      backgroundMidLayerObjects[1].transform.position.z);
        backgroundMidLayerObjects[2].transform.position = new Vector3(backgroundMidLayerObjects[1].transform.position.x +
                                                                      backgroundMidLayerObjects[1].GetComponent<SpriteRenderer>().bounds.extents.x * 2,
                                                                      backgroundMidLayerObjects[1].transform.position.y,
                                                                      backgroundMidLayerObjects[1].transform.position.z);
        #endregion
    }
    void Start () {
        GameObject container = new GameObject("Backgrounds");
        for (int i =0;i<backgroundFrontLayerObjects.Length;i++)
        {
            backgroundFrontLayerObjects[i].transform.localScale = bgSize;
            backgroundFrontLayerObjects[i].GetComponent<BoxCollider2D>().size = new Vector2(10, 0.5f);
            backgroundFrontLayerObjects[i].GetComponent<BoxCollider2D>().offset = new Vector2(0, -2.6f);
            backgroundFrontLayerObjects[i].GetComponent<SpriteRenderer>().sortingLayerName = "background";
            backgroundFrontLayerObjects[i].GetComponent<SpriteRenderer>().sortingOrder = 1;
            backgroundFrontLayerObjects[i].GetComponent<SpriteRenderer>().sprite = backgroundFrontLayer;
            backgroundFrontLayerObjects[i].transform.SetParent(container.transform);
            #region switch
            switch (i)
            {
                case 0:
                    backgroundFrontLayerObjects[i].GetComponent<ScrollBg>().prevBackground = backgroundFrontLayerObjects[2].transform;
                    backgroundFrontLayerObjects[i].GetComponent<ScrollBg>().lastBackground = backgroundFrontLayerObjects[1].transform;
                    break;
                case 1:
                    backgroundFrontLayerObjects[i].GetComponent<ScrollBg>().prevBackground = backgroundFrontLayerObjects[0].transform;
                    backgroundFrontLayerObjects[i].GetComponent<ScrollBg>().lastBackground = backgroundFrontLayerObjects[2].transform;
                    break;
                case 2:
                    backgroundFrontLayerObjects[i].GetComponent<ScrollBg>().prevBackground = backgroundFrontLayerObjects[1].transform;
                    backgroundFrontLayerObjects[i].GetComponent<ScrollBg>().lastBackground = backgroundFrontLayerObjects[0].transform;
                    break;
            }
            #endregion
        }
        for (int i = 0; i < backgroundMidLayerObjects.Length; i++)
        {
            backgroundMidLayerObjects[i].transform.localScale = bgSize;
            backgroundMidLayerObjects[i].GetComponent<Rigidbody2D>().isKinematic = true;
            backgroundMidLayerObjects[i].GetComponent<SpriteRenderer>().sortingLayerName = "background";
            backgroundMidLayerObjects[i].GetComponent<SpriteRenderer>().sortingOrder = 0;
            backgroundMidLayerObjects[i].GetComponent<SpriteRenderer>().sprite = backgroundMidLayer;
            backgroundMidLayerObjects[i].transform.SetParent(container.transform);
            #region switch
            switch (i)
            {
                case 0:
                    backgroundMidLayerObjects[i].GetComponent<ScrollBg>().prevBackground = backgroundMidLayerObjects[2].transform;
                    backgroundMidLayerObjects[i].GetComponent<ScrollBg>().lastBackground = backgroundMidLayerObjects[1].transform;
                    break;
                case 1:
                    backgroundMidLayerObjects[i].GetComponent<ScrollBg>().prevBackground = backgroundMidLayerObjects[0].transform;
                    backgroundMidLayerObjects[i].GetComponent<ScrollBg>().lastBackground = backgroundMidLayerObjects[2].transform;
                    break;
                case 2:
                    backgroundMidLayerObjects[i].GetComponent<ScrollBg>().prevBackground = backgroundMidLayerObjects[1].transform;
                    backgroundMidLayerObjects[i].GetComponent<ScrollBg>().lastBackground = backgroundMidLayerObjects[0].transform;
                    break;
            }
            #endregion
        }
        backgroundSkyObject.GetComponent<SpriteRenderer>().sortingLayerName="background";
        backgroundSkyObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
        backgroundSkyObject.GetComponent<SpriteRenderer>().sprite = backgroundSky;

    }
}
