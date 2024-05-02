
namespace SCarrillo.Models
{
    internal class DecimalPrecisionAttribute : Attribute
    {
        public int Precision { get; set; }
        public int Scale { get; set; }

        public DecimalPrecisionAttribute(int precision, int scale)
        {
            Precision = precision;
            Scale = scale;
        }
    }
}