using System.Drawing;
using Microsoft.VisualBasic;
//using TowerDefense.Entities.Api;

namespace Project
{
    public class Turret : RangedEntity
    {
        static int cost = 200;

        public Turret() : base(new Point(120, 400), 1, 8000, 500, "turret", cost)
        {
            base.ResizeRangebox(500, 200);
            base.ResizeHitbox(20, 200);
        }

        public override void UpdatePosition()
        {

        }

        public static int GetCost()
        {
            return cost;
        }
    }

    public class RangedEntity : MovingEntity
    {
        private Rectangle rangeBox;
        private long lastTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        private long currentTime;
        private string projectileType;
        private LinkedList<Projectile> projectiles = new LinkedList<Projectile>();
        private bool started = false;

        public RangedEntity(Point startPoint, int speed, int hp, int damage, string nameEntity, int cost) : base(startPoint, speed, hp, damage, nameEntity, cost)
        {
            rangeBox = new Rectangle(startPoint.X, startPoint.Y, 400, 80);
            currentTime = lastTime + 6000;
            if (nameEntity == "Archer")
            {
                projectileType = "Arrow";
            }
            else if (nameEntity == "Turret")
            {
                projectileType = "Boulder";
            }
            else {
                projectileType = "";
            }
        }

        public virtual void UpdatePosition()
        {

        }

        public void ResizeRangebox(int x, int y)
        {
            rangeBox.Size = new Size(x, y);
        }

        public override int GetDamage()
        {
            throw new NotImplementedException();
        }

        public override Rectangle GetHitbox()
        {
            throw new NotImplementedException();
        }

        public override int GetHp()
        {
            throw new NotImplementedException();
        }

        public override Point GetPosition()
        {
            throw new NotImplementedException();
        }

        public override int GetSpeed()
        {
            throw new NotImplementedException();
        }

        public override void IncomeDamage(int value)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class MovingEntity : Entity
    {
        private Point position;
        private Rectangle hitbox;
        private int speed;
        private int hp;
        private int damage;
        private int currentSpriteWalk = 0;
        private int currentSpriteAttack = 0;
        private long lastTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        private long lastTimeAttack;
        private string nameEntity;

        public MovingEntity(Point startPoint, int speed, int hp, int damage, string nameEntity, int cost)
        {
            position = new Point(startPoint.X, startPoint.Y);
            hitbox = new Rectangle(startPoint.X, startPoint.Y, 80, 80);
            this.speed = speed;
            this.hp = hp;
            this.damage = damage;
            lastTimeAttack = lastTime;
            this.nameEntity = nameEntity;
            //UpdateSprite(Constants.Walk);
        }

        public abstract int GetDamage();
        public abstract Rectangle GetHitbox();
        public abstract int GetHp();
        public abstract Point GetPosition();
        public abstract int GetSpeed();
        public abstract void IncomeDamage(int value);

        public void ResizeHitbox(int x, int y)
        {
            hitbox.Size = new Size(x, y);
        }

        

    }
    public interface Entity
    {
        /**
     * @return the current position of the entity, expressed by 2 coordinates
     */
        public Point GetPosition();

        /**
         * @return the speed of the entity
         */
        public int GetSpeed();

        /**
         * @return the current HP of the entity
         */
        public int GetHp();

        /**
         * @return the damage that the entity deals
         */
        public int GetDamage();

        /**
         * Calculates the incoming damage from another entity's attack
         *
         * @param value
         *          the amount of incoming damage
         */
        public void IncomeDamage(int value);

        /**
         * @return the hitbox of the entity, expressed by a rectangle
         */
        public Rectangle GetHitbox();
    }
}