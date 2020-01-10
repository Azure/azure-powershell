namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    /// <summary>Argument completer implementation for WebApplicationFirewallTransform.</summary>
    [System.ComponentModel.TypeConverter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransformTypeConverter))]
    public partial struct WebApplicationFirewallTransform :
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
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Lowercase".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("Lowercase", "Lowercase", global::System.Management.Automation.CompletionResultType.ParameterValue, "Lowercase");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Trim".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("Trim", "Trim", global::System.Management.Automation.CompletionResultType.ParameterValue, "Trim");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "UrlDecode".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("UrlDecode", "UrlDecode", global::System.Management.Automation.CompletionResultType.ParameterValue, "UrlDecode");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "UrlEncode".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("UrlEncode", "UrlEncode", global::System.Management.Automation.CompletionResultType.ParameterValue, "UrlEncode");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "RemoveNulls".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("RemoveNulls", "RemoveNulls", global::System.Management.Automation.CompletionResultType.ParameterValue, "RemoveNulls");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "HtmlEntityDecode".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("HtmlEntityDecode", "HtmlEntityDecode", global::System.Management.Automation.CompletionResultType.ParameterValue, "HtmlEntityDecode");
            }
        }
    }
}