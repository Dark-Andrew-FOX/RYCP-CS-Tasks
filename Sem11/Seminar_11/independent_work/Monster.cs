using System;
using System.Collections.Generic;
using System.Text;

namespace independent_work
{
    public class Monster
    {
        public string Name { get; }
        public int MaxHP { get; }
        public int AttackStrength { get; }

        public bool IsDead => HP == 0;

        // Здесь добавьте события по изменению здоровья и смерти.
        //.

        private int _hp;

        public int HP
        {
            get => _hp;

            private set
            {
                int oldHP = _hp;
                int newHP = Math.Clamp(value, 0, MaxHP);

                if (oldHP == newHP)
                    return;

                _hp = newHP;

                HPChanged?.Invoke(this, oldHP, newHP); // Вызов события здоровья.

                if (oldHP > 0 && newHP == 0)
                    Died?.Invoke(this); // Вызов события смерти.
            }
        }

        public Monster(string name, int maxHP, int attackStrength)
        {
            Name = name;
            MaxHP = Math.Max(1, maxHP);
            AttackStrength = Math.Max(0, attackStrength);

            _hp = MaxHP;
        }

        public void TakeDamage(int damage)
        {
            HP -= Math.Max(0, damage);
        }
    }
}
