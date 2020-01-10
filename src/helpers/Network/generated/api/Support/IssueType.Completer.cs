namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    /// <summary>Argument completer implementation for IssueType.</summary>
    [System.ComponentModel.TypeConverter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueTypeTypeConverter))]
    public partial struct IssueType :
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
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Unknown".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("Unknown", "Unknown", global::System.Management.Automation.CompletionResultType.ParameterValue, "Unknown");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "AgentStopped".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("AgentStopped", "AgentStopped", global::System.Management.Automation.CompletionResultType.ParameterValue, "AgentStopped");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "GuestFirewall".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("GuestFirewall", "GuestFirewall", global::System.Management.Automation.CompletionResultType.ParameterValue, "GuestFirewall");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "DnsResolution".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("DnsResolution", "DnsResolution", global::System.Management.Automation.CompletionResultType.ParameterValue, "DnsResolution");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "SocketBind".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("SocketBind", "SocketBind", global::System.Management.Automation.CompletionResultType.ParameterValue, "SocketBind");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "NetworkSecurityRule".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("NetworkSecurityRule", "NetworkSecurityRule", global::System.Management.Automation.CompletionResultType.ParameterValue, "NetworkSecurityRule");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "UserDefinedRoute".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("UserDefinedRoute", "UserDefinedRoute", global::System.Management.Automation.CompletionResultType.ParameterValue, "UserDefinedRoute");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "PortThrottled".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("PortThrottled", "PortThrottled", global::System.Management.Automation.CompletionResultType.ParameterValue, "PortThrottled");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Platform".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("Platform", "Platform", global::System.Management.Automation.CompletionResultType.ParameterValue, "Platform");
            }
        }
    }
}