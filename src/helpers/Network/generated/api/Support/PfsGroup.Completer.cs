namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    /// <summary>Argument completer implementation for PfsGroup.</summary>
    [System.ComponentModel.TypeConverter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PfsGroupTypeConverter))]
    public partial struct PfsGroup :
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
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "None".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("None", "None", global::System.Management.Automation.CompletionResultType.ParameterValue, "None");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "PFS1".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("PFS1", "PFS1", global::System.Management.Automation.CompletionResultType.ParameterValue, "PFS1");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "PFS2".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("PFS2", "PFS2", global::System.Management.Automation.CompletionResultType.ParameterValue, "PFS2");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "PFS2048".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("PFS2048", "PFS2048", global::System.Management.Automation.CompletionResultType.ParameterValue, "PFS2048");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "ECP256".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("ECP256", "ECP256", global::System.Management.Automation.CompletionResultType.ParameterValue, "ECP256");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "ECP384".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("ECP384", "ECP384", global::System.Management.Automation.CompletionResultType.ParameterValue, "ECP384");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "PFS24".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("PFS24", "PFS24", global::System.Management.Automation.CompletionResultType.ParameterValue, "PFS24");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "PFS14".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("PFS14", "PFS14", global::System.Management.Automation.CompletionResultType.ParameterValue, "PFS14");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "PFSMM".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("PFSMM", "PFSMM", global::System.Management.Automation.CompletionResultType.ParameterValue, "PFSMM");
            }
        }
    }
}