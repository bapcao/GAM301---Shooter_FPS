using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }

    public AudioSource ShootingChannel;

    public AudioClip UziShot;
    public AudioClip Pistol_FShot;
    public AudioClip M107Shot;

    public AudioSource emptyManagazineSoundUzi;

    public AudioSource reloadingSoundUzi;
    public AudioSource reloadingSoundPistol_F;
    public AudioSource reloadingSoundM107;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayShootingSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.Pistol_F:
                ShootingChannel.PlayOneShot(Pistol_FShot);
            break;
            case WeaponModel.Uzi:
                ShootingChannel.PlayOneShot(UziShot);
                break;
        }
    }

    public void PlayReloadSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.Pistol_F:
                reloadingSoundPistol_F.Play();
                break;
            case WeaponModel.Uzi:
                reloadingSoundUzi.Play();
                break;
        }
    }
}
