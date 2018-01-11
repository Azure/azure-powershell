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

namespace Microsoft.Azure.Commands.Common.Strategies.Compute
{
    static class Images
    {
        public static Dictionary<string, Dictionary<string, Image>> Instance { get; } =
            new Dictionary<string, Dictionary<string, Image>>
            {
                {
                    "Linux",
                    new Dictionary<string, Image>
                    {
                        {
                            "CentOS",
                            new Image
                            {
                                publisher = "OpenLogic",
                                offer = "CentOS",
                                sku = "7.3",
                                version = "latest",
                            }
                        },
                        {
                            "CoreOS",
                            new Image
                            {
                                publisher = "CoreOS",
                                offer = "CoreOS",
                                sku = "Stable",
                                version = "latest",

                            }
                        },
                        {
                            "Debian",
                            new Image
                            {
                                publisher = "credativ",
                                offer = "Debian",
                                sku = "8",
                                version = "latest",
                            }
                        },
                        {
                            "openSUSE-Leap",
                            new Image
                            {
                                publisher = "SUSE",
                                offer = "openSUSE-Leap",
                                sku = "42.2",
                                version = "latest",
                            }
                        },
                        {
                            "RHEL",
                            new Image
                            {
                                publisher = "RedHat",
                                offer = "RHEL",
                                sku = "7.3",
                                version = "latest"
                            }
                        },
                        {
                            "SLES",
                            new Image
                            {
                                publisher = "SUSE",
                                offer = "SLES",
                                sku = "12-SP2",
                                version = "latest",
                            }
                        },
                        {
                            "UbuntuLTS",
                            new Image
                            {
                                publisher = "Canonical",
                                offer = "UbuntuServer",
                                sku = "16.04-LTS",
                                version = "latest",
                            }
                        }
                    }
                },
                {
                    "Windows",
                    new Dictionary<string, Image>
                    {
                        {
                            "Win2016Datacenter",
                            new Image
                            {
                                publisher = "MicrosoftWindowsServer",
                                offer = "WindowsServer",
                                sku = "2016-Datacenter",
                                version = "latest",
                            }
                        },
                        {
                            "Win2012R2Datacenter",
                            new Image
                            {
                                publisher = "MicrosoftWindowsServer",
                                offer = "WindowsServer",
                                sku = "2012-R2-Datacenter",
                                version = "latest",
                            }
                        },
                        {
                            "Win2012Datacenter",
                            new Image
                            {
                                publisher = "MicrosoftWindowsServer",
                                offer = "WindowsServer",
                                sku = "2012-Datacenter",
                                version = "latest",
                            }
                        },
                        {
                            "Win2008R2SP1",
                            new Image
                            {
                                publisher = "MicrosoftWindowsServer",
                                offer = "WindowsServer",
                                sku = "2008-R2-SP1",
                                version = "latest",
                            }
                        }
                    }
                }
            };        
    }
}
