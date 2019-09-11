using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        const string APPID = "9cb17c73bb019bccc1aa0888983fc434";
        string cityName = "London";
        public Form1()
        {
            InitializeComponent();
            getWeather(cityName);
            getForecast(cityName);
            
        }

        void getForecast(string city)
        {
            
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric&cnt=6", city, APPID);
                var json = web.DownloadString(url);
                var Object = JsonConvert.DeserializeObject<WeatherForecast>(json);

                WeatherForecast weatherForecast = Object;
                Console.WriteLine("Object: "+ Object.list[1]);

                //label4.Text = string.Format("{0}", weatherForecast.list[1].weather[0].main);
            }
            
        }

        void getWeather(string city)
        {
            using(WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric&cnt=6", city, APPID);
                var json = web.DownloadString(url);
                
                var result = JsonConvert.DeserializeObject<WeatherInfo.root>(json);
                WeatherInfo.root output = result;
                label1.Text = string.Format("{0}", output.name);
                label2.Text = string.Format("{0}", output.sys.country);
                label3.Text = string.Format("{0} \u00B0" + "C", output.main.temp);
                Console.WriteLine(output.sys.country);
            }
           
        }
    }
}
