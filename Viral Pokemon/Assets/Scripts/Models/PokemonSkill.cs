using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonSkill
{
    public string skillName;
    public PokemonType skillType;
    public int skillPower;
    public int skillAccurate;
    public int skillPP;
    public string skillEffect;

    public PokemonSkill(string name, PokemonType type, int power, int acc, int pp, string eff)
    {
        this.skillName = name;
        this.skillType = type;
        this.skillPower = power;
        this.skillAccurate = acc;
        this.skillPP = pp;
        this.skillEffect = eff;
    }
}

