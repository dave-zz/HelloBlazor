using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HelloBlazor.Common.Model
{
    public class WeatherForecast
    {
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1900", "1/1/2101", ErrorMessage = "Value for {0} must be between {1:dd/MM/yyyy} and {2:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Date can not be empty", AllowEmptyStrings = false)]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Temperature can not be empty")]
        public int TemperatureC { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Summary is too long")]
        public string Summary { get; set; } = string.Empty;

        #region ToString & default summary values
        public override string ToString()
        {
            return $"Date: ";
        }

        public static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        #endregion
    }
}
