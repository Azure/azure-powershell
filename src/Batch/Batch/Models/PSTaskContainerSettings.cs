// -----------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Commands.Batch.Utils;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class PSTaskContainerSettings
    {
        internal TaskContainerSettings toMgmtContainerConfiguration()
        {
            TaskContainerSettings mgmtContainerConfiguration = new TaskContainerSettings();
            mgmtContainerConfiguration.ImageName = this.ImageName;
            mgmtContainerConfiguration.WorkingDirectory = (this.WorkingDirectory != null) ? Utils.Utils.toMgmtContainerWorkingDirectory(this.WorkingDirectory.Value) : (ContainerWorkingDirectory?)null;
            mgmtContainerConfiguration.Registry = (this.Registry != null) ? this.Registry.toMgmtContainerRegistry() : null;
            mgmtContainerConfiguration.ContainerRunOptions = this.ContainerRunOptions;
            mgmtContainerConfiguration.ContainerHostBatchBindMounts = (this.ContainerHostBatchBindMounts != null) ? Utils.Utils.toMgmtContainerHostBatchBindMounts(this.ContainerHostBatchBindMounts) : null;
            return mgmtContainerConfiguration;
        }

        internal static PSTaskContainerSettings fromMgmtContainerConfiguration(TaskContainerSettings mgmtContainerConfiguration)
        {
            if (mgmtContainerConfiguration == null)
            {
                return null;
            }
            PSTaskContainerSettings psContainerConfiguration = new PSTaskContainerSettings(
                imageName: mgmtContainerConfiguration.ImageName, 
                containerRunOptions: mgmtContainerConfiguration.ContainerRunOptions, 
                registry: (mgmtContainerConfiguration.Registry != null) ? PSContainerRegistry.fromMgmtContainerRegistry(mgmtContainerConfiguration.Registry) : null, 
                workingDirectory: (mgmtContainerConfiguration.WorkingDirectory != null) ? Utils.Utils.fromMgmtContainerWorkingDirectory(mgmtContainerConfiguration.WorkingDirectory) : null 
            );
            psContainerConfiguration.ContainerHostBatchBindMounts = (mgmtContainerConfiguration.ContainerHostBatchBindMounts != null) ? Utils.Utils.fromMgmtContainerHostBatchBindMounts(mgmtContainerConfiguration.ContainerHostBatchBindMounts) : null;

            return psContainerConfiguration;
        }
    }
}
