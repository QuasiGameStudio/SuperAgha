using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    private Player player;

	private Animator animator;

	private int directional;

    private void Start()
    {
        player = GetComponent<Player>();
		animator = transform.GetChild (0).GetComponent<Animator> ();
    }

    private void Update()
    {

//        Vector2 ddirectionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
//        player.SetDirectionalInput(directionalInput);
//		if (Input.GetAxisRaw ("Horizontal") != 0)
//			animator.SetBool ("Run",true);
//		else
//			animator.SetBool ("Run",false);
//			
//		Player.Instance.FlipCharacter (Input.GetAxisRaw("Horizontal"));

		Moving ();

        if (Input.GetButtonDown("Jump"))
        {
            player.OnJumpInputDown();
			animator.SetTrigger ("Jump");
        }

        if (Input.GetButtonUp("Jump"))
        {
            player.OnJumpInputUp();
        }


    }

	//Mobile

	void Moving(){
		Vector2 directionalInput = new Vector2(directional, 0);
		player.SetDirectionalInput(directionalInput);
		if (directional != 0)
			animator.SetBool ("Run",true);
		else
			animator.SetBool ("Run",false);

		Player.Instance.FlipCharacter (directional);
	}

	public void MoveTo(int newDirectional){
		directional = newDirectional;

	}

	public void StopMove(){
		directional = 0;
	}


	public void JumpInputUp(){
		
		player.OnJumpInputUp();
	}


	public void JumpInputDown(){
		
		player.OnJumpInputDown();
		animator.SetTrigger ("Jump");
	}

}
