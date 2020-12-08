using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillCountManager : MonoBehaviour
{
    public bool m_BlueMonsterKilled;
    public bool m_RedMonsterKilled;
    private bool m_PlayerWon;

    private Scene m_CurrentScene;
    private string sceneString;

    public void Awake()
    {
        m_PlayerWon = false;
        GameObject obj = GameObject.FindGameObjectWithTag("Manager");
        DontDestroyOnLoad(obj.gameObject);
    }
    public void Start()
    {
        m_CurrentScene = SceneManager.GetActiveScene();
        sceneString = m_CurrentScene.name;
    }

    public void Update()
    {
        if (m_BlueMonsterKilled && m_RedMonsterKilled && !m_PlayerWon)
        {
            m_PlayerWon = true;
            m_BlueMonsterKilled = false;
            m_RedMonsterKilled = false;
            WinningScreen();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            UpdateSceneName();
            if (sceneString == ("BlueMonsterScene"))
            {
                SceneManager.LoadScene(1);
            }
            else if (sceneString == ("RedMonsterScene"))
            {
                SceneManager.LoadScene(1);
            }
            else if (sceneString == ("MainGame"))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    public void WinningScreen()
    {
        SceneManager.LoadScene(4);
        m_PlayerWon = false;
    }
    public void UpdateSceneName()
    {
        m_CurrentScene = SceneManager.GetActiveScene();
        sceneString = m_CurrentScene.name;
    }
}
