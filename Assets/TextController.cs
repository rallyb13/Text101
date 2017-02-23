using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;

	// Use this for initialization
	void Start () {
		text.text = "Hello World";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			text.text = "Great Scott! You have just awoken in an attic, and you don't rememember how you got here. " +
						"You try calling for help, but no one answers. You try the door: locked! " +
						"What are you going to do? You see three boxes: Red, Yellow, and Green.\n\n" +
						"Choose which one to open by typing R, Y, or G.";
		}
	}
}
