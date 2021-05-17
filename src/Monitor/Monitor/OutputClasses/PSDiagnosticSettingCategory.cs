using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    public class PSDiagnosticSettingCategory
    {
        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public PSDiagnosticSettingCategoryType? CategoryType { get; set; }

        public PSDiagnosticSettingCategory() { }

        public PSDiagnosticSettingCategory(DiagnosticSettingsCategoryResource category)
        {
            this.Id = category?.Id;
            this.Name = category?.Name;
            this.Type = category?.Type;
            if (category != null)
            {
                switch (category.CategoryType)
                {
                    case Microsoft.Azure.Management.Monitor.Models.CategoryType.Metrics:
                        this.CategoryType = PSDiagnosticSettingCategoryType.Metrics;
                        break;
                    case Microsoft.Azure.Management.Monitor.Models.CategoryType.Logs:
                        this.CategoryType = PSDiagnosticSettingCategoryType.Logs;
                        break;
                    default:
                        this.CategoryType = null;
                        break;
                }
            }
        }
    }
}
