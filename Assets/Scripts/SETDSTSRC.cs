using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SETDSTSRC : MonoBehaviour
{
    private GameObject prevSRC;
    private GameObject prevDST;
    private bool srcass=false;
    private bool dstass=false;
    [SerializeField]
    private Color cc = Color.white;
    [SerializeField]
    private Color rr = Color.white;


    private void Start()
    {
        // Assign initial values to prevSRC and prevDST
        // prevSRC = GameObject.FindWithTag("Player");
        // prevDST = GameObject.FindWithTag("Enemy");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector3.forward);
            if (hit.collider != null)
            {
                GameObject hitObject = hit.collider.gameObject;
                hitObject.GetComponent<SpriteRenderer>().color = cc;
                if (prevSRC)
                {
                    prevSRC.GetComponent<SpriteRenderer>().color = MET.zero;
                }
                prevSRC = hitObject;
                srcass=true;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector3.forward);
            if (hit.collider != null)
            {
                GameObject hitObject = hit.collider.gameObject;
                hitObject.GetComponent<SpriteRenderer>().color = rr;
                if (prevDST)
                {
                    prevDST.GetComponent<SpriteRenderer>().color = MET.zero;
                }
                prevDST = hitObject;
                dstass=true;
            }
        }
    }
}
