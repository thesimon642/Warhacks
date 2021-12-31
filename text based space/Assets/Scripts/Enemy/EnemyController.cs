using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    //controls movement and damage
    [SerializeField]
    private GameObject topParent;
    private int stunnedTimer;
    private readonly int maxStun = 20;
    [SerializeField]
    private Rigidbody2D myBody;
    public int currentHP;
    private float damagePercentage;
    private AudioSource explodeSound;
    [SerializeField]
    private AudioSource mySound;
    [SerializeField]
    private Sprite damage_0;
    [SerializeField]
    private Sprite damage_1;
    [SerializeField]
    private Sprite damage_2;
    [SerializeField]
    private SpriteRenderer shipSprite;

    private Camera camera1;
    [SerializeField]
    private BoxCollider2D hitBox;
    private Vector2 mousePos;


    //differentiators between ships
    [SerializeField]
    public int maxHP = 1000;
    [SerializeField]
    private bool healFromFire;
    [SerializeField]
    private float speed = 30f;
    [SerializeField]
    private bool immuneToCharge;

    private bool mouseUpLastFrame;
    //all particles and sounds
    [SerializeField]
    private AudioClip[] zapFireHealSound;
    [SerializeField]
    private ParticleSystem[] zapFireHealParticle;
    [SerializeField]
    private float[] zapFireHealVolume;

    // Declare and initialize a new List of GameObjects called currentCollisions.
    List<EnemyController> currentCollisions = new List<EnemyController>();

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("EnemyHitbox"))
        { currentCollisions.Add(col.gameObject.GetComponent<EnemyController>()); }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        // Remove the GameObject collided with from the list.
        currentCollisions.Remove(col.gameObject.GetComponent<EnemyController>());
    }

    //disables charge only on update so all enemies are hit in pierce
    //private static bool disableCharge;
    //private void LateUpdate()
    //{
    //    if (disableCharge)
    //    { InputController.plusInCurrentWord = 0; }
    //}


    private void OnMouseDown()
    {
        //if (!InputController.pierceInCurrentWord)
        // { 
       //
       // (currentCollisions.Count);
            ApplyHaxAndDamage();
       // }
    }


    private void FixedUpdate()
    {
        //makes ships move choppy and allows stuns to slow them
        if (stunnedTimer <= 0)
        {
            myBody.velocity = Vector2.left * speed;
            stunnedTimer = Random.Range(1, maxStun);
        }
        else
        {
            stunnedTimer -= 1;
            //myBody.velocity = Vector2.left * speed;
        }
        //in pierce mode this detects all enemies in a line
        //make sure above hitbox
        mousePos = camera1.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePos3D = new Vector3(mousePos.x,mousePos.y,hitBox.bounds.center.z);
        //hitBoxtop       = hitBox.offset.y + (hitBox.size.y / 2f);
        //hitBoxbottom    = hitBox.offset.y - (hitBox.size.y / 2f);
        //hitBoxleft      = hitBox.offset.x - (hitBox.size.x / 2f);
        //hitBoxright     = hitBox.offset.x + (hitBox.size.x / 2f);
        //
        //
        //
        //.Log(Input.GetMouseButtonDown(0));
        //Debug.Log(InputController.pierceInCurrentWord);
        //if (Input.GetMouseButton(0))
        //{
        //    Debug.Log("start");
        //    Debug.Log(mousePos);
        //    Debug.Log(hitBox.bounds);
        //    Debug.Log(hitBox.bounds.Contains(mousePos));
            
        //}
        if (InputController.rapidInCurrentWord && hitBox.bounds.Contains(mousePos3D)&& Input.GetMouseButton(0)&&mouseUpLastFrame)
        {
            ApplyHaxAndDamage();
        }
        //turning this off lets you hold down fire, it may be more fun
        if (!InputController.rapidInCurrentWord)
        { mouseUpLastFrame = !Input.GetMouseButton(0); }
        else
        { mouseUpLastFrame = true; }
    }
    private void Awake()
    {
        currentHP = maxHP;
        explodeSound = PrefabHolder.explodeSound;
        camera1 = Camera.main;
        WaveCounter.spawnedEnemies += 1;
        //disableCharge = false;
        currentCollisions = new List<EnemyController>();
    }

    public void DamageShip(int damage, int stun, int damageType)
    {
        //reset stun frames on click and take damage
        stunnedTimer = Mathf.Max(stunnedTimer,stun);
        currentHP = Mathf.Max(currentHP - damage, 0);
        //halts it (stuns)
        myBody.velocity = Vector2.zero;
        DisplayDamageType(damageType);
        //controls the sprite when damaged
        damagePercentage = (float)currentHP / (float)maxHP;
        if (damagePercentage > 0.5f)
        { shipSprite.sprite = damage_0; }
        else if (damagePercentage > 0.2f)
        { shipSprite.sprite = damage_1; }
        else if (damagePercentage > 0f)
        { shipSprite.sprite = damage_2; }
        else
        {
            WaveCounter.defeatedEnemies += 1;
            DestroyShip();
        }
    }

    private void DisplayDamageType(int damageType)
    {
        //Debug.Log(damageType);
        mySound.volume = zapFireHealVolume[damageType];
        mySound.clip = zapFireHealSound[damageType];
        zapFireHealParticle[damageType].Play();
        if (OverridingSettings.sfxUnmuted)
        {
            mySound.Play();
        }

    }

    private void DestroyShip()
    {
        if (OverridingSettings.sfxUnmuted)
        { explodeSound.Play(); }

        Destroy(topParent);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Forcefield"))
        {
            ForcefieldController.currentHP--;
            if (ForcefieldController.currentHP >= 0)
            { WaveCounter.defeatedEnemies += 1; }

            DestroyShip();
        }
    }

    private void ApplyHaxAndDamage()
    {
        //don't fire while the console is down
        if (PrefabHolder.mainConsole.posisiondown)
        { return; }
        int eDamage;
        int eStun;
        int damageType;
        //set effective damage
        //if heals from fire, fully heal and don't even stun
        if (healFromFire && InputController.fireInCurrentWord)
        {
            eDamage = 0;
            eStun = 0;
            damageType = 2;
            currentHP = maxHP;
        }
        else
        {
            //if not charged always do low damage;
            if (InputController.plusInCurrentWord == 0)
            { eDamage = playerStats.playerDamage; }
            //if charged and not immune always do high damage;
            else if (!immuneToCharge)
            { eDamage = playerStats.playerDamageCharge * InputController.plusInCurrentWord; }
            //if charged and immune then do full damage if fire used but 0 if not
            else if (InputController.fireInCurrentWord)
            { eDamage = playerStats.playerDamageCharge * InputController.plusInCurrentWord; }
            else
            { eDamage = 0; }

            if (InputController.fireInCurrentWord)
            { damageType = 1; }
            else
            { damageType = 0; }

            //set effective stun time
            if (InputController.stunInCurrentWord)
            { eStun = playerStats.stunTimeBoosted; }
            else
            { eStun = playerStats.stunTime; }
        }
        //disableCharge = false;
        //if not in new mode reset the words
        if (!OverridingSettings.newMode)
        { InputController.ResetWords(); }
        else
        {
            //disableCharge = true; 
            InputController.plusInCurrentWord = 0;
        }
        //Debug.Log(InputController.plusInCurrentWord);
        if (InputController.pierceInCurrentWord)
        {
            foreach (EnemyController enemy in currentCollisions)
            {
                if (enemy != null)
                { enemy.DamageShip(eDamage, eStun, damageType); }
            }
        }
        DamageShip(eDamage, eStun,damageType);
    }

    

}
