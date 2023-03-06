using System.Collections.Generic;

namespace SqliteExample.Types
{
    public class MeasurementType
    {
        public virtual string NameMeasure { get; }
        public override string ToString()
        {
            return NameMeasure;
        }
        public static implicit operator string(MeasurementType d) => d.NameMeasure;
        public static implicit operator MeasurementType (string s)
        {
            List< MeasurementType> list = new List< MeasurementType>()
            {
                new ElectricityMeasurement(),
                new WaterMeasurement(),
                new GasMeasurement()
            };
            foreach (var item in list)
            {
                if (item.NameMeasure == s)
                {
                    return item;
                }
            }
            throw new System.Exception("Не могу привести строку к MeasurementType");


        }
    }
}