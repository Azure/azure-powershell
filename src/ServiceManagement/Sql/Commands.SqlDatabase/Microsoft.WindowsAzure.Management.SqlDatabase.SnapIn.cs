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

using System.ComponentModel;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.PowerShell
{
    /// <summary>
    /// Installer class for the Microsoft Azure Platform PowerShell Cmdlets
    /// Windows Powershell v2.0 snap-in.
    /// </summary>
    [RunInstaller(true)]
    public class WAPPSCmdletsSnapIn : PSSnapIn
    {
        /// <summary>
        /// Gets the snap-in description.
        /// </summary>
        public override string Description
        {
            get { return "Cmdlets to create and configure Microsoft Azure Sql Databases"; }
        }

        /// <summary>
        /// Gets the snap-in name.
        /// </summary>
        public override string Name
        {
            get { return "WindowsAzureSqlDatabaseCmdlets"; }
        }

        /// <summary>
        /// Gets the snap-in vendor.
        /// </summary>
        public override string Vendor
        {
            get { return "Microsoft Corporation"; }
        }
    }
}