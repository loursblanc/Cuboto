using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTranslate : MonoBehaviour
{
    public float speed = 5f;   
    void Awake() {
               
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime  * speed);
        //Debug.Log(this.transform.position.x);
        if (this.transform.position.x < -19)
        {            
            BackgroundsManager.Instance.createBackgroud();
            BackgroundsManager.Instance.DestroyBackground(this.gameObject);
        }


    }
}
