using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Functions to complete:
/// - Return Battle Points
/// - Deal Damage
/// </summary>
public class Character : MonoBehaviour
{
    public CharacterName charName; // This is a reference to an instance of the characters name script.

    [Range(0.0f, 1.0f)]
    public float mojoRemaining = 1; // This is the characters hp this is a float 0-100 but is normalised to 0.0 - 1.0;

    [Header("Stats")]
    public int availablePoints = 10; // The total amount of points we want to assign to our stats!

    public int level; // This is optional if you want to expand on this to level up your characters and stuff welcome to.
    public int currentXP; // This is optional as well if you want to expand on this brief to assign xp etc!
    public int style, luck, rhythm;


    [Header("Related objects")]
    public DanceTeam myTeam; // This holds a reference to the characters current dance team instance they are assigned to.

    public bool isSelected; // This is used for determining if this character is selected in a battle.

    [SerializeField]
    protected TMPro.TextMeshPro nickText; // This is just a piece of text in Unity,  to display the characters name.

    public AnimationController animController; // A reference to the animationController, is used to switch dancing states.

    // This is called once, this then calls Initial Stats function
    void Awake()
    {
        InitialStats();
        animController = GetComponent<AnimationController>();
    }

    /// <summary>
    /// A function used to handle setting the intial stats of our game at the begining of the game.
    /// </summary>
    private void InitialStats()
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

    /// <summary>
    /// We probably want to use this to remove some hp (mojo) from our character.....
    /// Then we probably want to check to see if they are dead or not from that damage and return true or false.
    /// </summary>
    public void DealDamage(float amount)
    {
        mojoRemaining -= amount;

        if (mojoRemaining <= 0)
        {
            myTeam.RemoveFromActive(this);
        }
    }

    /// <summary>
    /// Used to generate a number of battle points that is used in combat.
    /// </summary>
    /// <returns></returns>
    public int ReturnBattlePoints()
    {
        int battlePoints = 0;
        for (int i = 0; i < style; i++)
        {
            battlePoints += Random.Range(0, 7);
        }
        for (int i = 0; i < rhythm; i++)
        {
            battlePoints += Random.Range(2, 5);
        }
        int danceCritChance = luck * 5;
        if (Random.Range(0, 101) <= danceCritChance)
        {
            battlePoints += battlePoints / 2;
        }
        return battlePoints;
    }

    /// <summary>
    /// A function called when the battle is completed and some xp is to be awarded.
    /// Takes in and store in BattleOutcome from the BattleHandler script which is how much the player has won by.
    /// By Default it is set to 100% victory.
    /// </summary>
    public void CalculateXP(float BattleOutcome)
    {

    }

    /// <summary>
    /// A function used to handle actions associated with levelling up.
    /// </summary>
    private void LevelUp()
    {

    }

    /// <summary>
    /// A function used to assign a random amount of points ot each of our skills.
    /// </summary>
    public void AssignSkillPointsOnLevelUp(int PointsToAssign)
    {

    }

    /// <summary>
    /// Is called inside of our DanceTeam.cs is used to set the characters name!
    /// </summary>
    /// <param name="characterName"></param>
    public void AssignName(CharacterName characterName)
    {
        charName = characterName;
        if (nickText != null)
        {
            nickText.text = charName.nickname;
            nickText.transform.LookAt(Camera.main.transform.position);
            //text faces the wrong way so
            nickText.transform.Rotate(0, 180, 0);
        }
    }
}