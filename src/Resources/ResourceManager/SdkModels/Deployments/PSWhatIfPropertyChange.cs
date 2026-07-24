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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Newtonsoft.Json.Linq;

    public class PSWhatIfPropertyChange
    {
        private readonly WhatIfPropertyChange whatIfPropertyChange;

        private readonly Lazy<JToken> before;

        private readonly Lazy<JToken> after;

        private readonly Lazy<IList<PSWhatIfPropertyChange>> children;

        public PSWhatIfPropertyChange(WhatIfPropertyChange whatIfPropertyChange)
        {
            this.whatIfPropertyChange = whatIfPropertyChange;
            this.before = new Lazy<JToken>(() => whatIfPropertyChange.Before.ToJToken());
            this.after = new Lazy<JToken>(() => whatIfPropertyChange.After.ToJToken());
            this.children = new Lazy<IList<PSWhatIfPropertyChange>>(() =>
                whatIfPropertyChange.Children?.Select(pc => new PSWhatIfPropertyChange(pc)).ToList());
        }

        public string Path => this.whatIfPropertyChange.Path;

        public PropertyChangeType PropertyChangeType => this.whatIfPropertyChange.PropertyChangeType;

        public JToken Before => this.before.Value;

        public JToken After => this.after.Value;

        public IList<PSWhatIfPropertyChange> Children => this.children.Value;
    }
}
