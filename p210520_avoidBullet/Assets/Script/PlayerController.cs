using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;

    public float speed = 8f;

    public Text timer;
    private float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //실제속도를 입력값과 이동 속력을 사용하여 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        playerRigidbody.velocity = newVelocity;          // velocity : 새로운 속도 적용, 관성영향 X
        /* 
        if(Input.GetKey(KeyCode.UpArrow) == true)             AddForce() : 속력 점진적 증가, 관성영향 O
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }*/

        time += Time.deltaTime;

        timer.text = "Time : " + time.ToString("00.00");


    }

    public void Die()
    {
        //자신의 게임 오브젝트 비활성화
        gameObject.SetActive(false);

        SceneManager.LoadScene("SampleScene");
    }
}
