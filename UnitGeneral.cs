// Unit status effects, hp, and exp

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGeneral : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private int allegiance; // friend or enemy
    [SerializeField] private int hp;
    [SerializeField] private int actions;
    [SerializeField] private int remActions;
    [SerializeField] private int status;

    [SerializeField] private bool OOC; // out of combat

    UnitMovement movementUnit;

    //[SerializeField] private GameObject hpBar; // prefab storage
    //private GameObject healthBar; // actual reference
    //private HpBar hpBarScript;

    public void Init(int id_val, int allegiance_val, int hp_val, int actions_val)
    {
        id = id_val;
        allegiance = allegiance_val;
        hp = hp_val;
        actions = actions_val;
        remActions = actions_val;
        OOC = true;
    }

    // focus camera on this unit
    public void Focus()
    {
        Camera.main.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, Camera.main.transform.position.z);
    }

    public int GetHP()
    {
        return hp;
    }

    public int GetID()
    {
        return id;
    }

    public int GetStatus()
    {
        return status;
    }

    public int GetActions()
    {
        return actions;
    }

    public void SetActions(int actions_val)
    {
        actions = actions_val;
    }

    public int GetRemActions()
    {
        return remActions;
    }

    public void SetRemActions(int act_val)
    {
        remActions = act_val;
    }

    public void RestoreActions()
    {
        remActions = actions;
    }

    public bool GetOOC()
    {
        return OOC;
    }

    public void SetOOC(bool val)
    {
        OOC = val;
    }
}
