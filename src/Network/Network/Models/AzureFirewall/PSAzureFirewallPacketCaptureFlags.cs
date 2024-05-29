//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSAzureFirewallPacketCaptureFlags
    {
        public string Type { get; set; }
        public static List<string> AllFlags()
        {
            return new List<string> {
                MNM.AzureFirewallPacketCaptureFlagsType.Fin,
                MNM.AzureFirewallPacketCaptureFlagsType.Syn,
                MNM.AzureFirewallPacketCaptureFlagsType.Rst,
                MNM.AzureFirewallPacketCaptureFlagsType.Push,
                MNM.AzureFirewallPacketCaptureFlagsType.Ack,
                MNM.AzureFirewallPacketCaptureFlagsType.Urg,
            };
        }

        public static PSAzureFirewallPacketCaptureFlags MapUserInputToPacketCaptureFlag (string userInput)
        {
            var supportedFlags = new List<PSAzureFirewallPacketCaptureFlags>
            {
                new PSAzureFirewallPacketCaptureFlags { Type = MNM.AzureFirewallPacketCaptureFlagsType.Fin},
                new PSAzureFirewallPacketCaptureFlags { Type = MNM.AzureFirewallPacketCaptureFlagsType.Syn},
                new PSAzureFirewallPacketCaptureFlags { Type = MNM.AzureFirewallPacketCaptureFlagsType.Rst},
                new PSAzureFirewallPacketCaptureFlags { Type = MNM.AzureFirewallPacketCaptureFlagsType.Push},
                new PSAzureFirewallPacketCaptureFlags { Type = MNM.AzureFirewallPacketCaptureFlagsType.Ack},
                new PSAzureFirewallPacketCaptureFlags { Type = MNM.AzureFirewallPacketCaptureFlagsType.Urg},
            };

            //The actual validation is performed in NRP. Here we are just trying to map user info to our model

            if (!AllFlags().Contains(userInput, StringComparer.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"Invalid flag {userInput}");
            }

            PSAzureFirewallPacketCaptureFlags supportedFlag;
            try
            {
                supportedFlag = supportedFlags.Single(type => type.Type.Equals(userInput, StringComparison.InvariantCultureIgnoreCase));
            }
            catch
            {
                throw new ArgumentException($"Unsupported flag {userInput}. Supported flags are {string.Join(", ", supportedFlags.Select(type => type.Type))}");
            }

            return new PSAzureFirewallPacketCaptureFlags
            {
                Type = supportedFlag.Type
            };
        }
    }
}
