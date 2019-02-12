using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Model
{
    public class SensitivityClassificationModel
    {
        [Ps1Xml(Target = ViewControl.List, Position = 0)]
        public string ResourceGroupName { get; set; }

        [Ps1Xml(Target = ViewControl.List, Position = 2)]
        public string DatabaseName { get; set; }

        [Ps1Xml(Target = ViewControl.List)]
        public IList<SensitivityLabelModel> SensitivityLabels { get; set; }
    }
}
