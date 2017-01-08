using UnityEngine;
using System.Collections;

public class groundedScript : MonoBehaviour {

	private int collisions = 0;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            CharController.isJumping = false;
			collisions++;
        }
    }

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Platform")
		{
			collisions--;
		}
	}

	void Update()
	{
		if (collisions == 0) {
			CharController.isJumping = true;
		}
	}
}
