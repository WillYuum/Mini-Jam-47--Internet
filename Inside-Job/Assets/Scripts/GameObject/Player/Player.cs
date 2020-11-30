﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    void Start()
    {

    }


    [HideInInspector] public bool playerIsOverEntryPoint = false;
    [HideInInspector] public bool playerIsHoldingMessage = false;
    [HideInInspector] public bool playerIsOverRequestEntryPoint = false;


    public GameObject requestHolder;
    void Update()
    {
        if (playerIsOverEntryPoint)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("OVER HERE!!!" + playerIsHoldingMessage);
                if (!playerIsHoldingMessage)
                {
                    selectedEntry.GetMessageFromSlot(new Message().gameObject); //!Needs to be fixed, temp fix
                }
                else if (playerIsHoldingMessage && !playerIsOverRequestEntryPoint)
                {
                    GameObject message = requestHolder.transform.GetChild(0).gameObject;
                    selectedEntry.SetMessageToSlot(message);
                }
            }
        }
    }

    EntryPoint selectedEntry;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EntryPoint"))
        {
            playerIsOverEntryPoint = true;
            EntryPoint entryPoint = other.gameObject.GetComponent<EntryPoint>();
            selectedEntry = entryPoint;
            if (other.gameObject.CompareTag("RequestEntryPoint"))
            {
                Debug.LogWarning("over request point");
                playerIsOverRequestEntryPoint = true;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EntryPoint"))
        {
            playerIsOverEntryPoint = false;
            playerIsOverRequestEntryPoint = false;
        }
    }

}
