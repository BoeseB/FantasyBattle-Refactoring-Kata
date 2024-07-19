using System;
using System.Linq;

namespace FantasyBattle
{
    public class Player : Target
    {
        public Inventory Inventory { get; }
        public Stats Stats { get; }

        public Player(Inventory inventory, Stats stats)
        {
            Inventory = inventory;
            Stats = stats;
        }

        public Damage CalculateDamage(Target other)
        {
            var totalDamage = CalculateTotalDamage();

            int soak = GetSoak(other, totalDamage);
            return new Damage(Math.Max(0, totalDamage - soak));
        }

        private int CalculateTotalDamage()
        {
            int baseDamage = CalculateBaseDamage();
            float damageModifier = CalculateDamageModifier();
            var totalDamage = baseDamage * damageModifier;
            return (int)Math.Round(totalDamage, 0);
        }

        private int CalculateBaseDamage() => Inventory.CalculateBaseDamage();

        private float CalculateDamageModifier()
        {
            var equipmentModifier = Inventory.CalculateDamageModifier();
            var strengthModifier = Stats.CalculateDamageModifier();
            return strengthModifier + equipmentModifier;
        }

        private int GetSoak(Target other, int totalDamage)
        {
            int soak = 0;
            if (other is Player)
            {
                // TODO: Not implemented yet
                //  Add friendly fire
                soak = totalDamage;
            }
            else if (other is SimpleEnemy simpleEnemy)
            {
                soak = simpleEnemy.CalculateTotalSoak();
            }

            return soak;
        }
    }
}