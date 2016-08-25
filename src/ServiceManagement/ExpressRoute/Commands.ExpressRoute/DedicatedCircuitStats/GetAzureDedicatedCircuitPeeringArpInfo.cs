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


using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.ExpressRoute.Models;
using System;

namespace Microsoft.WindowsAzure.Commands.ExpressRoute
{
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Xml;
    public class CommonParser
    {
        public static string parseResult(string url, StringBuilder sb)
        {
            var contents = new System.Net.WebClient().DownloadString(url);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(contents);
            bool firstLine = true;
            StringBuilder header = new StringBuilder();
            StringBuilder body = new StringBuilder();
            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                foreach (XmlNode nodeChild in node.ChildNodes)
                {
                    if (firstLine)
                    {
                        header.Append(string.Format("{0,20}", nodeChild.Name));
                    }
                    body.Append(string.Format("{0,20}", nodeChild.InnerText));
                }
                firstLine = false;
                body.AppendLine();
            }
            sb.AppendLine();
            sb.AppendLine(header.ToString());
            sb.AppendLine(body.ToString());
            return sb.ToString();
        }
    }

    [Cmdlet(VerbsCommon.Get, "AzureDedicatedCircuitPeeringArpInfo"), OutputType(typeof(string), typeof(IEnumerable<string>))]
    public class GetAzureDedicatedCircuitPeeringArpInfoCommand : ExpressRouteBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service Key representing the Dedicated Circuit")]
        public Guid ServiceKey { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "Bgp Peering Access Type: Public or Private or Microsoft")]
        public BgpPeeringAccessType AccessType { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Device Path: Primary or Secondary")]
        public DevicePath Path { get; set; }

        public override void ExecuteCmdlet()
        {
            var arpInfo = ExpressRouteClient.GetAzureDedicatedCircuitPeeringArpInfo(ServiceKey, AccessType, Path);
            // parse output to a more user-friendly output
           StringBuilder sb = new StringBuilder();
           sb.AppendLine("");
           sb.AppendLine("ARP Info:");
           WriteObject(CommonParser.parseResult(arpInfo, sb));
        }

        
    }
}
