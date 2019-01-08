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

using Microsoft.Azure.Management.DataLake.Analytics.Models;
using System;

namespace Microsoft.Azure.Commands.DataLakeAnalytics.Models
{
    public class PSDataLakeAnalyticsAcl
    {
        public string Type { get; set; }

        public string Id { get; set; }

        public DataLakeAnalyticsEnums.PermissionType Permissions { get; set; }

        public PSDataLakeAnalyticsAcl(Acl baseAcl)
        {
            Type = MapAceType(baseAcl.AceType);
            Id = baseAcl.PrincipalId?.ToString() ?? string.Empty;
            Permissions = MapPermissionType(baseAcl.Permission);
        }

        private static string MapAceType(string aceType)
        {
            switch (aceType)
            {
                case AclType.User: case AclType.Group: case AclType.Other: return aceType;
                case AclType.UserObj: return "UserOwner";
                case AclType.GroupObj: return "GroupOwner";
                default: throw new ArgumentException("AceType is invalid");
            }
        }

        private static DataLakeAnalyticsEnums.PermissionType MapPermissionType(string permissionType)
        {
            switch (permissionType)
            {
                case PermissionType.None: return DataLakeAnalyticsEnums.PermissionType.None;
                case PermissionType.Use: return DataLakeAnalyticsEnums.PermissionType.Read;
                case PermissionType.All: return DataLakeAnalyticsEnums.PermissionType.ReadWrite;
                default: throw new ArgumentException("PermissionType is invalid");
            }
        }
    }
}
