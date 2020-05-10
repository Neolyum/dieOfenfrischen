using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using DefaultNamespace;
using UnityEngine;

public class TurretManager : MonoBehaviour {
	private FlightControls fc;
	private AudioSource source;
	[SerializeField] private Camera cam;
	[SerializeField] private AudioClip kathode;


	public Transform lookAt;
	private Vector2 aim;

	public float shotEnergy;
	public EnergyUI energyUI;

	public BeatPanel bp;
	public float weaponDistance = 100f;
	public Transform turretParent;
	private List<Turret> turrets;

	public Vector3 aimDir;

	private bool _shooting;

	void Awake() {
		energyUI = GameObject.Find("EnergyUI").GetComponent<EnergyUI>();

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
//		fc.Turret.Shoot.started += _ => Shoot();
		fc.Turret.Beat.started += _ => bp.OnBeatHitDown();
		fc.Turret.Beat.canceled += _ => bp.OnBeatHitUp();
		fc.Turret.Shoot.started += _ => StartCoroutine(Shoot());
		fc.Turret.Shoot.canceled += _ => ToggleShooting(false);
//		fc.Turret.Aim.canceled += ctx => aim = Vector2.zero;
	}


	void ToggleShooting(bool value) {
		if (value) {
			_shooting = true;
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


	private bool EnergyPredicate() {
		energyUI.currentEnergy = Mathf.Clamp(energyUI.currentEnergy - shotEnergy * 0.05f, 0, 500f);

		return energyUI.currentEnergy == 0 || !_shooting;
	}

	private IEnumerator Shoot() {
		if (energyUI.currentEnergy >= 10) {
			ToggleShooting(true);
			yield return new WaitUntil(EnergyPredicate);
		}

		ToggleShooting(false);
	}

	private void Aim() {
		float x = aim.x * Time.deltaTime;
		float y = Mathf.Clamp(-aim.y * Time.deltaTime, -90f, 90f);

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