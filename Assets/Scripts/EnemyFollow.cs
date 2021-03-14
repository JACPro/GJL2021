using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] int speed = 4;
    [SerializeField] int attackingDistance = 7;
    [SerializeField] int stoppingDistance = 5;
    [SerializeField] int spottingDistance = 14;

    //TODO Replace with Unity navmesh system to avoid obstacles

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) >= stoppingDistance && Vector3.Distance(transform.position, player.position) <= spottingDistance)
        {
            transform.LookAt(player);
            transform.position += transform.forward * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, player.position) <= attackingDistance)
            {
                //TODO Attack player
            }

        }
    }
}