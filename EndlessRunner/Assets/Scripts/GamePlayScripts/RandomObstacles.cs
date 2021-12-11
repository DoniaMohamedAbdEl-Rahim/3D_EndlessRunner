using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacles : MonoBehaviour
{
    [SerializeField]
    GameObject[] obstaclePrefabs;
    [SerializeField]
    GameObject player;
    bool createObstacle = true;
    void Start()
    {

    }

    void Update()
    {
        if (createObstacle)
        {
            createObstacle = false;
            StartCoroutine(InstantiateObstacle());
        }

    }
    IEnumerator InstantiateObstacle()
    {
        int radnomIdx = Random.Range(0, obstaclePrefabs.Length);
        GameObject obstacle = obstaclePrefabs[radnomIdx];
        float x = Random.Range(-4.2f, 5.5f);
        float z = Random.Range(player.transform.position.z + 50, player.transform.position.z + 200);
        Vector3 obstaclePosition = new Vector3(x, 0f, z);
        Instantiate(obstacle, obstaclePosition, obstacle.gameObject.transform.localRotation);
        yield return new WaitForSeconds(0.8f);
        createObstacle = true;
    }
}
