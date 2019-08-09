namespace Microsoft.Azure.Commands.MachineLearning
{
    using System.Management.Automation;

    public class MachineLearningSkuNameCompleterAttribute : ArgumentCompleterAttribute
    {
        public MachineLearningSkuNameCompleterAttribute()
               : base(CreateScriptBlock())
        {
        }

        private static ScriptBlock CreateScriptBlock()
        {
            string script = "param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)\n" +
                "$skuNames = [Microsoft.Azure.Commands.MachineLearning.MachineLearningSkuNameCompleterAttribute]::GetSkuNames()\n" +
                "$locations | Where-Object { $_ -Like \"*$wordToComplete*\" } | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }";
            return ScriptBlock.Create(script);
        }

        public static string[] GetSkuNames()
        {
            return new string[] { };
        }
    }
}
