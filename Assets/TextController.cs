using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {attic, yellow, green, wrong, letter, mirrorEarly, brick, yellowEscape, rope, forest, stream, sandwich, mirrorCorrect};
	private States myState;
	public string reset = "Press the Space Bar to restart game, loser.";
	public string wrongChoice;
	public bool justEntered = true;
	public string deeper = "deeper";
	
	// Use this for initialization
	void Start () {
		myState = States.attic;
	}
	
	// Update is called once per frame
	void Update () {
		if (myState == States.attic) {
			state_attic();
		} else if (myState == States.yellow) {
			state_yellow();
		} else if (myState == States.green) {
			state_green();
		} else if (myState == States.wrong) {
			state_wrong();
		} else if (myState == States.letter) {
			state_letter();
		} else if (myState == States.mirrorEarly) {
			state_mirrorEarly();
		} else if (myState == States.brick) {
			state_brick();
		} else if (myState == States.yellowEscape) {
			state_yellowEscape();
		} else if (myState == States.rope) {
			state_rope();
		} else if (myState == States.forest) {
			state_forest();
		} else if (myState == States.stream) {
			state_stream();
		} else if (myState == States.sandwich) {
			state_sandwich();
		} else if (myState == States.mirrorCorrect) {
			state_mirrorCorrect();
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
					"a Nylon rope, and a Mirror.\n\n" +
					"Choose S, N, or M to use an item. R or G to look at another box.";
		
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
	
	void state_wrong () {
		if (wrongChoice == "red") {
			text.text = "The Red Box is filled with cobras. You get bitten a lot and die horribly.\n\n" + reset;
		} else if (wrongChoice == "sandwich") {
			text.text = "You fool! That almond smell was cyanide! And the dry roast beef needed mustard, " +
						"making it a pitiful last meal. You die by poison, unsatisfied.\n\n" + reset;
		} else if (wrongChoice == "rope") {
			text.text = "You assume the situation is hopeless and hang yourself. Geez.\n\n" + reset;
		} else if (wrongChoice == "wine") {
			text.text = "You drink the whole bottle and start singing, really obnoxiously. " +
						"The people who kidnapped you decide you're not worth suffering through. " +
						"They kill you a whole lot so that you are dead for good.\n\n" + reset;
		} else if (wrongChoice == "letter") {
			text.text = "You get caught by the kidnappers while you are reading the letter. " +
						"Complaining about the writer's spelling does you no good. They push you out " +
						"the window and your head cracks open like Humpty Dumpty. You are a mess.\n\n" + reset;
		} else if (wrongChoice == "mirror") {
			text.text = "The last thing you see is your sexy, screaming face as you're attacked.\n\n" + reset;
		} else if (wrongChoice == "surrender") {
			text.text = "Oops, you've seen their faces. And you made them run upstairs AND back down to get you. " +
						"The whole idea of kidnapping is you get to be lazy, just waiting for money to show up. " +
						"So they kill you a bit, exerting the minimum effort required to make you be dead.\n\n" + reset; 
		} else if (wrongChoice == "run") {
			text.text = "You can't outrun a wolf, stupid. Especially not a demon wolf. I guess you'll die as you lived: " +
						"pointlessly.\n\n" + reset;
		} else if (wrongChoice == "give") {
			text.text = "The demon wolf is disgusted with you. I'm disgusted with you. You die miserable " +
						"and alone, like you always knew you would.\n\n" + reset;
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
	
	void state_yellowEscape() {
		text.text = "You grab the Yellow box and get to the window. Inside are a Sandwich (roast beef " +
					"with an almondy smell), a Nylon rope, and a Mirror.\n\n" +
					"Choose S, N, or M to use an item. But hurry!";
		
		if (Input.GetKeyDown(KeyCode.S)) {
			wrongChoice = "sandwich";
			myState = States.wrong;
		} else if (Input.GetKeyDown(KeyCode.N)) {
			myState = States.rope;
		} else if (Input.GetKeyDown(KeyCode.M)) {
			wrongChoice = "mirror";
			myState = States.wrong;
		}
	}
	
	void state_rope() {
		text.text = "You tie the nylon rope off to the radiator under the window and toss the rope down. " +
					"Thinking fast, you pocket the Sandwich and the Mirror from the box. Then you " +
					"scramble down the rope. But beyond the house is a Haunted Forest!\n\n" +
					"Choose F to run headlong into the Forest or S to surrender to the kidnappers.";
		
		if (Input.GetKeyDown(KeyCode.S)) {
			wrongChoice = "surrender";
			myState = States.wrong;
		} else if (Input.GetKeyDown(KeyCode.F)) {
			myState = States.forest;
		}
	}
	
	void state_forest() {
		string decision = "\n\nPress R to keep Running. Press D to Drink from a nearby stream.";

		if (justEntered == true) {
			text.text = "You dash into the Haunted Forest. It's spooky." + decision;
		} else {
			text.text = "You run " + deeper + " into the Haunted Forest. It's still spooky." + decision;
		}
		
		if (Input.GetKeyDown(KeyCode.D)) {
			myState = States.stream;
			deeper = "deeper";
			justEntered = true;
		} else if (Input.GetKeyDown(KeyCode.R)) {
			if (justEntered == false) {
				deeper = deeper + " and deeper";
			}
			justEntered = false;
		}
	}
	
	void state_stream() {
		text.text = "Water from the Haunted Forest is delicious. You consider starting a fancy bottled water company, " +
					"but you suddenly realize you're not alone! There is a demon wolf staring at you! It has quenched its " +
					"thirst, too. Now it's hungry.\n\nPress R to Run, S to use the Sandwich, or M to use the Mirror.";
		if (Input.GetKeyDown(KeyCode.R)) {
			wrongChoice = "run";
			myState = States.wrong;
		} else if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sandwich;
		} else if (Input.GetKeyDown(KeyCode.M)) {
			wrongChoice = "mirror";
			myState = States.wrong;
		}
	}
	
	void state_sandwich() {
		text.text = "You feed the demon wolf the roast beef sandwich. It belches fire after it's done and seems " +
					"quite content. It indicates you should follow it, and who are you to argue with a demon wolf? " +
					"It takes you up a steep incline to a small clearing. Hey, there's a plane passing by!\n\n" +
					"Press M to use Mirror or G to Give up on living.";
		if (Input.GetKeyDown(KeyCode.G)) {
			wrongChoice = "give";
			myState = States.wrong;
		} else if (Input.GetKeyDown(KeyCode.M)) {
			myState = States.mirrorCorrect;
		}
	}
	
	void state_mirrorCorrect() {
		text.text = "The Mirror reflects sunlight at the plane, which calls in a rescue. The pilot, who " +
					"is super hot, stops by. You share your Haunted Forest Water idea. You both get rich and build " +
					"a cozy cabin there. The demon wolf devours all your enemies, including those loser kidnappers.\n\n" +
					"Press Space Bar to play again, Champ.";
		if (Input.GetKeyDown(KeyCode.Space)) {
			myState = States.attic;
		}
	}
}
