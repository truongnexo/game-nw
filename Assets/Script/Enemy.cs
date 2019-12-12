using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public PlayerMove playerCheck;
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    public Transform player; // lay vi tri cua player
    [SerializeField]
    public Transform Sword_Arc;// lay vitri phat chem cua player
    [SerializeField]
    protected bool colliderPlayer;


    [SerializeField]
    protected Transform pointA, pointB;
    // cac bien phuc vu kiem tra khoang cach giua nguoi choi va enemy
    [SerializeField]
    protected float distance; // khoang cach giua player va enemy
    [SerializeField]
    public float distanceMIN;// khoang cach enemy thuc day
    public virtual void Attack()
    {
        Debug.Log("BaseAttack Called");
    }
    public void Start()
    {
        playerCheck = GetComponent<PlayerMove>();
    }

    public abstract void FixedUpdate();
}
