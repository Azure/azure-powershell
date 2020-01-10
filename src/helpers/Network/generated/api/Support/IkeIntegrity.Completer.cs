namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    /// <summary>Argument completer implementation for IkeIntegrity.</summary>
    [System.ComponentModel.TypeConverter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IkeIntegrityTypeConverter))]
    public partial struct IkeIntegrity :
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
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "MD5".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("MD5", "MD5", global::System.Management.Automation.CompletionResultType.ParameterValue, "MD5");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "SHA1".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("SHA1", "SHA1", global::System.Management.Automation.CompletionResultType.ParameterValue, "SHA1");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "SHA256".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("SHA256", "SHA256", global::System.Management.Automation.CompletionResultType.ParameterValue, "SHA256");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "SHA384".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("SHA384", "SHA384", global::System.Management.Automation.CompletionResultType.ParameterValue, "SHA384");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "GCMAES256".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("GCMAES256", "GCMAES256", global::System.Management.Automation.CompletionResultType.ParameterValue, "GCMAES256");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "GCMAES128".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("GCMAES128", "GCMAES128", global::System.Management.Automation.CompletionResultType.ParameterValue, "GCMAES128");
            }
        }
    }
}