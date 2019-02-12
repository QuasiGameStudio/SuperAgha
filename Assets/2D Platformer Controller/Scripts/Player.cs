using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : Singleton<Player>
{
    public float maxJumpHeight = 4f;
    public float minJumpHeight = 1f;
    public float timeToJumpApex = .4f;
    private float accelerationTimeAirborne = .2f;
    private float accelerationTimeGrounded = .1f;
    private float moveSpeed = 6f;

    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    public bool canDoubleJump;
    private bool isDoubleJumping = false;

    public float wallSlideSpeedMax = 3f;
    public float wallStickTime = .25f;
    private float timeToWallUnstick;

    private float gravity;
    private float maxJumpVelocity;
    private float minJumpVelocity;
    private Vector3 velocity;
    private float velocityXSmoothing;

    private Controller2D controller;

    private Vector2 directionalInput;
    private bool wallSliding;
    private int wallDirX;

	[SerializeField]
	private CameraFollow cameraFollow;

	[SerializeField]
	private GameObject[] bullets;
	private Animator animator;
	private float playerDir;


	void Awake(){
		playerDir = 1;
	}

    private void Start()
    {		

		animator = transform.GetChild (0).GetComponent<Animator> ();
        controller = GetComponent<Controller2D>();
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
    }

    private void Update()
    {
//		Debug.Log (bulletCount);
        CalculateVelocity();
        HandleWallSliding();

        controller.Move(velocity * Time.deltaTime, directionalInput);

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0f;
        }


    }

    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

    public void OnJumpInputDown()
    {
        if (wallSliding)
        {
            if (wallDirX == directionalInput.x)
            {
                velocity.x = -wallDirX * wallJumpClimb.x;
                velocity.y = wallJumpClimb.y;
            }
            else if (directionalInput.x == 0)
            {
                velocity.x = -wallDirX * wallJumpOff.x;
                velocity.y = wallJumpOff.y;
            }
            else
            {
                velocity.x = -wallDirX * wallLeap.x;
                velocity.y = wallLeap.y;
            }
            isDoubleJumping = false;
        }
        if (controller.collisions.below)
        {
            velocity.y = maxJumpVelocity;
            isDoubleJumping = false;
        }
        if (canDoubleJump && !controller.collisions.below && !isDoubleJumping && !wallSliding)
        {
            velocity.y = maxJumpVelocity;
            isDoubleJumping = true;
        }
    }

    public void OnJumpInputUp()
    {
        if (velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;
        }
    }

    private void HandleWallSliding()
    {
        wallDirX = (controller.collisions.left) ? -1 : 1;
        wallSliding = false;
        if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
        {
            wallSliding = true;

            if (velocity.y < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }

            if (timeToWallUnstick > 0f)
            {
                velocityXSmoothing = 0f;
                velocity.x = 0f;
                if (directionalInput.x != wallDirX && directionalInput.x != 0f)
                {
                    timeToWallUnstick -= Time.deltaTime;
                }
                else
                {
                    timeToWallUnstick = wallStickTime;
                }
            }
            else
            {
                timeToWallUnstick = wallStickTime;
            }
        }
    }

    private void CalculateVelocity()
    {
        float targetVelocityX = directionalInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below ? accelerationTimeGrounded : accelerationTimeAirborne));
        velocity.y += gravity * Time.deltaTime;
    }

	public void Attack(){
		Debug.Log ("Attack!");

		int rand = Random.Range (0, bullets.Length);
		GameObject bullet = Instantiate (bullets [rand], transform.GetChild (1).position, transform.GetChild (1).rotation);
		animator.SetTrigger ("Attack_" + rand);
		GameAudio.Instance.ShotClip (12);
	}


		
	public void Dead(){		
		cameraFollow.enabled = false;
		StartCoroutine( GameManager.Instance.GameOver ());
		velocity.y = maxJumpVelocity;
		animator.SetTrigger ("Jump");
		GameAudio.Instance.ShotClip (9);
		GameAudio.Instance.ShotClip (6);
		GetComponent<BoxCollider2D> ().enabled = false;
		GetComponent<Rigidbody2D> ().gravityScale = 1;
	}

	public void Drown(){
		cameraFollow.enabled = false;
		StartCoroutine( GameManager.Instance.GameOver ());
		//velocity.y = maxJumpVelocity;
		//animator.SetTrigger ("Jump");
		GameAudio.Instance.ShotClip (7);
		GetComponent<BoxCollider2D> ().enabled = false;
		GetComponent<Rigidbody2D> ().gravityScale = 1;

		foreach (Transform child in transform) {
			child.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
			child.GetComponent<SpriteRenderer> ().sortingOrder = 1;	
			foreach (Transform child_1 in child) {
				child_1.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
				child_1.GetComponent<SpriteRenderer> ().sortingOrder = 1;	
				foreach (Transform child_2 in child_1) {
					child_2.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
					child_2.GetComponent<SpriteRenderer> ().sortingOrder = 1;	
					foreach (Transform child_3 in child_2) {
						child_3.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
						child_3.GetComponent<SpriteRenderer> ().sortingOrder = 1;	
					}	
				}	
			}	

		}


	}

	public void FlipCharacter(float dir){
		
		if (dir != 0) {			
			transform.localScale = new Vector3 (dir, transform.localScale.y,transform.localScale.z);
			playerDir = dir;
		}

	}

	public float GetPlayerDir(){
		return playerDir;
	}
}
