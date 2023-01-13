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
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Aks.Models
{
    /// <summary>
    /// Describes the Power State of the cluster.
    /// </summary>
    public partial class PSPowerState
    {
        //
        // Summary:
        //     Gets or sets tells whether the cluster is Running or Stopped. Possible values
        //     include: 'Running', 'Stopped'
        public string Code
        {
            get;
            set;
        }
    }
}
