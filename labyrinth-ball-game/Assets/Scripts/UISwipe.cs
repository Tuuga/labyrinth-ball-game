using UnityEngine;
using System.Collections;

public class UISwipe : MonoBehaviour {

	public AnimationClip left;
	public AnimationClip right;

	Animator anim;
	bool playing;

	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update () {

		if (Input.GetKeyDown(KeyCode.LeftArrow) && !playing) {
			StartCoroutine(Move(left));
		}
		if (Input.GetKeyDown(KeyCode.RightArrow) && !playing) {
			StartCoroutine(Move(right));
		}

		if (Gestures.Swipe.currentDirection == Gestures.Swipe.Direction.Left && !playing) {
			StartCoroutine(Move(left));
		}
		if (Gestures.Swipe.currentDirection == Gestures.Swipe.Direction.Right && !playing) {
			StartCoroutine(Move(right));
		}
	}

	public IEnumerator Move(AnimationClip clip) {
		playing = true;
		anim.Play(clip.name);
		yield return new WaitForSeconds(clip.length);
		playing = false;
	}
}
