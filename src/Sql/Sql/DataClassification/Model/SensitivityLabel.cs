using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Model
{
    public class SensitivityLabel
    {
        [Ps1Xml(Target = ViewControl.List)]
        public string SchemaName { get; set; }

        [Ps1Xml(Target = ViewControl.List)]
        public string TableName { get; set; }

        [Ps1Xml(Target = ViewControl.List)]
        public string ColumnName { get; set; }

        [Ps1Xml(Target = ViewControl.List)]
        public string LabelName { get; set; }

        [Ps1Xml(Target = ViewControl.List)]
        public string InformationType { get; set; }
    }
}
