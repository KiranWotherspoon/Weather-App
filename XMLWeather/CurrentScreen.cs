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
    public partial class CurrentScreen : UserControl
    {
        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            cityLabel.Text = Form1.days[0].location;
            dateLabel.Text = Form1.days[0].date;
            tempLabel.Text = Convert.ToDouble(Form1.days[0].currentTemp).ToString("0.") + "°";
            minTempLabel.Text = Convert.ToDouble(Form1.days[0].tempLow).ToString("0.") + "°";
            maxTempLabel.Text = Convert.ToDouble(Form1.days[0].tempHigh).ToString("0.") + "°";
            
            if (Convert.ToDouble(Form1.days[0].weather) <= 232)
            {
                weatherLabel.Text = "it storm";
                icomBox.BackgroundImage = Properties.Resources.thunderIcon;
            }
            else if (Convert.ToDouble(Form1.days[0].weather) <= 321)
            {
                weatherLabel.Text = "it baby rain";
                icomBox.BackgroundImage = Properties.Resources.babyRainIcom;
            }
            else if (Convert.ToDouble(Form1.days[0].weather) <= 531)
            {
                weatherLabel.Text = "it rain";
                icomBox.BackgroundImage = Properties.Resources.rainIcom;
            }
            else if (Convert.ToDouble(Form1.days[0].weather) <= 622)
            {
                weatherLabel.Text = "it snow";

                icomBox.BackgroundImage = Properties.Resources.snowIcom;
            }
            else if (Form1.days[0].weather == "800")
            {
                weatherLabel.Text = "it clear";
                icomBox.BackgroundImage = Properties.Resources.clearIcom;
            }
            else if (Convert.ToDouble(Form1.days[0].weather) > 800)
            {
                weatherLabel.Text = "it cloud";
                icomBox.BackgroundImage = Properties.Resources.cloudIcom;
            }
        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }
    }
}
