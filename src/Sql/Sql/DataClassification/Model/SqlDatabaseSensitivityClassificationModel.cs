using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Model
{
    public class SqlDatabaseSensitivityClassificationModel : SensitivityClassificationModel
    {
        [Ps1Xml(Target = ViewControl.List, Position = 1)]
        public string ServerName { get; set; }
    }
}
