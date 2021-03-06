﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unlockable : MonoBehaviour
{
    // Unlocked status
    public bool unlocked = false;

    public Sprite unlockedsprite;

    // Click handler for action
    public void OnMouseDown()
    {
        int manaCost = GameplayController.getGameplayOptions().unlockManaCost;
        GameActor player = GameplayController.getPlayer();

        // Checking if action should be performed
        if (GameplayController.getCurrentAction() == GameplayController.PlayerAction.UNLOCK_ACTION)
        {
            // Checking available mana and unlock status
            if (player.getMana() < manaCost || unlocked || player.getHealth() < 0.1f) return;

            // Disabling collider
            Collider2D attachedCollider = GetComponent<Collider2D>();
            if (attachedCollider) attachedCollider.enabled = false;
            unlocked = true;

            // Changing sprite
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.sprite = GameplayController.getGameplayOptions().unlockedDoorSprite;

            // Spending mana from player mana pool
            player.setMana(player.getMana() - manaCost);

            GetComponent<SpriteRenderer>().sprite = unlockedsprite;
        }
    }
}
