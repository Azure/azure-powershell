using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    public abstract class PSDiagnosticDetailSettings
    {
        public string Category { get; set; }

        public bool Enabled { get; set; }

        public PSRetentionPolicy RetentionPolicy { get; set; }

        public PSDiagnosticSettingCategoryType CategoryType { get; set; }
    }
}
