using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Model
{
    public class ManagedDatabaseSensitivityClassificationModel : SensitivityClassificationModel
    {
        public string InstanceName { get; set; }
    }
}
