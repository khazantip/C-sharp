using System.Net;
using System.Text.Json;

namespace Cross
{
    
        public partial class Form1 : Form
        {

            List<Button> Buttons;

            public Form1()
            {
                InitializeComponent();

                Buttons = new List<Button>();

                var webClient = new WebClient();
                string imgJson = webClient.DownloadString("http://192.168.88.7:3000/img");

                var img = JsonSerializer.Deserialize<GameImage>(imgJson);

                // цифры сверху
                for (int x = 0; x < img.Size; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        var btn = new Button();
                        btn.Location = new Point(110 + x * 35, 5 + y * 35);
                        btn.Size = new Size(30, 30);
                        btn.UseVisualStyleBackColor = true;
                        btn.BackColor = Color.Gray;
                        btn.Enabled = false;
                        btn.Name = $"btnTop_{x}_{y}";
                        Controls.Add(btn);
                    }
                }

                // цифры слева
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < img.Size; y++)
                    {
                        var btn = new Button();
                        btn.Location = new Point(5 + x * 35, 110 + y * 35);
                        btn.Size = new Size(30, 30);
                        btn.UseVisualStyleBackColor = true;
                        btn.BackColor = Color.Gray;
                        btn.Enabled = false;
                        btn.Name = $"btnLeft_{x}_{y}";
                        Controls.Add(btn);
                    }
                }

                // картинка
                for (int i = 0; i < img.Size; i++)
                {
                    for (int j = 0; j < img.Size; j++)
                    {
                        var btn = new Button();
                        btn.Location = new Point(110 + i * 35, 110 + j * 35);
                        btn.Size = new Size(30, 30);
                        btn.Name = $"btn{i}_{j}";
                        btn.UseVisualStyleBackColor = true;
                        btn.Click += new EventHandler(gridBtn_Click);
                        btn.BackColor = Color.White;
                        Buttons.Add(btn);
                        Controls.Add(btn);
                    }
                }
            }

            private void InitializeComponent()
            {
                throw new NotImplementedException();
            }

            private void gridBtn_Click(object sender, EventArgs e)
            {
                var btn = (Button)sender;
                btn.BackColor = btn.BackColor == Color.White ? Color.Black : Color.White;
            }
        }
    
}