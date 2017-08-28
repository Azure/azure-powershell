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

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Azure VM specific recovery point access info class.
    /// </summary>
    public class AzureVmRecoveryPointAccessInfo : RecoveryPointAccessInfo
    {
        /// <summary>
        /// OS Type of the client script 
        /// </summary>
        public string OsType { get; set; }

        /// <summary>
        /// Password required to run the script.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Filename of the downloaded script
        /// </summary>
        public string Filename { get; set; }

        public AzureVmRecoveryPointAccessInfo(string osType, string fileName, string password)
        {
            this.OsType = osType;
            this.Filename = fileName;
            this.Password = password;
        }
    }
}