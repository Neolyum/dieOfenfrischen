using Boo.Lang;
using MFlight;
using UnityEngine;

namespace Controller {
	public enum controllerType {
		MOUSE,
		CONTROLLER,
	}

	[RequireComponent(typeof(GamepadController))]
	[RequireComponent(typeof(MouseFlightController))]
	public class ControllerManager : MonoBehaviour {
		public controllerType selectedController;
		public MouseFlightController mouse;
		public GamepadController gamepad;


		void Start() {
			mouse = GetComponent<MouseFlightController>();
			gamepad = GetComponent<GamepadController>();
		}

		public AbstractFlightController GetController() {
			if (selectedController == controllerType.MOUSE) {
				return mouse;
			}

			return gamepad;
		}
	}
}