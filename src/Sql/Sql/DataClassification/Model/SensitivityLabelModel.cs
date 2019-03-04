using Microsoft.Azure.Commands.Sql.DataClassification.Services;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Model
{
    public class SensitivityLabelModel
    {
        [Ps1Xml(Target = ViewControl.List)]
        public string SchemaName { get; set; }

        [Ps1Xml(Target = ViewControl.List)]
        public string TableName { get; set; }

        [Ps1Xml(Target = ViewControl.List)]
        public string ColumnName { get; set; }

        [Ps1Xml(Target = ViewControl.List)]
        public string SensitivityLabel { get; set; }

        [Ps1Xml(Target = ViewControl.List)]
        public string InformationType { get; set; }

        [Hidden]
        public string SensitivityLabelId { get; set; }

        [Hidden]
        public string InformationTypeId { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("{");
            foreach (var property in this.GetType().GetProperties())
            {
                string name = property.Name;
                if (name == "InformationTypeId" || name == "SensitivityLabelId")
                {
                    continue;
                }

                object value = property.GetValue(this);
                if (value != null)
                {
                    builder.AppendLine($"\t{name}: {value},");
                }
            }

            builder.Append("}");

            return builder.ToString();
        }

        internal void ApplyModel(SensitivityLabelModel sensitivityLabel, InformationProtectionPolicy informationProtectionPolicy)
        {
            ApplyInput(sensitivityLabel.InformationType, sensitivityLabel.SensitivityLabel, informationProtectionPolicy);
        }

        internal void ApplyInput(string informationType, string sensitivityLabel, InformationProtectionPolicy informationProtectionPolicy)
        {
            if (string.IsNullOrEmpty(informationType) && string.IsNullOrEmpty(sensitivityLabel))
            {
                throw new Exception("Value is not specified neither for InformationType parameter nor for SensitivityLabel parameter");
            }

            ApplyInformationType(informationType, informationProtectionPolicy);
            ApplySensitivityLabel(sensitivityLabel, informationProtectionPolicy);
        }

        private void ApplyInformationType(string newInformationType, InformationProtectionPolicy informationProtectionPolicy)
        {
            if (!string.IsNullOrEmpty(newInformationType) &&
                !string.Equals(InformationType, newInformationType))
            {
                if (informationProtectionPolicy.InformationTypes.TryGetValue(newInformationType, out Guid informationTypeId))
                {
                    InformationType = newInformationType;
                    InformationTypeId = informationTypeId.ToString();
                }
                else
                {
                    throw new Exception($"Information Type '{newInformationType}' is not part of Information Protection Policy. Please add '{newInformationType}' to the Information Protection Policy, or use one of the following: {ToString(informationProtectionPolicy.SensitivityLabels.Keys)}");
                }
            }
        }

        private void ApplySensitivityLabel(string newSensitivityLabel, InformationProtectionPolicy informationProtectionPolicy)
        {
            if (!string.IsNullOrEmpty(newSensitivityLabel) ||
                !string.Equals(SensitivityLabel, newSensitivityLabel))
            {
                if (informationProtectionPolicy.SensitivityLabels.TryGetValue(newSensitivityLabel, out Guid sensitivityLabelId))
                {
                    SensitivityLabel = newSensitivityLabel;
                    SensitivityLabelId = sensitivityLabelId.ToString();
                }
                else
                {
                    throw new Exception($"Sensitivity Label '{newSensitivityLabel}' is not part of Information Protection Policy. Please add '{newSensitivityLabel}' to the Information Protection Policy, or use one of the following: {ToString(informationProtectionPolicy.InformationTypes.Keys)}");
                }
            }
        }

        private static string ToString(ICollection<string> collection)
        {
            return string.Join(", ", collection.Select(s => $"'{s}'"));
        }
    }
}
