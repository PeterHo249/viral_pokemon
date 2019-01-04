using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonSkill
{
    public int id;
    public string skillName;
    public int type;
    public int power;
    public int pp;

    public PokemonSkill(int id, string name, int type, int power, int pp)
    {
        this.id = id;
        this.skillName = name;
        this.type = type;
        this.power = power;
        this.pp = pp;
    }
}
