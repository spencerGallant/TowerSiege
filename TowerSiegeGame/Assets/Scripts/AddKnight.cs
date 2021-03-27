using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddKnight : MonoBehaviour
{
   public GameObject knight;
   private Vector3 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
    }


    void Update()
    {

        if(Input.GetMouseButtonDown(0))//Checks to see if left mouse button was clicked.
     	{
          CreateKnight();
          
     	}
     	
    }

    void CreateKnight()
	{
	     GameObject k = Instantiate(knight);
	     mousePosition = Input.mousePosition;
         mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

         k.transform.position = new Vector3 (mousePosition.x, mousePosition.y, 0.0f);
         //k.transform.localScale = new Vector3(.1f, .1f, 1);
	}
}
