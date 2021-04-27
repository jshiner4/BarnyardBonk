using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30;
    public LayerMask layerMask;

    private Vector3 newForce;

    public Camera cam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    [SerializeField] private GameObject bulletPrefab;
    private GameObject bullet;

    private void Start()
    {
        //newForce = new Vector3(5f, 3f, 5f);
        newForce = new Vector3(0f, 3f, 0f);
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        //shoot out ray starting at position of camera, shooting in the direction we are facing, gather info on what we hit & put it into hit. range optional
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, layerMask))
        {
            Debug.Log(hit.transform.name);

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);

            if (hit.rigidbody != null)
            {
                //Debug.Log(hit.normal);
                hit.rigidbody.AddForce(-hit.normal * impactForce);
                hit.rigidbody.AddForce(newForce, ForceMode.Impulse);
            }

            //if (bullet == null)
            // {
            //bullet = Instantiate(bulletPrefab) as GameObject;
            // bullet.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
            // bullet.transform.rotation = transform.rotation;
            //}


            //Target target = hit.transform.GetComponent<Target>();
            //if (target != null)
            //{
            //target.TakeDamage(damage);
            //}
        }

    }
}
