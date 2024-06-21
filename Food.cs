using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Food : MonoBehaviour
{
    public ChopFood chopFood;
    public ChopFood chopFoodClone;

    private GameObject player;

    private bool m_bIsHold = false;
    private bool m_bIsDead = false;

    public void SetIsHold(bool bIsHold) { m_bIsHold = bIsHold; }
    public bool GetIsHold() { return m_bIsHold; }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        CollisionFloor();

        if (m_bIsHold)
            SetTransform(player.transform);
    }

    private void CollisionFloor()
    {

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
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!m_bIsHold)
                    m_bIsHold = true;
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Knife") && !m_bIsDead)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl)) 
            {
                player.GetComponent<Player>().SetPlayerIsMove(false);
                chopFoodClone = Instantiate(chopFood, this.transform.position, Quaternion.identity);
                m_bIsDead = true;
            }
        }
    }

    void SetTransform(Transform pTrans)
    {
        this.transform.rotation = pTrans.rotation;
        this.transform.position = pTrans.position + pTrans.forward * THROUGHTIME;
    }
}
