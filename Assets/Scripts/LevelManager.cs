using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public List<Level> levels;
    public Level activeLevel;
    public Transform levelHolder;
    public bool isLevelRestarted = false;
    public int activeLevelID;
    public Cinemachine.CinemachineVirtualCamera cmVirtual;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        levelHolder = transform.GetChild(0).transform;

        LoadLevel(GetLevelID() % instance.levels.Count);
    }

    public static void SetLevelID(int levelID)
    {
        PlayerPrefs.SetInt("levelIndex", levelID);
    }

    public static int GetLevelID()
    {
        int levelID = PlayerPrefs.GetInt("levelIndex", 0);

        return levelID;
    }

    public static void LoadNextLevel()
    {
        int levelID = GetLevelID() + 1;
        SceneManager.LoadScene(0);
        SetLevelID(levelID);
    }

    public void LoadLevel(int index)
    {
        this.RemoveLevel();
        Level currentLevel = Instantiate(levels[index], levelHolder.transform);
        this.activeLevel = currentLevel;
        activeLevelID = index;

        CanvasManager.instance.guide.SetActive(true);

        CanvasManager.instance.levelText.SetText((GetLevelID() + 1).ToString());
    }

    public void RestartCurrentLevel()
    {
        LoadLevel(activeLevelID);
    }

    public void RemoveLevel()
    {

        if (GetActiveLevel() != null)
            Destroy(GetActiveLevel().gameObject);
    }

    public Level GetActiveLevel()
    {
        if (levelHolder.childCount > 0)
            return levelHolder.GetChild(0).GetComponent<Level>();
        else
            return null;


    }

    
}
