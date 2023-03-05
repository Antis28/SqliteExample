using SqliteExample.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqliteExample.Types
{
    internal class ElectricityMeasurement : IMeasurement
    {
        public string NameMeasure { get => AppResources.MeasurementElectricity; }
    }
}
