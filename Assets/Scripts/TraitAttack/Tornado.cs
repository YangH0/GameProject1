using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    public float speed;
    public float damage;
    public int debuffType;
    public float range;
    private Vector3 defaultRange;

    private void Awake()
    {
        defaultRange = transform.localScale;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed);
    }

    public void UpdateScale()
    {
        gameObject.transform.localScale = (defaultRange * (range * 0.01f + 1));

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            Monster monster = other.GetComponent<Monster>();
            monster.GetDamage(damage, debuffType);

        }
    }
}