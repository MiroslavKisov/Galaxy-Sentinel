using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PerkSelector : MonoBehaviour
{
    [SerializeField] Sprite[] perkImages;
    [SerializeField] Button homingMissileButton;
    [SerializeField] Button shieldButton;
    [SerializeField] Image perkSlot;

    public bool perkSlotOccupied = false;

    private void OnEnable()
    {
        PlayerPrefs.DeleteAll();
    }

    private void SetImageToSlot()
    {
        var buttonName = EventSystem.current.currentSelectedGameObject.name;

        if (!perkSlotOccupied)
        {
           perkSlot.sprite = SelectSprite(buttonName);
           perkSlotOccupied = true;
        }
    }

    private Sprite SelectSprite(string name)
    {
        switch (name)
        {
            case "HomingMissileButton":
                return perkImages[0];
            case "ShieldButton":
                return perkImages[1];
            default:
                return null;
        }
    }

    private void LoadPerk()
    {
        var buttonName = EventSystem.current.currentSelectedGameObject.name;

        if (!perkSlotOccupied)
        {
            switch (buttonName)
            {
                case "HomingMissileButton":
                    PlayerPrefs.SetString("perk", "homingMissile");
                    break;
                case "ShieldButton":
                    PlayerPrefs.SetString("perk", "shield");
                    break;
                default:
                    break;
            }
        }
    }

    public void DisablePerkButtons()
    {
        homingMissileButton.interactable = false;
    }

    public void EnablePerkButtons()
    {
        homingMissileButton.interactable = true;
    }

    public void SelectPerk()
    {
        LoadPerk();
        SetImageToSlot();
    }

    public void DeselectPerk()
    {
        var buttonName = EventSystem.current.currentSelectedGameObject.name;

        switch (buttonName)
        {
            case "PerkSlotButton":
                perkSlot.sprite = null;
                perkSlotOccupied = false;
                PlayerPrefs.DeleteKey("perk");
                break;
            default:
                break;
        }
    }
}
