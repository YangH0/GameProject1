using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTrait : MonoBehaviour
{
    public float damage;
    public int debuffType;

    private void OnEnable()
    {
        StartCoroutine(SetFalse());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            Monster monster = other.GetComponent<Monster>();
            monster.GetDamage(damage, debuffType);
        }
    }

    IEnumerator SetFalse()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}