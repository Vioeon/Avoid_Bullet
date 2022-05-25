using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    //생성할 총알의 원본 프리팹
    public GameObject bulletPrefab;
    //최소 총알 생성 주기
    public float spawnRateMin = 0.5f;
    //최대 총알 생성 주기
    public float spawnRateMax = 3f;
    //발사할 대상 -> 조준 대상
    private Transform target;
    //총알 생성 간격
    private float spawnRate;
    //최신 생성시점에서 지난시간
    private float timeAfterSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        // 총알 생성 간격이 Min ~ Max 사이의 랜덤값으로 설정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //PlayerController 컴포넌트를 가진 게임오브젝트를 찾아서 조준 대상으로 설정
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        //최근 생성 시점에서 누적된 시간이 생성 주기보다 크거나 같으면
        if(timeAfterSpawn >= spawnRate)
        {
            //누적된 시간 리셋
            timeAfterSpawn = 0f;

            //bullet 프리팹 복제본을 transform.position위치와 transform.rotation 회전으로 생성함
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //생성된 bullet 게임 오브젝트의 정면 방향이 target(플레이어)를 향하도록 함
            bullet.transform.LookAt(target);
            //다음 생성 간격을 Min ~ Max 사이의 랜덤값으로 설정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }

    }
}
