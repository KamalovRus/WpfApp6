using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp6
{
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty = DependencyProperty.Register(
             nameof(Temperature),
             typeof(int),
             typeof(WeatherControl),
             new FrameworkPropertyMetadata(
                 0,
                 FrameworkPropertyMetadataOptions.AffectsMeasure,
                 null,
                 new CoerceValueCallback(CoerceTemperature)
                 ), new ValidateValueCallback(ValidateTemperature)
            );

        private static bool ValidateTemperature(object value)
        {
            int v = (int)value;
            if (v > -50 && v < 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v < -50)
            {
                return -50;
            }
            else
            {
                return v;
            }
        }

        private string windDirection;
        private int windSpeed;

        public string WindDirection { get => windDirection; set => windDirection = value; }
        public int WindSpeed { get => windSpeed; set => windSpeed = value; }
        public int Temperature { get => (int)GetValue(TemperatureProperty); set => SetValue(TemperatureProperty, value); }

        public WeatherControl(string windDirection, int windSpeed, int temperature)
        {
            WindDirection = windDirection;
            WindSpeed = windSpeed;
            Temperature = temperature;
        }

        public enum Precepitation
        {
            Sunny = 0,
            Cloudy = 1,
            Rain = 2,
            Snow = 3
        }
    }
}
