using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
	public float range = 100f;
	public float fireRate = 15f;
	public float impactForce = 30f;

	public Camera fpsCam;
	public ParticleSystem muzzelFlash;
	public GameObject impactEffect;

	private float nextTimeTofire = 0f;
    // Update is called once per frame
    void Update()
    {
    	if(GameManager.GameIsOver)
    	{
    		this.enabled = false;
    		return;
    	}

        if (Input.GetButton("Fire1") && Time.time > nextTimeTofire)
        {
        	nextTimeTofire = Time.time + 1f / fireRate;
        	Shoot();
        }
    }

    void Shoot()
    {
    	muzzelFlash.Play();

    	RaycastHit hit;
    	if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
    	{
    		Debug.Log(hit.transform.name);

    		Target target = hit.transform.GetComponent<Target>();
    		if (target != null)
    		{
    			target.TakeDamage(damage);
    		}

    		if (hit.rigidbody != null)
    		{
    			hit.rigidbody.AddForce(-hit.normal * impactForce);
    		}

    		GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
    		Destroy(impactGO, 2f);

    		GetComponent<AudioSource> ().Play ();
    	}
    }
}

