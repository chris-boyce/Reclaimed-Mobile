using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;
using Facebook.Unity;
using TMPro;

public class LeaderBoardController : MonoBehaviour
{
    public InputField MemberID, PlayerScore;
    public int ID;
    public string Name;
    public TMP_Text Player1;

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
        });
        FB.API("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
    }
    public void SubmitScores()
    {
        int leaderboardID = 13363;
        

        LootLockerSDKManager.SubmitScore(Name, PlayerPrefs.GetInt("SavedLevel"), leaderboardID, (response) =>
        {
            if (response.statusCode == 200)
            {
                Debug.Log("Successful");
            }
            else
            {
                Debug.Log("failed: " + response.Error);
            }
        });
    }
    void DisplayUsername(IResult result)
    {
        if (result.Error == null)
        {
            Name = "" + result.ResultDictionary["first_name"];
        }
        else
        {
            Debug.Log(result.Error);
        }
    }

    public void RequestLeaderBoard()
    {
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
                Player1.text = Scores[0].member_id + " : " + Scores[0].score;

            }
            else
            {
                Debug.Log("failed: " + response.Error);
            }
        });
    }

}
