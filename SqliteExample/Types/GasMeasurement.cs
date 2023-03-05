using SqliteExample.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqliteExample.Types
{
    public class GasMeasurement : MeasurementType
    {
        public override string NameMeasure { get => AppResources.MeasurementGas; }        
    }
}
