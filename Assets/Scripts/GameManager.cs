using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
 
    //Reference to PauseMenu
    public PauseMenu pauseMenu;

    //Reference to the boss HP bar
    public GameObject bossHPbar;

    //Amount of meteors spawned each waves
    public int numberOfMeteors = 20;

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

    //Boss
    public GameObject jellyfish;

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

    //Indicate if the bossfight cutscene started
    bool isBossCutsceneHappening = false;

    //Indicate if the bossfight started
    public bool isBossfightHappening = false;

    //Is the boss theme playing
    bool bossThemePlaying = false;

    //Is the boss dead ?
    public bool isBossDead = false;

    /***
    Start is called before the first frame update.
    ***/
    void Start(){
        Scene currentScene = SceneManager.GetActiveScene ();
        if(currentScene.name == "Story"){
            PlayerPrefs.SetInt("Mode", 0);
            PlayerPrefs.Save();
            currentMode = 0;
        }
        else{
            PlayerPrefs.SetInt("Mode", 1);
            PlayerPrefs.Save();
            currentMode = 1;
        }
        bossHPbar.SetActive(false);
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
        timerBetweenEnemyWaves += Time.deltaTime;
        timerBetweenBonus += Time.deltaTime;

        //Spawn the boss and prevent the meteor from spawning if the player reaches 200 points in story mode
        if(score >= 200 && currentMode == 0 && isBossCutsceneHappening == false)
        {
            FindObjectOfType<AudioManager>().Stop("Theme");
            FindObjectOfType<AudioManager>().Play("BossThemeFadeIn");
            isBossCutsceneHappening = true;
            numberOfMeteors = 0;
            FindObjectOfType<AudioManager>().Play("BossSpawn");
            BossSpawner();
        }
        else if(isBossCutsceneHappening == true)
        {
            //Spawn bonuses
            if(timerBetweenBonus >= bonusTime){

                //
                //Select a random bonus type
                int randomNumber = Random.Range(0,bonuses.Count-1);
                //Select random coords in game screen
                Vector2 randomSpawn = new Vector2(Random.Range(min_x,max_x),Random.Range(min_y,max_y));
                GameObject clone = Instantiate(bonuses[randomNumber], randomSpawn, Quaternion.identity);
                clone.name = bonuses[randomNumber].name;
                //

                FindObjectOfType<AudioManager>().Play("BonusSpawn");
                timerBetweenBonus = 0f;
                bonusTime = 0f;
            }
            if(FindObjectOfType<AudioManager>().isPlaying("BossThemeFadeIn") == false && bossThemePlaying == false) {
                bossThemePlaying = true;
                FindObjectOfType<AudioManager>().Play("BossTheme");
            }

                
        }
        else
        {
            //Change difficulty in relation to the score
            if(currentMode == 1 && score < 25 && numberOfMeteors != 4) numberOfMeteors = 4;
            if(currentMode == 1 && score >= 25 && score < 50 && numberOfMeteors != 5) numberOfMeteors = 5;
            if(currentMode == 1 && score >= 50 && score < 100 && numberOfMeteors != 8) numberOfMeteors = 8;
            if(currentMode == 1 && score >= 100 && score < 200 && numberOfMeteors != 10) numberOfMeteors = 10;
            if(currentMode == 1 && score >= 200 && score < 500 && numberOfMeteors != 15) numberOfMeteors = 15;
            if(currentMode == 1 && score >= 500 && score < 800 && numberOfMeteors != 20) numberOfMeteors = 20;
            if(currentMode == 1 && score >= 800) numberOfMeteors = Random.Range(20,28);

            //Spawn enemies
            
            if(timerBetweenEnemyWaves >= spawnTime){
                EnemiesSpawner();
                timerBetweenEnemyWaves = 0f;
                spawnTime = 0f;
            }
            //Spawn bonuses
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

    /***
    Boss spawner.
    Spawn the Boss when player reaches 200 points.
    ***/
    void BossSpawner(){
        //Select random coords in game screen
        Vector2 bossSpawn = new Vector2(((min_x + max_x)/2),(max_y + 2));
        GameObject clone = Instantiate(jellyfish, bossSpawn, Quaternion.identity);
        clone.name = jellyfish.name;
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
        SceneManager.LoadScene("EndScreen");
    }

    /***
    Behavior upon losing.
    Load the losing screen.
    ***/
    public void GameWon(){
        SetHighscore();
        SetScore();
        PlayerPrefs.SetInt("bossDefeated", 1);
        SceneManager.LoadScene("EndScreen");
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

    /***
    Indicate that the bossfight started.
    ***/
    public void SetBossfightStart(){
        isBossfightHappening = true;
    }

    /***
    Indicate that the bossfight started.
    ***/
    public void StopBossfight(){
        isBossfightHappening = false;
    }

    /***
    Indicate that the boss is dead.
    ***/
    public void SetBossDead(){
        isBossDead = true;
    }
}
