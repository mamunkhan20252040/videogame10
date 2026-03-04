using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    
    public bool isShooting, readyToShoot;
    bool allowReset = true;
    public float shootingDelay = 2f;
    public float bulletsPerBurst = 3f;
    public float burstBulletsLeft;
    public float spreadIntensity;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 30f;
    public float bulletPrefabLifeTime = 3f;

    private Animator animator;
    public float reloadTime;
    public float magazineSize;
    public float bulletsLeft;
    public bool isReloading;
    
    private float ammoNeeded;
    
    private float maxbulletsLeft;
    private float bulletsToTake;
    

    public enum ShootingMode
    {
        Single,
        Burst,
        Auto
    }

    public ShootingMode currentShootingMode;

    public void Awake()
    {
        readyToShoot = true;
        burstBulletsLeft = bulletsPerBurst;
        animator = GetComponent<Animator>();
        //bulletsLeft = magazineSize;
        
        maxbulletsLeft = bulletsLeft;
        
        
        
    }

    
    void Update()
    {
        if(bulletsLeft == 0 && isShooting)
        {
            SoundManager.Instance.emptyMagazineSound.Play();
        }
        if(currentShootingMode == ShootingMode.Auto)
        {
            isShooting = Input.GetKey(KeyCode.Mouse0);
        }
        else if(currentShootingMode == ShootingMode.Single || currentShootingMode == ShootingMode.Burst)
        {
            isShooting = Input.GetKeyDown(KeyCode.Mouse0);
        }
        if(readyToShoot && isShooting && bulletsLeft > 0 && isReloading == false)
        {
            burstBulletsLeft = bulletsPerBurst;
            FireWeapon();
            
        }
        // if(Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && isReloading == false)
        // {
        //     Reload();
        // }
        if(Input.GetKeyDown(KeyCode.R) && bulletsLeft < maxbulletsLeft && magazineSize > 0 && isReloading == false)
        {
            Reload();
        }
        if(readyToShoot && isShooting == false && isReloading == false && bulletsLeft <= 0)
        {
            //Reload();
        }
        if(AmmoManager.Instance.ammoDisplay != null)
        {
            AmmoManager.Instance.ammoDisplay.text = $"{bulletsLeft/bulletsPerBurst}/{magazineSize/bulletsPerBurst}";
            
        }
        
    }

    public void FireWeapon()
    {
        bulletsLeft--;
        
        
        animator.SetTrigger("RECOIL");
        SoundManager.Instance.shootingSound.PlayOneShot(SoundManager.Instance.pistolShootingSound);
        readyToShoot = false;
        Vector3 shootingDirection = CalculateDirectionAndSpread().normalized;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        bullet.transform.forward = shootingDirection;
        bullet.GetComponent<Rigidbody>().AddForce(shootingDirection * bulletVelocity, ForceMode.Impulse);
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime));
        if (allowReset)
        {
            Invoke("ResetShot", shootingDelay);
            allowReset = false;
        }
        if(currentShootingMode == ShootingMode.Burst && burstBulletsLeft > 1)
        {
            burstBulletsLeft--;
            Invoke("FireWeapon", shootingDelay);
        }
    }

    public void Reload()
    {
        SoundManager.Instance.reloadingSound.Play();
        animator.SetTrigger("RELOAD");
        isReloading = true;
        Invoke("ReloadCompleted", reloadTime);
    }

    public void ReloadCompleted()
    {
        
        ammoNeeded = maxbulletsLeft - bulletsLeft;
        bulletsToTake = Mathf.Min(ammoNeeded, magazineSize);
        bulletsLeft += bulletsToTake;
        magazineSize -= bulletsToTake;

        isReloading = false;
    }

    public void ResetShot()
    {
        readyToShoot = true;
        allowReset = true;
    }

    public Vector3 CalculateDirectionAndSpread()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if(Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(100);
        }

        Vector3 direction = targetPoint - bulletSpawn.position;
        float x = UnityEngine.Random.Range(-spreadIntensity, spreadIntensity);
        float y = UnityEngine.Random.Range(-spreadIntensity, spreadIntensity);
        return direction + new Vector3(x, y, 0);
    }

    public IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
