using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RetriveTokenAndLectureID : MonoBehaviour
{
    private string _urlExample = "http://54.67.78.241:3000/xrlecture/xroom/index.html?XRLecture=6224f6227e236be570ce5652?Token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjYyMjRmNDMzN2UyMzZiZTU3MGNlNTYyMiIsImlhdCI6MTY0NjkzNTU0NiwiZXhwIjoxNjQ2OTQ2MzQ2fQ.OKsrhKBWLcxoTFKc4FEI6W5IWZ3gZtyRedZZJ115Xjo";
    //Url if you load the game

    private string _url;
    InputField _outputArea;

    private string _findToken = "?Token="; //look for token in the url
    private string _findLectureID = "?XRLecture="; //look for lecture in the url

    private string _getLectureID; // obtain token in this variable
    private string _getToken; // obtain token in this variable

    private void Awake()
    {

    }
    private void Start()
    {
        //      Debug.Log(_url);
        //      Debug.Log(_url.IndexOf(_findToken));
                _outputArea = GameObject.Find("OutputArea").GetComponent<InputField>();
     //   GameObject.Find("GetButton").GetComponent<Button>().onClick.AddListener(this.GetData);
    }

    public void GetData()
    {
        _url = "http://54.67.78.241:3000/xrlecture/xroom/index.html?XRLecture=6224f6227e236be570ce5652?Token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjYyMjRmNDMzN2UyMzZiZTU3MGNlNTYyMiIsImlhdCI6MTY0NjkzNTU0NiwiZXhwIjoxNjQ2OTQ2MzQ2fQ.OKsrhKBWLcxoTFKc4FEI6W5IWZ3gZtyRedZZJ115Xjo";

        string tokenOutput;
        string IdOutput;
        if (_url.Contains(_findToken))
        {
            _getToken = _url.Substring(_url.IndexOf(_findToken) + _findToken.Length);

            tokenOutput =_getToken;
            Debug.Log("Token from browser: " + _getToken);
            Debug.Log("Got Token");
        }
        else
        {
            tokenOutput = "Token not found";
            Debug.LogError("Token not found");
        }

        if (_url.Contains(_findLectureID))
        {
            string stringBeforeID = _url.Substring(0, _url.IndexOf(_findLectureID) + _findLectureID.Length); // refers to http://54.67.78.241:3000/xrlecture/xroom/index.html?XRLecture= in string
            string stringAfterID = _url.Substring(_url.IndexOf(_findToken)); // refers to ?Token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjYyMjRmNDMzN2UyMzZiZTU3MGNlNTYyMiIsImlhdCI6MTY0NjkzNTU0NiwiZXhwIjoxNjQ2OTQ2MzQ2fQ.OKsrhKBWLcxoTFKc4FEI6W5IWZ3gZtyRedZZJ115Xjo
            int IDLength = _url.Length - stringBeforeID.Length - stringAfterID.Length; // get the total length of ID
            _getLectureID = _url.Substring(_url.IndexOf(_findLectureID) + _findLectureID.Length, IDLength); // Starting point is one index after '?XRLecture' and the length will be the ID length

            IdOutput = _getLectureID;
            Debug.Log("Lecture ID from browser: " + _getLectureID);
            Debug.Log("Got Lecture ID");
        }
        else
        {
            IdOutput = "Lecture ID not found";
            Debug.LogError("Lecture ID not found");
        }

        _outputArea.text = "- URL: \n" + _url + "\n- Token from browser: \n" + tokenOutput + "\n- Lecture ID from browser: \n" + IdOutput ;
    }
}
