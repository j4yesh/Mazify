using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSrc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector3.forward);
            if (hit.collider != null)
            {
                GameObject hitObject = hit.collider.gameObject;
                hitObject.GetComponent<SpriteRenderer>().color=MET.zero;
            }
    }
}
