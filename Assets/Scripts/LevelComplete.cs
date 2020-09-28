using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private InGameMenu inGameMenu;

    // Start is called before the first frame update
    void Start()
    {
        inGameMenu = FindObjectOfType<InGameMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Time.timeScale = 0;

            switch (SceneManager.GetActiveScene().buildIndex)
            {
                case 2:
                    inGameMenu.GameOver();
                    break;
            }
        }
    }
}
