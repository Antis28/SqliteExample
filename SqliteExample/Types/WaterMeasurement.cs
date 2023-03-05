using SqliteExample.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqliteExample.Types
{
    internal class WaterMeasurement : MeasurementType
    {
        public override string NameMeasure { get => AppResources.MeasurementWater; }   
    }
}