using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    Vector3 offset = new Vector3(0, 5.52f, -10f);

    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, 2f, player.transform.position.z) + offset;
    }
}
