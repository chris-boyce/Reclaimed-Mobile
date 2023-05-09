using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;
using Facebook.Unity;
using TMPro;

public class LeaderBoardController : MonoBehaviour
{
    public string Name;
    public GameObject ScoreboardItem;
    public GameObject GridHolder;

    void Start()
    {
        
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }
            Debug.Log("successfully started LootLocker session");
            RequestLeaderBoard();
        });
    }
    public void SubmitScores()
    {
        FB.API("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
        
    }
    void DisplayUsername(IResult result)
    {
        if (result.Error == null)
        {
            Name = "" + result.ResultDictionary["first_name"];
            
            Debug.Log("Done");
        }
        else
        {
            Debug.Log("No");
            Debug.Log(result.Error);
        }
        int leaderboardID = 13363;
        if (Name == "")
        {
            Name = PlayerPrefs.GetString("PlayerID");
        }
        
        LootLockerSDKManager.SubmitScore(Name, PlayerPrefs.GetInt("SavedPlayerLevel"), leaderboardID, (response) =>
        {
            if (response.statusCode == 200)
            {
                Debug.Log("Successful1");
            }
            else
            {
                Debug.Log("failed: " + response.Error);
            }
        });

    }

    public void RequestLeaderBoard()
    {
        GameObject[] gameObjectsWithTag = GameObject.FindGameObjectsWithTag("PlayerData");

        foreach (GameObject gameObject in gameObjectsWithTag)
        {
            Destroy(gameObject);
        }


        int leaderboardKey = 13363;
        int count = 10;
        
        LootLockerSDKManager.GetScoreList(leaderboardKey, count, 0, (response) =>
        {
            if (response.statusCode == 200)
            {
                Debug.Log("Successful");
                LootLockerLeaderboardMember[] Scores = response.items;
                Debug.Log(Scores[0].member_id);
                Debug.Log(Scores[0].score);
                for (int i = 0; i < response.items.Length; i++)
                {
                    var obj = Instantiate(ScoreboardItem, new Vector3(0, 0, 0), Quaternion.identity);
                   
                    obj.transform.SetParent(GridHolder.transform);
                    obj.GetComponentInChildren<TMP_Text>().text =
                        response.items[i].member_id + " : " + response.items[i].score;
                }
                  

            }
            else
            {
                Debug.Log("failed: " + response.Error);
            }
        });
    }

}
