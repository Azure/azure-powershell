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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    /// <summary>
    /// AutoPatching settings to configure auto-patching on SQL VM
    /// </summary>
    public class AutoPatchingSettings
    {
        private const string Important = "important";
        private const string Optional = "optional";

        /// <summary>
        /// Enable / Disable auto patching
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// Day of the week
        /// </summary>
        public string DayOfWeek { get; set; }

        /// <summary>
        /// Maintainance Windows Start hour ( 0 to 23 ) 
        /// </summary>
        public int MaintenanceWindowStartingHour { get; set; }
        
        /// <summary>
        /// Maintainance window duration in minutes
        /// </summary>
        public int MaintenanceWindowDuration { get; set; }
        
        /// <summary>
        /// pathc category returned as string
        /// </summary>
        public string PatchCategory 
        {
            get
            {
                return this.patchCategory.ToString("G");
            }
        }

        private AzureVMSqlServerAutoPatchingPatchCategoryEnum patchCategory = AzureVMSqlServerAutoPatchingPatchCategoryEnum.Unknown;

        public void UpdatePatchingCategory(AzureVMSqlServerAutoPatchingPatchCategoryEnum category)
        {
            this.patchCategory = category;
        }

        /// <summary>
        /// Update patching category enum
        /// </summary>
        /// <param name="category"></param>
        public void UpdatePatchingCategory(string category)
        {
            if (!string.IsNullOrEmpty(category))
            {
                switch (category.ToLower())
                {
                    case Important:
                        this.patchCategory = AzureVMSqlServerAutoPatchingPatchCategoryEnum.Important;
                        break;

                    case Optional:
                        this.patchCategory = AzureVMSqlServerAutoPatchingPatchCategoryEnum.Optional;
                        break;

                    default:
                        this.patchCategory = AzureVMSqlServerAutoPatchingPatchCategoryEnum.Unknown;
                        break;
                }
            }
        }
    }
}
