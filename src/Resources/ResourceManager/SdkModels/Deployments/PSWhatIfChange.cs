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
    using Components;
    using Extensions;
    using Microsoft.Azure.Management.Resources.Models;
    using Newtonsoft.Json.Linq;

    public class PSWhatIfChange
    {
        private readonly WhatIfChange whatIfChange;

        private readonly Lazy<JToken> before;

        private readonly Lazy<JToken> after;

        private readonly Lazy<IList<PSWhatIfPropertyChange>> delta;

        private readonly Lazy<string> apiVersion;

        public PSWhatIfChange(WhatIfChange whatIfChange)
        {
            this.whatIfChange = whatIfChange;

            (string scope, string relativeResourceId) = ResourceIdUtility.SplitResourceId(whatIfChange.ResourceId);
            this.Scope = scope;
            this.RelativeResourceId = relativeResourceId;
            this.UnsupportedReason = whatIfChange.UnsupportedReason;

            this.apiVersion = new Lazy<string>(() =>
                this.Before?["apiVersion"]?.Value<string>() ?? this.After?["apiVersion"]?.Value<string>());
            this.before = new Lazy<JToken>(() => whatIfChange.Before.ToJToken());
            this.after = new Lazy<JToken>(() => whatIfChange.After.ToJToken());
            this.delta = new Lazy<IList<PSWhatIfPropertyChange>>(() =>
                whatIfChange.Delta?.Select(pc => new PSWhatIfPropertyChange(pc)).ToList());
        }

        public string Scope { get; }

        public string RelativeResourceId { get; }

        public string UnsupportedReason { get; }

        public string FullyQualifiedResourceId => this.whatIfChange.ResourceId;

        public ChangeType ChangeType => this.whatIfChange.ChangeType;

        public string ApiVersion => this.apiVersion.Value;

        public JToken Before => this.before.Value;

        public JToken After => this.after.Value;

        public IList<PSWhatIfPropertyChange> Delta => this.delta.Value;
    }
}
