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

using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers.Resources.Models;
using Microsoft.Azure.Commands.KeyVault.Extensions;
using Microsoft.Azure.Commands.KeyVault.Helpers;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
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
            Scope = scope;
            RelativeResourceId = relativeResourceId;

            apiVersion = new Lazy<string>(() =>
                Before?["apiVersion"]?.Value<string>() ?? After?["apiVersion"]?.Value<string>());
            before = new Lazy<JToken>(() => whatIfChange.Before.ToJToken());
            after = new Lazy<JToken>(() => whatIfChange.After.ToJToken());
            delta = new Lazy<IList<PSWhatIfPropertyChange>>(() =>
                whatIfChange.Delta?.Select(pc => new PSWhatIfPropertyChange(pc)).ToList());
        }

        public string Scope { get; }

        public string RelativeResourceId { get; }

        public string FullyQualifiedResourceId => whatIfChange.ResourceId;

        public ChangeType ChangeType => whatIfChange.ChangeType;

        public string ApiVersion => apiVersion.Value;

        public JToken Before => before.Value;

        public JToken After => after.Value;

        public IList<PSWhatIfPropertyChange> Delta => delta.Value;
    }
}