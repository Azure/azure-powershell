using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Strategies.Compute
{
    public static class Images
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
