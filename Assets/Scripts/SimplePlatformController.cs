using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SimplePlatformController : MonoBehaviour
{
    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = false;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 500f;
    public Transform groundCheck;
    public Text scoreText;
    public int score = 0;
    public AudioSource[] sounds;

    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;
	private bool blanketActive = false;
	private GameObject blanket;
	private Slider fearMeter;
	private float fearValue;
	private GameObject heart1;
	private GameObject heart2;
	private GameObject heart3;
	private GameObject winText;
	private int hearts;
	private bool blind;

	void Awake ()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
		blanket = GameObject.Find ("blanket");
		blanket.SetActive (false);
		fearMeter = Slider.FindObjectOfType<Slider> ();
		fearValue = 0.5f;
		heart1 = GameObject.Find ("heart1");
		heart2 = GameObject.Find ("heart2");
		heart3 = GameObject.Find ("heart3");
		winText = GameObject.Find ("winText");
		winText.SetActive (false);
		hearts = 3;
		blind = false;
    }
	
	void Update ()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump")) // && grounded)
        {
            jump = true;
        }

		if (Input.GetButtonDown ("Fire1")) 
		{
			if (blanketActive && !blind)
			{
				blanket.SetActive(false);
				blanketActive = false;
			}
			else
			{
				blanket.SetActive(true);
				blanketActive = true;
			}
		}


	}

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
            //AudioSource audio = GetComponent<AudioSource>();
            //audio.Play();
            sounds[0].Play();
        }

		if (blanketActive) {
			if (fearValue <= 1f)
				fearValue += .002f;
		} else
			if (fearValue >= 0f)
				fearValue -= .002f;

		if (fearValue <= .01f) {
			loseHeart();
			if (hearts > 0)
				fearValue = .25f;
		}

		if (fearValue >= .99f)
			blind = true;

		fearMeter.value = fearValue;
			
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void UpdateScore()
    {
        ++score;
        sounds[1].Play();
        scoreText.text = "Stuffies: " + score;  
		if (score == 10)
			winText.SetActive (true);
    }

	public void loseHeart()
	{
		if (hearts == 3) {
			heart3.SetActive (false);
			--hearts;
		} else if (hearts == 2) {
			heart2.SetActive (false);
			--hearts;
		} else {
			heart1.SetActive (false);
			--hearts;
		}
	}
}
