using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour {
	private FlightControls fc;

	[SerializeField] private Camera cam;


	public Transform lookAt;
	public float sensitivity = 100f;
	private Vector2 aim;


	public BeatPanel bp;
	public float weaponDistance = 100f;
	public Shot weapon;
	public Transform turretParent;
	private List<Turret> turrets;

	void Awake() {
		turrets = new List<Turret>();
		foreach (Transform child in turretParent) {
			Turret t = child.gameObject.AddComponent(typeof(Turret)) as Turret;
			t.ammo = weapon;
			turrets.Add(t);
		}

		fc = new FlightControls();
		fc.Turret.Aim.performed += ctx => aim = ctx.ReadValue<Vector2>();
		fc.Turret.Shoot.started += _ => Shoot();
		fc.Turret.Beat.started += _ => bp.OnBeatHitDown();
		fc.Turret.Beat.canceled+= _ => bp.OnBeatHitUp();
//		fc.Turret.Aim.canceled += ctx => aim = Vector2.zero;
	}


	private void Aim() {
		float x = aim.x * sensitivity * Time.deltaTime;
		float y = Mathf.Clamp(-aim.y * sensitivity * Time.deltaTime, -90f, 90f);

		transform.RotateAround(transform.position, transform.up, x);
		transform.RotateAround(transform.position, transform.right, y);
		cam.transform.LookAt(lookAt);
	}


	private void Shoot() {
		Vector3 dir = lookAt.position - transform.position;

		foreach (Turret t in turrets) {
			Debug.DrawLine(lookAt.position, t.transform.position, Color.yellow);
			t.Shoot(dir.normalized, weaponDistance);
		}
	}

	private void OnEnable() {
		fc.Enable();
	}

	private void OnDisable() {
		fc.Disable();
	}

	void Update() {
		Aim();
	}
}