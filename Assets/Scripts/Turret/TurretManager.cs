using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class TurretManager : MonoBehaviour {
	private FlightControls fc;
	private AudioSource source;
	[SerializeField] private Camera cam;
	[SerializeField] private AudioClip kathode;


	public Transform lookAt;
	public float sensitivity = 100f;
	private Vector2 aim;
	private bool running = true;

	public float weaponDistance = 100f;
	public Transform turretParent;
	private List<Turret> turrets;

	public Vector3 aimDir;


	void Awake() {
		source = gameObject.AddComponent<AudioSource>();
		LineRenderer line = GetComponent<LineRenderer>();
		turrets = new List<Turret>();
		foreach (Transform child in turretParent) {
			Turret t = child.gameObject.AddComponent(typeof(Turret)) as Turret;
			t.direction = aimDir;
			t.distance = weaponDistance;
			t.line = line;
			LineRenderer tRef = t.gameObject.AddComponent(typeof(LineRenderer)) as LineRenderer;
			tRef.GetCopyOf(line);
			turrets.Add(t);
		}

		fc = new FlightControls();
		fc.Turret.Aim.performed += ctx => aim = ctx.ReadValue<Vector2>();
		fc.Turret.Shoot.started += _ => ToggleShooting(true);
		fc.Turret.Shoot.canceled += _ => ToggleShooting(false);
//		fc.Turret.Aim.canceled += ctx => aim = Vector2.zero;
	}


	void ToggleShooting(bool value) {
		if (value) {
			source.clip = kathode;
			source.Play();
		}
		else {
			source.Stop();
		}

		foreach (Turret t in turrets) {
			t.ToggleShooting(value);
		}
	}

	private void Aim() {
		float x = aim.x * sensitivity * Time.deltaTime;
		float y = Mathf.Clamp(-aim.y * sensitivity * Time.deltaTime, -90f, 90f);

		transform.RotateAround(transform.position, transform.up, x);
		transform.RotateAround(transform.position, transform.right, y);
		foreach (Turret turret in turrets) {
			turret.direction = aimDir;
		}

		cam.transform.LookAt(lookAt);
		aimDir = lookAt.position - transform.position;
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