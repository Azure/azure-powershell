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
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Management.Automation;
using System.Text;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Automation.Common
{
    public static class PowerShellJsonConverter
    {
        public static string Serialize(object inputObject)
        {
            return JsonConvert.SerializeObject(ConvertObjectInternal(inputObject));
        }

        private static object ConvertObjectInternal(object inputObject)
        {
            if (inputObject is string @str)
            {
                return str.Trim();
            }
            else if (inputObject is object[] @objectArray)
            {
                return ConvertArray(objectArray);
            }
            else if (inputObject is PSObject @psObject)
            {
                return ConvertPsObject(psObject);
            }
            return inputObject;
        }

        private static Dictionary<string, object> ConvertPsObject(PSObject @psObject)
        {
            Dictionary<string, object> hashTable = new Dictionary<string, object>();
            foreach (var item in @psObject.Properties)
            {
                hashTable.Add(item.Name, ConvertObjectInternal(item.Value));
            }

            return hashTable;
        }

        private static List<object> ConvertArray(object[] objectArray)
        {
            List<object> objectList = objectArray.ToList();
            return objectList.Select(ConvertObjectInternal).ToList();
        }

        public static PSObject Deserialize(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            try
            {
                object result = JsonConvert.DeserializeObject(json);
                return new PSObject(result);
            }
            catch
            {
                return json;
            }
        }
    }
}
