using UnityEngine;

public class PlayerMouvemnt : MonoBehaviour
{

    [SerializeField] private float speed ;
    private Rigidbody2D body;
    private Animator anim;
    private bool isGrounded;

    private void Awake()
    {

        // Grab references to the components
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);  

        // ki the character yimchi mil imin wla isar yita9lab
        if(horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // ki the character yitla3 l fo9
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
         // animation of running activation 
         anim.SetBool("run", horizontalInput != 0);
         anim.SetBool("grounded", isGrounded);

    }
            private void Jump()
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
            anim.SetTrigger("jump");
            isGrounded = false;
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }
}
