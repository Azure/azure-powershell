﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Management.ResourceManager.Models;

    public class PSWhatIfOperationResult
    {
        private readonly WhatIfOperationResult whatIfOperationResult;

        private readonly Lazy<IList<PSWhatIfChange>> changes;

        public PSWhatIfOperationResult(WhatIfOperationResult whatIfOperationResult)
        {
            this.whatIfOperationResult = whatIfOperationResult;
            this.changes = new Lazy<IList<PSWhatIfChange>>(() =>
                whatIfOperationResult.Changes?.Select(c => new PSWhatIfChange(c)).ToList());
        }

        public string Status => this.whatIfOperationResult.Status;

        public ErrorResponse Error => this.whatIfOperationResult.Error;

        public IList<PSWhatIfChange> Changes => this.changes.Value;
    }
}
