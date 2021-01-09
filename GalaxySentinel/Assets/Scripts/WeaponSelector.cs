using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour
{
    [SerializeField] Sprite[] weaponImages;
    [SerializeField] Button playButton;
    [SerializeField] Button electricGunButton;
    [SerializeField] Button plasmaCannonButton;
    [SerializeField] Button machineGunButton;
    [SerializeField] Button apCannonButton;
    [SerializeField] Button laserButton;
    [SerializeField] Image weaponSlot;

    bool weaponSlotOccupied = false;
    bool perkSlotOccupied = false;

    private void OnEnable()
    {
        PlayerPrefs.DeleteAll();
    }

    private void Update()
    {
        EnablePlayButton();
    }

    private void EnablePlayButton()
    {
        perkSlotOccupied = FindObjectOfType<PerkSelector>().perkSlotOccupied;

        if (weaponSlotOccupied && perkSlotOccupied)
        {
            playButton.interactable = true;
        }
        else
        {
            playButton.interactable = false;
        }
    }

    private void SetImageToSlot()
    {
        var buttonName = EventSystem.current.currentSelectedGameObject.name;

        if (!weaponSlotOccupied)
        {
            weaponSlot.sprite = SelectSprite(buttonName);
            weaponSlotOccupied = true;
        }
    }

    private Sprite SelectSprite(string name)
    {
        switch (name)
        {
            case "ElectricGunButton":
                return weaponImages[0];
            case "PlasmaCannonButton":
                return weaponImages[1];
            case "MachineGunButton":
                return weaponImages[2];
            case "ApCannonButton":
                return weaponImages[3];
            case "LaserButton":
                return weaponImages[4];
            default:
                return null;
        }
    }

    private void LoadWeapon()
    {
        var buttonName = EventSystem.current.currentSelectedGameObject.name;

        if (!weaponSlotOccupied)
        {
            switch (buttonName)
            {
                case "ElectricGunButton":
                    PlayerPrefs.SetString("weapon", "electricGun");
                    break;
                case "PlasmaCannonButton":
                    PlayerPrefs.SetString("weapon", "plasmaCannon");
                    break;
                case "MachineGunButton":
                    PlayerPrefs.SetString("weapon", "machineGun");
                    break;
                case "ApCannonButton":
                    PlayerPrefs.SetString("weapon", "apCannon");
                    break;
                case "LaserButton":
                    PlayerPrefs.SetString("weapon", "laser");
                    break;
                default:
                    break;
            }
        }
    }

    public void DisableWeaponButtons()
    {
        electricGunButton.interactable = false;
        plasmaCannonButton.interactable = false;
        machineGunButton.interactable = false;
        apCannonButton.interactable = false;
        laserButton.interactable = false;
    }

    public void EnableWeaponButtons()
    {
        electricGunButton.interactable = true;
        plasmaCannonButton.interactable = true;
        machineGunButton.interactable = true;
        apCannonButton.interactable = true;
        laserButton.interactable = true;
    }

    public void SelectWeapon()
    {
        LoadWeapon();
        SetImageToSlot();
    }

    public void DeselectWeapon()
    {
        var buttonName = EventSystem.current.currentSelectedGameObject.name;

        switch (buttonName)
        {
            case "WeaponSlotButton":
                weaponSlot.sprite = null;
                weaponSlotOccupied = false;
                PlayerPrefs.DeleteKey("weapon");
                break;
            default:
                break;
        }
    }
}
