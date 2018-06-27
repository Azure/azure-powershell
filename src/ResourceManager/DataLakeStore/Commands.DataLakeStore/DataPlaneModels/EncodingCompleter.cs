using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    public class EncodingCompleterAttribute :ArgumentCompleterAttribute
    {
        public EncodingCompleterAttribute(params string[] resourceTypes) : base(CreateScriptBlock(resourceTypes))
        {
        }

        public static string[] FindEncodings(string[] resourceTypes, int timeout)
        {
            return FindLocations(resourceTypes);
        }

        public static ScriptBlock CreateScriptBlock(string[] resourceTypes)
        {
            string scriptResourceTypeList = "'" + String.Join("' , '", resourceTypes) + "'";
            string script = "param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)\n" +
                            String.Format("$resourceTypes = {0}\n", scriptResourceTypeList) +
                            "$locations = [Microsoft.Azure.Commands.DataLakeStore.Models.EncodingCompleterAttribute]::FindEncodings($resourceTypes)\n" +
                            "$locations | Where-Object { $_ -Like \"'$wordToComplete*\" } | Sort-Object | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }";
            ScriptBlock scriptBlock = ScriptBlock.Create(script);
            return scriptBlock;
        }
    }
}
