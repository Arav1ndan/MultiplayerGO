 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private Controls controls;
    private Camera cam;
    private RaycastHit rayHit;
     public float BulletRange = 10f;
    public float FireRate, ReloadTime;
    public bool isAutomatic;
    public int MagazineSize;
    private int ammoleft;
    private bool IsShooting, ReadyToShoot, Reloading;
    private void Awake()
    {
        ammoleft = MagazineSize;
        ReadyToShoot = true;
        controls = new  Controls();
        cam = Camera.main;
        if(cam == null){
            Debug.LogWarning("camer not attached");
        }

        //controls.Player.Fire.started += ctx => StartShot();
        //controls.Player.Fire.canceled += ctx => EndShoot();
        
    }
    private void Update()
    {
       if(IsShooting && ReadyToShoot && ammoleft > 0)
       {
            performedShot();
       }
    }
    public void StartShot()
    {

    }
    public void EndShoot()
    {

    }
    private void performedShot()
    {
        ReadyToShoot = false;
        Vector3 direction =  cam.transform.forward;
        if(Physics.Raycast(cam.transform.position, direction, out rayHit,BulletRange))
        {
            Debug.Log(rayHit.collider.gameObject.name);
        }
        ammoleft--;
        if(ammoleft >= 0)
        {
            Invoke("ResetShot",FireRate);
            if(!isAutomatic)
            {
                EndShoot();
            }
        }
    }
    private void ResetShot()
    {
        ReadyToShoot = true;
        
    }
    private void Reload()
    {
        Reloading = true;
        Invoke("ReloadFinished",ReloadTime);
    }
    private void ReloadFinished()
    {
        ammoleft = MagazineSize;
        Reloading = false;
    }
}
