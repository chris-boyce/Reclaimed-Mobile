using Facebook.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class TESTFB : MonoBehaviour
{
    public Text FB_userName;
    public Image FB_useerDp;

    void Awake()
    {
        FB_userName.text = "Guest:" + PlayerPrefs.GetString("PlayerID");
        if (!FB.IsInitialized)
        {
            FB.Init(InitCallback, OnHideUnity);
            if (FB.IsLoggedIn)
            {
                FB.Mobile.RefreshCurrentAccessToken();
                DealWithFbMenus(FB.IsLoggedIn);
            }
        }
        else
        {
            FB.ActivateApp();
        }
    }

    void Start()
    {
        if (FB.IsLoggedIn)
        {
            FB.Mobile.RefreshCurrentAccessToken();
            DealWithFbMenus(FB.IsLoggedIn);
        }
        
    }
    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
 
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }
    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void SetInit()
    {
        if (FB.IsLoggedIn)
        {
            Debug.Log("Facebook is Login!");
        }

        else
        {
            Debug.Log("Facebook is not Logged in!");

        }
        DealWithFbMenus(FB.IsLoggedIn);
    }

    public void FBLogin()
    {
        var perms = new List<string>() { "public_profile", "email" };
        FB.LogInWithReadPermissions(perms, AuthCallback);
    }
    private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions)
            {
                Debug.Log(perm);
            }
        }
        else
        {
            Debug.Log("User cancelled login");
        }
        DealWithFbMenus(FB.IsLoggedIn);
    }



    public void CallLogout()
    {
        StartCoroutine("FBLogout");

    }

    IEnumerator FBLogout()
    {
        FB.LogOut();
        while (FB.IsLoggedIn)
        {
            print("Logging Out");
            yield return null;
        }
        print("Logout Successful");
        FB_useerDp.sprite = null;
        FB_userName.text = "";
    }


    public void FacebookSharefeed()
    {
        FB.ShareLink(new System.Uri("https://chris-boyce.github.io/#"), "Check it out", "Hhaha", new System.Uri("https://chris-boyce.github.io/images/pic03.jpg") );
    }

    void AuthCallBack(IResult result)
    {
        if (result.Error != null)
        {
            Debug.Log(result.Error);
        }

        else
        {
            if (FB.IsLoggedIn)
            {
                Debug.Log("Facebook is Login!");
                // Panel_Add.SetActive(true);
            }
            else
            {
                Debug.Log("Facebook is not Logged in!");
            }

            DealWithFbMenus(FB.IsLoggedIn);
        }
    }



    void DealWithFbMenus(bool isLoggedIn)
    {
        if (isLoggedIn)
        {
            FB.API("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
            FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfilePic);
        }
    }

    void DisplayUsername(IResult result)
    {
        if (result.Error == null)
        {
            string name = "" + result.ResultDictionary["first_name"];
            FB_userName.text = name;
            Debug.Log("" + name);
        }
        else

        {
            Debug.Log(result.Error);
        }
    }



    void DisplayProfilePic(IGraphResult result)
    {
        if (result.Texture != null)
        {
            Debug.Log("Profile Pic");
            FB_useerDp.sprite = Sprite.Create(result.Texture, new Rect(0, 0, 128, 128), new Vector2());
        }
        else
        {
            Debug.Log(result.Error);
        }

    }
}