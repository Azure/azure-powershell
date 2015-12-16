using System.Globalization;

namespace System.Management.Automation
{
    public class ErrorCategoryInfo
    {
        public string Activity { get; set; }
        public ErrorCategory Category { get; private set; }
        public string Reason { get; set; }
        public string TargetName { get; set; }
        public string TargetType { get; set; }

        public string GetMessage() { return null; }
        public string GetMessage(CultureInfo uiCultureInfo) { return null; }
        public override string ToString()
        {
            return GetMessage();
        }
    }
}
