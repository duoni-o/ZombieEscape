using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유저가 마우스 왼쪽 버튼을 누르면 Ray를 이용해서 총을 쏘고 싶다.
// 총구위치 : 카메라 위치
// 조준(crosshair)
// - 총알자국 공장
public class Gun : MonoBehaviour
{
    // - 총알자국 공장
    public GameObject bImpactFatory;
    // - 총알 발사 위치
    public Transform firePosition;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 만약 유저가 마우스 왼쪽 버튼을 누르면
        if (Input.GetButtonDown("Fire1"))
        {
            // 2. 시선(Ray)을 만들고
            Ray ray = new Ray(firePosition.position, firePosition.forward);
            // 3. 닿은곳의 정보를 담을 변수 HitInfo도 만들고
            RaycastHit hitInfo;
            // 4. 시선을 이용해서 바라보고싶다.
            if (Physics.Raycast(ray, out hitInfo, 1000))
            {
                // 닿은것이 있다
                // 6. 그곳에 총알자국을 남기고 싶다.
                GameObject bImpact = Instantiate(bImpactFatory);
                bImpact.transform.position = hitInfo.point;
                // 이펙트의 튀어오르는 방향(앞)이 닿은물체의 Normal방향이 되게 하고싶다.
                bImpact.transform.forward = hitInfo.normal;
                // 7. 그 닿은 물체가 배경이 아니라면
                if (hitInfo.collider.gameObject.tag != "Land")
                {
                    Destroy(hitInfo.collider.gameObject);
                }
            }
            else
            {
                // 닿은것이 없다.
            }
        }
    }
}
