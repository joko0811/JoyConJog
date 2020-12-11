using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class AgentController : MonoBehaviour
{
    //Rigidbodyを変数に入れる
    Rigidbody rb;
    //移動スピード
    public float speed = 3f;
    //スピードに対しての定数倍
    public float mulSpeed = 1.5f;
    //ユニティちゃんの位置を入れる
    Vector3 playerPos;
    public bool isJoycon;
    float velocity = 0;
    float tmp = 0;
    float time = 0;
    Vector3 firstPos;
    public Transform target;
    NavMeshAgent agent;
    
    //joycon関係の変数
    private List<Joycon> m_joycons;
    private Joycon m_joyconL;
    private Joycon m_joyconR;

    private float levelValue;//加速度のいき値

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //Rigidbodyを取得
        rb = GetComponent<Rigidbody>();
        //ユニティちゃんの現在より少し前の位置を保存
        playerPos = transform.position;
        firstPos = transform.position;

        //joycon準備
        m_joycons = JoyconManager.Instance.j;
        if (m_joycons == null || m_joycons.Count <= 0) return;
        m_joyconL = m_joycons.Find(c => c.isLeft);
        m_joyconR = m_joycons.Find(c => !c.isLeft);

        levelValue = ChangeGameScene.levelValue;
    }

    void Update()
    {
        agent.destination = target.transform.position;
        if (isJoycon)
        {
            if (m_joycons == null || m_joycons.Count <= 0) return;
            //var accelR = m_joyconR.GetAccel();  // 加速度
            //Debug.Log("accelR" + accelR);
            var accelL = m_joyconL.GetAccel();  // 加速度
            //Debug.Log("accelL" + accelL);
            //var accelAve = (accelR.magnitude + accelL.magnitude ) / 2.0f;
            float accelMag = accelL.magnitude;
            speed = accelMag * mulSpeed;
            accelMag /= 3.0f;
            //Debug.Log("accelMag" + accelMag);
            Debug.Log("velocity" + ((transform.position - playerPos) / Time.deltaTime).magnitude);

            float z;
            //Debug.Log(accelMag);
           // if (accelMag > 0.4)
            if (accelMag > levelValue)
            {
                time = 0;
                //float x = Time.deltaTime * speed;
                z = Time.deltaTime * speed;
                rb.MovePosition(transform.position + new Vector3(0, 0, z));
                agent.speed = speed ;
                Vector3 direction = transform.position - playerPos;

                Debug.Log("agentspeed"+agent.speed);
                if (direction.magnitude > 0.01f)
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3
                        (0, 0, direction.z));
                }
                //ユニティちゃんの位置を更新する
                playerPos = transform.position;
            }
            else
            {
                //Stop();
                
                time += Time.deltaTime;
                if (time > 2)
                {
                    /*
                    rb.AddForce(new Vector3(0, 0, -time * rb.velocity.magnitude / 5));
                    if (rb.velocity.magnitude < 1)
                    {
                    */
                        Stop();
                    //}
                }
                
            }

        }
        else
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
                }


                //ユニティちゃんの位置を更新する
                playerPos = transform.position;
        }


    }
    //止めたい時に呼び出し
    void Stop()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
