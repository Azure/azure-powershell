namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    /// <summary>Argument completer implementation for ApplicationGatewaySkuName.</summary>
    [System.ComponentModel.TypeConverter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuNameTypeConverter))]
    public partial struct ApplicationGatewaySkuName :
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
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Standard_Small".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("Standard_Small", "Standard_Small", global::System.Management.Automation.CompletionResultType.ParameterValue, "Standard_Small");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Standard_Medium".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("Standard_Medium", "Standard_Medium", global::System.Management.Automation.CompletionResultType.ParameterValue, "Standard_Medium");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Standard_Large".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("Standard_Large", "Standard_Large", global::System.Management.Automation.CompletionResultType.ParameterValue, "Standard_Large");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "WAF_Medium".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("WAF_Medium", "WAF_Medium", global::System.Management.Automation.CompletionResultType.ParameterValue, "WAF_Medium");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "WAF_Large".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("WAF_Large", "WAF_Large", global::System.Management.Automation.CompletionResultType.ParameterValue, "WAF_Large");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Standard_v2".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("Standard_v2", "Standard_v2", global::System.Management.Automation.CompletionResultType.ParameterValue, "Standard_v2");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "WAF_v2".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("WAF_v2", "WAF_v2", global::System.Management.Automation.CompletionResultType.ParameterValue, "WAF_v2");
            }
        }
    }
}