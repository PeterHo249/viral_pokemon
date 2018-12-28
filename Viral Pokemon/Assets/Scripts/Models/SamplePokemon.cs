using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PokemonType
{
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Posion,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon,
    Dark,
    Steel,
    Fairy
}

public class SamplePokemon
{
    public string pokemonName;
    public int hp;
    public int attack;
    public int defense;
    public int spAttack;
    public int spDefense;
    public int speed;
    public List<PokemonType> pokemonType;
    public List<PokemonSkill> pokemonSkill;

    public SamplePokemon(string name, int hp, int atk, int def, int spAtk, int spDef, int spd)
    {
        this.pokemonName = name;
        this.hp = hp;
        this.attack = atk;
        this.defense = def;
        this.spAttack = spAtk;
        this.spDefense = spDef;
        this.speed = spd;
        this.pokemonType = new List<PokemonType>();
        this.pokemonSkill = new List<PokemonSkill>();
    }
}
