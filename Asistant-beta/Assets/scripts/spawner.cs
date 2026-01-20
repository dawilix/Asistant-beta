using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float cd;
    [SerializeField] float r;
    float ti;
   
    void Start()
    {

        //InvokeRepeating("spa",0,cd);
        StartCoroutine(_test());

    }

    
    void Update()
    {
        //ti += Time.deltaTime;
        //if (ti > cd)
        //{
        //    ti = 0;
        //    spa();
        //}
    }
    void spa()
    {
        Instantiate (prefab , transform.position + new Vector3(Random.Range(-r , r), 0 , Random.Range(-r , r)), Quaternion.identity);
        
    }
    IEnumerator _test()
    {
        //yield return new WaitForSeconds(5);
        //yield return new WaitForSecondsRealtime(5);
        //yield return new WaitWhile(() => Input.GetKeyDown(KeyCode.Space));
        while (true)
        {
            yield return new WaitForSeconds(cd);
            spa();
        }
    }
}
