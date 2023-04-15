using System.Diagnostics.Metrics;

namespace XO
{
    public partial class XO : Form
    {
        public XO()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            MakeAMove(sender);
        }
      
        public int Counter { get; set; }
        private void MakeAMove(object sender)
        {
            if(sender is Button)
            {
                var button = sender as Button;
                if (button.Text == "")
                {
                    if (Counter % 2 == 0)
                        button.Text = "X";
                    else
                        button.Text = "O";
                    Counter++;
                    PlayerOnTheMove();
                    if (EndOfTheGame()) 
                    {
                        DisableButton(false);
                        Winner();
                    }
                    TieGame();
                }
            }
        }

       private void TieGame()
       {
           if (Counter == 9) {
                lblNextPlayer.Text = "";
                MessageBox.Show("Tie game!");
           }
        }

        private bool EndOfTheGame()
        {
            return CheckRows() || CheckColumns() || CheckDiagonals();
        }
        private bool Winner()
        {
            if (Counter % 2 == 0) 
            { 
                lblNextPlayer.Text = "";
                MessageBox.Show("Player O won!");
            }
            else { 
                lblNextPlayer.Text = "";
                MessageBox.Show("Player X won!");
            }
            return true;
        }

        private bool CheckDiagonals()
        {
            return CheckVictory(btn1, btn5, btn9) ||
            CheckVictory(btn3, btn5, btn7);
        }

        private bool CheckColumns()
        {
            return CheckVictory(btn1, btn4, btn7) ||
                  CheckVictory(btn2, btn5, btn8) ||
                  CheckVictory(btn3, btn6, btn9);
        }

        private bool CheckRows()
        {
            return CheckVictory(btn1, btn2, btn3) ||
                   CheckVictory(btn4, btn5, btn6) ||
                   CheckVictory(btn7, btn8, btn9);
        }

        private bool CheckVictory(Button btn1, Button btn2, Button btn3)
        {
            if(btn1.Text!="" && btn1.Text==btn2.Text && btn1.Text == btn3.Text)
            {
                btn1.BackColor = btn2.BackColor = btn3.BackColor = Color.Green;
                return true;
            }
            return false;
        }

        private void DisableButton(bool enabled, bool resetText = false,
          bool resetColor = false)
        {
            foreach (var control in this.Controls)
            {
                if (control is Button)
                {
                    var button = control as Button;
                    if (button != btnNewGame)
                    {
                        button.Enabled = enabled;
                        button.Text = resetText ? "" : button.Text;
                        if (resetColor)
                        {
                            button.UseVisualStyleBackColor = true;
                            Counter = 0;
                            lblNextPlayer.Text = "Player X on the move";
                        }
                    }
                }
            }
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            MakeAMove(sender);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            MakeAMove(sender);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            MakeAMove(sender);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            MakeAMove(sender);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            MakeAMove(sender);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            MakeAMove(sender);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            MakeAMove(sender);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            MakeAMove(sender);
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            DisableButton(true, true, true);
        }

        private void XO_Load(object sender, EventArgs e)
        {
            PlayerOnTheMove();
        }

        private void PlayerOnTheMove()
        {
            lblNextPlayer.Text = Counter % 2 == 0 ? "Player X on the move."  : "Player O on the move";
        }
    }
}