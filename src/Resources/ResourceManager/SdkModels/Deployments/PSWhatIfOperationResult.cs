namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Management.ResourceManager.Models;

    public class PSWhatIfOperationResult
    {
        private readonly WhatIfOperationResult whatIfOperationResult;

        public PSWhatIfOperationResult(WhatIfOperationResult whatIfOperationResult)
        {
            this.whatIfOperationResult = whatIfOperationResult;
        }

        public string Status => this.whatIfOperationResult.Status;

        public ErrorResponse Error => this.whatIfOperationResult.Error;

        public IList<PSWhatIfChange> Changes => new Lazy<IList<PSWhatIfChange>>(() =>
            this.whatIfOperationResult.Changes?.Select(c => new PSWhatIfChange(c)).ToList()).Value;
    }
}
