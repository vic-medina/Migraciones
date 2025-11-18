using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtController : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Animator anim;
    [SerializeField] private ObjectsMovement objMov;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private List<GameObject> heartIcons;
    [SerializeField] private List<ParallaxBG> pBg;

    [Header("Vida")]
    [SerializeField] private int maxhealt = 3;
    public int currenthealt = 3;
    public bool gameOver = false;
    
   
    [Header("Enemigos y Objetos")]
    [SerializeField] private float cooldownTime;
    [SerializeField] private float knockbackTime;
    [SerializeField] private bool canTakeDamage;

    private List<Vector2> speedBufferList = new List<Vector2>();
    private float collisionPos;
    private Vector3 knockbackTarget;

    private void Awake()
    {
        //canTakeDamage = true;
    }

    private void Update()
    {
        if (currenthealt > maxhealt)
        {
            currenthealt = maxhealt;
        }
        if (currenthealt <= 0)
        {
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTakeDamage && (collision.CompareTag("Owl") || collision.CompareTag("Object") || collision.CompareTag("Snake")))
        {
            collisionPos = collision.transform.position.y;
            TakeDamage(1);
        }
        else if (collision.CompareTag("Food"))
        {
            AddHealt(1);
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currenthealt -= damage;
        anim.SetBool("damage",true);

        /*if ((collisionPos > transform.position.y) && (transform.position.y >= 5f)) //Hacia abajo
        {
            knockbackTarget = transform.position + new Vector3(-1f, -2.5f, 0);
        }
        else if ((collisionPos > transform.position.y) && (transform.position.y <= 5f)) //Hacia arriba
        {
            knockbackTarget = transform.position + new Vector3(-1f, 2.5f, 0);
        }
        else if ((collisionPos < transform.position.y) && (transform.position.y >= 5f)) //Hacia abajo
        {
            knockbackTarget = transform.position + new Vector3(-1f, -2.5f, 0);
        }
        else if ((collisionPos < transform.position.y) && (transform.position.y <= 5f)) //Hacia arriba
        {
            knockbackTarget = transform.position + new Vector3(-1f, 2.5f, 0);
        }*/
        
        if (collisionPos > transform.position.y ) //Hacia abajo
        {
            knockbackTarget = transform.position + new Vector3(-1f, -2f, 0);
        }
        else //Hacia arriba
        {
            knockbackTarget = transform.position + new Vector3(-1f, 2f, 0);
        }

        transform.DOMove(knockbackTarget, 0.3f).SetEase(Ease.OutQuad);

        FreezeWorld();
        rb.constraints |= RigidbodyConstraints2D.FreezePositionY;

        Debug.Log("Player took damage");
        UpdateHealt();
        StartCoroutine(DamageCooldown(knockbackTime, cooldownTime));
    }

    private IEnumerator DamageCooldown(float knockBack, float cooldown)
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(knockBack);

        transform.DOMoveX(0f, 0.3f).SetEase(Ease.OutQuad);
        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;

        objMov.speed = 4f;
        for (int i = 0; i < pBg.Count; i++)
        {
            if (i < speedBufferList.Count)
            {
                pBg[i].movementSpeed = speedBufferList[i];
            }
        }

        yield return new WaitForSeconds(cooldown);
        anim.SetBool("damage", false);
        canTakeDamage = true;
    }

    private void UpdateHealt()
    {
        for (int i = 0; i < heartIcons.Count; i++)
        {
            if (i < currenthealt)
            {
                heartIcons[i].SetActive(true);
                heartIcons[i].transform.DOScale(Vector3.one, 0.2f);
            }
            else
            {
                int index = i;
                heartIcons[index].transform.DOScale(Vector3.zero, 0.2f).OnComplete(() =>
                {
                    heartIcons[index].SetActive(false);
                });
            }
        }
    }

    public void AddHealt(int amount)
    {
        currenthealt += amount;

        if (currenthealt > maxhealt)
            currenthealt = maxhealt;

        UpdateHealt();
    }

    private void FreezeWorld()
    {
        objMov.speed = 0f;

        speedBufferList.Clear();
        foreach (ParallaxBG bg in pBg)
        {
            speedBufferList.Add(bg.movementSpeed);
            bg.movementSpeed = Vector2.zero;
        }
    }

    private void GameOver()
    {
        gameOverCanvas.SetActive(true);
        gameOver = true;
        Time.timeScale = 0f;
    }
}
