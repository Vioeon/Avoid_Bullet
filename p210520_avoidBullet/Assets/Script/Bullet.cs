using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;

    private Rigidbody bulletRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아서 할당
        bulletRigidbody = GetComponent<Rigidbody>();


        bulletRigidbody.velocity = transform.forward * speed;

        //3초 뒤 게임 오브젝트(자신) 파괴
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //충돌한 오브젝트의 태그가 Player인 경우
        if(other.tag == "Player")
        {
            //해당 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            //상대 오브젝트에서 PlayerController 컴포넌트를 가져오는데 성공했는지 확인
            if(playerController != null)
            {
                //PlayerController 스크립트의 Die() 메서드 실행
                playerController.Die();
            }
        }
    }
}
