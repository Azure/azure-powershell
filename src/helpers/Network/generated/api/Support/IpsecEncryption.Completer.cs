namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    /// <summary>Argument completer implementation for IpsecEncryption.</summary>
    [System.ComponentModel.TypeConverter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IpsecEncryptionTypeConverter))]
    public partial struct IpsecEncryption :
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
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "DES".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("DES", "DES", global::System.Management.Automation.CompletionResultType.ParameterValue, "DES");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "DES3".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("DES3", "DES3", global::System.Management.Automation.CompletionResultType.ParameterValue, "DES3");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "AES128".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("AES128", "AES128", global::System.Management.Automation.CompletionResultType.ParameterValue, "AES128");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "AES192".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("AES192", "AES192", global::System.Management.Automation.CompletionResultType.ParameterValue, "AES192");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "AES256".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("AES256", "AES256", global::System.Management.Automation.CompletionResultType.ParameterValue, "AES256");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "GCMAES128".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("GCMAES128", "GCMAES128", global::System.Management.Automation.CompletionResultType.ParameterValue, "GCMAES128");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "GCMAES192".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("GCMAES192", "GCMAES192", global::System.Management.Automation.CompletionResultType.ParameterValue, "GCMAES192");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "GCMAES256".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("GCMAES256", "GCMAES256", global::System.Management.Automation.CompletionResultType.ParameterValue, "GCMAES256");
            }
        }
    }
}