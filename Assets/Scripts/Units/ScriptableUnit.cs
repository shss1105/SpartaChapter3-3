using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "new Unit", menuName = "scriptable Unit")]
public class ScriptableUnit : ScriptableObject
{
    public Faction Faction;
    public BaseUnit UnitPrefab; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum Faction
{
    Hero = 0,
    Enemy = 1
}
