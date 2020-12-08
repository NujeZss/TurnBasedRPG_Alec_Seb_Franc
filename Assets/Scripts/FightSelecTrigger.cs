using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightSelecTrigger : MonoBehaviour
{
    public GameObject m_CanvasOpen;
    public GameObject m_PlayerMove;

    public GameObject m_KillManager;

    public GameObject m_RedMonsterButton;
    public GameObject m_BlueMonsterButton;
    public GameObject m_RedTileSpawn;
    public GameObject m_BlueTileSpawn;

    public void Awake()
    {
        m_KillManager = GameObject.FindGameObjectWithTag("Manager");
        m_KillManager.GetComponent<KillCountManager>();
    }

    private void Update()
    {
        if(m_KillManager.GetComponent<KillCountManager>().m_RedMonsterKilled == true)
        {
            m_RedTileSpawn.SetActive(false);
        }
        if(m_KillManager.GetComponent<KillCountManager>().m_BlueMonsterKilled == true)
        {
            m_BlueTileSpawn.SetActive(false);
        }

            if(Input.GetKeyDown(KeyCode.Space))
            {
            m_CanvasOpen.SetActive(true);
            m_PlayerMove.SetActive(false);

            if(m_KillManager.GetComponent<KillCountManager>().m_RedMonsterKilled == true)
            {
                m_RedMonsterButton.SetActive(false);
            }

            if(m_KillManager.GetComponent<KillCountManager>().m_BlueMonsterKilled == true)
            {
                m_BlueMonsterButton.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(m_KillManager.GetComponent<KillCountManager>().m_BlueMonsterKilled == false)
        {
            if (this.CompareTag("BlueMonster"))
            {
                SceneManager.LoadScene(3);
            }
        }
        if (m_KillManager.GetComponent<KillCountManager>().m_RedMonsterKilled == false)
        {
            if (this.CompareTag("RedMonster"))
            {
                SceneManager.LoadScene(2);
            }
        }
    }
    public void QuitFightSelector()
    {
        m_CanvasOpen.SetActive(false);
        m_PlayerMove.SetActive(true);
    }

    public void FightRedMonster()
    {
         SceneManager.LoadScene(2);
    }
    public void FightBlueMonster()
    {
         SceneManager.LoadScene(3);    
    }
}
