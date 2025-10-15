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

using Microsoft.Azure.Commands.Batch.Utils;
using Microsoft.Azure.Graph.RBAC.Version1_6_20190326.Models;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Management.Monitor.Version2018_09_01.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class PSCifsMountConfiguration
    {
        internal CifsMountConfiguration toMgmtCifsMountConfiguration()
        {
            return new CifsMountConfiguration()
            {
                UserName = this.Username,
                Source = this.Source,
                RelativeMountPath = this.RelativeMountPath,
                MountOptions = this.MountOptions,
                Password = this.Password
            };
        }

        internal static PSCifsMountConfiguration fromMgmtCifsMountConfiguration(CifsMountConfiguration cifsMountConfiguration)
        {
            if (cifsMountConfiguration == null)
            {
                return null;
            }
            return new PSCifsMountConfiguration(
                username: cifsMountConfiguration.UserName,
                source: cifsMountConfiguration.Source,
                relativeMountPath: cifsMountConfiguration.RelativeMountPath,
                mountOptions: cifsMountConfiguration.MountOptions,
                password: cifsMountConfiguration.Password
                );
        }
    }
}
