using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterPerks : MonoBehaviour
{
    [SerializeField] GameObject[] perks;

    Coroutine firePerkCoroutine;
    GameObject perk;
    Perk perkScript;

    void Start()
    {
        LoadPerk();
    }


    void Update()
    {
        Fire();
    }

    private void LoadPerk()
    {
        var selectedPerk = PlayerPrefs.GetString("perk");

        switch (selectedPerk)
        {
            case "homingMissile":
                perk = perks[0];
                break;
            case "shield":
                perk = perks[1];
                break;
            default:
                break;
        }

        perkScript = perk.GetComponent<Perk>();
    }

    private void Fire()
    {
        if (perkScript.isStaticPerk)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                perkScript.InstantiateStaticPerk(transform);
            }
            else if(Input.GetButtonUp("Fire2"))
            {
                perkScript.DestroyStaticPerk();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire2"))
            {
                firePerkCoroutine = StartCoroutine(FireToggleKinematic(perkScript));
            }
            else if (Input.GetButtonUp("Fire2"))
            {
                StopCoroutine(firePerkCoroutine);
            }
        }
    }

    private IEnumerator FireToggleKinematic(Perk perkScript)
    {
        while (true)
        {
            perkScript.InstantiateKinematicPerk(transform);
            yield return new WaitForSeconds(perkScript.fireSpeed);
        }
    }
}
