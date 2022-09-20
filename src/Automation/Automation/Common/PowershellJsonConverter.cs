// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Automation.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Automation.Common
{
    
    public static class PowerShellJsonConverter
    {
        public static string Serialize(object inputObject)
        {
            if (inputObject == null)
            {
                return null;
            }

            Hashtable parameters = new Hashtable();
            parameters.Add(Constants.PsCommandParamInputObject, inputObject);
            parameters.Add(Constants.PsCommandParamDepth, Constants.PsCommandValueDepth);
            parameters.Add(Constants.PsCommandParamCompress, true);
            var result = PowerShellJsonConverter.InvokeScript(Constants.PsCommandConvertToJson, parameters);

            if (result.Count != 1)
            {
                return null;
            }

            return result[0].ToString();
        }
  public static PSObject Deserialize(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            Hashtable parameters = new Hashtable();
            int PSVersion = 5;
            Collection<PSObject> result=null;
            PSVersion = Int32.Parse(AzurePSCmdlet.PowerShellVersion[0].ToString());
            parameters.Add(Constants.PsCommandParamInputObject, json);
            if (PSVersion > 6)
            {
                try
                {
                    result = PowerShellJsonConverter.InvokeScript(Constants.PsCommandConvertFromJson, parameters,true);
                    if (result.Count != 1)
                    {
                        return null;
                    }
                    return result[0];
                }
                catch (Exception)
                {
                    return json;
                }
                
            }
            else
            {
                try
                {
                    result = PowerShellJsonConverter.InvokeScript(Constants.PsCommandConvertFromJson, parameters);
                    if (result.Count != 1)
                    {
                        return null;
                    }
                    return result[0];
                }
                catch (Exception)
                {
                    return json;
                }
                
            }

        }

        private static Collection<PSObject> InvokeScript(string scriptName, Hashtable parameters, bool addNoEnumerateSwitchToParameters=false)
        {
            using (var powerShell = System.Management.Automation.PowerShell.Create(RunspaceMode.CurrentRunspace))
            {
                powerShell.AddCommand(scriptName);
                foreach (DictionaryEntry parameter in parameters)
                {
                    powerShell.AddParameter(parameter.Key.ToString(), parameter.Value);
                }
                if(addNoEnumerateSwitchToParameters)
                {
                    powerShell.AddParameter("NoEnumerate");
                }
                var result = powerShell.Invoke();
                //Error handling
                if (powerShell.HadErrors)
                {
                    StringBuilder errorStringBuilder = new StringBuilder();
                    foreach (var error in powerShell.Streams.Error)
                    {
                        errorStringBuilder.AppendLine(error.InvocationInfo.MyCommand.Name + " : " + error.Exception.Message);
                        errorStringBuilder.AppendLine(error.InvocationInfo.PositionMessage);
                    }
                    throw new AzureAutomationOperationException(string.Format(CultureInfo.CurrentCulture,
                       Resources.PowershellJsonDecrypterFailed, errorStringBuilder.ToString()));
                }
                return result;
            }
        }
    }
}

