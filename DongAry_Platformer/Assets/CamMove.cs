using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform targetTr;
    private Transform camTr;
    public float distance = 10.0f;
    public float height = 2.0f;
    public float damping = 10.0f;
    // 카메라 LookAt의 Offset 값
    public float targetOffset = 2.0f;
    // SmoothDamp에서 사용할 변수
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        camTr = GetComponent<Transform>();
    }
    void LateUpdate()
    {
        // 추적해야 할 대상의 뒤쪽으로 distance만큼 이동
        // 높이를 height만큼 이동
        Vector3 pos = targetTr.position
        + (-targetTr.forward * distance)
        + (Vector3.up * height);
        // 구면 선형 보간함수를 사용해 부드럽게 위치를 변경
        // camTr.position = Vector3.Slerp(camTr.position, // 시작 위치
        // pos, // 목표 위치
        // Time.deltaTime * damping); // 시간 t
        // SmoothDamp을 이용한 위치 보간
        camTr.position = Vector3.SmoothDamp(camTr.position, // 시작 위치
        pos, // 목표 위치
        ref velocity, // 현재 속도
        damping); // 목표 위치까지 도달할 시간

    }
}
