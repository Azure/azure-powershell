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
    public partial class PSAutoUserSpecification
    {
        internal Management.Batch.Models.AutoUserSpecification toMgmtAutoUserSpecification()
        {
            Management.Batch.Models.AutoUserSpecification mgmtAutoUserSpecification = new Management.Batch.Models.AutoUserSpecification();
            mgmtAutoUserSpecification.ElevationLevel = Utils.Utils.toMgmtElevationLevel(this.ElevationLevel);
            mgmtAutoUserSpecification.Scope = Utils.Utils.toMgmtAutoUserScope(this.Scope);
            return mgmtAutoUserSpecification;
        }

        internal static PSAutoUserSpecification fromMgmtAutoUserSpecification(Management.Batch.Models.AutoUserSpecification mgmtAutoUserSpecification)
        {
            if (mgmtAutoUserSpecification == null)
            {
                return null;
            }
            var elevationLevel = Utils.Utils.fromMgmtElevationLevel(mgmtAutoUserSpecification.ElevationLevel);
            Azure.Batch.Common.AutoUserScope? scope = mgmtAutoUserSpecification.Scope.HasValue 
                ? Utils.Utils.fromMgmtAutoUserScope(mgmtAutoUserSpecification.Scope) 
                : (Azure.Batch.Common.AutoUserScope?)null;

            PSAutoUserSpecification psAutoUserSpecification = new PSAutoUserSpecification(scope, elevationLevel);
            return psAutoUserSpecification;
        }
    }
}
