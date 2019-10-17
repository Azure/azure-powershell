namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using Management.ResourceManager.Models;
    using Newtonsoft.Json.Linq;

    public class PSWhatIfPropertyChange
    {
        private readonly WhatIfPropertyChange whatIfPropertyChange;

        public PSWhatIfPropertyChange(WhatIfPropertyChange whatIfPropertyChange)
        {
            this.whatIfPropertyChange = whatIfPropertyChange;
        }

        public string Path => whatIfPropertyChange.Path;

        public PropertyChangeType PropertyChangeType => whatIfPropertyChange.PropertyChangeType;

        public JToken Before => new Lazy<JToken>(() => whatIfPropertyChange.Before.ToJToken()).Value;

        public JToken After => new Lazy<JToken>(() => whatIfPropertyChange.After.ToJToken()).Value;

        public IList<PSWhatIfPropertyChange> Children =>
            new Lazy<IList<PSWhatIfPropertyChange>>(() =>
                whatIfPropertyChange.Children?.Select(pc => new PSWhatIfPropertyChange(pc)).ToList()).Value;
    }
}
