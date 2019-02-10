using System;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Model
{
    public class SensitivityLabel
    {
        public string SchemaName { get; set; }

        public string TableName { get; set; }

        public string ColumnName { get; set; }

        public string LabelName { get; set; }

        public string InformationType { get; set; }
    }
}
