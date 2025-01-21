using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    public GameObject pistol;
    public GameObject uzi;
    public GameObject m107;

    private GameObject currentWeapon;

    void Start()
    {
        // Start with the pistol
        EquipWeapon(pistol);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipWeapon(pistol);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeapon(uzi);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipWeapon(m107);
        }
    }

    void EquipWeapon(GameObject weapon)
    {
        // Deactivate the current weapon
        if (currentWeapon != null)
        {
            currentWeapon.SetActive(false);
        }

        // Activate the new weapon
        weapon.SetActive(true);
        currentWeapon = weapon;
    }
}