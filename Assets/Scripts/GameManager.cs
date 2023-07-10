using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
 
    //Reference to PauseMenu
    public PauseMenu pauseMenu;

    //Amount of meteors spawned each waves
    public int numberOfMeteors;

    //Max time between each wave
    float spawnTime = 0f;

    //Timer between each wave of enemies
    float timerBetweenEnemyWaves = 0f;

    //Score
    public int score = 0;

    //List containing different types of enemies to spawn
    public List<GameObject> enemies;

    //List containing different types of bonuses to spawn
    public List<GameObject> bonuses;

    //Axis coords to randomize the spawn of each enemy
    public float min_x = -9;
    public float max_x = 9;
    public float min_y = -5;
    public float max_y = 5;

    //Offset to spawn enemies outside of view but close to game screen
    int offset = 3;

    //Random timer for bonuses spawn
    float bonusTime = 0f;

    //Timer between each bonus spawn
    float timerBetweenBonus = 0f;

    //Highscore
    public int highScore = 0;

    //Indicate if the game is paused or not
    bool pauseControl = false;

    //Indicate if it's the first wave
    bool firstWave = true;

    //Indicate the current mode : 0 for story, 1 for endless;
    int currentMode;

    /***
    Start is called before the first frame update.
    ***/
    void Start(){
        Scene currentScene = SceneManager.GetActiveScene ();
        if(currentScene.name == "Story"){
            PlayerPrefs.SetInt("Mode", 0);
            PlayerPrefs.Save();
        }
        else{
            PlayerPrefs.SetInt("Mode", 1);
            PlayerPrefs.Save();
        }

        FindObjectOfType<AudioManager>().Play("Theme");
        //Get the highscore from player prefs if it is there, 0 otherwise
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        EnemiesSpawner();
    }

    void Update(){
        //Set up the spawn timers
        if(bonusTime == 0f){
            bonusTime = Random.Range(10f, 15f);
        }
        if(spawnTime == 0f){
            spawnTime = Random.Range(2f, 8f);
        }
        //Spawn enemies
        timerBetweenEnemyWaves += Time.deltaTime;
        if(timerBetweenEnemyWaves >= spawnTime){
            EnemiesSpawner();
            timerBetweenEnemyWaves = 0f;
            spawnTime = 0f;
        }
        //Spawn bonuses
        timerBetweenBonus += Time.deltaTime;
        if(timerBetweenBonus >= bonusTime){
            BonusSpawner();
            FindObjectOfType<AudioManager>().Play("BonusSpawn");
            timerBetweenBonus = 0f;
            bonusTime = 0f;
        }
        //Check if the Pause key is pressed
        if(Input.GetKey(KeyCode.Escape)){
            FindObjectOfType<AudioManager>().Play("Button");
            SetScore();
            pauseMenu.Pause();
        } 
    }

    // SPAWNERS //

    /***
    Enemy spawner.
    Spawn enemies at the beginning of the game and at the start of each wave.
    ***/
    void EnemiesSpawner(){
        if(firstWave == true){
            int acc = 0;
            while(acc < numberOfMeteors/2){
                //Select random coords in game screen plus offset
                Vector2 randomSpawn = new Vector2(Random.Range(min_x - offset,max_x + offset),Random.Range(min_y - offset,max_y + offset));
                //If coords are in screen view, do not spawn, the 1 is added to make sure meteors are not half visible
                if((randomSpawn[0] > min_x -1) && (randomSpawn[0] < max_x +1) && (randomSpawn[1] > min_y -1) && (randomSpawn[1] < max_y +1)){  
                //If coords are on the side of the screen view, spawn
                }else{
                    GameObject clone = Instantiate(enemies[1], randomSpawn, Quaternion.identity);
                    clone.name = enemies[1].name;
                    acc+=1;
                }
            }
            firstWave = false;
        }else{
            int acc = 0;
            while(acc < numberOfMeteors){
                //Select a random enemy type
                int randomNumber = Random.Range(0,enemies.Count);
                //Select random coords in game screen plus offset
                Vector2 randomSpawn = new Vector2(Random.Range(min_x - offset,max_x + offset),Random.Range(min_y - offset,max_y + offset));
                //If coords are in screen view, do not spawn, the 1 is added to make sure meteors are not half visible
                if((randomSpawn[0] > min_x -1) && (randomSpawn[0] < max_x +1) && (randomSpawn[1] > min_y -1) && (randomSpawn[1] < max_y +1)){  
                //If coords are on the side of the screen view, spawn
                }else{
                    GameObject clone = Instantiate(enemies[randomNumber], randomSpawn, Quaternion.identity);
                    clone.name = enemies[randomNumber].name;
                    acc+=1;
                }
            }
        }
    }
    
    /***
    Bonus spawner.
    Spawn bonus between 10 and 15 seconds
    ***/
    void BonusSpawner(){
        //Select a random bonus type
        int randomNumber = Random.Range(0,bonuses.Count);
        //Select random coords in game screen
        Vector2 randomSpawn = new Vector2(Random.Range(min_x,max_x),Random.Range(min_y,max_y));
        GameObject clone = Instantiate(bonuses[randomNumber], randomSpawn, Quaternion.identity);
        clone.name = bonuses[randomNumber].name;
    }

    // MENUS //

    /***
    Pause or unpause the game considering its current state.
    ***/
    public void pauseGame(){
        pauseControl = !pauseControl;
    }

    /***
    Indicate if the game is paused or not
    ***/
    public bool isPaused(){
        return pauseControl;
    }


    /***
    Behavior upon losing.
    Load the losing screen.
    ***/
    public void gameLost(){
        SetHighscore();
        SetScore();
        SceneManager.LoadScene("LosingScreen");
    }

    // SCORES //

    /***
    Increase score for big meteor's destruction.
    ***/
    public void IncreaseBigScore(){
        score+=5;
    }

    /***
    Increase score for tiny meteor's destruction.
    ***/
    public void IncreaseScore(){
        score+=2;
    }

    /***
    Set new highscore in PlayerPrefs.
    ***/
    public void SetHighscore(){
        if(score>highScore){
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }

    /***
    Set current score in PlayerPrefs.
    ***/
    public void SetScore(){
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }
}
