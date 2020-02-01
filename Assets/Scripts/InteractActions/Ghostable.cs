﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ghostable : MonoBehaviour
{
    public GameplayController gameplayController;

    // Mana cost of action
    public const int ghostManaCost = 20;

    // Click handler for action
    public void OnPointerClick(PointerEventData eventData)
    {
        // Checking if action should be performed
        if(gameplayController.currentAction == GameplayController.PlayerAction.GHOST_ACTION)
        {
            // Spending mana from player mana pool
            gameplayController.playerMana -= ghostManaCost;

            // Rest of the action...
        }
    }
}