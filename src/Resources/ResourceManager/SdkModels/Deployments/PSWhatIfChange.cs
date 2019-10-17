namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using Management.ResourceManager.Models;
    using Newtonsoft.Json.Linq;
    using Utilities;

    public class PSWhatIfChange
    {
        private readonly WhatIfChange whatIfChange;

        public PSWhatIfChange(WhatIfChange whatIfChange)
        {
            (string scope, string shortResourceId) = ResourceIdParser.ParseResourceId(whatIfChange.ResourceId);

            this.whatIfChange = whatIfChange;
            this.Scope = scope;
            this.ShortResourceId = shortResourceId;
        }

        public string Scope { get; }

        public string ShortResourceId { get; }

        public string FullResourceId => whatIfChange.ResourceId;

        public ChangeType ChangeType => this.whatIfChange.ChangeType;

        public JToken Before => new Lazy<JToken>(() => whatIfChange.Before.ToJToken()).Value;

        public JToken After => new Lazy<JToken>(() => whatIfChange.After.ToJToken()).Value;

        public IList<PSWhatIfPropertyChange> Delta =>
            new Lazy<IList<PSWhatIfPropertyChange>>(() =>
                this.whatIfChange.Delta?.Select(pc => new PSWhatIfPropertyChange(pc)).ToList()).Value;
    }
}
