using UnityEngine;
using UnityEngine.Events;

public enum BallType { First , Second, Third, Fourth, Fifth, Sixth, Seventh, Eighth, Ninth, Tenth };

public class Ball : MonoBehaviour
{
    [SerializeField] public BallData ballData;
    [SerializeField] public bool isShoot;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] public float speed;
        
    [SerializeField] Gravity gravity;

    public event UnityAction<Ball, Transform, GameObject> OnCreate;

    private void Awake()
    {
        isShoot = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = ballData.sprite;
    }
    private void OnEnable()
    {
        OnCreate += BallCreator.Instance.CreateBall;

        speed = ballData.prefab.speed;
        isShoot = ballData.prefab.isShoot; 

        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        rb.drag = 0f;

        if (isShoot) 
        {
            rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        }
    }
    private void OnDisable()
    {
        OnCreate -= BallCreator.Instance.CreateBall;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gravity == null)
        {
            gravity = collision.gameObject.GetComponent<Gravity>();
        }
        gravity.GetGravity(rb);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gravity = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.localScale == transform.localScale)
        {
            OnCreate?.Invoke(this, transform, ballData.nextBall);
            BallPool.Instance.ReturnPool(gameObject, ballData.ballType);
        }
    }

}
