using MoreLinq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    internal class AsteroidMap
    {
        private List<Asteroid> asteroids;

        public AsteroidMap()
        {
            this.asteroids = new List<Asteroid>();
        }

        public void Add(Asteroid asteroid)
        {
            this.asteroids.Add(asteroid);
        }

        public int MaxNumberOfVisibleAsteroids()
        {
            var x = this.asteroids.MaxBy(a => NumberOfVisibleAsteroids(a));
            Asteroid maxDetectionAsteroid = x.First();
            int numberOfVisibleAsteroids = NumberOfVisibleAsteroids(maxDetectionAsteroid);
            return numberOfVisibleAsteroids;
        }

        public int AsteroidVaporizedAt200()
        {
            Asteroid maxDetectionAsteroid = this.asteroids.MaxBy(a => NumberOfVisibleAsteroids(a)).First();
            this.asteroids.Remove(maxDetectionAsteroid);
            double degree = 0;
            int destroyed = 0;
            while (this.asteroids.Count() > 0)
            {
                var destroy = this.asteroids
                    .MinBy(a => Degree(maxDetectionAsteroid, a, degree))
                    .Where(a => IsClearLineOfSight(maxDetectionAsteroid, a))
                    .First();
                degree += Degree(maxDetectionAsteroid, destroy, degree);
                degree += 0.00001;
                degree %= 360;

                destroyed++;

                if (destroyed == 200)
                {
                    return destroy.X * 100 + destroy.Y;
                }

                this.asteroids.Remove(destroy);
            }
            return 0;
        }

        private double Degree(Asteroid a, Asteroid b, double offset)
        {
            double degree = Angle(a, b);
            degree -= offset;
            if (degree < 0)
            {
                degree += 360;
            }
            return degree;
        }

        private int NumberOfVisibleAsteroids(Asteroid a)
        {
            return this.asteroids.Where(b => !b.Equals(a) && this.IsClearLineOfSight(a, b)).Count();
        }

        private bool IsClearLineOfSight(Asteroid a, Asteroid b)
        {
            return !this.asteroids.Exists(c => !c.Equals(a) && !c.Equals(b) && IsBetween(a, b, c));
        }

        private bool IsBetween(Asteroid a, Asteroid b, Asteroid c)
        {
            if (!((a.X <= c.X && c.X <= b.X) || (b.X <= c.X && c.X <= a.X)))
            {
                return false;
            }
            if (!((a.Y <= c.Y && c.Y <= b.Y) || (b.Y <= c.Y && c.Y <= a.Y)))
            {
                return false;
            }
            if (a.X == b.X)
            {
                return a.X == c.X;
            }
            if (a.Y == b.Y)
            {
                return a.Y == c.Y;
            }
            int dX = b.X - a.X;
            int dY = b.Y - a.Y;
            double delta = (double)dY / (double)dX;
            return Math.Abs(c.Y - (a.Y + delta * (c.X - a.X))) <= 0.0001;
        }

        private double Angle(Asteroid a, Asteroid b)
        {
            int dX = b.X - a.X;
            int dY = b.Y - a.Y;
            double result = Math.Atan2(dY, dX) * (180 / Math.PI);
            if (result < 0)
            {
                result += 360;
            }
            result += 90;
            result %= 360;
            return result;
        }
    }

    internal class Asteroid : IEquatable<Asteroid>
    {
        public int X { get; }
        public int Y { get; }

        public Asteroid(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool Equals([AllowNull] Asteroid other)
        {
            return this.X == other.X && this.Y == other.Y;
        }
    }
}