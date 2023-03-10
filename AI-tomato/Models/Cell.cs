using AI_tomato.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace AI_tomato
{
    public class Cell
    {
        private Random _rand = new Random();
        // private List<Color> allowedColors = new List<Color>() { Color.Blue, Color.Red, Color.Purple, Color.Pink, Color.Aqua, Color.Chocolate, Color.Gold, Color.LightBlue, Color.LightYellow, Color.Yellow, Color.Orange, Color.Salmon };
        private const int MaxEnergy = 700;
        private const int ReproductionEnergy = 350;
        private const int EnergyPerFood = 450;
        private const int EnergyPerStep = 1;

        private const bool DoNotLetTheLastOneDie = true;
        private const bool EnableMaxAge = false;
        private const int MaxAge = 1000;

        private int _energy;
        private int _direction;
        private bool _isDead;

        //public Color _color { get; set; }
        public int Age { get; set; }
        public int Reproductions { get; set;  }
        public int X { get; set; }
        public int Y { get; set; }

        public bool IsDead
        {
            get { return _isDead; }
        }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            Reproductions = 0;
            Age = 0;

            _energy = MaxEnergy / 2;
            _direction = 0;
            //_color = Color.Yellow;
            _isDead = false;
        }

        public void Step(List<Food> foods, List<Cell> cells)
        {
            _energy -= EnergyPerStep;
            Age++;
            if (_energy <= 0 || (EnableMaxAge && Age > MaxAge))
            {
                if(DoNotLetTheLastOneDie && cells.Count <= 1)
                {
                    _energy += 100;
                    Move(foods);
                    return;
                }

                _isDead = true;
                return;
            }
            if (_energy >= ReproductionEnergy)
            {
                Reproduce(cells);
            }
            else
            {
                Move(foods);
            }
        }

        private void Move(List<Food> foods)
        {
            int dx = (int)Math.Round(Math.Cos(_direction * Math.PI / 2));
            int dy = (int)Math.Round(Math.Sin(_direction * Math.PI / 2));
            int x = X + dx;
            int y = Y + dy;
            if (x < 0 || x >= Form1.GridWidth || y < 0 || y >= Form1.GridHeight)
            {
                _direction = (_direction + 2) % 4;
                return;
            }
            Food food = foods.Find(f => f.X == x && f.Y == y);
            if (food != null)
            {
                _energy += EnergyPerFood;
                foods.Remove(food);
                X = x;
                Y = y;
                return;
            }
            X = x;
            Y = y;
            _direction = (_direction + _rand.Next(3) + 1) % 4;
        }

        private void Reproduce(List<Cell> cells)
        {
            Reproductions++;
            _energy -= ReproductionEnergy;
    //        Form1 form = (Form1)Application.OpenForms[0];
            cells.Add(new Cell(X, Y));
      //      form.AddCell(new Cell(X, Y));
        }
    }
}
