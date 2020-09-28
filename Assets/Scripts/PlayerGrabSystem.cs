using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabSystem : MonoBehaviour
{
    private string objectName;
    public string ObjectName { get { return objectName; } set { objectName = value; } }

    private char objectIndex;
    public char ObjectIndex { get { return objectIndex; } set { objectIndex = value; } }

    private bool hasObject = false;
    public bool HasObject { get { return hasObject; } set { hasObject = value; } }

    [SerializeField]
    private GameObject box_0;
    [SerializeField]
    private GameObject box_1;
    [SerializeField]
    private GameObject box_2;
    [SerializeField]
    private GameObject box_3;
    [SerializeField]
    private GameObject box_4;
    [SerializeField]
    private GameObject box_5;
    [SerializeField]
    private GameObject box_6;
    [SerializeField]
    private GameObject box_7;
    [SerializeField]
    private GameObject box_8;
    [SerializeField]
    private GameObject box_9;

    private void Start()
    {

    }

    private void Update()
    {
        if(objectName != null && hasObject == false)
        {
            CheckAndActive();
        }
    }

    private void CheckAndActive()   //Sprawdza symbol kliknietego obiektu, a następnie aktywuje go w ręce gracza
    {
        objectIndex = ObjectName[4];

        Debug.Log("Indeks obiektu: " + objectIndex);

        switch (objectIndex)
        {
            case '0':
                box_0.SetActive(true);
                break;
            case '1':
                box_1.SetActive(true);
                break;
            case '2':
                box_2.SetActive(true);
                break;
            case '3':
                box_3.SetActive(true);
                break;
            case '4':
                box_4.SetActive(true);
                break;
            case '5':
                box_5.SetActive(true);
                break;
            case '6':
                box_6.SetActive(true);
                break;
            case '7':
                box_7.SetActive(true);
                break;
            case '8':
                box_8.SetActive(true);
                break;
            case '9':
                box_9.SetActive(true);
                break;
        }

        HasObject = true;
    }

    public void DropObject()    //Sprawdza indeks aktualnie trzymanego obiektu i dezaktywuje jego odpowiednik
    {
        Debug.Log("Indeks obiektu: " + objectIndex);

        switch (objectIndex)
        {
            case '0':
                box_0.SetActive(false);
                break;
            case '1':
                box_1.SetActive(false);
                break;
            case '2':
                box_2.SetActive(false);
                break;
            case '3':
                box_3.SetActive(false);
                break;
            case '4':
                box_4.SetActive(false);
                break;
            case '5':
                box_5.SetActive(false);
                break;
            case '6':
                box_6.SetActive(false);
                break;
            case '7':
                box_7.SetActive(false);
                break;
            case '8':
                box_8.SetActive(false);
                break;
            case '9':
                box_9.SetActive(false);
                break;
        }

        ObjectName = null;
        HasObject = false;
    }
}
