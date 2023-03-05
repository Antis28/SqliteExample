using SqliteExample.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqliteExample.Types
{
    internal class ElectricityMeasurement : MeasurementType
    {
        public override string NameMeasure { get => AppResources.MeasurementElectricity; }
    }
}
