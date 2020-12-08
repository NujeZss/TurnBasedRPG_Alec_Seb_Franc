using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody m_PlayerRigid;
    [SerializeField] private float m_MovementSpeed;
    private bool m_PlayerMovingU = false;
    private bool m_PlayerMovingR = false;
    private bool m_PlayerMovingL = false;
    private bool m_PlayerMovingD = false;

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_PlayerMovingU = true;
            m_PlayerRigid.AddForce(0, m_MovementSpeed * Time.deltaTime * 1000, 0);
            m_PlayerMovingU = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_PlayerMovingD = true;
            m_PlayerRigid.AddForce(0, -m_MovementSpeed * Time.deltaTime * 1000, 0);
            m_PlayerMovingD = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_PlayerMovingL = true;
            m_PlayerRigid.AddForce(-m_MovementSpeed * Time.deltaTime * 1000, 0, 0);
            m_PlayerMovingL = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            m_PlayerMovingR = true;
            m_PlayerRigid.AddForce(m_MovementSpeed * Time.deltaTime * 1000, 0, 0);
            m_PlayerMovingR = false;
        }
        if(!m_PlayerMovingD && !m_PlayerMovingL && !m_PlayerMovingR && !m_PlayerMovingU)
        {
            m_PlayerRigid.velocity = new Vector3(0, 0, 0);
        }
    }
}
