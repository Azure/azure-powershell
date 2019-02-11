using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Model
{
    public class ManagedDatabaseSensitivityClassificationModel : SensitivityClassificationModel
    {
        [Ps1Xml(Target = ViewControl.List, Position = 1)]
        public string InstanceName { get; set; }
    }
}
