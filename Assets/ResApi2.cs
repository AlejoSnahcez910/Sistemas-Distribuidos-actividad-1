using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;


public class ResApi2 : MonoBehaviour
{
    [SerializeField] private List<RawImage> YourRawImage;
    [SerializeField] private List<TMP_Text> YourTextMesh;
    [SerializeField] private int UserId = 1;
    [SerializeField] private string MyApiServer = "https://my-json-server.typicode.com/AlejoSnahcez910/Json-Server";
    [SerializeField] private string RickAndMortyApi = "https://rickandmortyapi.com/api";
    public int[] cards;

    public void GetCharacterClick()
    {
        StartCoroutine(GetCharacter(1, 1));
    }
    public void GetPlayerInfoClick()
    {
        StartCoroutine(GetPlayerInfo());
        

    }


    IEnumerator GetPlayerInfo()
    {
        string url = MyApiServer + "/users/" + UserId;
        Debug.Log(url);
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.Send();

        if (www.isNetworkError)
        {
            Debug.Log("NETWORK ERROR:" + www.error);
        }
        else
        {

            if (www.responseCode == 200)
            {
                UserData user = JsonUtility.FromJson<UserData>(www.downloadHandler.text);

                Debug.Log("Name:" + user.name);
                

                for (int i = 0; i < user.deck.Length; i++)
                {
                    StartCoroutine(GetCharacter(user.deck[i], i));
                    StartCoroutine(GetCharactertext(user.deck[i], i));

                    yield return new WaitForSeconds(0.1f);
                }
            }
            else
            {
                string mensaje = "Status:" + www.responseCode;
                mensaje += "\ncontent-type:" + www.GetResponseHeader("content-type");
                mensaje += "\nError:" + www.error;
                Debug.Log(mensaje);
            }

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
    IEnumerator GetCharacter(int Id, int Card)
    {
        UnityWebRequest www = UnityWebRequest.Get(RickAndMortyApi + "/character/" + Id);
        yield return www.Send();

        if (www.isNetworkError)
        {
            Debug.Log("NETWORK ERROR:" + www.error);
        }
        else
        {


            if (www.responseCode == 200)
            {
                Character character = JsonUtility.FromJson<Character>(www.downloadHandler.text);
                Debug.Log(character.id);
                StartCoroutine(DownloadImage(character.image, Card));


            }
            else
            {
                string mensaje = "Status:" + www.responseCode;
                mensaje += "\ncontent-type:" + www.GetResponseHeader("content-type");
                mensaje += "\nError:" + www.error;
                Debug.Log(mensaje);
            }

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator GetCharactertext(int Id, int textinfo)
    {
        UnityWebRequest www = UnityWebRequest.Get(RickAndMortyApi + "/character/" + Id);
        yield return www.Send();

        if (www.isNetworkError)
        {
            Debug.Log("NETWORK ERROR:" + www.error);
        }
        else
        {


            if (www.responseCode == 200)
            {
                Character character = JsonUtility.FromJson<Character>(www.downloadHandler.text);
                Debug.Log(character.id);
                StartCoroutine(GetTextinfo(character.name, textinfo));


            }
            else
            {
                string mensaje = "Status:" + www.responseCode;
                mensaje += "\ncontent-type:" + www.GetResponseHeader("content-type");
                mensaje += "\nError:" + www.error;
                Debug.Log(mensaje);
            }

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }




    IEnumerator DownloadImage(string url, int Card)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else YourRawImage[Card].texture = ((DownloadHandlerTexture)request.downloadHandler).texture;

    }

    IEnumerator GetTextinfo(string url, int textinfo)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else YourTextMesh[textinfo].text = ((DownloadHandler)request.downloadHandler).text;

    }


}

    [System.Serializable]
public class CharacterList
{
    public CharacterListInfo info;
    public List<Character> results;
}

[System.Serializable]
public class CharacterListInfo
{
    public int count;
    public int pages;
    public string prev;
    public string next;
}

[System.Serializable]
public class Character
{
    public int id;
    public string name;
    public string image;
}
public class CharacterImage
{
    public string image;
}

public class UserData
{
    public int id;
    public string name;
    public int[] deck;
}

    