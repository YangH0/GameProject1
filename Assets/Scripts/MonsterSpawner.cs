using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] GameObject rabbit;
    [SerializeField] GameObject llama;
    [SerializeField] GameObject boar;
    [SerializeField] GameObject lion;
    [SerializeField] GameObject elephant;
    [SerializeField] GameObject Unicorn;

    private List<GameObject> rabbitPool = new List<GameObject>();
    public List<GameObject> llamaPool = new List<GameObject>();
    private List<GameObject> boarPool = new List<GameObject>();
    private List<GameObject> lionPool = new List<GameObject>();
    private List<GameObject> elephantPool = new List<GameObject>();

    private int monsterNum = 0;


    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(StartSpawn());
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject newObj = Instantiate(Unicorn);
            newObj.transform.position = new Vector3(0, 5, 0);
        }
    }

    private IEnumerator StartSpawn()
    {
        int num = Random.Range(1, 6);

        switch (num)
        {
            case 1:
                Spawnmonster(rabbit, rabbitPool);
                break;
            case 2:
                Spawnmonster(boar, boarPool);
                break;
            case 3:
                Spawnmonster(llama, llamaPool);
                break;
            case 4:
                Spawnmonster(lion, lionPool);
                break;
            case 5:
                Spawnmonster(elephant, elephantPool);
                break;

        }
        yield return new WaitForSeconds(2f);
        StartCoroutine(StartSpawn());
    }

    public void Spawnmonster(GameObject obj,List<GameObject> pool)
    {
        GameObject spawnObj = null;

        for(int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeSelf)
            {
                spawnObj = pool[i].gameObject;
                spawnObj.SetActive(true);
                break;
            }
        }
        if (spawnObj == null)
        {
            spawnObj = Instantiate(obj);
            pool.Add(spawnObj);
        }

        spawnObj.transform.position = GetRandomPosition();

    }

    private Vector3 GetRandomPosition()
    {
        int direction = Random.Range(1, 5);
        Vector3 randomPosition = new Vector3(0,0,0);
        switch (direction)
        {
            case 1:
                randomPosition = new Vector3(Random.Range(-70,51), 1, -58);
                break;
            case 2:
                randomPosition = new Vector3(-72, 1, Random.Range(-54, 70));
                break;
            case 3:
                randomPosition = new Vector3(Random.Range(-70, 51), 1, 70);
                break;
            case 4:
                randomPosition = new Vector3(51, 1, Random.Range(-54, 70));
                break;
        }


        return randomPosition;
    }



}
