﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Extinguishable : MonoBehaviour,
                              IPointerClickHandler
{
    public GameplayController gameplayController;

    // Mana cost of action
    public const int extinguishManaCost = 20;

    // Click handler for action
    public void OnPointerClick(PointerEventData eventData)
    {
        // Checking if action should be performed
        if (gameplayController.currentAction == GameplayController.PlayerAction.EXTINGUISH_ACTION)
        {
            // Checking available mana
            if (gameplayController.playerMana < extinguishManaCost) return;

            // Rest of the action...
            Collider attachedCollider = GetComponent<Collider>();
            if(attachedCollider) attachedCollider.enabled = false;

            // Spending mana from player mana pool
            gameplayController.playerMana -= extinguishManaCost;
        }
    }
}