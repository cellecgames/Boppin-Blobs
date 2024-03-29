﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomizationManager : MonoBehaviour
{
    enum ApearanceDetail
    {
        HAT,
        EYE,
        WEAPON,
        SKIN_COLOR
    }

    [SerializeField] private GameObject player;

    public GameObject[] hatModels;
    public int hatIndex;
    public GameObject activeHat;

    public Material[] eyeModels;
    public int eyeIndex;

    public GameObject[] weaponModels;
    public int weaponIndex;
    public GameObject activeWeapon;

    public Material[] skinColor;
    public int colorIndex;

    [Header("Player name input")]
    public TMP_InputField playerNameInputField;

    private void Start()
    {
        hatIndex = PlayerPrefs.GetInt("hatIndex", hatIndex);
        eyeIndex = PlayerPrefs.GetInt("eyeIndex", eyeIndex);
        colorIndex = PlayerPrefs.GetInt("colorIndex", colorIndex);

        string playerName = PlayerPrefs.GetString("PLAYER_INPUT_NAME");
        if(playerName != "") {
            playerNameInputField.text = playerName;
        }
    }

    private void ApplyModification(ApearanceDetail detail, int id)
    {
        switch (detail)
        {
            case ApearanceDetail.HAT:

                if (activeHat != null)
                {
                    Destroy(activeHat);
                }
                activeHat = Instantiate(hatModels[id], player.transform);
                activeHat.transform.localPosition = Vector3.zero;
                activeHat.transform.localScale = Vector3.one;
                break;

            case ApearanceDetail.EYE:

                Material[] mat = player.GetComponent<MeshRenderer>().materials;
                mat[1] = eyeModels[id];
                player.GetComponent<MeshRenderer>().materials = mat;
                break;

            case ApearanceDetail.WEAPON:

                if (activeWeapon != null)
                {
                    Destroy(activeWeapon);
                }
                activeWeapon = Instantiate(weaponModels[id], player.transform.parent.parent);
                activeWeapon.transform.localPosition = Vector3.left;
                break;

            case ApearanceDetail.SKIN_COLOR:

                player.GetComponent<MeshRenderer>().material = skinColor[id];
                break;
        }
    }

    public void NextHat()
    {
        if (hatIndex < hatModels.Length -1)
        {
            hatIndex++;
        }
        else
        {
            hatIndex = 0;
        }

        ApplyModification(ApearanceDetail.HAT, hatIndex);
    }

    public void PreviousHat()
    {
        if (hatIndex > 0)
        {
            hatIndex--;
        }
        else
        {
            hatIndex = hatModels.Length - 1;
        }

        ApplyModification(ApearanceDetail.HAT, hatIndex);
    }

    public void NextEye()
    {
        if (eyeIndex < eyeModels.Length - 1)
        {
            eyeIndex++;
        }
        else
        {
            eyeIndex = 0;
        }

        ApplyModification(ApearanceDetail.EYE, eyeIndex);
    }

    public void PreviousEye()
    {
        if (eyeIndex > 0)
        {
            eyeIndex--;
        }
        else
        {
            eyeIndex = eyeModels.Length - 1;
        }

        ApplyModification(ApearanceDetail.EYE, eyeIndex);
    }

    public void NextWeapon()
    {
        if (weaponIndex < weaponModels.Length - 1)
        {
            weaponIndex++;
        }
        else
        {
            weaponIndex = 0;
        }

        ApplyModification(ApearanceDetail.WEAPON, weaponIndex);
    }

    public void PreviousWeapon()
    {
        if (weaponIndex > 0)
        {
            weaponIndex--;
        }
        else
        {
            weaponIndex = weaponModels.Length - 1;
        }

        ApplyModification(ApearanceDetail.WEAPON, weaponIndex);
    }

    public void NextColor()
    {
        if (colorIndex < skinColor.Length -1)
        {
            colorIndex++;
        }
        else
        {
            colorIndex = 0;
        }
        ApplyModification(ApearanceDetail.SKIN_COLOR, colorIndex);
    }

    public void PreviousColor()
    {
        if (colorIndex > 0)
        {
            colorIndex--;
        }
        else
        {
            colorIndex = skinColor.Length - 1;
        }
        ApplyModification(ApearanceDetail.SKIN_COLOR, colorIndex);
    }

    public void Equip()
    {
        CustomizeData.instance.hatIndex = this.hatIndex;
        CustomizeData.instance.eyeIndex = this.eyeIndex;
        CustomizeData.instance.colorIndex = this.colorIndex;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("Confirmed");

        // Save the data to PlayerPrefs as well
        PlayerPrefs.SetInt("hatIndex", hatIndex);
        PlayerPrefs.SetInt("eyeIndex", eyeIndex);
        PlayerPrefs.SetInt("weaponIndex", weaponIndex);
        PlayerPrefs.SetInt("colorIndex", colorIndex);


        PlayerPrefs.SetString("PLAYER_INPUT_NAME", playerNameInputField.text);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (GameObject.FindGameObjectWithTag("CustomizePlayer"))
        {
            player = GameObject.FindGameObjectWithTag("CustomizePlayer");
        }
    }
}
