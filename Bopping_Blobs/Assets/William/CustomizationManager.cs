﻿using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private GameObject[] hatModels;
    [SerializeField] private int hatIndex;
    [SerializeField] private GameObject activeHat;

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
                activeHat.transform.localPosition = Vector3.zero + new Vector3(0,0.75f,0);
                break;
            case ApearanceDetail.EYE:

                break;
            case ApearanceDetail.WEAPON:

                break;
            case ApearanceDetail.SKIN_COLOR:

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
}
