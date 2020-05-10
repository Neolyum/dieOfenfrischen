using System;
using UnityEngine;

namespace ArcadeJets {
	public class StickInput : MonoBehaviour {
		private FlightControls fc;
		public Camera cam;
		public float speed = 100f;


		private Vector2 aimVec;
		[SerializeField] private Vector3 stickInput;
		[SerializeField] private float throttle;

		public float Pitch {
			get { return stickInput.x; }
			set { stickInput.x = value; }
		}

		public float Roll {
			get { return stickInput.z; }
			set { stickInput.z = value; }
		}

		public float Yaw {
			get { return stickInput.y; }
			set { stickInput.y = value; }
		}

		/// <summary>
		/// Pitch, Yaw, and Roll represented as a Vector3, in that order.
		/// </summary>
		public Vector3 Combined {
			get { return stickInput; }
			set { stickInput = value; }
		}

		[SerializeField]
		public float Throttle {
			get { return throttle; }
			set { throttle = value; }
		}


		public const float ThrottleNeutral = 1f;
		public const float ThrottleMin = 0.33f;
		public const float ThrottleMax = 3f;
		public const float ThrottleSpeed = 2f;

		private void Awake() {
			fc = new FlightControls();
			fc.Flight.PitchYaw.performed += ctx => PitchYawSet(ctx.ReadValue<Vector2>());
			fc.Flight.Roll.performed += ctx => RollSet(ctx.ReadValue<float>());
			fc.Flight.Speed.performed += ctx => Turbo(ctx.ReadValue<float>());
			fc.Flight.Camera.performed += ctx => RotateCamera(ctx.ReadValue<Vector2>());
			fc.Flight.Camera.started += ctx => RotateCamera(ctx.ReadValue<Vector2>());
			fc.Flight.Camera.canceled += ctx => RotateCamera(ctx.ReadValue<Vector2>());
		}


		void RotateCamera(Vector2 aimVec) {
			Debug.Log(aimVec);
			cam.transform.Translate(Time.deltaTime * speed * aimVec);
			cam.transform.LookAt(transform);
		}

		private void OnEnable() {
			fc.Enable();
		}

		private void OnDisable() {
			fc.Disable();
		}

		void RollSet(float r) {
			Roll = r;
		}

		void PitchYawSet(Vector2 py) {
			Pitch = py.y;
			Yaw = py.x;
		}

		void Turbo(float t) {
			throttle = Mathf.MoveTowards(throttle, t > 1 ? ThrottleMax : t == 0 ? ThrottleNeutral : ThrottleMin,
				ThrottleSpeed * Time.deltaTime);
		}
	}
}