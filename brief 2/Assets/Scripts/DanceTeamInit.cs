using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// This class generates and assigns names to the 2 dance teams in our dance off battle.
/// It also controls the number of dancers on each team via the inspector
/// It also uses the name generator to pass character names to the teams so they can initialise
/// 
/// TODO:
///     Generate unique team names for both teams and assign them via team_.SetTroupeName(str);
///     Use the nameGenerator to get enough names for the number of dancers on both teams and pass the required names via array to each team for init (InitaliseTeamFromNames)
/// </summary>
public class DanceTeamInit : MonoBehaviour
{
    public DanceTeam teamA, teamB;

    public GameObject dancerPrefab;
    public int dancersPerSide = 3;
    public CharacterNameGenerator nameGenerator;
    private CharacterName[] teamANames;
    private CharacterName[] teamBNames;

    private void OnEnable()
    {
        GameEvents.OnBattleInitialise += InitTeams;
    }
    private void OnDisable()
    {
        GameEvents.OnBattleInitialise -= InitTeams;
    }
   
    void InitTeams()
    {
        Debug.LogWarning("InitTeams called, needs to generate names for the teams and set them with teamA.SetTroupeName");
        teamA.SetTroupeName("Team Awesome");
        teamANames = nameGenerator.GenerateNames(dancersPerSide);
        teamA.InitialiseTeamFromNames(dancerPrefab, 0, teamANames);

        teamB.SetTroupeName("Team Bestest");
        teamBNames = nameGenerator.GenerateNames(dancersPerSide);
        teamB.InitialiseTeamFromNames(dancerPrefab, 0, teamBNames);

        Debug.LogWarning("InitTeams called, needs to create character names via CharacterNameGenerator and get them into the team.InitaliseTeamFromNames");
    }
}
