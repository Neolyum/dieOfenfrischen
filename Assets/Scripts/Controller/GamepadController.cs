using System;
using MFlight;
using UnityEngine;

namespace Controller {
	public class GamepadController : AbstractFlightController {
		public override Vector2 getTargetValues() {
			return new Vector2(Input.GetAxis("Horizontal") * sensitivity,
				-Input.GetAxis("Vertical") * sensitivity);
		}
	}
}