//
// Copyright (c) Brian Hernandez. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for details.
//

using System;
using UnityEngine;

namespace MFlight {
	public class MouseFlightController : AbstractFlightController {
		public override Vector2 getTargetValues() {
			return new Vector2(Input.GetAxis("Mouse X") * sensitivity,
				-Input.GetAxis("Mouse Y") * sensitivity);
		}
	}
}