namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    /// <summary>Argument completer implementation for ApplicationGatewaySslCipherSuite.</summary>
    [System.ComponentModel.TypeConverter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySslCipherSuiteTypeConverter))]
    public partial struct ApplicationGatewaySslCipherSuite :
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
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384", "TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256", "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA", "TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA", "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_DHE_RSA_WITH_AES_256_GCM_SHA384".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_DHE_RSA_WITH_AES_256_GCM_SHA384", "TLS_DHE_RSA_WITH_AES_256_GCM_SHA384", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_DHE_RSA_WITH_AES_256_GCM_SHA384");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_DHE_RSA_WITH_AES_128_GCM_SHA256".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_DHE_RSA_WITH_AES_128_GCM_SHA256", "TLS_DHE_RSA_WITH_AES_128_GCM_SHA256", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_DHE_RSA_WITH_AES_128_GCM_SHA256");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_DHE_RSA_WITH_AES_256_CBC_SHA".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_DHE_RSA_WITH_AES_256_CBC_SHA", "TLS_DHE_RSA_WITH_AES_256_CBC_SHA", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_DHE_RSA_WITH_AES_256_CBC_SHA");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_DHE_RSA_WITH_AES_128_CBC_SHA".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_DHE_RSA_WITH_AES_128_CBC_SHA", "TLS_DHE_RSA_WITH_AES_128_CBC_SHA", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_DHE_RSA_WITH_AES_128_CBC_SHA");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_RSA_WITH_AES_256_GCM_SHA384".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_RSA_WITH_AES_256_GCM_SHA384", "TLS_RSA_WITH_AES_256_GCM_SHA384", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_RSA_WITH_AES_256_GCM_SHA384");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_RSA_WITH_AES_128_GCM_SHA256".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_RSA_WITH_AES_128_GCM_SHA256", "TLS_RSA_WITH_AES_128_GCM_SHA256", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_RSA_WITH_AES_128_GCM_SHA256");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_RSA_WITH_AES_256_CBC_SHA256".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_RSA_WITH_AES_256_CBC_SHA256", "TLS_RSA_WITH_AES_256_CBC_SHA256", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_RSA_WITH_AES_256_CBC_SHA256");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_RSA_WITH_AES_128_CBC_SHA256".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_RSA_WITH_AES_128_CBC_SHA256", "TLS_RSA_WITH_AES_128_CBC_SHA256", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_RSA_WITH_AES_128_CBC_SHA256");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_RSA_WITH_AES_256_CBC_SHA".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_RSA_WITH_AES_256_CBC_SHA", "TLS_RSA_WITH_AES_256_CBC_SHA", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_RSA_WITH_AES_256_CBC_SHA");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_RSA_WITH_AES_128_CBC_SHA".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_RSA_WITH_AES_128_CBC_SHA", "TLS_RSA_WITH_AES_128_CBC_SHA", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_RSA_WITH_AES_128_CBC_SHA");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384", "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256", "TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA384".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA384", "TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA384", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA384");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA256".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA256", "TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA256", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA256");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA", "TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA", "TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_DHE_DSS_WITH_AES_256_CBC_SHA256".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_DHE_DSS_WITH_AES_256_CBC_SHA256", "TLS_DHE_DSS_WITH_AES_256_CBC_SHA256", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_DHE_DSS_WITH_AES_256_CBC_SHA256");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_DHE_DSS_WITH_AES_128_CBC_SHA256".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_DHE_DSS_WITH_AES_128_CBC_SHA256", "TLS_DHE_DSS_WITH_AES_128_CBC_SHA256", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_DHE_DSS_WITH_AES_128_CBC_SHA256");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_DHE_DSS_WITH_AES_256_CBC_SHA".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_DHE_DSS_WITH_AES_256_CBC_SHA", "TLS_DHE_DSS_WITH_AES_256_CBC_SHA", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_DHE_DSS_WITH_AES_256_CBC_SHA");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_DHE_DSS_WITH_AES_128_CBC_SHA".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_DHE_DSS_WITH_AES_128_CBC_SHA", "TLS_DHE_DSS_WITH_AES_128_CBC_SHA", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_DHE_DSS_WITH_AES_128_CBC_SHA");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_RSA_WITH_3DES_EDE_CBC_SHA".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_RSA_WITH_3DES_EDE_CBC_SHA", "TLS_RSA_WITH_3DES_EDE_CBC_SHA", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_RSA_WITH_3DES_EDE_CBC_SHA");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_DHE_DSS_WITH_3DES_EDE_CBC_SHA".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_DHE_DSS_WITH_3DES_EDE_CBC_SHA", "TLS_DHE_DSS_WITH_3DES_EDE_CBC_SHA", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_DHE_DSS_WITH_3DES_EDE_CBC_SHA");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256", "TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384", "TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384", global::System.Management.Automation.CompletionResultType.ParameterValue, "TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384");
            }
        }
    }
}