using AI_tomato.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AI_tomato
{
    public partial class Form1 : Form
    {

        public const int GridWidth = 40;
        public const int GridHeight = 30;
        private const int InitialNumFoods = 15;
        private const int NumCells = 5;
        private const int HistoryChartMaxSize = 200;
        //private const int NumSteps = 200;

        private List<Cell> _cells;
        private List<Food> _foods;
        private int deadCells;
        private int MaxAgeCell = 0;
        private int MaxReproductions = 0;
        private int _step = 0;
        private Random _rand;
        private Button[,] _buttons;
        private Timer _timer;

        public Form1()
        {
            InitializeComponent();
            _cells = new List<Cell>();
            _foods = new List<Food>();
            _rand = new Random();
            _buttons = new Button[GridWidth, GridHeight];
            _timer = new Timer();
            _timer.Interval = 1;
            _timer.Tick += OnTimerTick;

            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    Button button = new Button();
                    button.Size = new Size(20, 20);
                    button.Location = new Point(x * 20, y * 20);
                    button.BackColor = Color.White;
                    button.Click += OnGridButtonClick;
                    _buttons[x, y] = button;
                    Controls.Add(button);
                }
            }

            for (int i = 0; i < InitialNumFoods; i++)
            {
                int x = _rand.Next(GridWidth);
                int y = _rand.Next(GridHeight);
                _foods.Add(new Food(x, y));
                _buttons[x, y].BackColor = Color.Green;
            }

            for (int i = 0; i < NumCells; i++)
            {
                int x = _rand.Next(GridWidth);
                int y = _rand.Next(GridHeight);
                _cells.Add(new Cell(x, y));
                _buttons[x, y].BackColor = Color.FromArgb(_rand.Next(0, 256), _rand.Next(0, 256), 0);
            }


            UpdateGrid();
        }

        private void UpdateCounters()
        {
            cellCountLabel.Text = $"Células vivas: {_cells.Count}";
            foodCountLabel.Text = $"Comida: {_foods.Count}";
            maxReproductionsLabel.Text = $"Maior número de reproduções: {MaxReproductions}";
            maxAgeLabel.Text = $"Maior idade: {MaxAgeCell}";
            ticksLabel.Text = $"Rounds/Ticks: {_step}";
        }

        private void UpdateChart()
        {
            historyChart.Series[0].Points.AddY(_cells.Count);
            historyChart.Series[1].Points.AddY(_foods.Count);

            // Remove os pontos mais antigos do gráfico para manter o histórico com tamanho fixo
            if (historyChart.Series[0].Points.Count > HistoryChartMaxSize)
            {
                historyChart.Series[0].Points.RemoveAt(0);
                historyChart.Series[1].Points.RemoveAt(0);
            }

            historyChart.ChartAreas[0].RecalculateAxesScale();
        }

        private void UpdateGrid()
        {
            UpdateChart();
            UpdateCounters();
            foreach (Button button in _buttons)
            {
                button.BackColor = Color.White;
            }
            foreach (Food food in _foods)
            {
                _buttons[food.X, food.Y].BackColor = Color.Green;
            }
            foreach (Cell cell in _cells)
            {
                _buttons[cell.X, cell.Y].BackColor = Color.FromArgb(Color.Red.ToArgb() + (cell.Age * 2));
            }
        }

        private void OnGridButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int x = button.Location.X / 20;
            int y = button.Location.Y / 20;
            if (_foods.Remove(_foods.Find(f => f.X == x && f.Y == y)))
            {
                UpdateGrid();
                return;
            }
            if (_cells.Remove(_cells.Find(c => c.X == x && c.Y == y)))
            {
                UpdateGrid();
                return;
            }
            _foods.Add(new Food(x, y));
            UpdateGrid();
        }

        private void OnStepButtonClick(object sender, EventArgs e)
        {
            _step++;
            for (int i = 0; i < _cells.Count; i++)
            {
                Cell cell = _cells[i];
                cell.Step(_foods, _cells);
                
                MaxAgeCell = cell.Age > MaxAgeCell ? cell.Age : MaxAgeCell;
                MaxReproductions = cell.Reproductions > MaxReproductions ? cell.Reproductions : MaxReproductions;

                if (cell.IsDead)
                {
                    deadCells++;
                    _cells.Remove(cell);
                    i--;
                }
            }
            if (_step % 10 == 0 && _rand.NextDouble() >= 0.45)
            {
                AddFood();
            }
            UpdateGrid();

            if (_cells.Count <= 0)
                _timer.Stop();
        }

        private void AddFood(int x = -1, int y = -1)
        {
            x = x == -1 ? _rand.Next(GridWidth) : x;
            y = y == -1 ? _rand.Next(GridHeight) : y;
            _foods.Add(new Food(x, y));
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            OnStepButtonClick(sender, e);
        }

        private void OnStartButtonClick(object sender, EventArgs e)
        {
            _timer.Start();
        }

        private void OnStopButtonClick(object sender, EventArgs e)
        {
            _timer.Stop();
        }
    }
}
