using Microsoft.Azure.Commands.Automation.Properties;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace Microsoft.Azure.Commands.Automation.Common
{
    public static class PowershellJsonConverter
    {
        private const string PsCommandConvertToJson = "ConvertTo-Json";
        private const string PsCommandConvertFromJson = "ConvertFrom-Json";
        private const string PsCommandParamInputObject = "InputObject";
        private const string PsCommandParamDepth = "Depth";

        public static PSObject Deserialize(string json)
        {
            if (String.IsNullOrEmpty(json))
            {
                return null;
            }

            Hashtable parameters = new Hashtable();
            parameters.Add(PsCommandParamInputObject, json);
            var result = PowershellJsonConverter.InvokeScript(PsCommandConvertFromJson, parameters);
            if (result.Count != 1)
            {
                return null;
            }

            //count == 1. return the first psobject
            return result[0];
        }

        /// <summary>
        /// Invokes a powershell script using the same runspace as the caller.
        /// </summary>
        /// <param name="scriptName">script name</param>
        /// <param name="parameters">parameters for the script</param>
        /// <returns></returns>
        private static Collection<PSObject> InvokeScript(string scriptName, Hashtable parameters)
        {
            using (Pipeline pipe = Runspace.DefaultRunspace.CreateNestedPipeline())
            {
                Command scriptCommand = new Command(scriptName);

                foreach (DictionaryEntry parameter in parameters)
                {
                    CommandParameter commandParm = new CommandParameter(parameter.Key.ToString(), parameter.Value);
                    scriptCommand.Parameters.Add(commandParm);
                }
                pipe.Commands.Add(scriptCommand);

                var result = pipe.Invoke();

                //Error handling
                if (pipe.Error.Count > 0)
                {
                    StringBuilder errorStringBuilder = new StringBuilder();
                    while (!pipe.Error.EndOfPipeline)
                    {
                        var value = pipe.Error.Read() as PSObject;
                        if (value != null)
                        {
                            var r = value.BaseObject as ErrorRecord;
                            if (r != null)
                            {
                                errorStringBuilder.AppendLine(r.InvocationInfo.MyCommand.Name + " : " + r.Exception.Message);
                                errorStringBuilder.AppendLine(r.InvocationInfo.PositionMessage);
                            }
                        }
                    }

                    throw new AzureAutomationOperationException(string.Format(CultureInfo.CurrentCulture,
                        Resources.PowershellJsonDecrypterFailed, errorStringBuilder.ToString()));
                }
                return result;
            }
        }
    }
}
