using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitField : MonoBehaviour
{
    public float damage;
    public int debuffType;
    public Collider col;
    public float range;
    private Vector3 defaultRange;

    private void Awake()
    {
        defaultRange = transform.localScale;
    }

    private void OnEnable()
    {
        StartCoroutine(Damage());
    }

    public void UpdateScale()
    {
        gameObject.transform.localScale = (defaultRange * (range * 0.01f + 1));

    }

    private IEnumerator Damage()
    {
        col.enabled = true;
        yield return new WaitForSeconds(0.1f);
        col.enabled = false;
        yield return new WaitForSeconds(1f);
        StartCoroutine(Damage());

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
