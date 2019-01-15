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

using Microsoft.Azure.Management.Compute.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Microsoft.Azure.Commands.Compute.Strategies.ComputeRp
{
    static class Images
    {
        public static Dictionary<string, Dictionary<string, ImageReference>> GenerateImageDictionary()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Microsoft.Azure.Commands.Compute.Strategies.ComputeRp.Images.json";

            var instanceDict = new Dictionary<string, Dictionary<string, ImageReference>>();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                Dictionary<string, object> jsonFile = (Dictionary<string, object>)JsonConvert.DeserializeObject(reader.ReadToEnd(), typeof(Dictionary<string, object>));
                foreach (var oSType in jsonFile.Keys)
                {
                    Dictionary<string, object> osDict = (Dictionary<string, object>)JsonConvert.DeserializeObject(jsonFile[oSType].ToString(), typeof(Dictionary<string, object>));
                    Dictionary<string, ImageReference> innerComputeTypeDict = new Dictionary<string, ImageReference>();
                    foreach (var computerType in osDict.Keys)
                    {
                        Dictionary<string, string> computerDict = (Dictionary<string, string>)JsonConvert.DeserializeObject(osDict[computerType].ToString(), typeof(Dictionary<string, string>));
                        ImageReference innerImageReference = new ImageReference
                        {
                            Publisher = computerDict["publisher"],
                            Offer = computerDict["offer"],
                            Sku = computerDict["sku"],
                            Version = computerDict["version"]
                        };
                        innerComputeTypeDict.Add(computerType, innerImageReference);
                    }
                    instanceDict.Add(oSType, innerComputeTypeDict);
                }
            }

            return instanceDict;
        }

        public static Dictionary<string, Dictionary<string, ImageReference>> Instance { get; } = GenerateImageDictionary();   
    }
}
