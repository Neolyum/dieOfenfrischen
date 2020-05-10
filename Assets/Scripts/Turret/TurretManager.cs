using System;
using System.Collections;
using System.Collections.Generic;
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
	public Shot weapon;
	public Transform turretParent;
	private List<Turret> turrets;

	void Awake() {
        source = gameObject.AddComponent<AudioSource>();
		turrets = new List<Turret>();
		foreach (Transform child in turretParent) {
			Turret t = child.gameObject.AddComponent(typeof(Turret)) as Turret;
			t.ammo = weapon;
			turrets.Add(t);
		}

		fc = new FlightControls();
		fc.Turret.Aim.performed += ctx => aim = ctx.ReadValue<Vector2>();
        fc.Turret.Shoot.started += _ => StartShooting();
        fc.Turret.Shoot.canceled += _ => StopShooting();
//		fc.Turret.Aim.canceled += ctx => aim = Vector2.zero;
	}
    private void StartShooting()
    {
        Debug.Log("Start shootiung");
        running = true;
        source.clip = kathode;
        source.Play();
        StartCoroutine("Shoot");
    }

    private void StopShooting()
    {
        source.Stop();
        Debug.Log("Stopping shoot");
        running = false;
        foreach (Turret t in turrets)
        {
            t.StopShoot();
        }
        StopCoroutine("Shoot");
    }

	private void Aim() {
		float x = aim.x * sensitivity * Time.deltaTime;
		float y = Mathf.Clamp(-aim.y * sensitivity * Time.deltaTime, -90f, 90f);

		transform.RotateAround(transform.position, transform.up, x);
		transform.RotateAround(transform.position, transform.right, y);
		cam.transform.LookAt(lookAt);
	}


	private IEnumerator Shoot() {
        while (running)
        {
            Vector3 dir = lookAt.position - transform.position;

            foreach (Turret t in turrets)
            {
                Debug.DrawLine(lookAt.position, t.transform.position, Color.yellow);
                t.Shoot(dir.normalized, weaponDistance);
            }
            yield return new WaitForEndOfFrame();
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