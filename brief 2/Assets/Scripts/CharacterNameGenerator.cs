﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Functions to complete:
/// - Generate Names
/// </summary>
public class CharacterNameGenerator : MonoBehaviour
{

    [Header("Possible first names")]
    public List<string> firstNames; // These appear in the inspector, you should be assigning names to these in the inspector.
    [Header("Possible last names")]
    public List<string> lastNames;
    [Header("Possible nicknames")]
    public List<string> nicknames;
    [Header("Possible adjectives to describe the character")]
    public List<string> descriptors;

    /// <summary>
    /// Returns an Array of Character Names based on the number of namesNeeded.
    /// </summary>
    /// <param name="namesNeeded"></param>
    /// <returns></returns>
    public CharacterName[] GenerateNames(int namesNeeded)
    {
        Debug.LogWarning("CharacterNameGenerator called, it needs to fill out the names array with unique randomly constructed character names");
        CharacterName[] names = new CharacterName[namesNeeded];
        string firstName, lastName, nickname, descriptor;


        for (int i = 0; i < names.Length; i++)
        {
            firstName = firstNames[Random.Range(0, firstNames.Count)];
            lastName = lastNames[Random.Range(0, lastNames.Count)];
            nickname = nicknames[Random.Range(0, nicknames.Count)];
            descriptor = descriptors[Random.Range(0, descriptors.Count)];
            names[i] = new CharacterName(firstName, lastName, nickname, descriptor);
        }

        //Returns an array of names that we just created.
        return names;
    }
}