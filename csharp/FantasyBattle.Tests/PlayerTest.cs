using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;

namespace FantasyBattle.Tests
{
    public class PlayerTest
    {
        [Fact]
        public void DamageCalculations()
        {
            var player = new Player(
                new Inventory(new Equipment(
                    new BasicItem("round shield", 0, 1.4f),
                    new BasicItem("excalibur", 20, 1.5f),
                    new BasicItem("helmet of swiftness", 0, 1.2f),
                    new BasicItem("ten league boots", 0, 0.1f),
                    new BasicItem("breastplate of steel", 0, 1.4f))),
                new Stats(0));

            var target = new SimpleEnemy(
                new SimpleArmor(5),
                [new BasicBuff(1.0f, 1.0f)]);

            Damage damage = player.CalculateDamage(target);

            Assert.Equal(102, damage.Amount);
        }
    }
}