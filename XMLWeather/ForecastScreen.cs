using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class ForecastScreen : UserControl
    {
        List<Label> dateLabels = new List<Label>();
        List<Label> tempLabels = new List<Label>();
        List<PictureBox> pictureBoxes = new List<PictureBox>();

        public ForecastScreen()
        {
            InitializeComponent();

            dateLabels.Add(dateOne); dateLabels.Add(dateTwo); dateLabels.Add(dateThree);
            dateLabels.Add(dateFour); dateLabels.Add(dateFive);

            tempLabels.Add(tempOne); tempLabels.Add(tempTwo); tempLabels.Add(tempThree);
            tempLabels.Add(tempFour); tempLabels.Add(tempFive);

            pictureBoxes.Add(iconOne); pictureBoxes.Add(iconTwo); pictureBoxes.Add(iconThree);
            pictureBoxes.Add(iconFour); pictureBoxes.Add(iconFive);

            displayForecast();
        }

        public void displayForecast()
        {
            for (int i = 0; i < 5; i++)
            {
                dateLabels[i].Text = DateTime.Now.AddDays(i).ToString("dddd");

                tempLabels[i].Text = Convert.ToDouble(Form1.days[i].tempLow).ToString("0.") + "°    " + Convert.ToDouble(Form1.days[i].tempHigh).ToString("0.") + "°";

                if (Convert.ToDouble(Form1.days[i].weather) <= 232)
                {
                    pictureBoxes[i].BackgroundImage = Properties.Resources.thunderIcon;
                }
                else if (Convert.ToDouble(Form1.days[i].weather) <= 321)
                {
                    pictureBoxes[i].BackgroundImage = Properties.Resources.babyRainIcom;
                }
                else if (Convert.ToDouble(Form1.days[i].weather) <= 531)
                {
                    pictureBoxes[i].BackgroundImage = Properties.Resources.rainIcom;
                }
                else if (Convert.ToDouble(Form1.days[i].weather) <= 622)
                {
                    pictureBoxes[i].BackgroundImage = Properties.Resources.snowIcom;
                }
                else if (Form1.days[i].weather == "800")
                {
                    pictureBoxes[i].BackgroundImage = Properties.Resources.clearIcom;
                }
                else if (Convert.ToDouble(Form1.days[i].weather) >= 800)
                {
                    pictureBoxes[i].BackgroundImage = Properties.Resources.cloudIcom;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }  
    }
}
