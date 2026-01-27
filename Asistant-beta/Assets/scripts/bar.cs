using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar : MonoBehaviour
{
    [SerializeField][Range(1f, 15f)] float radius = 10f;
    [SerializeField] float MaxDamage = 120f;
    [SerializeField] GameObject particle;
    
    public void babaxa()
    {
        //урон
        float dist = Vector3.Distance(transform.position, move.instance.transform.position);
        float K = 1 - (dist/radius);
        K = Mathf.Clamp(K, 0, 1);
        move.instance.ChangeHealth(-(int)(MaxDamage*K));
        //люти эфект спавн
        GameObject E = Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(E, 3f);
        //объект удались пожалуйста по братски а я тебе сотку
        Destroy(gameObject);
        
    }
}
