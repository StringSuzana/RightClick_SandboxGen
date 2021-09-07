using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This automatically puts BoxCollider2D on object that has this script!!
//[RequireComponent(typeof(BoxCollider2D))]
public class Collidable : MonoBehaviour
{

    public ContactFilter2D filter;
    private BoxCollider2D boxCollider2D;
    private Collider2D[] hits = new Collider2D[10];
    protected virtual void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        boxCollider2D.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }
            Debug.Log(hits[i].name);

            hits[i] = null;
        }
    }
}
