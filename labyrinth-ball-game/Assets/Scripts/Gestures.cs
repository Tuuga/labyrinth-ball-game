using UnityEngine;
using System.Collections;

public class Gestures : MonoBehaviour {

	public static class Pinch {
		public static float rawDelta;
		public static float normalizedDelta;
		public static float rawDistance;
		public static float normalizedDistance;
		static float rawLastDist;
		static float normalizedLastDist;

		public static void UpdatePinch() {

			// If 2 fingers are touching the screen
			if (Input.touchCount != 2) {
				rawDelta = 0;
				normalizedDelta = 0;
				return;
			}

			var touchPosOne = Input.touches[0].position;
			var touchPosTwo = Input.touches[1].position;

			var normalizedPosOne = new Vector2(touchPosOne.x / Screen.width, touchPosOne.y / Screen.height);
			var normalizedPosTwo = new Vector2(touchPosTwo.x / Screen.width, touchPosTwo.y / Screen.height);

			rawDistance = (touchPosOne - touchPosTwo).magnitude;
			normalizedDistance = (normalizedPosOne - normalizedPosTwo).magnitude;

			rawDelta = rawLastDist - rawDistance;
			normalizedDelta = normalizedLastDist - normalizedDistance;

			// If one of the fingers just began touching the screen
			// delta = 0
			if (Input.touches[0].phase == TouchPhase.Began || Input.touches[1].phase == TouchPhase.Began) {
				rawDelta = 0;
				normalizedDelta = 0;
			}

			rawLastDist = rawDistance;
			normalizedLastDist = normalizedDistance;
		}
	}

	public static class Swipe {
		public enum Direction {None, Left, Right, Up, Down };
		public static Direction currentDirection;
		public static Direction lastDirection;

		static Vector2 startPos;
		static Vector2 endPos;
		public static Vector2 dir;

		public static void UpdateSwipe() {
			if (Input.touchCount != 1) {
				currentDirection = Direction.None;
				return;
			}

			if (Input.touches[0].phase == TouchPhase.Began) {
				startPos = Input.touches[0].position;
			}

			if (Input.touches[0].phase == TouchPhase.Ended) {
				endPos = Input.touches[0].position;
				dir = (endPos - startPos).normalized;

				if (dir.x > 0 && (dir.x > dir.y && dir.x > -dir.y)) { // Right
					lastDirection = Direction.Right;
					currentDirection = Direction.Right;
				} else if (dir.x < 0 && (-dir.x > dir.y && -dir.x > -dir.y)) { // Left
					lastDirection = Direction.Left;
					currentDirection = Direction.Left;
				} else if (dir.y > 0 && (dir.y > dir.x && dir.y > -dir.x)) { // Up
					lastDirection = Direction.Up;
					currentDirection = Direction.Up;
				} else if (dir.y < 0 && (-dir.y > dir.x && -dir.y > -dir.x)) { // Down
					lastDirection = Direction.Down;
					currentDirection = Direction.Down;
				}
			}
		}
	}

	void Update() {
		Pinch.UpdatePinch();
		Swipe.UpdateSwipe();
	}
}
