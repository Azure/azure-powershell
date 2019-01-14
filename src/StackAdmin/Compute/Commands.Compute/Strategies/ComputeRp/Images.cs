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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Strategies.ComputeRp
{
    static class Images
    {
        public static Dictionary<string, Dictionary<string, ImageReference>> Instance { get; } =
            new Dictionary<string, Dictionary<string, ImageReference>>
            {
                {
                    "Linux",
                    new Dictionary<string, ImageReference>
                    {
                        {
                            "CentOS",
                            new ImageReference
                            {
                                Publisher = "OpenLogic",
                                Offer = "CentOS",
                                Sku = "7.3",
                                Version = "latest",
                            }
                        },
                        {
                            "CoreOS",
                            new ImageReference
                            {
                                Publisher = "CoreOS",
                                Offer = "CoreOS",
                                Sku = "Stable",
                                Version = "latest",

                            }
                        },
                        {
                            "Debian",
                            new ImageReference
                            {
                                Publisher = "credativ",
                                Offer = "Debian",
                                Sku = "8",
                                Version = "latest",
                            }
                        },
                        {
                            "openSUSE-Leap",
                            new ImageReference
                            {
                                Publisher = "SUSE",
                                Offer = "openSUSE-Leap",
                                Sku = "42.2",
                                Version = "latest",
                            }
                        },
                        {
                            "RHEL",
                            new ImageReference
                            {
                                Publisher = "RedHat",
                                Offer = "RHEL",
                                Sku = "7.3",
                                Version = "latest"
                            }
                        },
                        {
                            "SLES",
                            new ImageReference
                            {
                                Publisher = "SUSE",
                                Offer = "SLES",
                                Sku = "12-SP2",
                                Version = "latest",
                            }
                        },
                        {
                            "UbuntuLTS",
                            new ImageReference
                            {
                                Publisher = "Canonical",
                                Offer = "UbuntuServer",
                                Sku = "16.04-LTS",
                                Version = "latest",
                            }
                        }
                    }
                },
                {
                    "Windows",
                    new Dictionary<string, ImageReference>
                    {
                        {
                            "Win2016Datacenter",
                            new ImageReference
                            {
                                Publisher = "MicrosoftWindowsServer",
                                Offer = "WindowsServer",
                                Sku = "2016-Datacenter",
                                Version = "latest",
                            }
                        },
                        {
                            "Win2012R2Datacenter",
                            new ImageReference
                            {
                                Publisher = "MicrosoftWindowsServer",
                                Offer = "WindowsServer",
                                Sku = "2012-R2-Datacenter",
                                Version = "latest",
                            }
                        },
                        {
                            "Win2012Datacenter",
                            new ImageReference
                            {
                                Publisher = "MicrosoftWindowsServer",
                                Offer = "WindowsServer",
                                Sku = "2012-Datacenter",
                                Version = "latest",
                            }
                        },
                        {
                            "Win2008R2SP1",
                            new ImageReference
                            {
                                Publisher = "MicrosoftWindowsServer",
                                Offer = "WindowsServer",
                                Sku = "2008-R2-SP1",
                                Version = "latest",
                            }
                        }
                    }
                }
            };        
    }
}
