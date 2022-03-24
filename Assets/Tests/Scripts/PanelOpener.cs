using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;

    private void Start()
    {
        StartCoroutine(ShowMessage());
    }

    public IEnumerator ShowMessage()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSecondsRealtime(3);
            OpenPanel();
            
            yield return new WaitForSecondsRealtime(2);
            OpenPanel();
        }
    }

    public void OpenPanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Debug.Log("Panel " + isActive);
            Panel.SetActive(!isActive);
        }

    }
}
