using UnityEngine;
using TMPro;
using Photon.Pun;

public class GunSystemMP : MonoBehaviour
{
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
    public int aimAnimationSpeed = 1;

    bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
    public LayerMask whatIsFriendly;

    public GameObject muzzleFlash, bulletHoleGraphic, playerHoleGraphic;
    //public Transform WeaponDefaultPosition, WeaponADSPosition;
    public TextMeshProUGUI text;
    //public AudioClip gunShotFire;
    //AudioSource audioSource;
    PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();

        bulletsLeft = magazineSize;
        readyToShoot = true;

        //audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        MyInput();

        text.SetText(bulletsLeft + " / " + magazineSize);
    }

    void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }

    void Shoot()
    {
        //audioSource.PlayOneShot(gunShotFire);
        readyToShoot = false;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        /*if(Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            *//*Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("RedTeam"))
            {
                rayHit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(damage);
                PV.RPC("RPC_Shoot", RpcTarget.All, rayHit.point, rayHit.normal);
            }*//*

            rayHit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(damage);
            PV.RPC("RPC_Shoot", RpcTarget.All, rayHit.point, rayHit.normal);

            Debug.Log("Hit Red Team");
        }

        if(Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsFriendly))
        {
            rayHit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(damage);
            PV.RPC("RPC_Shoot", RpcTarget.All, rayHit.point, rayHit.normal);

            Debug.Log("Hit Blue Team");
        }*/

    if(Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
    {
        Debug.Log(rayHit.collider.name);
    
        if (rayHit.collider.CompareTag("RedTeam"))
        {
            rayHit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(damage);
            PV.RPC("RPC_Shoot", RpcTarget.All, rayHit.point, rayHit.normal);
        }
    
        Debug.Log("Hit Red Team");
    }




    PhotonNetwork.Instantiate("BulletImpactStoneEffect", rayHit.point, Quaternion.Euler(0, 180, 0));
    PhotonNetwork.Instantiate("MuzzleFlashEffect", attackPoint.position, Quaternion.identity);
    
    bulletsLeft--;
    bulletsShot--;
    
    Invoke("ResetShot", timeBetweenShooting);
    if (bulletsShot > 0 && bulletsLeft > 0)
        Invoke("Shoot", timeBetweenShots);
    }
    
    [PunRPC]
    void RPC_Shoot(Vector3 hitPosition, Vector3 hitNormal)
    {
        Collider[] colliders = Physics.OverlapSphere(hitPosition, 0.3f);
        if (colliders.Length != 0)
        {
            GameObject bulletImpactObj = Instantiate(playerHoleGraphic, hitPosition + hitNormal * 0.001f, Quaternion.LookRotation(hitNormal, Vector3.up) * playerHoleGraphic.transform.rotation);
            Destroy(bulletImpactObj, 10f);
            bulletImpactObj.transform.SetParent(colliders[0].transform);
        }
    }
    
    void ResetShot()
    {
        readyToShoot = true;
    }
    
    void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    
    void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
