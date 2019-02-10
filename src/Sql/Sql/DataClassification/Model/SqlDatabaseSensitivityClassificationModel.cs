using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Model
{
    public class SqlDatabaseSensitivityClassificationModel : SensitivityClassificationModel
    {
        public string ServerName { get; set; }
    }
}
