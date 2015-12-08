using System.Collections.ObjectModel;

namespace System.Management.Automation
{
    /// <summary>
    /// Describes a terminating or nonterminating error that occurred during the processing of a command.
    /// </summary>
    public class ErrorRecord
    {
        public ErrorRecord(Exception exception, string errorId, ErrorCategory errorCategory, object targetObject)
        {
            Exception = exception;
            TargetObject = targetObject;
        }

        public ErrorCategoryInfo CategoryInfo { get; private set; }
        public ErrorDetails ErrorDetails { get; set; }
        public Exception Exception { get; private set; }
        public string FullyQualifiedErrorId { get; private set; }
        public InvocationInfo InvocationInfo { get; private set; }
        public ReadOnlyCollection<int> PipelineIterationInfo { get; private set; }
        public object TargetObject { get; private set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
