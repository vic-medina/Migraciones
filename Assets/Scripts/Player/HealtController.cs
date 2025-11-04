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
    [SerializeField] public int currenthealt = 3;
   
    [Header("Enemigos y Objetos")]
    [SerializeField] private float cooldownTime;
    [SerializeField] private bool canTakeDamage;

    private List<Vector2> speedBufferList = new List<Vector2>();
    private float collisionPos;
    private Vector3 knockbackTarget;

    private void Start()
    {
        canTakeDamage = true;
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
        if (canTakeDamage && (collision.CompareTag("Object") || collision.CompareTag("Owl") || collision.CompareTag("Snake")) )
        {
            collisionPos = collision.transform.position.y;
            TakeDamage(cooldownTime);
            UpdateHealt();
        }
        else if (collision.CompareTag("Food"))
        {
            AddHealt(1);
            Destroy(collision.gameObject);
        }
    }

    private void TakeDamage(float cooldown)
    {
        currenthealt -= 1;
        anim.SetTrigger("damage");

        if (collisionPos > transform.position.y)
        {
            knockbackTarget = transform.position + new Vector3(-1f, -1.5f, 0);
        }
        else
        {
            knockbackTarget = transform.position + new Vector3(-1f, 1.5f, 0);
        }

        transform.DOMove(knockbackTarget, 0.3f).SetEase(Ease.OutQuad);

        FreezeWorld();
        rb.constraints |= RigidbodyConstraints2D.FreezePositionY;

        Debug.Log("Player took damage");
        StartCoroutine(DamageCooldown(cooldown));
    }

    private IEnumerator DamageCooldown(float cooldown)
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(cooldown);

        objMov.speed = 4f;
        for (int i = 0; i < pBg.Count; i++)
        {
            if (i < speedBufferList.Count)
            {
                pBg[i].movementSpeed = speedBufferList[i];
            }
        }

        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;

        transform.DOMoveX(0f, 0.3f).SetEase(Ease.OutQuad);
        canTakeDamage = true;
    }

    private void UpdateHealt()
    {
        for (int i = 0; i < heartIcons.Count; i++)
        {
            heartIcons[i].SetActive(i < currenthealt); // Solo activa los corazones que aún tiene
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
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
    }
}
