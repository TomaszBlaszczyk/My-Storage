using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControllerLevel_2 : MonoBehaviour
{
    public Floor tile_1;
    public Floor tile_2;
    public Floor tile_3;
    public Floor tile_4;
    public Floor tile_5;
    public Floor tile_6;
    public Floor tile_7;
    public Floor tile_8;
    public Floor tile_9;
    public Floor tile_10;
    public Floor tile_11;
    public Floor tile_12;
    public Floor tile_13;
    public Floor tile_14;
    public Floor tile_15;
    public Floor tile_16;
    public Floor tile_17;
    public Floor tile_18;
    public Floor tile_19;
    public Floor tile_20;
    public Floor tile_21;
    public Floor tile_22;
    public Floor tile_23;
    public Floor tile_24;
    public Floor tile_25;
    public Floor tile_26;
    public Floor tile_27;

    private ScoreBoard scoreBoard;
    private int points = 0;

    public AudioSource rowClean;
    private SpawnBoxes spawnBoxes;

    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        spawnBoxes = FindObjectOfType<SpawnBoxes>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //**********************************
        //Siódemka góra
        if (tile_1.BoxIndex == tile_2.BoxIndex &&
           tile_1.BoxIndex == tile_5.BoxIndex &&
           tile_1.BoxIndex == tile_6.BoxIndex &&
           tile_1.BoxIndex == tile_9.BoxIndex &&
           tile_1.BoxIndex == tile_10.BoxIndex &&
           tile_1.BoxIndex == tile_13.BoxIndex &&
           tile_1.BoxIndex != ' ')
        {
            tile_1.BoxIndex = ' ';
            tile_2.BoxIndex = ' ';
            tile_5.BoxIndex = ' ';
            tile_6.BoxIndex = ' ';
            tile_9.BoxIndex = ' ';
            tile_10.BoxIndex = ' ';
            tile_13.BoxIndex = ' ';

            Destroy(tile_1.target);
            Destroy(tile_2.target);
            Destroy(tile_5.target);
            Destroy(tile_6.target);
            Destroy(tile_9.target);
            Destroy(tile_10.target);
            Destroy(tile_13.target);

            rowClean.Play();
            spawnBoxes.BoxesToSpawn += 7;

            points = 700;
            Invoke("AddPoints", 0f);
        }

        //**********************************
        //Siódemka środek

        if (tile_3.BoxIndex == tile_4.BoxIndex &&
           tile_3.BoxIndex == tile_7.BoxIndex &&
           tile_3.BoxIndex == tile_8.BoxIndex &&
           tile_3.BoxIndex == tile_11.BoxIndex &&
           tile_3.BoxIndex == tile_12.BoxIndex &&
           tile_3.BoxIndex == tile_14.BoxIndex &&
           tile_3.BoxIndex != ' ')
        {
            tile_3.BoxIndex = ' ';
            tile_4.BoxIndex = ' ';
            tile_7.BoxIndex = ' ';
            tile_8.BoxIndex = ' ';
            tile_11.BoxIndex = ' ';
            tile_12.BoxIndex = ' ';
            tile_14.BoxIndex = ' ';

            Destroy(tile_3.target);
            Destroy(tile_4.target);
            Destroy(tile_7.target);
            Destroy(tile_8.target);
            Destroy(tile_11.target);
            Destroy(tile_12.target);
            Destroy(tile_14.target);

            rowClean.Play();
            spawnBoxes.BoxesToSpawn += 7;

            points = 700;
            Invoke("AddPoints", 0f);
        }

        //**********************************
        //Siódemka dół

        if (tile_15.BoxIndex == tile_16.BoxIndex &&
           tile_15.BoxIndex == tile_17.BoxIndex &&
           tile_15.BoxIndex == tile_18.BoxIndex &&
           tile_15.BoxIndex == tile_19.BoxIndex &&
           tile_15.BoxIndex == tile_20.BoxIndex &&
           tile_15.BoxIndex == tile_21.BoxIndex &&
           tile_15.BoxIndex != ' ')
        {
            tile_15.BoxIndex = ' ';
            tile_16.BoxIndex = ' ';
            tile_17.BoxIndex = ' ';
            tile_18.BoxIndex = ' ';
            tile_19.BoxIndex = ' ';
            tile_20.BoxIndex = ' ';
            tile_21.BoxIndex = ' ';

            Destroy(tile_15.target);
            Destroy(tile_16.target);
            Destroy(tile_17.target);
            Destroy(tile_18.target);
            Destroy(tile_19.target);
            Destroy(tile_20.target);
            Destroy(tile_21.target);

            rowClean.Play();
            spawnBoxes.BoxesToSpawn += 7;

            points = 700;
            Invoke("AddPoints", 0f);
        }

        //**********************************
        //Trójka przy regałach

        if (tile_1.BoxIndex == tile_3.BoxIndex &&
            tile_1.BoxIndex == tile_15.BoxIndex &&
            tile_1.BoxIndex != ' ')
        {
            tile_1.BoxIndex = ' ';
            tile_3.BoxIndex = ' ';
            tile_15.BoxIndex = ' ';

            Destroy(tile_1.target);
            Destroy(tile_3.target);
            Destroy(tile_15.target);

            rowClean.Play();
            spawnBoxes.BoxesToSpawn += 3;

            points = 300;
            Invoke("AddPoints", 0f);
        }

        //**********************************
        //Trójka przy paletach (lewo)

        if (tile_2.BoxIndex == tile_4.BoxIndex &&
            tile_2.BoxIndex == tile_16.BoxIndex &&
            tile_2.BoxIndex != ' ')
        {
            tile_2.BoxIndex = ' ';
            tile_4.BoxIndex = ' ';
            tile_16.BoxIndex = ' ';

            Destroy(tile_2.target);
            Destroy(tile_4.target);
            Destroy(tile_16.target);

            rowClean.Play();
            spawnBoxes.BoxesToSpawn += 3;

            points = 300;
            Invoke("AddPoints", 0f);
        }

        //**********************************
        //Trójka przy paletach (prawo)

        if (tile_5.BoxIndex == tile_7.BoxIndex &&
            tile_5.BoxIndex == tile_17.BoxIndex &&
            tile_5.BoxIndex != ' ')
        {
            tile_5.BoxIndex = ' ';
            tile_7.BoxIndex = ' ';
            tile_17.BoxIndex = ' ';

            Destroy(tile_5.target);
            Destroy(tile_7.target);
            Destroy(tile_17.target);

            rowClean.Play();
            spawnBoxes.BoxesToSpawn += 3;

            points = 300;
            Invoke("AddPoints", 0f);
        }

        //**********************************
        //Czwórka przy tablicy

        if (tile_22.BoxIndex == tile_23.BoxIndex &&
            tile_22.BoxIndex == tile_24.BoxIndex &&
            tile_22.BoxIndex == tile_25.BoxIndex &&
            tile_22.BoxIndex != ' ')
        {
            tile_22.BoxIndex = ' ';
            tile_23.BoxIndex = ' ';
            tile_24.BoxIndex = ' ';
            tile_25.BoxIndex = ' ';

            Destroy(tile_22.target);
            Destroy(tile_23.target);
            Destroy(tile_24.target);
            Destroy(tile_25.target);

            rowClean.Play();
            spawnBoxes.BoxesToSpawn += 4;

            points = 400;
            Invoke("AddPoints", 0f);
        }

        //**********************************
        //Czwórka lewa

        if (tile_6.BoxIndex == tile_8.BoxIndex &&
            tile_6.BoxIndex == tile_18.BoxIndex &&
            tile_6.BoxIndex == tile_22.BoxIndex &&
            tile_6.BoxIndex != ' ')
        {
            tile_6.BoxIndex = ' ';
            tile_8.BoxIndex = ' ';
            tile_18.BoxIndex = ' ';
            tile_22.BoxIndex = ' ';

            Destroy(tile_6.target);
            Destroy(tile_8.target);
            Destroy(tile_18.target);
            Destroy(tile_22.target);

            rowClean.Play();
            spawnBoxes.BoxesToSpawn += 4;

            points = 400;
            Invoke("AddPoints", 0f);
        }

        //**********************************
        //Czwórka lewy środek

        if (tile_9.BoxIndex == tile_11.BoxIndex &&
            tile_9.BoxIndex == tile_19.BoxIndex &&
            tile_9.BoxIndex == tile_23.BoxIndex &&
            tile_9.BoxIndex != ' ')
        {
            tile_9.BoxIndex = ' ';
            tile_11.BoxIndex = ' ';
            tile_19.BoxIndex = ' ';
            tile_23.BoxIndex = ' ';

            Destroy(tile_9.target);
            Destroy(tile_11.target);
            Destroy(tile_19.target);
            Destroy(tile_23.target);

            rowClean.Play();
            spawnBoxes.BoxesToSpawn += 4;

            points = 400;
            Invoke("AddPoints", 0f);
        }

        //**********************************
        //Czwórka prawy środek

        if (tile_10.BoxIndex == tile_12.BoxIndex &&
            tile_10.BoxIndex == tile_20.BoxIndex &&
            tile_10.BoxIndex == tile_24.BoxIndex &&
            tile_10.BoxIndex != ' ')
        {
            tile_10.BoxIndex = ' ';
            tile_12.BoxIndex = ' ';
            tile_20.BoxIndex = ' ';
            tile_24.BoxIndex = ' ';

            Destroy(tile_10.target);
            Destroy(tile_12.target);
            Destroy(tile_20.target);
            Destroy(tile_24.target);

            rowClean.Play();
            spawnBoxes.BoxesToSpawn += 4;

            points = 400;
            Invoke("AddPoints", 0f);
        }

        //**********************************
        //Czwórka prawa

        if (tile_13.BoxIndex == tile_14.BoxIndex &&
            tile_13.BoxIndex == tile_21.BoxIndex &&
            tile_13.BoxIndex == tile_25.BoxIndex &&
            tile_13.BoxIndex != ' ')
        {
            tile_13.BoxIndex = ' ';
            tile_14.BoxIndex = ' ';
            tile_21.BoxIndex = ' ';
            tile_25.BoxIndex = ' ';

            Destroy(tile_13.target);
            Destroy(tile_14.target);
            Destroy(tile_21.target);
            Destroy(tile_25.target);

            rowClean.Play();
            spawnBoxes.BoxesToSpawn += 4;

            points = 400;
            Invoke("AddPoints", 0f);
        }
    }

    private void AddPoints()
    {
        scoreBoard.Points += points;
    }
}
