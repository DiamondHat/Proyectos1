using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, Spin }

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public GameObject player;
    public float bulletLife = 1f;
    public float speed = 1f;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;

    private GameObject spawnedBullet;
    private float timer = 0f;

    void Start()
    {
       
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z+1f);
        if(timer >= firingRate) {
            Fire();
            timer = 0;
        }
    }
     private void Fire() {
        if(bullet) {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            Bullet bulletScript = spawnedBullet.GetComponent<Bullet>();
            bulletScript.speed = speed;
            bulletScript.bulletLife = bulletLife;
            bulletScript.SetTarget(player.transform.position);
        }
    }
}

