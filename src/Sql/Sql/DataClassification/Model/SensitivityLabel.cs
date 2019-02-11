using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System.Text;

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

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("{");
            foreach (var property in this.GetType().GetProperties())
            {
                string name = property.Name;
                object value = property.GetValue(this);
                builder.AppendLine($"\t{name}: {value},");
            }
            builder.Append("}");

            return builder.ToString();
        }
    }
}
