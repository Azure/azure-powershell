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
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core;
using Microsoft.WindowsAzure.Management.HDInsight.Logging;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters
{
    internal abstract class AzureHDInsightCommandBase : DisposableObject, IAzureHDInsightCommandBase
    {
        public virtual CancellationToken CancellationToken
        {
            get { return CancellationToken.None; }
        }

        public X509Certificate2 Certificate { get; set; }

        public string HostedService { get; set; }

        public Uri Endpoint { get; set; }

        public bool IgnoreSslErrors { get; set; }

        public ILogWriter Logger { get; set; }

        public string Subscription { get; set; }

        public AzureSubscription CurrentSubscription { get; set; }

        public virtual void Cancel()
        {
        }

        public abstract Task EndProcessing();
    }
}
