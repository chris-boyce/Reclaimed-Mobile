using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Spawner
{
    public int Enemy1Amount;
    public int Enemy2Amount;
    public int Enemy3Amount;
    public float SpawnTime;
    public bool Finished;
}

public class Wavespawner : MonoBehaviour
{
    public List<GameObject> TypesOfEnemies;
    public Transform[] SpawnPostion;
    int SpawnLocationNumber;
    int i = 0;
    public bool FinishedSpawning = false;
    public List<Spawner> Level1 = new List<Spawner>();

    public CharcterXP PlayerXP;

    private UnityAction<float> DeathXP;

    private void Update()
    {
        if (!FinishedSpawning)//To Control the end of Level / wave
        {
            SpawnLocationNumber =  UnityEngine.Random.Range(0, SpawnPostion.Length);

            if (Level1[i].Enemy1Amount > 0)
            {
                GameObject temp =  Instantiate(TypesOfEnemies[0], SpawnPostion[SpawnLocationNumber].position, Quaternion.identity);
                Level1[i].Enemy1Amount--;
                temp.gameObject.GetComponent<EnemyHealth>().GiveXP += PlayerXP.OnGiveXP; //Subs to the GiveXP event in the enmies health and links it to the XP Controllers

            }
            else if (Level1[i].Enemy2Amount > 0)
            {
                GameObject temp = Instantiate(TypesOfEnemies[1], SpawnPostion[SpawnLocationNumber].position, Quaternion.identity);
                Level1[i].Enemy2Amount--;
                temp.gameObject.GetComponent<EnemyHealth>().GiveXP += PlayerXP.OnGiveXP; //Subs to the GiveXP event in the enmies health and links it to the XP Controllers
            }
            else if (Level1[i].Enemy3Amount > 0)
            {
                GameObject temp = Instantiate(TypesOfEnemies[2], SpawnPostion[SpawnLocationNumber].position, Quaternion.identity);
                Level1[i].Enemy3Amount--;
                temp.gameObject.GetComponent<EnemyHealth>().GiveXP += PlayerXP.OnGiveXP; //Subs to the GiveXP event in the enmies health and links it to the XP Controllers
            }
            else
            {
                Level1[i].SpawnTime -= Time.deltaTime; 
                if (Level1[i].SpawnTime <= 0)
                {
                    Level1[i].Finished = true;
                    i++;
                    if(i > Level1.Count)
                    {
                        Debug.Log("Done");
                        FinishedSpawning = true;
                        this.gameObject.AddComponent<EndRound>(); // Starts the end wave checks
                    }
                }

                if (Level1.Count <= i) //System to go to next wave after all have spawned
                {
                    FinishedSpawning = true;
                }

            }
        }

    }



}
