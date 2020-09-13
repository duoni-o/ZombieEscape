using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유저의 입력에따라 총알을 만들어서 총구 위치에 가져다 놓고싶다.
// - 총알 공장
// - 총구 위치
public class PlayerFire : MonoBehaviour
{
    // - 총알 공장
    public GameObject bulletFactory;
    // - 총구 위치
    public Transform firePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 만약 유저가 마우스 좌측 버튼을 누르면
        if (Input.GetButtonDown("Fire2"))
        {
            // 2. 총알 공장에서 총알을 만들어서
            GameObject bullet = Instantiate(bulletFactory);
            // 3. 만들어진 총알을 총구 위치에 가져다 놓고싶다.
            bullet.transform.position = firePosition.position;
            // 4. firePosition의 앞방향으로 총알의 앞방향을 회전해야한다.
            bullet.transform.forward = firePosition.forward;
        }

    }
}
