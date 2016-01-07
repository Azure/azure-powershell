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

using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Microsoft.Azure.Management.WebSites.Models;
using Newtonsoft.Json.Linq;


namespace Microsoft.Azure.Commands.WebApps.Validations
{
    public class ValidateConnectionStringsAttribute : ValidateArgumentsAttribute
    {
        protected override void Validate(object arguments, EngineIntrinsics engineIntrinsics)
        {
            /*
            This would be required for Powershell as it is easy to construct Hashtables in Posh vs Dictionary. For CLU when the user passes
            this - "{ \"connstring1\": { \"Type\": \"MySql1212\", \"Value\": \"string value 1\" }}" as the connectionstring then 
            JsonConvert.Deserialize() correctly converts it into a Dictionary<string, ConnStringValueTypePair>. Inbuilt model validation 
            in the website MAML library works well. Hence this is not required for CLU. When we port this to master branch then we need to 
            use #if def and have two definitions for connectionstrings, each for CLU and Powershell resp. as follows:
            - public Dictionary<string, ConnStringValueTypePair> ConnectionStrings { get; set; }
            - public Hashtable ConnectionStrings { get; set; }
            var hashtable = arguments as Hashtable;
            if (hashtable == null)
            {
                throw new PSArgumentException("Argument must be of type 'System.Collections.Hashtable'");
            }

            foreach (var key in hashtable.Keys)
            {
                if (key.GetType() != typeof(string))
                {
                    throw new PSArgumentException(string.Format("Key '{0}' should be of type string instead of {1}", key, key.GetType()));
                }

                var typeValuePair = hashtable[key] as Hashtable;
                if (typeValuePair == null)
                {
                    throw new PSArgumentException("Connection string type value pair must be of type 'System.Collections.Hashtable'");
                }
                var typeValuePairIgnoreCase = new Hashtable(typeValuePair, StringComparer.OrdinalIgnoreCase);

                if (!typeValuePairIgnoreCase.ContainsKey("Type") || typeValuePairIgnoreCase["Type"].GetType() != typeof(string))
                {
                    throw new PSArgumentException("Connection string type must be specified.");
                }

                DatabaseServerType type;
                if (!Enum.TryParse(typeValuePairIgnoreCase["Type"].ToString(), true, out type))
                {
                    throw new PSArgumentException("Database server type values are [MySql| SQLAzure| SQLServer| Custom]");
                }

                if (!typeValuePairIgnoreCase.ContainsKey("Value") || typeValuePairIgnoreCase["Value"].GetType() != typeof(string))
                {
                    throw new PSArgumentException("Connection string value must be specified.");
                }
            }*/
        }
    }
}
