namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Support
{
    /// <summary>Argument completer implementation for RuntimeOptions.</summary>
    [System.ComponentModel.TypeConverter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RuntimeType))]
    public partial struct RuntimeType :
        System.Management.Automation.IArgumentCompleter
    {

        /// <summary>
        /// Implementations of this function are called by PowerShell to complete arguments.
        /// </summary>
        /// <param name="commandName">The name of the command that needs argument completion.</param>
        /// <param name="parameterName">The name of the parameter that needs argument completion.</param>
        /// <param name="wordToComplete">The (possibly empty) word being completed.</param>
        /// <param name="commandAst">The command ast in case it is needed for completion.</param>
        /// <param name="fakeBoundParameters">This parameter is similar to $PSBoundParameters, except that sometimes PowerShell cannot
        /// or will not attempt to evaluate an argument, in which case you may need to use commandAst.</param>
        /// <returns>
        /// A collection of completion results, most like with ResultType set to ParameterValue.
        /// </returns>
        public global::System.Collections.Generic.IEnumerable<global::System.Management.Automation.CompletionResult> CompleteArgument(global::System.String commandName, global::System.String parameterName, global::System.String wordToComplete, global::System.Management.Automation.Language.CommandAst commandAst, global::System.Collections.IDictionary fakeBoundParameters)
        {
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "DotNet".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("DotNet", "DotNet", global::System.Management.Automation.CompletionResultType.ParameterValue, "DotNet");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Node_8".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("Node_8", "Node_8", global::System.Management.Automation.CompletionResultType.ParameterValue, "Node_8");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Node_10".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("Node_10", "Node_10", global::System.Management.Automation.CompletionResultType.ParameterValue, "Node_10");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Java".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("Java", "Java", global::System.Management.Automation.CompletionResultType.ParameterValue, "Java");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "PowerShell".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("PowerShell", "PowerShell", global::System.Management.Automation.CompletionResultType.ParameterValue, "PowerShell");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Python_3.6".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("Python_3.6", "Python_3.6", global::System.Management.Automation.CompletionResultType.ParameterValue, "Python_3.6");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Python_3.7".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("Python_3.7", "Python_3.7", global::System.Management.Automation.CompletionResultType.ParameterValue, "Python_3.7");
            }
        }
    }
}
