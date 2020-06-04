using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    //트리거 감지 후 해당 오브젝트 삭제
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
