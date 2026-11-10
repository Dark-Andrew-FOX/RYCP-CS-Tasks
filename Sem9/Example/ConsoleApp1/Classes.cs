using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HarderProgram
{
    // Simplified version of the lecturer's example.
    public class Monster
    {
        // Public fields are included when IncludeFields = true.
        public string Name = "";
        public Stats Stats = new();

        // JsonInclude allows deserialization through the private setter.
        [JsonInclude]
        public int HP { get; private set; }

        // A parameterless constructor makes the example easier to follow.
        public Monster() { }

        public Monster(string name, Stats stats)
        {
            Name = name;
            Stats = stats;
            HP = stats.MaxHP;
        }

        public void TakeDamage(int damage)
        {
            HP = Math.Clamp(HP - Math.Max(damage, 0), 0, Stats.MaxHP);
        }
    }

    public class Stats
    {
        public float CritChance;
        public int AttackStrength;
        public int MaxHP;

        public Stats() { }

        public Stats(float critChance, int attackStrength, int maxHP)
        {
            CritChance = critChance;
            AttackStrength = attackStrength;
            MaxHP = maxHP;
        }
    }

}
