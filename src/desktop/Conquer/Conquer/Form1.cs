using System.Runtime.CompilerServices;

namespace Conquer
{
    public partial class Form1 : Form
    {
        internal int mapXSize = 10;
        internal int mapYSize = 10;
        internal int squareSize = 118;

        internal Label[,] MapLabels;
        internal Game Game;

        internal Square? SelectedSquare = null;

        public Form1()
        {
            InitializeComponent();
            GenerateMap();
            RefreshUI();
        }

        private void GenerateMap()
        {
            MapLabels = new Label[mapXSize, mapYSize];
            this.Game = new Game(mapXSize, mapYSize);

            for (int x = 0; x < mapXSize; x++)
            {
                for (int y = 0; y < mapYSize; y++)
                {
                    Label lblSquare = new Label();

                    // 
                    // lblSquare
                    // 
                    lblSquare.Location = new Point(56 + squareSize * x, 44 + squareSize * y);
                    lblSquare.Name = "lblSquare";
                    lblSquare.Size = new Size(squareSize, squareSize);
                    lblSquare.TabIndex = 0;
                    lblSquare.Text = "lblSquare";
                    lblSquare.BackColor = Color.AliceBlue;
                    lblSquare.ForeColor = Color.Black;
                    lblSquare.Click += label1_Click;
                    lblSquare.Tag = Game.Map.Squares[x, y];

                    MapLabels[x, y] = lblSquare;
                    this.Controls.Add(lblSquare);
                }
            }
        }

        private void RefreshUI()
        {
            for (int x = 0; x < mapXSize; x++)
            {
                for (int y = 0; y < mapYSize; y++)
                {
                    MapLabels[x, y].Text = Game.Map.Squares[x, y].SoldiersCount.ToString();
                    if (Game.Map.Squares[x, y].Player == Game.HumanPlayer)
                    {
                        MapLabels[x, y].BackColor = Color.Green;
                    }
                    else
                    {
                        MapLabels[x, y].BackColor = Color.Azure;
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Label clickedLbl = (Label)sender;
            Square clickedSquare = (Square)clickedLbl.Tag;

            if (SelectedSquare == null || SelectedSquare.Player != Game.HumanPlayer)
            {
                SelectedSquare = clickedSquare;
                return;
            }

            // We are movilizing
            // different players
            if (clickedSquare.Player != SelectedSquare.Player)
            {
                if (clickedSquare.SoldiersCount < SelectedSquare.SoldiersCount - 1)
                {
                    // we win!
                    clickedSquare.Player = SelectedSquare.Player;
                    clickedSquare.SoldiersCount = SelectedSquare.SoldiersCount - clickedSquare.SoldiersCount - 1;
                }
                else
                {
                    clickedSquare.SoldiersCount -= SelectedSquare.SoldiersCount - 1;
                }

            }
            else
            {
                clickedSquare.SoldiersCount += SelectedSquare.SoldiersCount - 1;
                // same player
            }

            SelectedSquare.SoldiersCount = 1;

            SelectedSquare = null;
            RefreshUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Game.IncreasePlayersSoldiers();
            RefreshUI();
        }
    }
}