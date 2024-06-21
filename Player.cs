using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigidbody;
    Vector3 movement;
    float h, v;

    private bool m_bIsMove = true;

    public bool GetPlayerIsMove() { return m_bIsMove; }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        h = -Input.GetAxisRaw("Horizontal");
        v = -Input.GetAxisRaw("Vertical");
    }

    void LateUpdate()
    {
    }

    void FixedUpdate()
    {
        if(m_bIsMove)
        {
            PlayerMove();
            PlayerTurn();
        }
    }

    private void PlayerMove()
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        rigidbody.MovePosition(transform.position + movement);
    }

    private void PlayerTurn()
    {
        if (h == 0 && v == 0) return;

        Quaternion newRotation = Quaternion.LookRotation(movement);
        rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, newRotation, PLAYERSPEED * Time.deltaTime);
    }
}
