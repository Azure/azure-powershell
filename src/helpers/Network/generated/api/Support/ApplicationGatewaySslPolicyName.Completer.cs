namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    /// <summary>Argument completer implementation for ApplicationGatewaySslPolicyName.</summary>
    [System.ComponentModel.TypeConverter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslPolicyNameTypeConverter))]
    public partial struct ApplicationGatewaySslPolicyName :
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
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "AppGwSslPolicy20150501".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("AppGwSslPolicy20150501", "AppGwSslPolicy20150501", global::System.Management.Automation.CompletionResultType.ParameterValue, "AppGwSslPolicy20150501");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "AppGwSslPolicy20170401".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("AppGwSslPolicy20170401", "AppGwSslPolicy20170401", global::System.Management.Automation.CompletionResultType.ParameterValue, "AppGwSslPolicy20170401");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "AppGwSslPolicy20170401S".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("AppGwSslPolicy20170401S", "AppGwSslPolicy20170401S", global::System.Management.Automation.CompletionResultType.ParameterValue, "AppGwSslPolicy20170401S");
            }
        }
    }
}