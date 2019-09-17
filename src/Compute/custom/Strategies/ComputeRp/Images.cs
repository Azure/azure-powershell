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

using Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201;
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
            string ImageJson = @"{
  ""Linux"": {
    ""CentOS"": {
      ""publisher"": ""OpenLogic"",
      ""offer"": ""CentOS"",
      ""sku"": ""7.5"",
      ""version"": ""latest""
    },
    ""CoreOS"": {
      ""publisher"": ""CoreOS"",
      ""offer"": ""CoreOS"",
      ""sku"": ""Stable"",
      ""version"": ""latest""
    },
    ""Debian"": {
      ""publisher"": ""Debian"",
      ""offer"": ""debian-10"",
      ""sku"": ""10"",
      ""version"": ""latest""
    },
    ""openSUSE-Leap"": {
      ""publisher"": ""SUSE"",
      ""offer"": ""openSUSE-Leap"",
      ""sku"": ""42.3"",
      ""version"": ""latest""
    },
    ""RHEL"": {
      ""publisher"": ""RedHat"",
      ""offer"": ""RHEL"",
      ""sku"": ""7-RAW"",
      ""version"": ""latest""
    },
    ""SLES"": {
      ""publisher"": ""SUSE"",
      ""offer"": ""SLES"",
      ""sku"": ""15"",
      ""version"": ""latest""
    },
    ""UbuntuLTS"": {
      ""publisher"": ""Canonical"",
      ""offer"": ""UbuntuServer"",
      ""sku"": ""18.04-LTS"",
      ""version"": ""latest""
    }
  },
  ""Windows"": {
    ""Win2019Datacenter"": {
      ""publisher"": ""MicrosoftWindowsServer"",
      ""offer"": ""WindowsServer"",
      ""sku"": ""2019-Datacenter"",
      ""version"": ""latest""
    },
    ""Win2016Datacenter"": {
      ""publisher"": ""MicrosoftWindowsServer"",
      ""offer"": ""WindowsServer"",
      ""sku"": ""2016-Datacenter"",
      ""version"": ""latest""
    },
    ""Win2012R2Datacenter"": {
      ""publisher"": ""MicrosoftWindowsServer"",
      ""offer"": ""WindowsServer"",
      ""sku"": ""2012-R2-Datacenter"",
      ""version"": ""latest""
    },
    ""Win2012Datacenter"": {
      ""publisher"": ""MicrosoftWindowsServer"",
      ""offer"": ""WindowsServer"",
      ""sku"": ""2012-Datacenter"",
      ""version"": ""latest""
    },
    ""Win2008R2SP1"": {
      ""publisher"": ""MicrosoftWindowsServer"",
      ""offer"": ""WindowsServer"",
      ""sku"": ""2008-R2-SP1"",
      ""version"": ""latest""
    },
    ""Win10"": {
      ""publisher"": ""MicrosoftVisualStudio"",
      ""offer"": ""Windows"",
      ""sku"": ""Windows-10-N-x64"",
      ""version"": ""latest""
    }
  }
}
";

        var instanceDict = new Dictionary<string, Dictionary<string, ImageReference>>();
            
            using (Stream stream = new MemoryStream(System.Text.Encoding.ASCII.GetBytes(ImageJson)))
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
