using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 Velocity;
    [SerializeField]
    float SpeedMove;
    [SerializeField]
    GameObject PrefabMazzleFlash;

    const float INITIAL_SPEED = 0.01f;   // 初期速度
    const float MOVE_FACT = 0.6f;   // 移動量減衰係数

    // Start is called before the first frame update
    void Start()
    {
        Velocity = new Vector3(0.0f, 0.0f, 0.0f);
        SpeedMove = INITIAL_SPEED;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Accelaration = new Vector3(0.0f, 0.0f, 0.0f);

        // 移動入力
        if (Input.GetKey(KeyCode.W))
        {
            Accelaration.z += SpeedMove;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Accelaration.z -= SpeedMove;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Accelaration.x -= SpeedMove;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Accelaration.x += SpeedMove;
        }

        Accelaration.Normalize();

        Accelaration *= SpeedMove;

        Velocity += Accelaration;

        // 移動量を位置に反映
        transform.Translate(Velocity);

        // 移動量の減衰
        Velocity *= MOVE_FACT;

        // 弾の発射
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject EffectMF = (GameObject)Instantiate(PrefabMazzleFlash);
        }
    }
}
