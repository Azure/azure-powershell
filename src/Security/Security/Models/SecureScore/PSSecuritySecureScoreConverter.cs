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

using Microsoft.Azure.Management.Security.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.SecurityCenter.Models.SecureScore
{
    public static class PSSecuritySecureScoreConverter
    {
        public static PSSecuritySecureScore ConvertToPSType(this SecureScoreItem value)
        {
            return new PSSecuritySecureScore
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                DisplayName = value.DisplayName,
                CurrentScore = value.Current,
                MaxScore = value.Max,
                Percentage = value.Percentage,
                Weight = value.Weight
            };
        }

        public static List<PSSecuritySecureScore> ConvertToPSType(this IEnumerable<SecureScoreItem> value)
        {
            return value.Select(item => item.ConvertToPSType()).ToList();
        }
    }
}
