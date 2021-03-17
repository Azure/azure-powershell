using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    public class PSSubscriptionDiagnosticSettingCategory
    {
        public string Name { get; private set; }

        public PSDiagnosticSettingCategoryType? CategoryType { get; set; }

        public PSSubscriptionDiagnosticSettingCategory() { }

        public PSSubscriptionDiagnosticSettingCategory(string Name, PSDiagnosticSettingCategoryType type) { }
    }
}