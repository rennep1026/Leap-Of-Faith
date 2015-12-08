using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SimplePlatformController : MonoBehaviour
{
    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = false;
    private int level_no = 1;



    // HERBERT -----------------------
    public GameObject herbert;
    public Rigidbody2D rb2d;
    public Vector3 initialPosition;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpVal = 0.01f;
    private int availableJumps;

    // blanket
    public bool blanketActive = false;
    private GameObject blanket;
    private bool blind;
    private GameObject blindText;

    // UI ----------------------------
    public Text scoreText;
    public int score = 0;
    private GameObject winText;

    // lives, hearts 
    public int hearts;
    private GameObject heart1;
    private GameObject heart2;
    private GameObject heart3;
    private GameObject loseMenu;

    // fear meter
    private Slider fearMeter;
    private float fearValue;
    private GameObject fearText;
    private GameObject paranoiaText;
    private float fearDecrease;
    private float fearIncrease;



    // AUDIO ------------------------
    public AudioSource[] sounds;


    //private Animator anim;


	void Awake ()
    {
        herbert = GameObject.Find("hero");
        availableJumps = 1;

		initialPosition = transform.position;
        //anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
		blanket = GameObject.Find ("blanket");
		blanket.SetActive (false);
		fearMeter = Slider.FindObjectOfType<Slider> ();
		fearValue = 0.5f;
        fearText = GameObject.Find ("fearText");
        paranoiaText = GameObject.Find ("paranoiaText");
		heart1 = GameObject.Find ("heart1");
		heart2 = GameObject.Find ("heart2");
		heart3 = GameObject.Find ("heart3");
		winText = GameObject.Find ("winText");
		loseMenu = GameObject.Find ("loseMenu");
		winText.SetActive (false);
		loseMenu.SetActive(false);
		hearts = 3;
		blind = false;
		blindText = GameObject.Find ("blindText");
		blindText.SetActive(false);
        fearIncrease = 0.002f;
        fearDecrease = 0.001f;
    }
	
	void Update ()
    {
        if (Input.GetButtonDown("Jump"))
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

		if (blind)
			blindText.SetActive(true);


	}

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (availableJumps>0 && jump) // was if(jump)
        {
            //anim.SetTrigger("Jump");
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpVal);
            //AudioSource audio = GetComponent<AudioSource>();
            //audio.Play();
            sounds[0].Play();
            //grounded = false;
            availableJumps--;
        }
        jump = false;


        if (blanketActive)
        {
            if (fearValue <= 1f)
                //fearValue += .002f;
                fearValue += fearIncrease;
        }
        else
            if (fearValue >= 0f)
            //fearValue -= .002f;
            fearValue -= fearDecrease;

		if (fearValue <= .01f) {
			loseHeart();
		}

		if (fearValue >= .99f)
			blind = true;

		fearMeter.value = fearValue;
			
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            //grounded = true;
            availableJumps = 1;
        }
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
        {
            //winText.SetActive (true);
            Application.LoadLevel(++level_no);
        }
    }

	public void loseHeart()
	{
		if (hearts == 3) {
			heart3.SetActive (false);
			--hearts;
		} else if (hearts == 2) {
			heart2.SetActive (false);
			--hearts;
		} else if (hearts == 1){
			heart1.SetActive (false);
			--hearts;
		} else {
			blindText.SetActive(false);
			loseMenu.SetActive(true);
            fearMeter.gameObject.SetActive(false);
            fearText.gameObject.SetActive(false);
            paranoiaText.gameObject.SetActive(false);
            scoreText.gameObject.SetActive(false);
            // DISABLE HERBERT'S MOVEMENTS ON DEATH.
            availableJumps = 0;
		}
		fearValue = 0.5f;
	}
}
