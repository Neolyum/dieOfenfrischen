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

		public Transform lookAt;
		public float sensitivity = 100f;
		private Vector2 aim;

		private void Awake() {
			fc = new FlightControls();
			fc.Flight.PitchYaw.performed += ctx => PitchYawSet(ctx.ReadValue<Vector2>());
			fc.Flight.Roll.performed += ctx => RollSet(ctx.ReadValue<float>());
			fc.Flight.Speed.performed += ctx => Turbo(ctx.ReadValue<float>());

			fc.Flight.Camera.performed += ctx => aim = ctx.ReadValue<Vector2>();
		}


		private void Aim() {
			float x = aim.x * sensitivity * Time.deltaTime;
			float y = Mathf.Clamp(-aim.y * sensitivity * Time.deltaTime, -90f, 90f);

			transform.RotateAround(transform.position, transform.up, x);
			transform.RotateAround(transform.position, transform.right, y);
			cam.transform.LookAt(lookAt);
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


		void Update() {
			Aim();
		}
	}
}