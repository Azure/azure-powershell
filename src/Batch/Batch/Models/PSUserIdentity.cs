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
    public partial class PSUserIdentity
    {
        internal UserIdentity toMgmtUserIdentity()
        {
            UserIdentity mgmtUserIdentity = null;
            if (this.AutoUser != null)
            {
                mgmtUserIdentity = new UserIdentity();
                mgmtUserIdentity.AutoUser = this.AutoUser.toMgmtAutoUserSpecification();
            }
            else if (!string.IsNullOrEmpty(this.UserName))
            {
                mgmtUserIdentity = new UserIdentity();
                mgmtUserIdentity.UserName = this.UserName;
            }
            return mgmtUserIdentity;
        }

        internal static PSUserIdentity fromMgmtUserIdentity(UserIdentity userIdentity)
        {
            if (userIdentity == null)
            {
                return null;
            }

            PSUserIdentity psUserIdentity = null;

            if (userIdentity.AutoUser != null) {
                psUserIdentity = new PSUserIdentity(PSAutoUserSpecification.fromMgmtAutoUserSpecification(userIdentity.AutoUser));
            }else if (!string.IsNullOrEmpty(userIdentity.UserName)) {
                psUserIdentity = new PSUserIdentity(userIdentity.UserName);
            }
            return psUserIdentity;
        }
    }
}
