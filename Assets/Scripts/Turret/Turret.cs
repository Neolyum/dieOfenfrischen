using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
	public Shot ammo;
    Shot laser;
    private bool shot = false;
	public void Shoot(Vector3 direction, float distance) {
		Vector3 pos = transform.position;
		int layerMask = ~LayerMask.NameToLayer("Enemy");
		bool rayHit = Physics.Raycast(pos, direction, distance, layerMask);
		if (!rayHit && !shot) {
			ShootLaser(direction, distance);
            shot = true;
            line.enabled = true;
		}
        if (!rayHit && shot)
        {
            UpdateLaser(direction);
        }
	}
    
    public void StopShoot()
    {
        shot = false;
        line.enabled = false;
        laser.destroy();
        Destroy(laser);
    }
    // Add a Line Renderer to the GameObject
    private LineRenderer line;                           // Line Renderer

    // Use this for initialization
    void Start()
    {
        // Add a Line Renderer to the GameObject
        line = this.gameObject.AddComponent<LineRenderer>();
        // Set the width of the Line Renderer
        line.SetWidth(0.05F, 0.05F);
        // Set the number of vertex fo the Line Renderer
        line.SetVertexCount(2);
        line.startColor = new Color(0, 1, 0);
        line.endColor = new Color(0.3f, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the GameObjects are not null
        if ( laser != null)
        {
            // Update position of the two vertex of the Line Renderer
            line.SetPosition(0, transform.position);
            line.SetPosition(1, laser.transform.position);
        }
    }
    private void UpdateLaser(Vector3 direction)
    {
        laser.up(direction);
        Debug.DrawLine(transform.position, laser.transform.position);
    }
	private void ShootLaser(Vector3 direction, float distance) {
		laser = Instantiate(ammo);
		laser.transform.position = transform.position;
		laser.Shoot(direction, distance);
	}
}