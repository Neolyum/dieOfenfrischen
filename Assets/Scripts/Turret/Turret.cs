using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
	public Shot ammo;

	public void Shoot(Vector3 direction, float distance) {
		Vector3 pos = transform.position;
		int layerMask = ~LayerMask.NameToLayer("Enemy");
		bool rayHit = Physics.Raycast(pos, direction, distance, layerMask);
		if (!rayHit) {
			ShootLaser(direction, distance);
		}
	}

	private void ShootLaser(Vector3 direction, float distance) {
		Shot laser = Instantiate(ammo);
		laser.transform.position = transform.position;
		laser.Shoot(direction, distance);
	}
}