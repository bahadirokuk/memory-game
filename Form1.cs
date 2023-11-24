namespace MemoryGame
{
    public partial class Form1 : Form
    {
        Game game= new();
        private PictureBox? firstClickedBox = null;
        private bool delayInProgress = false;
        Player player1;
        Player player2;
        Player CurrentPlayer;
        int timer = 5;
        int changer = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void basla_Click(object sender, EventArgs e)
        {
            player1 = new Player(textBox1.Text);
            player2 = new Player(textBox2.Text);
            PlayerChng();
            for (int i = 0; i < 20; i++)
            {
                //Her bir Picturebox'a resim atanýyor

                PictureBox picBox = (PictureBox)this.Controls.Find("pictureBox" + i, true)[0];
                PictureBox picBoxcover = (PictureBox)this.Controls.Find("pictureBox" + i +"x", true)[0];
                picBox.Image = game.List[i];
                picBoxcover.BackColor = Color.CornflowerBlue;
                picBoxcover.Enabled = true;
            }
            playerSettings(player1, textBox1, playername1,playerpoint1);
            playerSettings(player2, textBox2, playername2,playerpoint2);
            button1.Enabled = false;
            label1.Visible = false;
        }

        void playerSettings(Player player, TextBox textBox, Label label,Label point)
        {
            label.Text = player.Name;
            label.Visible = true;
            textBox.Visible = false;
            point.Visible = true;
        }

        private async void pictureBox0x_Click(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;

            //ilk kutumuzu seçiyoruz. Daha önceden seçili kutumuz var mý kontrol ediyor
            if (firstClickedBox == null)
            {
                timer1.Start();
                firstClickedBox = box;
                firstClickedBox.Visible = false;
            }
            else if (box != firstClickedBox && !delayInProgress)
            {
                firstClickedBox.Visible = false;  
                box.Visible = false;
                timer1.Stop();
                timer = 5;
                timerlabel.Text = "Time = " + timer.ToString();

                //Bastýðýmýz 2 kutunun altlarýndaki resmiler ayný mý kontrol ediyor
                if (isImageSame(((PictureBox)this.Controls.Find((box.Name).Substring(0, (box.Name).Length - 1), true)[0]).Image,
                    ((PictureBox)this.Controls.Find((firstClickedBox.Name).Substring(0, (firstClickedBox.Name).Length - 1), true)[0]).Image
                    ))
                {
                    if (CurrentPlayer == player1)
                    {
                        player1.point++;
                        playerpoint1.Text = "Point = " + player1.point;
                    }
                    else
                    {
                        player2.point++;
                        playerpoint2.Text = "Point = " + player2.point;
                    }                  
                    firstClickedBox = null;
                    return;
                }
                // 2. kutuda ne olduðunu görmek için bekliyoruz
                // Beklerken baþka kutuya basýlmamasý için delay hala devam ediyor mu kontrol ediyoruz
                delayInProgress = true;

                await Task.Delay(700);
                PlayerChng();
                firstClickedBox.Visible = true; 
                box.Visible = true;
                firstClickedBox = null;

                delayInProgress = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer--;
            timerlabel.Text = "Time = " + timer.ToString();
            if (timer == 0)
            {
                timer1.Stop();
                timer = 5;
                PlayerChng();
                firstClickedBox!.Visible = true;
                firstClickedBox = null;
                timerlabel.Text = "Time = " + timer.ToString();
                MessageBox.Show("Zaman doldu seçim sýrasý "+ CurrentPlayer.Name);
            }
        }

        //Resimlerin ayný olup olmadýðýný pixellerine bakýp karar veriyor
        private bool isImageSame(Image image1, Image image2)
        {
            Bitmap bmp1 = new Bitmap(image1);
            Bitmap bmp2 = new Bitmap(image2);
            if (bmp1.Size != bmp2.Size) 
            {
                return false;
            }
            for (int x = 0; x < bmp1.Width; x++)
            {
                for (int y = 0; y < bmp1.Height; y++)
                {
                    if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y)) 
                    {
                        return false; 
                    }
                }
            }
            return true;
        }
        private void PlayerChng()
        {
            changer++;
            if (changer%2 == 0)
            {
                playerlabel1.BackColor = Color.Transparent;
                playerlabel2.BackColor = Color.CornflowerBlue;
                CurrentPlayer = player2;
                return;
            }
            playerlabel2.BackColor = Color.Transparent;
            playerlabel1.BackColor = Color.CornflowerBlue;
            CurrentPlayer = player1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}