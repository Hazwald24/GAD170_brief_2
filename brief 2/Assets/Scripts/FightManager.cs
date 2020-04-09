using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Functions to complete:
/// - Attack
/// </summary>
public class FightManager : MonoBehaviour
{
    public BattleSystem battleSystem; //A reference to our battleSystem script in our scene
    public Color drawCol = Color.gray; // A colour you might want to set the battle log message to if it's a draw.
    private float fightAnimTime = 2; //An amount to wait between initiating the fight, and the fight begining, so we can see some of that sick dancing.


    IEnumerator Attack(Character teamACharacter, Character teamBCharacter)
    {
        Character winner;
        Character defeated;

        float charAPoints, charBPoints;
        charAPoints = (float)teamACharacter.ReturnBattlePoints();
        charBPoints = (float)teamBCharacter.ReturnBattlePoints();

        float outcome;

        if (charAPoints > charBPoints)
        {
            winner = teamACharacter;
            defeated = teamBCharacter;
            outcome = charAPoints / charBPoints - 1;
        }
        else
        {
            winner = teamBCharacter;
            defeated = teamACharacter;
            outcome = charBPoints / charAPoints - 1;
        }

        // Tells each dancer that they are selcted and sets the animation to dance.
        SetUpAttack(teamACharacter);
        SetUpAttack(teamBCharacter);

        // Tells the system to wait X number of seconds until the fight to begins.
        yield return new WaitForSeconds(fightAnimTime);

        BattleLog.Log("Fight is over! The winner is " + winner.charName.GetFullCharacterName() + " with a score of " + outcome, drawCol);

        // Pass on the winner/loser and the outcome to our fight completed function.
        FightCompleted(winner, defeated, outcome);
        yield return null;
    }

    #region Pre-Existing - No Modes Required
    /// <summary>
    /// Is called when two dancers have been selected and begins a fight!
    /// </summary>
    /// <param name="data"></param>
    public void Fight(Character TeamA, Character TeamB)
    {
        StartCoroutine(Attack(TeamA, TeamB));
    }

    /// <summary>
    /// Passes in a winning character, and a defeated character, as well as the outcome between -1 and 1
    /// </summary>
    /// <param name="winner"></param>
    /// <param name="defeated"></param>
    /// <param name="outcome"></param>
    private void FightCompleted(Character winner, Character defeated, float outcome)
    {
        var results = new FightResultData(winner, defeated, outcome);

        winner.isSelected = false;
        defeated.isSelected = false;

        battleSystem.FightOver(winner, defeated, outcome);
        winner.animController.BattleResult(winner, defeated, outcome);
        defeated.animController.BattleResult(winner, defeated, outcome);
    }

    /// <summary>
    /// Sets up a dancer to be selected and the animation to start dancing.
    /// </summary>
    /// <param name="dancer"></param>
    private void SetUpAttack(Character dancer)
    {
        dancer.isSelected = true;
        dancer.GetComponent<AnimationController>().Dance();
        BattleLog.Log(dancer.charName.GetFullCharacterName() + " Selected", dancer.myTeam.teamColor);
    }
    #endregion  
}