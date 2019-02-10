using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.DataClassification.Model
{
    public class SensitivityClassificationModel
    {
        public string ResourceGroupName { get; set; }

        public string DatabaseName { get; set; }

        public IList<SensitivityLabel> SensitivityLabels { get; set; }
    }
}
