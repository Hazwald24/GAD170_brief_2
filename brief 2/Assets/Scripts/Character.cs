using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a single character, their stats, name and current mojo (or hp) in the dance battle.
/// 
/// TODO:
///     Initialise stats for the character that will be used to determine their victory in dance offs.
///     You may wish or need to add additional stats here for use in the fight (FightManager)
///     May need to handle the loss of mojo when loosing a fight
/// </summary>
public class Character : MonoBehaviour
{
    public CharacterName charName;

    [Range(0.0f,1.0f)]
    public float mojoRemaining = 1;

    [Header("Stats")]
    public int availablePoints = 10;

    public int level;
    public int xp;
    public int style, luck, rhythm;


    [Header("Related objects")]
    public DanceTeam myTeam;

    public bool isSelected;

    [SerializeField]
    protected TMPro.TextMeshPro nickText;


    void Awake()
    {
        InitialStats();
    }

    public void InitialStats()
    {
        level = 1;

        int statChoice;

        for (int i = 0; i < 10; i++)
        {
            statChoice = Random.Range(0, 3);
            switch (statChoice)
            {
                case 0:
                    style++;
                    break;
                case 1:
                    luck++;
                    break;
                case 2:
                    rhythm++;
                    break;
            }
        }
    }

    public void AssignName(CharacterName characterName)
    {
        charName = characterName;
        if(nickText != null)
        {
            nickText.text = charName.nickname;
            nickText.transform.LookAt(Camera.main.transform.position);
            //text faces the wrong way so
            nickText.transform.Rotate(0, 180, 0);
        }
    }
}
