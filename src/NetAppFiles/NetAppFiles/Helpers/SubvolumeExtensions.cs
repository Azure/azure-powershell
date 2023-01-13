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

using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.NetAppFiles.Helpers
{
    public static class SubvolumeExtensions
    {       
        public static PSNetAppFilesSubvolumeInfo ConvertToPs(this Management.NetApp.Models.SubvolumeInfo subvolumeInfo)
        {
            var psSubvolumeInfo = new PSNetAppFilesSubvolumeInfo()
            {
                ResourceGroupName = new ResourceIdentifier(subvolumeInfo.Id).ResourceGroupName,                
                Id = subvolumeInfo.Id,
                Name = subvolumeInfo.Name,
                Type = subvolumeInfo.Type,
                ProvisioningState = subvolumeInfo.ProvisioningState,                
                Path = subvolumeInfo.Path,
                ParentPath = subvolumeInfo.ParentPath,
                Size = subvolumeInfo.Size,  
                SystemData = subvolumeInfo.SystemData?.ToPsSystemData()                                
            };
            return psSubvolumeInfo;
        }

        public static List<PSNetAppFilesSubvolumeInfo> ConvertToPS(this IList<Management.NetApp.Models.SubvolumeInfo> subvolumeInfos)
        {
            return subvolumeInfos.Select(e => e.ConvertToPs()).ToList();
        }

        public static PSNetAppFilesSubvolumeModel ConvertToPs(this Management.NetApp.Models.SubvolumeModel subvolumeModel)
        {
            var psSubvolumeModel = new PSNetAppFilesSubvolumeModel()
            {
                ResourceGroupName = new ResourceIdentifier(subvolumeModel.Id).ResourceGroupName,
                Id = subvolumeModel.Id,
                Name = subvolumeModel.Name,
                Type = subvolumeModel.Type,
                ProvisioningState = subvolumeModel.ProvisioningState,
                Path = subvolumeModel.Path,
                ParentPath = subvolumeModel.ParentPath,
                Size = subvolumeModel.Size,                
                BytesUsed = subvolumeModel.BytesUsed,
                Permissions = subvolumeModel.Permissions,
                CreationTimeStamp = subvolumeModel.CreationTimeStamp,
                AccessedTimeStamp = subvolumeModel.AccessedTimeStamp,
                ChangedTimeStamp = subvolumeModel.ChangedTimeStamp,                
                ModifiedTimeStamp = subvolumeModel.ModifiedTimeStamp                     
            };
            return psSubvolumeModel;
        }
    }
}
