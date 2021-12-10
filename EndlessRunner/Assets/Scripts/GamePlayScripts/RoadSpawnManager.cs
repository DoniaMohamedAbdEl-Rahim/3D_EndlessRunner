using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawnManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> roads;
    float offset = 50f;
    void Start()
    {
        if (roads != null && roads.Count > 0)
            roads = roads.OrderBy(road => road.transform.position.z).ToList();

    }

    public void MoveRoad()
    {
        GameObject movedRoad = roads[0];
        roads.Remove(movedRoad);
        float newZPosition = roads[roads.Count - 1].transform.position.z + offset;
        movedRoad.transform.position = new Vector3(0, 0, newZPosition);
        var coins = movedRoad.gameObject.transform.Find("Coins");
        for(int i = 0; i < coins.transform.childCount; i++)
        {
            coins.transform.GetChild(i).gameObject.SetActive(true);
        }
            roads.Add(movedRoad);
    }
}
