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

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSAdditionalUnattendContent
    {
        public string ComponentName { get; set; }

        public string Content { get; set; }

        public string PassName { get; set; }

        public string SettingName { get; set; }
    }

    public static class PSAdditionalUnattendContentConversions
    {
        public static PSAdditionalUnattendContent ToPSAdditionalUnattendContent(this AdditionalUnattendContent auc)
        {
            if (auc == null)
            {
                return null;
            }

            var result = new PSAdditionalUnattendContent
            {
                ComponentName = auc.ComponentName,
                Content = auc.Content,
                PassName = auc.PassName,
                SettingName = auc.SettingName,
            };

            return result;
        }

        public static AdditionalUnattendContent ToAdditionalUnattendContent(this PSAdditionalUnattendContent psauc)
        {
            if (psauc == null)
            {
                return null;
            }

            var result = new AdditionalUnattendContent
            {
                ComponentName = psauc.ComponentName,
                Content = psauc.Content,
                PassName = psauc.PassName,
                SettingName = psauc.SettingName,
            };

            return result;
        }
    }
}
