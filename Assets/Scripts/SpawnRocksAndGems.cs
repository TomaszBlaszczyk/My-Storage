using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnRocksAndGems : MonoBehaviour
{
    public SpawnPoint[] spawnPoints;
    private GameObject[] boxes;

    public GameObject box_0; //Tu będą odwołania do nowych obiektów (skały i kryształy)
    public GameObject box_1;
    public GameObject box_2;
    public GameObject box_3;
    public GameObject box_4;
    public GameObject box_5;
    public GameObject box_6;
    public GameObject box_7;
    public GameObject box_8;
    public GameObject box_9;

    private float timeToWait;
    public float TimeToWait { get => timeToWait; set { if (value > 0) timeToWait = value; } }

    private bool canSpawn = true;

    private int boxesToSpawn;
    public int BoxesToSpawn { get { return boxesToSpawn; } set { boxesToSpawn = value; } }
    public Text spawnedBoxes;
    public Image boxImage;

    private InGameMenu inGameMenu;
    public bool gameFinished;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeToWait = 5f;
        gameFinished = false;
        BoxesToSpawn = PlayerPrefs.GetInt("Objects");
        spawnPoints = FindObjectsOfType<SpawnPoint>();
        inGameMenu = FindObjectOfType<InGameMenu>();
        boxes = new GameObject[10] { box_0, box_1, box_2, box_3, box_4, box_5, box_6, box_7, box_8, box_9 };

        if (PlayerPrefs.GetInt("Challenge Type") == 2)
        {
            boxImage.enabled = true;
            spawnedBoxes.enabled = true;
        }
        else
        {
            boxImage.enabled = false;
            spawnedBoxes.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn == true && !gameFinished)
        {
            StartCoroutine(SpawnBox());
        }

        if (BoxesToSpawn <= 0 && PlayerPrefs.GetInt("Challenge Type") == 2)
        {
            //Debug.LogWarning("You Lost!");
            inGameMenu.GameOver();
            spawnedBoxes.enabled = false;
            BoxesToSpawn = PlayerPrefs.GetInt("Objects");
        }

        spawnedBoxes.text = BoxesToSpawn.ToString();

        if (BoxesToSpawn <= 10)
        {
            spawnedBoxes.color = Color.red;
        }
        else
        {
            spawnedBoxes.color = Color.green;
        }

        if (BoxesToSpawn < 0)
        {
            BoxesToSpawn = 0;
        }
    }

    IEnumerator SpawnBox()
    {
        canSpawn = false;

        int place = Random.Range(0, spawnPoints.Length - 1);
        int type = Random.Range(0, 10);

        Instantiate(boxes[type], spawnPoints[place].transform.position, spawnPoints[place].transform.rotation);
        BoxesToSpawn--;

        yield return new WaitForSeconds(timeToWait);

        canSpawn = true;
    }
}
