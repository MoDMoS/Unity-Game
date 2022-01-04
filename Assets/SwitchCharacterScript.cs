using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacterScript : MonoBehaviour {

	// referenses to controlled game objects
	public GameObject avatar1, avatar2,avatar3,avatar4,avatar5;

	// variable contains which avatar is on and active
	int whichAvatarIsOn = 1;

	// Use this for initialization
	void Start () {

		// anable first avatar and disable another one
		avatar1.gameObject.SetActive (true);
		avatar2.gameObject.SetActive (false);
		avatar3.gameObject.SetActive (false);
		avatar4.gameObject.SetActive (false);
		avatar5.gameObject.SetActive (false);
	}

	// public method to switch avatars by pressing UI button
	public void SwitchAvatar()
	{

		// processing whichAvatarIsOn variable
		switch (whichAvatarIsOn) {

		// if the first avatar is on
		case 1:

			// then the second avatar is on now
			whichAvatarIsOn = 2;

			// disable the first one and anable the second one
			avatar1.gameObject.SetActive (false);
			avatar2.gameObject.SetActive (true);
			break;

		// if the second avatar is on
		case 2:

			// then the first avatar is on now
			whichAvatarIsOn = 3;

			// disable the second one and anable the first one
			avatar2.gameObject.SetActive (false);
			avatar3.gameObject.SetActive (true);
			break;

		case 3:

			// then the first avatar is on now
			whichAvatarIsOn = 4;

			// disable the second one and anable the first one
			avatar3.gameObject.SetActive (false);
			avatar4.gameObject.SetActive (true);
			break;

		case 4:

			// then the first avatar is on now
			whichAvatarIsOn = 5;

			// disable the second one and anable the first one
			avatar4.gameObject.SetActive (false);
			avatar5.gameObject.SetActive (true);
			break;
		
		case 5:

			// then the first avatar is on now
			whichAvatarIsOn = 1;

			// disable the second one and anable the first one
			avatar5.gameObject.SetActive (false);
			avatar1.gameObject.SetActive (true);
			break;
		}
	}
}
