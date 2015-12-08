using System.Reflection;

namespace System.Management.Automation
{
    public class ErrorDetails
    {
        public ErrorDetails(string message) { Message = message; }
        public ErrorDetails(Assembly assembly, string baseName, string resourceId, params object[] args)
        {
        }

        public ErrorDetails(Cmdlet cmdlet, string baseName, string resourceId, params object[] args)
        {
        }

        public string Message { get; private set; }
        public string RecommendedAction { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
