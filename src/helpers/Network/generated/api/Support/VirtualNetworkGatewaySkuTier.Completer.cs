namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    /// <summary>Argument completer implementation for VirtualNetworkGatewaySkuTier.</summary>
    [System.ComponentModel.TypeConverter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewaySkuTierTypeConverter))]
    public partial struct VirtualNetworkGatewaySkuTier :
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
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Basic".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("Basic", "Basic", global::System.Management.Automation.CompletionResultType.ParameterValue, "Basic");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "HighPerformance".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("HighPerformance", "HighPerformance", global::System.Management.Automation.CompletionResultType.ParameterValue, "HighPerformance");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Standard".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("Standard", "Standard", global::System.Management.Automation.CompletionResultType.ParameterValue, "Standard");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "UltraPerformance".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("UltraPerformance", "UltraPerformance", global::System.Management.Automation.CompletionResultType.ParameterValue, "UltraPerformance");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "VpnGw1".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("VpnGw1", "VpnGw1", global::System.Management.Automation.CompletionResultType.ParameterValue, "VpnGw1");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "VpnGw2".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("VpnGw2", "VpnGw2", global::System.Management.Automation.CompletionResultType.ParameterValue, "VpnGw2");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "VpnGw3".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("VpnGw3", "VpnGw3", global::System.Management.Automation.CompletionResultType.ParameterValue, "VpnGw3");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "VpnGw1AZ".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("VpnGw1AZ", "VpnGw1AZ", global::System.Management.Automation.CompletionResultType.ParameterValue, "VpnGw1AZ");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "VpnGw2AZ".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("VpnGw2AZ", "VpnGw2AZ", global::System.Management.Automation.CompletionResultType.ParameterValue, "VpnGw2AZ");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "VpnGw3AZ".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("VpnGw3AZ", "VpnGw3AZ", global::System.Management.Automation.CompletionResultType.ParameterValue, "VpnGw3AZ");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "ErGw1AZ".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("ErGw1AZ", "ErGw1AZ", global::System.Management.Automation.CompletionResultType.ParameterValue, "ErGw1AZ");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "ErGw2AZ".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("ErGw2AZ", "ErGw2AZ", global::System.Management.Automation.CompletionResultType.ParameterValue, "ErGw2AZ");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "ErGw3AZ".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("ErGw3AZ", "ErGw3AZ", global::System.Management.Automation.CompletionResultType.ParameterValue, "ErGw3AZ");
            }
        }
    }
}