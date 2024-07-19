using System;
using System.Collections.Generic;
using System.Linq;

namespace FantasyBattle
{
    public class SimpleEnemy : Target
    {
        public virtual Armor Armor { get; }
        public virtual Buffs Buffs { get; }

        public SimpleEnemy() { }

        public SimpleEnemy(Armor armor, Buffs buffs)
        {
            Armor = armor;
            Buffs = buffs;
        }

        public int CalculateTotalSoak()
        {
            var totalSoak = ArmorDamageSoak() * BuffSoakModifier();
            return (int)Math.Round(totalSoak, 0);
        }

        private int ArmorDamageSoak() => Armor.DamageSoak;
        private float BuffSoakModifier() => Buffs.CalculateSoakModifier();
    }

    public class Buffs : List<Buff>
    {
        public float CalculateSoakModifier() 
            => this.Select(x => x.SoakModifier).Sum() + 1;
    }
    
    public interface Buff
    {
        float SoakModifier { get; }
        float DamageModifier { get; }
    }

    public interface Armor
    {
        int DamageSoak { get; }
    }
}