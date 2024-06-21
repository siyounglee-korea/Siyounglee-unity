using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private GameObject player;

    private bool m_bIsHold = false;
    private bool m_bIsDead = false;
    private bool m_bIsOnFood = false;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        CollisionFloor();

        if (m_bIsOnFood)
            m_bIsDead = true;

        if (m_bIsHold)
            SetTransform(player.transform);
    }

    private void CollisionFloor()
    {
        Vector3 vTempPos = this.transform.position;
        if (vTempPos.y < 0f)
        {
            vTempPos.y = 0f;
            this.transform.position = vTempPos;
        }
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && m_bIsHold)
        {
            m_bIsHold = false;
        }

        if (m_bIsDead)
            Destroy(this.gameObject);
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !m_bIsDead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!m_bIsHold)
                    m_bIsHold = true;
                else
                {
                    m_bIsHold = false;
                    m_bIsOnFood = false;
                }
            }
        }
        else if (other.gameObject.CompareTag("Food")) 
        {
            if(!m_bIsDead) 
                m_bIsDead = true;
        }
    }

    void SetTransform(Transform pTrans)
    {
        transform.rotation = pTrans.transform.rotation;
        transform.position = pTrans.position;
    }
}
