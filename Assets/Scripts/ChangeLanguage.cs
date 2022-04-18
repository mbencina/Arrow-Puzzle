using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLanguage : MonoBehaviour
{
    public Transform MenuCanvas;

    private bool english = true;
    private bool finnish = false;

    private List<GameObject> enList = new List<GameObject>();
    private List<GameObject> fiList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateList();

        PlayerPrefs.SetString("language", "english");
    }

    public void CreateList()
    {
        foreach (Transform child in MenuCanvas)
        {
            if (child.gameObject.CompareTag("English"))
            {
                enList.Add(child.gameObject);
            }
            else if (child.gameObject.CompareTag("Finnish"))
            {
                fiList.Add(child.gameObject);
            }
        }
    }

    public void SwitchLanguage(string language)
    {
        if (language == "english")
        {
            english = true;
            finnish = false;
            PlayerPrefs.SetString("language", "english");
        }
        else if (language == "finnish")
        {
            english = false;
            finnish = true;
            PlayerPrefs.SetString("language", "finnish");
        }

        foreach (GameObject button in enList)
        {
            button.SetActive(english);
        }
        foreach (GameObject button in fiList)
        {
            button.SetActive(finnish);
        }

        PlayerPrefs.Save();
    }
}
