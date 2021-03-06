﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayButtonController : MonoBehaviour,
                                    IPointerClickHandler
{
    public GameObject menuBar;
    public GameObject teamBar;
    public GameObject actionBar;
    public GameObject generator;
    public InputField playerName;

    public void OnPointerClick(PointerEventData eventData)
    {
        

        // Random.seed = ???
        Random.seed = playerName.text.GetHashCode();

        // Generate map
        generator.GetComponent<GeneratorEntity>().GenerateMap(4, 30);

        // Switch GUI items
        menuBar.SetActive(false);
        teamBar.SetActive(true);
        actionBar.SetActive(true);

        // Activate player
        GameplayController.getPlayer().GetComponent<SpriteRenderer>().enabled = true;
        GameplayController.getPlayer().GetComponent<PlayerControllable>().enabled = true;

        GameplayController.setGameState(GameplayController.GameState.PLAY_STATE);
    }
}
