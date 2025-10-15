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
using System.Xml;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Commands.Batch.Utils;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class PSStartTask
    {
        internal StartTask toMgmtStartTask()
        {
            StartTask mgmtStartTask = new StartTask();
            mgmtStartTask.CommandLine = this.CommandLine;
            mgmtStartTask.ContainerSettings = this.ContainerSettings?.toMgmtContainerConfiguration();
            mgmtStartTask.EnvironmentSettings = Utils.Utils.toMgmtEnvironmentSettings(this.EnvironmentSettings);
            mgmtStartTask.MaxTaskRetryCount = this.MaxTaskRetryCount;
            mgmtStartTask.ResourceFiles = Utils.Utils.toMgmtResourceFiles(this.ResourceFiles);
            mgmtStartTask.UserIdentity = this.UserIdentity?.toMgmtUserIdentity();
            mgmtStartTask.WaitForSuccess = this.WaitForSuccess;
            return mgmtStartTask;
        }

        internal static PSStartTask fromMgmtStartTask(StartTask mgmtStartTask)
        {
            PSStartTask psStartTask = new PSStartTask();
            psStartTask.CommandLine = mgmtStartTask.CommandLine;
            psStartTask.ContainerSettings = PSTaskContainerSettings.fromMgmtContainerConfiguration(mgmtStartTask.ContainerSettings);
            psStartTask.EnvironmentSettings = Utils.Utils.fromMgmtEnvironmentSettings(mgmtStartTask.EnvironmentSettings);
            psStartTask.MaxTaskRetryCount = mgmtStartTask.MaxTaskRetryCount;
            psStartTask.ResourceFiles = Utils.Utils.fromMgmtResourceFiles(mgmtStartTask.ResourceFiles);
            psStartTask.UserIdentity = PSUserIdentity.fromMgmtUserIdentity(mgmtStartTask.UserIdentity);
            psStartTask.WaitForSuccess = mgmtStartTask.WaitForSuccess;
            return psStartTask;
        }
    }
}
