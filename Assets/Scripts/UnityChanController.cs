using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class UnityChanController : MonoBehaviour
{
    //Rigidbodyを変数に入れる
    Rigidbody rb;
    //移動スピード
    public float speed = 3f;
    //ジャンプ力
    public float thrust = 200;
    //Animatorを入れる変数
    private Animator animator;
    //ユニティちゃんの位置を入れる
    Vector3 playerPos;
    //地面に接触しているか否か
    bool ground;
    public bool isJoycon;

    //joycon関係の変数
    private List<Joycon> m_joycons;
    private Joycon m_joyconL;
    private Joycon m_joyconR;

    void Start()
    {
        //Rigidbodyを取得
        rb = GetComponent<Rigidbody>();
        //ユニティちゃんのAnimatorにアクセスする
        animator = GetComponent<Animator>();
        //ユニティちゃんの現在より少し前の位置を保存
        playerPos = transform.position;

        //joycon準備
        m_joycons = JoyconManager.Instance.j;
        if (m_joycons == null || m_joycons.Count <= 0) return;
        m_joyconL = m_joycons.Find(c => c.isLeft);
        m_joyconR = m_joycons.Find(c => !c.isLeft);
    }

    void Update()
    {
        if (isJoycon)
        {
            if (m_joycons == null || m_joycons.Count <= 0) return;
            //var accelR = m_joyconR.GetAccel();  // 加速度
            //Debug.Log("accelR" + accelR);
            var accelL = m_joyconL.GetAccel();  // 加速度
            Debug.Log("accelL" + accelL);
            //var accelAve = (accelR.magnitude + accelL.magnitude ) / 2.0f;
            float accelMag = accelL.magnitude;
            const float mulSpeed = 1.5f;
            speed = accelMag * mulSpeed;
            accelMag /= 3.0f;
            Debug.Log("accelMag" + accelMag);

            if (ground)
            {
                //Debug.Log(accelMag);
                if (accelMag > 0.4)
                {
                    float x = Time.deltaTime * speed;
                    float z = Time.deltaTime * speed;
                    rb.MovePosition(transform.position + new Vector3(0, 0, z));
                    Vector3 direction = transform.position - playerPos;

                    Debug.Log(direction.magnitude);
                    if (direction.magnitude > 0.01f)
                    {

                        transform.rotation = Quaternion.LookRotation(new Vector3
                            (0, 0, direction.z));

                        animator.SetBool("Running", true);
                        animator.speed = accelMag;
                    }
                    else
                    {
                        //animator.SetBool("Running", false);
                    }
                    playerPos = transform.position;
                }
                else
                {
                    animator.SetBool("Running", false);
                }
            }

        }
        else
        {
            //地面に接触していると作動する
            if (ground)
            {
                //A・Dキー、←→キーで横移動
                float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

                //W・Sキー、↑↓キーで前後移動
                float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

                //現在の位置＋入力した数値の場所に移動する
                rb.MovePosition(transform.position + new Vector3(x, 0, z));

                //ユニティちゃんの最新の位置から少し前の位置を引いて方向を割り出す
                Vector3 direction = transform.position - playerPos;

                //移動距離が少しでもあった場合に方向転換
                if (direction.magnitude > 0.01f)
                {
                    //directionのX軸とZ軸の方向を向かせる
                    transform.rotation = Quaternion.LookRotation(new Vector3
                        (direction.x, 0, direction.z));
                    //走るアニメーションを再生
                    animator.SetBool("Running", true);
                }
                else
                {
                    //ベクトルの長さがない＝移動していない時は走るアニメーションはオフ
                    animator.SetBool("Running", false);
                }

                //ユニティちゃんの位置を更新する
                playerPos = transform.position;

                //スペースキーやゲームパッドの3ボタンでジャンプ
                if (Input.GetButton("Jump"))
                {
                    //thrustの分だけ上方に力がかかる
                    rb.AddForce(transform.up * thrust);
                    //速度が出ていたら前方と上方に力がかかる
                    if (rb.velocity.magnitude > 0)
                        rb.AddForce(transform.forward * thrust + transform.up * thrust);
                }
            }

        }


    }

    //Planに触れている間作動
    void OnCollisionStay(Collision col)
    {
        ground = true;
        //ジャンプのアニメーションをオフにする
        animator.SetBool("Jumping", false);
    }

    //Planから離れると作動
    void OnCollisionExit(Collision col)
    {
        ground = false;
        //ジャンプのアニメーションをオンにする
        animator.SetBool("Jumping", true);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "target")
        {
            m_joyconL.SetRumble(160, 320, 0.6f, 200);

        }
    }
}
