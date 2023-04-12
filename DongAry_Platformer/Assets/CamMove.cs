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
    // ī�޶� LookAt�� Offset ��
    public float targetOffset = 2.0f;
    // SmoothDamp���� ����� ����
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        camTr = GetComponent<Transform>();
    }
    void LateUpdate()
    {
        // �����ؾ� �� ����� �������� distance��ŭ �̵�
        // ���̸� height��ŭ �̵�
        Vector3 pos = targetTr.position
        + (-targetTr.forward * distance)
        + (Vector3.up * height);
        // ���� ���� �����Լ��� ����� �ε巴�� ��ġ�� ����
        // camTr.position = Vector3.Slerp(camTr.position, // ���� ��ġ
        // pos, // ��ǥ ��ġ
        // Time.deltaTime * damping); // �ð� t
        // SmoothDamp�� �̿��� ��ġ ����
        camTr.position = Vector3.SmoothDamp(camTr.position, // ���� ��ġ
        pos, // ��ǥ ��ġ
        ref velocity, // ���� �ӵ�
        damping); // ��ǥ ��ġ���� ������ �ð�

    }
}
