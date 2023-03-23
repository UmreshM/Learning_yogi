using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : WrapPlayableArea
{
    public event Action OnPlayerDied;

    [SerializeField]
    private GameObject shipExplosionGO;
    [SerializeField]
    private GameObject playerContainerGO;
    public Bullet currentActiveWeapon;
    Animator explosionAnimator;
    Coroutine explosionCoroutine;

    // delegate void ChangeWeapon();

    public override void Start()
    {
        base.Start();
        explosionAnimator = shipExplosionGO.GetComponent<Animator>();
    }


    public event Action EventDied;

    private PlayerController controller;
    // private CollisionWithAsteroid collisionWithAsteroid;
    // private PlayerDeath playerDeath;
    // private PlayerShield shield;

    void Awake()
    {
        controller = GetComponent<PlayerController>();
        AsteroidManager.OnAstriodHitPlayer += OnCollisionWithAsteroid;

        // collisionWithAsteroid = GetComponent<CollisionWithAsteroid>();
        // collisionWithAsteroid.EventCollision += OnCollisionWithAsteroid;

        // playerDeath = GetComponent<PlayerDeath>();
        // playerDeath.EventDieComplete += OnDeathComplete;

        // shield = GetComponent<PlayerShield>();
    }

    public void Spawn()
    {
        gameObject.transform.position = Vector3.zero;
        playerContainerGO.SetActive(true);
        shipExplosionGO.SetActive(false);
        // shield.Show();
    }

    private void OnCollisionWithAsteroid()
    {
        // if (!shield.IsInvincible)
        {
            controller.Reset();
            shipExplosionGO.SetActive(true);
            playerContainerGO.SetActive(false);
            StartCoroutine(WaitForPlayerRespawn());
			AudioManager.Instance.PlaySFX(GameManager.Instance.audioFilesSO.playerExplode);
        }
    }
    
    IEnumerator WaitForPlayerRespawn()
    {
        AnimatorStateInfo animState = explosionAnimator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(animState.length);
        OnPlayerDied?.Invoke();
    }
}
