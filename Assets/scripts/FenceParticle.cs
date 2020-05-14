using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine("DieSoon");
       
        
    }

    IEnumerator DieSoon(){
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
