using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharController : MonoBehaviour {

    public float GameTime;
    private float startTime;

    public int jumpForce;
    public int moveForce;

	public GameObject character;
    private Rigidbody2D char_rigidBody;

	private Animator animator;

    public GameObject LeftArrow;
    public GameObject RightArrow;
    public GameObject Jump;
	private BoxCollider2D LeftArrowArea;
	private BoxCollider2D RightArrowArea;
	private BoxCollider2D JumpArea;

    private bool isRight;
	public static bool isJumping;
	public static float lastGroundedTime;

    public AudioClip jumpSound;
    private AudioSource source;
    public AudioClip WalkSound;
    
    void Awake()
    {
		animator = character.GetComponent<Animator> ();
        source = GetComponent<AudioSource>();
    }

	void Start()
	{
        startTime = Time.time;
		lastGroundedTime = startTime;
		isRight = true;
		isJumping = false;
        char_rigidBody = character.GetComponent<Rigidbody2D>();
		LeftArrowArea = LeftArrow.GetComponent<BoxCollider2D>();
        RightArrowArea = RightArrow.GetComponent<BoxCollider2D>();
		JumpArea = Jump.GetComponent<BoxCollider2D>();
	}

	void Update()
	{
		animator.SetFloat ("Speed", Mathf.Abs(char_rigidBody.velocity.x));
	}

	void FixedUpdate () {

        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                Vector3 wp = Camera.main.ScreenToWorldPoint(touch.position);
                Vector2 touchPos = new Vector2(wp.x, wp.y);

                if (LeftArrowArea == Physics2D.OverlapPoint(touchPos))
                {
                    if(!source.isPlaying && !isJumping && GameConstants.isSoundEnabled)
                        source.PlayOneShot(WalkSound);
                    if (isRight)
                        flip();
                    char_rigidBody.velocity = new Vector2(-1 * moveForce, char_rigidBody.velocity.y);
                }

                if (RightArrowArea == Physics2D.OverlapPoint(touchPos))
                {
                    if(!source.isPlaying && !isJumping && GameConstants.isSoundEnabled)
                        source.PlayOneShot(WalkSound);
                    if (!isRight)
                        flip();
                    char_rigidBody.velocity = new Vector2(1 * moveForce, char_rigidBody.velocity.y);
                }

				if (JumpArea == Physics2D.OverlapPoint(touchPos) && isJumping == false)
                {
					if (GameConstants.isSoundEnabled) {
						source.Stop ();
						source.PlayOneShot (jumpSound, 0.3f);
					}
                    char_rigidBody.AddForce(new Vector2(0, jumpForce));
                    isJumping = true;
                }
            }
        }
	}

	void flip()
	{
		isRight = !isRight;
		Vector3 scale = char_rigidBody.transform.localScale;
		scale.x *= -1;
        char_rigidBody.transform.localScale = scale;
	}
}
