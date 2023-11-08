using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Compute.Common
{
    internal class ImageAliases
    {
        public static Dictionary<string, Dictionary<string, string>> ImageAliasValues = new Dictionary<string, Dictionary<string, string>>()
        {
            {
                "Ubuntu2204", new Dictionary<string, string>()
                {
                    {"publisher", "Canonical"},
                    {"offer", "0001-com-ubuntu-server-jammy"},
                    {"sku", "22_04-lts-gen2"},
                    {"version", "latest"}
                }
            },
            {
                "CentOS85Gen2", new Dictionary<string, string>()
                {
                    {"publisher", "OpenLogic"},
                    {"offer", "CentOS"},
                    {"sku", "8_5-gen2"},
                    {"version", "latest"}
                }
            },
            {
                "Debian11", new Dictionary<string, string>()
                {
                    {"publisher", "Debian"},
                    {"offer", "debian-11"},
                    {"sku", "11-backports-gen2"},
                    {"version", "latest"}
                }
            },
            {
                "OpenSuseLeap154Gen2", new Dictionary<string, string>()
                {
                    {"publisher", "SUSE"},
                    {"offer", "openSUSE-leap-15-4"},
                    {"sku", "gen2"},
                    {"version", "latest"}
                }
            },
            {
                "RHELRaw8LVMGen2", new Dictionary<string, string>()
                {
                    {"publisher", "RedHat"},
                    {"offer", "RHEL"},
                    {"sku", "8-lvm-gen2"},
                    {"version", "latest"}
                }
            },
            {
                "SuseSles15SP3", new Dictionary<string, string>()
                {
                    {"publisher", "SUSE"},
                    {"offer", "sles-15-sp3"},
                    {"sku", "gen2"},
                    {"version", "latest"}
                }
            },
            {
                "FlatcarLinuxFreeGen2", new Dictionary<string, string>()
                {
                    {"publisher", "kinvolk"},
                    {"offer", "flatcar-container-linux-free"},
                    {"sku", "stable-gen2"},
                    {"version", "latest"}
                }
            },
            //windows aliases
            {
                "Win2022AzureEdition", new Dictionary<string, string>()
                {
                    {"publisher", "MicrosoftWindowsServer"},
                    {"offer", "WindowsServer"},
                    {"sku", "2022-datacenter-azure-edition"},
                    {"version", "latest"}
                }
            },
            {
                "Win2022AzureEditionCore", new Dictionary<string, string>()
                {
                    {"publisher", "MicrosoftWindowsServer"},
                    {"offer", "WindowsServer"},
                    {"sku", "2022-datacenter-azure-edition-core"},
                    {"version", "latest"}
                }
            },
            {
                "Win2019Datacenter", new Dictionary<string, string>()
                {
                    {"publisher", "MicrosoftWindowsServer"},
                    {"offer", "WindowsServer"},
                    {"sku", "2019-Datacenter"},
                    {"version", "latest"}
                }
            },
            {
                "Win2019DatacenterGen2", new Dictionary<string, string>()
                {
                    {"publisher", "MicrosoftWindowsServer"},
                    {"offer", "WindowsServer"},
                    {"sku", "2019-DATACENTER-GENSECOND"},
                    {"version", "latest"}
                }
            },
            {
                "Win2016Datacenter", new Dictionary<string, string>()
                {
                    {"publisher", "MicrosoftWindowsServer"},
                    {"offer", "WindowsServer"},
                    {"sku", "2016-Datacenter"},
                    {"version", "latest"}
                }
            },
            {
                "Win2012R2Datacenter", new Dictionary<string, string>()
                {
                    {"publisher", "MicrosoftWindowsServer"},
                    {"offer", "WindowsServer"},
                    {"sku", "2012-R2-Datacenter"},
                    {"version", "latest"}
                }
            },
            {
                "Win2012Datacenter", new Dictionary<string, string>()
                {
                    {"publisher", "MicrosoftWindowsServer"},
                    {"offer", "WindowsServer"},
                    {"sku", "2012-Datacenter"},
                    {"version", "latest"}
                }
            },
            {
                "Win10", new Dictionary<string, string>()
                {
                    {"publisher", "MicrosoftVisualStudio"},
                    {"offer", "Windows"},
                    {"sku", "Windows-10-N-x64"},
                    {"version", "latest"}
                }
            },
            {
                "Win2016DataCenterGenSecond", new Dictionary<string, string>()
                {
                    {"publisher", "MicrosoftWindowsServer"},
                    {"offer", "WindowsServer"},
                    {"sku", "2016-datacenter-gensecond"},
                    {"version", "latest"}
                }
            }
            

            // Add more dictionary entries here...  
        };



    }
}
