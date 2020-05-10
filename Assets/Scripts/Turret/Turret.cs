using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
	public Shot ammo;

	private bool _isShooting;

	public float distance;
	public Vector3 direction;
	private int _layerMask;


	// Add a Line Renderer to the GameObject
	public LineRenderer line; // Line Renderer

	// Use this for initialization
	void Start() {
		_layerMask = ~LayerMask.NameToLayer("Enemy");
	}

	public void ToggleShooting(bool value) {
		_isShooting = value;
		line.enabled = _isShooting;
	}


	void Update() {
		bool rayHit = Physics.Raycast(transform.position, direction, distance, _layerMask);

		if (_isShooting) {
			Debug.DrawLine(transform.position, direction * distance, Color.yellow);

			
			// Update position of the two vertex of the Line Renderer
			line.SetPosition(0, transform.position);
			line.SetPosition(1, direction * distance);
			Debug.DrawLine(transform.position, direction * distance);
		}
	}
}