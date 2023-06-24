using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    class MovingEntity : IEntity
    {
        private readonly int _speed;
        private int _hp;
        private readonly int _damage;
        private readonly string _nameEntity;

        public MovingEntity (int speed, int hp, int damage, string nameEntity)
        {
            _speed = speed;
            _hp = hp;
            _damage = damage;
            _nameEntity = nameEntity;
        }

        public int GetDamage()
        {
            return _damage;
        }

        public int GetHp()
        {
            return _hp;
        }

        public int GetSpeed()
        {
            return _speed;
        }

        public void IncomeDamage(int value)
        {
            _hp = _hp - value;
        }
        public string GetNameEntity()
        {
            return _nameEntity;
        }
    }
}
