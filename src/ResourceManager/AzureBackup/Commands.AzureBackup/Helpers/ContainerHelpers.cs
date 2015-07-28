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
using System.Management.Automation;
using System.Collections.Generic;
using System.Xml;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using System.Threading;
using Hyak.Common;
using Microsoft.Azure.Commands.AzureBackup.Properties;
using System.Net;
using Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Commands.AzureBackup.Cmdlets;
using System.Linq;
using Microsoft.Azure.Commands.AzureBackup.Models;
using CmdletModel = Microsoft.Azure.Commands.AzureBackup.Models;
using System.Collections.Specialized;
using System.Web;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.AzureBackup.Helpers
{
    internal class ContainerHelpers
    {
        internal static AzureBackupContainerType GetContainerType(string customerType)
        {
            CustomerType type = (CustomerType)Enum.Parse(typeof(CustomerType), customerType);

            AzureBackupContainerType containerType = 0;

            switch (type)
            {
                case CustomerType.DPM:
                    containerType = AzureBackupContainerType.SCDPM;
                    break;
                case CustomerType.InMage:
                    break;
                case CustomerType.Invalid:
                    break;
                case CustomerType.ManagedContainer:
                    break;
                case CustomerType.OBS:
                    containerType = AzureBackupContainerType.Windows;
                    break;
                case CustomerType.SBS:
                    containerType = AzureBackupContainerType.Windows;
                    break;
                case CustomerType.SqlPaaS:
                    break;
                default:
                    break;
            }

            return containerType;
        }
    }
}
