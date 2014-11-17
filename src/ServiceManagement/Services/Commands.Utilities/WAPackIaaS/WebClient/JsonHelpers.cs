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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.WebClient
{
    internal class JsonHelpers<T>
    {
        internal String Serialize(object obj)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new JsonNumericConverter());
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);

            return json;
        }

        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        internal List<T> Deserialize(string json)
        {
            var returnList = new List<T>();

            if (String.IsNullOrEmpty(json))
            {
                return returnList;
            }


            byte[] byteArray = Encoding.UTF8.GetBytes(json);
            using (var stream = new MemoryStream(byteArray))
            {
                using (var reader = new StreamReader(stream))
                {
                    var jObject = JObject.Parse(reader.ReadToEnd());
                    var settings = new JsonSerializerSettings {MissingMemberHandling = MissingMemberHandling.Ignore};

                    JToken value;

                    if (jObject.TryGetValue("value", out value))
                    {
                        foreach (var obj in jObject["value"])
                        {
                            var result = JsonConvert.DeserializeObject<T>(obj.ToString());
                            returnList.Add(result);
                        }
                    }
                    else
                    {
                        var results = JsonConvert.DeserializeObject<T>(jObject.ToString(), settings);
                        returnList.Add(results);
                    }
                }
            }
            return returnList;
        }

    }
}
