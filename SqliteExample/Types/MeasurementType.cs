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
    }
}