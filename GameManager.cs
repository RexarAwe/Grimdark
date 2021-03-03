// managers the game flow and all other components

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject penguinViking;

    public int turn;
    [SerializeField] public List<GameObject> units;
    private int unitID = 0;

    private MapManager mapManager;
    private GameObject StartCombatBT;
    private GameObject EndCombatBT;

    void Start()
    {
        mapManager = GameObject.Find("Map Manager").GetComponent<MapManager>();
        StartCombatBT = GameObject.Find("Start Combat BT");
        EndCombatBT = GameObject.Find("End Combat BT");
        StartCombatBT.SetActive(false);
        EndCombatBT.SetActive(false);

        mapManager.Init();
        SpawnPC();

        units[0].GetComponent<UnitMovement>().Move();
    }

    public void InitBattle()
    {
        // roll to see initiative
    }

    public void EndBattle()
    {
        units[0].GetComponent<UnitGeneral>().SetOOC(true);
        StartCombatBT.SetActive(false);
        EndCombatBT.SetActive(false);

        units[0].GetComponent<UnitMovement>().Move();
    }

    private void SpawnPC()
    {
        GameObject unit;
        UnitGeneral generalUnit;
        UnitMovement movementUnit;
        UnitCombat combatUnit;

        unit = Instantiate(penguinViking, new Vector3(0, 0, 0), transform.rotation);

        movementUnit = unit.GetComponent<UnitMovement>();
        movementUnit.Init(2);

        Debug.Log("Unit location: " + movementUnit.GetLoc());

        generalUnit = unit.GetComponent<UnitGeneral>();
        generalUnit.Init(unitID, 0, 10, 2);

        combatUnit = unit.GetComponent<UnitCombat>();
        combatUnit.Init();

        AddUnit(unit);
        unitID++;
    }

    public void AddUnit(GameObject unit) // add the unit to the unit tracking list
    {
        units.Add(unit);
    }

    public void CombatTrigger()
    {
        units[0].GetComponent<UnitGeneral>().SetOOC(false);
        StartCombatBT.SetActive(true);
        EndCombatBT.SetActive(true);
    }
}
