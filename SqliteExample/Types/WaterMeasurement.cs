using SqliteExample.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqliteExample.Types
{
    internal class WaterMeasurement : IMeasurement
    {
        public string NameMeasure { get => AppResources.MeasurementWater; }
    }
}
