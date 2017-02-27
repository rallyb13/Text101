using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {attic, yellow, green, wrong, letter, mirrorEarly, brick, yellowEscape, rope, sandwich, mirrorCorrect};
	private States myState;
	public string reset = "Press the Space Bar to restart game, loser.";
	public string yellowChoice = "Choose S, N, or M to use an item. R or G to look at another box.";
	public string wrongChoice;
	
	// Use this for initialization
	void Start () {
		myState = States.attic;
	}
	
	// Update is called once per frame
	void Update () {
//		print (myState);
		if (myState == States.attic) {
			state_attic();
		} else if (myState == States.yellow) {
			state_yellow();
		} else if (myState == States.green) {
			state_green();
		} else if (myState == States.wrong) {
			state_wrong(wrongChoice);
		} else if (myState == States.letter) {
			state_letter();
		} else if (myState == States.mirrorEarly) {
			state_mirrorEarly();
		} else if (myState == States.brick) {
			state_brick();
		}
	}
	
	void state_attic () {
		text.text = "Great Scott! You have just awoken in an attic, and you don't rememember how you got here. " +
				"You try calling for help, but no one answers. You try the door: locked! The windows are bolted shut. " +
				"What are you going to do? You see three boxes: Red, Yellow, and Green.\n\n" +
				"Choose which one to open by typing R, Y, or G.";

		if (Input.GetKeyDown(KeyCode.R)) {
			wrongChoice = "red";
			myState = States.wrong;
		} else if (Input.GetKeyDown(KeyCode.Y)) {
			myState = States.yellow;
		} else if (Input.GetKeyDown(KeyCode.G)) {
			myState = States.green;
		}
	}
	
	void state_yellow () {
		text.text = "The Yellow Box has a Sandwich (smells like roast beef and almonds), " +
					"a Nylon rope, and a Mirror.\n\n" + yellowChoice;
		
		if (Input.GetKeyDown(KeyCode.S)) {
			wrongChoice = "sandwich";
			myState = States.wrong;
		} else if (Input.GetKeyDown(KeyCode.N)) {
			wrongChoice = "rope";
			myState = States.wrong;
		} else if (Input.GetKeyDown(KeyCode.M)) {
			myState = States.mirrorEarly;
		} else if (Input.GetKeyDown(KeyCode.R)) {
			wrongChoice = "red";
			myState = States.wrong;
		} else if (Input.GetKeyDown(KeyCode.G)) {
			myState = States.green;
		}
	}
	
	void state_green () {
		text.text = "The Green Box has a Brick, a Letter, and a bottle of Wine (white and expensive).\n\n" +
					"Choose B, L, or W to use an item. R or Y to look at another box.";
	
		if (Input.GetKeyDown(KeyCode.B)) {
			myState = States.brick;
		} else if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.letter;
		} else if (Input.GetKeyDown(KeyCode.W)) {
			wrongChoice = "wine";
			myState = States.wrong;
		} else if (Input.GetKeyDown(KeyCode.R)) {
			wrongChoice = "red";
			myState = States.wrong;
		} else if (Input.GetKeyDown(KeyCode.Y)) {
			myState = States.yellow;
		}
	}
	
	void state_wrong (string choice) {
		if (choice == "red") {
			text.text = "The Red Box is filled with cobras. You get bitten a lot and die horribly.\n\n" + reset;
		} else if (choice == "sandwich") {
			text.text = "You fool! That almond smell was cyanide! And the dry roast beef needed mustard, " +
						"making it a pitiful last meal. You die by poison, unsatisfied.\n\n" + reset;
		} else if (choice == "rope") {
			text.text = "You assume the situation is hopeless and hang yourself. Geez.\n\n" + reset;
		} else if (choice == "wine") {
			text.text = "You drink the whole bottle and start singing, really obnoxiously. " +
						"The people who kidnapped you decide you're not worth suffering through. " +
						"They kill you a whole lot so that you are dead for good.\n\n" + reset;
		} else if (choice == "letter") {
			text.text = "You get caught by the kidnappers while you are reading the letter. " +
						"Complaining about the writer's spelling does you no good. They push you out " +
						"the window and your head cracks open like Humpty Dumpty. You are a mess.\n\n" + reset;
		}
		
		if (Input.GetKeyDown(KeyCode.Space)) {
			myState = States.attic;
		}
	}
	
	void state_letter() {
		text.text = "The letter describes (for pages) cleaning this very attic, where the former tenants " +
				"let cobras (offered as a metaphor for the futility of love) move in. The writer resolves " +
				"to set off into the forest and probably be eaten by a demon wolf. As if the poor spelling hadn't been " +
				"depressing enough.\n\nPress Space Bar to put the letter back in the box.";
		if (Input.GetKeyDown(KeyCode.Space)) {
			myState = States.green;
		}	
	}
	
	void state_mirrorEarly() {
		text.text = "Damn, for a kidnap victim, you still look FINE.\n\n" +
					"Press Space Bar to put the mirror back in the box.";
		if (Input.GetKeyDown(KeyCode.Space)) {
			myState = States.yellow;
		}
	}
	
	void state_brick() {
		text.text = "You have always wanted to throw a brick through a window. Now is your chance! " +
					"The shattering sound is all you could have hoped for, but it's a long way down. " +
					"And now you hear footsteps below. Hurry!\n\n" +
					"Press L or W to use another item in the box. Or R or Y to grab a different box.";

		if (Input.GetKeyDown(KeyCode.L)) {
			wrongChoice = "letter";
			myState = States.wrong;
		} else if (Input.GetKeyDown(KeyCode.W)) {
			wrongChoice = "wine";
			myState = States.wrong;
		} else if (Input.GetKeyDown(KeyCode.R)) {
			wrongChoice = "red";
			myState = States.wrong;
		} else if (Input.GetKeyDown(KeyCode.Y)) {
			myState = States.yellowEscape;
		}
	}
}
