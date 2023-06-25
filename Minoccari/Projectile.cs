using System;
using System.Drawing;
using Microsoft.VisualBasic;

namespace Project
{
    public class Projectile
    {
        private Rectangle hitbox;
        private Point position;
        private int damage;
        private int speed;
        private Image currentSprite;
        private Point initialPos;

        public Projectile(int damage, Point position, string type, Entity target)
        {
            this.damage = damage;
            this.position = position;
            this.initialPos = new Point((Size)position);
            if (type == "Arrow")
            {
                this.speed = 4;
                this.hitbox = new Rectangle(this.position, new Size(10, 5));
                try
                {
                    this.currentSprite = Image.FromFile("Assets/Projectile/Arrow.png");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            else if (type == "Boulder")
            {
                this.speed = 4;
                this.hitbox = new Rectangle(this.position, new Size(15, 15));
                try
                {
                    this.currentSprite = Image.FromFile("Assets/Projectile/Boulder.png");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        public void Hit(Entity target)
        {
            target.IncomeDamage(this.damage);
        }

        public void Move(Entity target)
        {
            this.position.X += this.speed;
            this.position.Y += (int)this.GetTrajectory(target);
            this.hitbox.Location = this.position;
        }

        public bool CheckCollide(Entity enemy)
        {
            return this.hitbox.IntersectsWith(enemy.GetHitbox());
        }

        public bool CheckDistance()
        {
            if (this.position.X - this.initialPos.X > 200)
            {
                return true;
            }
            return false;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(this.currentSprite, this.position.X, this.position.Y);
        }

        public Rectangle GetHitbox()
        {
            return hitbox;
        }

        public Point GetPosition()
        {
            return this.position;
        }

        public Point GetInitialPos()
        {
            return this.initialPos;
        }

        public int GetDamage()
        {
            return damage;
        }

        public int GetSpeed()
        {
            return speed;
        }

        public Image GetCurrentSprite()
        {
            return this.currentSprite;
        }

        public double GetTrajectory(Entity target)
        {
            double Dx = target.GetPosition().X - this.position.X;
            double Dy = 40 + target.GetPosition().Y - this.position.Y;
            return ((double)speed * Dy) / Dx;
        }
    }
}
