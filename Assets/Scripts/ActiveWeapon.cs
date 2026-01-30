using UnityEngine;
using StarterAssets;
using Cinemachine;
using TMPro;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] TMP_Text ammoText;
    Animator animator;
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] Camera weaponCamera;
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] GameObject zoomImage;
    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController firstPersonController;
    Weapon weapon;

    float coolDownTime = 0f;
    const string shoot = "Shoot";
    float zoomStartPos;
    float originalRotateSpeed;

    int currentAmmo;

    void Awake()
    {
        zoomStartPos = cinemachineVirtualCamera.m_Lens.FieldOfView;
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        weapon = GetComponentInChildren<Weapon>();
        currentAmmo = weaponSO.MagzineSize;
    }

    void Start()
    {  
        ammoText.text = currentAmmo.ToString();     
        animator = GetComponentInChildren<Animator>();
        originalRotateSpeed = firstPersonController.RotationSpeed;        
    }

    void Update()
    {
        coolDownTime += Time.deltaTime;
        HandleShoot();
        HandleZoom();
    }

    public void AmmoAdjust(int ammo)
    {
        currentAmmo += ammo;
        AmmoPrinter();
    }

    void AmmoPrinter()
    {
        ammoText.text = currentAmmo.ToString();
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if(weapon)
        {
            Destroy(weapon.gameObject);
        }
        GameObject nextWeapon = Instantiate(weaponSO.weaponPrefab,transform);
        this.animator = nextWeapon.GetComponent<Animator>();        
        weapon = nextWeapon.GetComponent<Weapon>();
        this.weaponSO = weaponSO;
        AmmoCollector();
    }

    public void AmmoCollector()
    {
        this.currentAmmo = weaponSO.MagzineSize;
        AmmoPrinter();
    }

    public void HandleShoot()
    {
        if(!starterAssetsInputs.shoot) return;
       
        if(coolDownTime >= weaponSO.ShootRate && currentAmmo > 0)
        {  
            weapon.Shooting(weaponSO);
            animator.Play(shoot,0,0f);
            coolDownTime = 0f;
            AmmoAdjust(-1);
        }
        if(!weaponSO.isAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }
    }

    void HandleZoom()
    {
        if(starterAssetsInputs.zoom)
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }

    public void ZoomIn()
    {
        cinemachineVirtualCamera.m_Lens.FieldOfView = weaponSO.zoomDistance;
        weaponCamera.fieldOfView = 10;
        RotationSpeedMethod(weaponSO.speedAfterZoom);
        zoomImage.SetActive(true);
    }

    public void ZoomOut()
    {
        cinemachineVirtualCamera.m_Lens.FieldOfView = zoomStartPos;
        weaponCamera.fieldOfView = zoomStartPos;
        RotationSpeedMethod(originalRotateSpeed);
        zoomImage.SetActive(false);
    }

    void RotationSpeedMethod(float rotateSpeedRef)
    {
        firstPersonController.RotateSpeedChange(rotateSpeedRef);
    }
}
