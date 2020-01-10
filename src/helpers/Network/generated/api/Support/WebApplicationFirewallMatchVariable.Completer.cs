namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    /// <summary>Argument completer implementation for WebApplicationFirewallMatchVariable.</summary>
    [System.ComponentModel.TypeConverter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMatchVariableTypeConverter))]
    public partial struct WebApplicationFirewallMatchVariable :
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
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "RemoteAddr".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("RemoteAddr", "RemoteAddr", global::System.Management.Automation.CompletionResultType.ParameterValue, "RemoteAddr");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "RequestMethod".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("RequestMethod", "RequestMethod", global::System.Management.Automation.CompletionResultType.ParameterValue, "RequestMethod");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "QueryString".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("QueryString", "QueryString", global::System.Management.Automation.CompletionResultType.ParameterValue, "QueryString");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "PostArgs".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("PostArgs", "PostArgs", global::System.Management.Automation.CompletionResultType.ParameterValue, "PostArgs");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "RequestUri".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("RequestUri", "RequestUri", global::System.Management.Automation.CompletionResultType.ParameterValue, "RequestUri");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "RequestHeaders".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("RequestHeaders", "RequestHeaders", global::System.Management.Automation.CompletionResultType.ParameterValue, "RequestHeaders");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "RequestBody".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("RequestBody", "RequestBody", global::System.Management.Automation.CompletionResultType.ParameterValue, "RequestBody");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "RequestCookies".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("RequestCookies", "RequestCookies", global::System.Management.Automation.CompletionResultType.ParameterValue, "RequestCookies");
            }
        }
    }
}