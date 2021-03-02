using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<GameObject> Managers;
    public List<GameObject> Terrain;
    public List<GameObject> Player;
    public List<GameObject> Other;


    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject gameObject in Managers) { gameObject.SetActive(true); }
        foreach(GameObject gameObject in Terrain) { gameObject.SetActive(true); }
        foreach(GameObject gameObject in Player) { gameObject.SetActive(true); }
        foreach(GameObject gameObject in Other) { gameObject.SetActive(true); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
