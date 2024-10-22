using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : MonoBehaviour
{
    float distance = 5;
    private Transform pos;
    private Rigidbody rb;
    private FPC_Param fpc_;
    private void Start()
    {
        rb =  GetComponent<Rigidbody>();
        fpc_ =  GameObject.Find("Player").GetComponent<FPC_Param>();
        pos = GameObject.FindGameObjectWithTag("Pos").transform;
    }
    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, distance) && fpc_.Take==false)
        {
            rb.isKinematic = true;
            fpc_.Take = true;
            rb.MovePosition(pos.position);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (rb.isKinematic == true)
        {
            this.gameObject.transform.position = pos.position;
            if (Input.GetKey(KeyCode.Q))
            {
                fpc_.Take = false;
                rb.useGravity = true;
                rb.isKinematic = false;
                rb.AddForce(Camera.main.transform.forward * 500);
            }
        }
    }
}
