using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform limiteI;
    public Transform limiteD;
    public Transform positionGorro;
    public GameObject prefabGorro;
    void Start()
    {
        lanzaGorro();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void lanzaGorro()
    {
        Vector3 newPos = Vector3.Lerp(limiteI.position,limiteD.position,Random.Range(0f,1f));
        positionGorro.position = newPos;
        Instantiate(prefabGorro, positionGorro.position, positionGorro.rotation);
        Invoke(nameof(lanzaGorro),1f);
    }
}
