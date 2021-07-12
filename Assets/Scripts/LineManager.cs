using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public const int DESTROYING_MS = 1000;
    public const double DESTROYING_MODIFIER = 2.0;
    public const int LINES_COUNT = 5;

    public const string DESTROYED_MARKER = "LineDestroyedMarker";
    public const string SELECTED_MARKER = "LineSelectedMarker";

    public GameObject[] lines;
    public int selectedLine = -1;
    public int destroyingLine = -1;

    public System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("LineManager created");
        lines = new GameObject[LINES_COUNT];
        for (int i = 0; i < LINES_COUNT; i++)
        {
            lines[i] = FindLineById(i);
            Debug.Log(lines[i]);
        }
    }

    int frame = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        frame += 1;
        if(frame == 60)
        {
            frame = 0;
            int identifier = random.Next(LINES_COUNT);

            if(destroyingLine != -1)
            {
                FindDestroyerMarker(destroyingLine).SetActive(false);
                destroyingLine = -1;
            }

            if(selectedLine != -1)
            {
                FindSelectedMarker(selectedLine).SetActive(false);
                destroyingLine = selectedLine;
                FindDestroyerMarker(destroyingLine).SetActive(true);
            }
            selectedLine = identifier;
            FindSelectedMarker(selectedLine).SetActive(true);
        }
    }

    GameObject FindSelectedMarker(int id)
    {
        string toFind = "Lines/Line" + (id + 1).ToString() + "/" + SELECTED_MARKER;
        return GameObject.Find(toFind);
    }
    GameObject FindDestroyerMarker(int id)
    {
        string toFind = "Lines/Line" + (id + 1).ToString() + "/" + DESTROYED_MARKER;
        return GameObject.Find(toFind);
    }
    GameObject FindLineById(int id) => GameObject.Find("Line" + (id + 1).ToString());
}
