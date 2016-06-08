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
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.BaseInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Logging;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;
using Microsoft.WindowsAzure.Management.HDInsight.Logging;
using Microsoft.Azure.Commands.Common.Authentication;
using System.IO;
using Microsoft.Azure.ServiceManagemenet.Common;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.PSCmdlets
{
    /// <summary>
    ///     The base class for HDInsight Cmdlets.
    /// </summary>
    public abstract class AzureHDInsightCmdlet : AzureSMCmdlet
    {
        internal static AzureSubscription testSubscription;

        private ILogWriter logger;

      
        /// <summary>
        ///     Gets or sets a value indicating whether logging should be enabled.
        /// </summary>
        public ILogWriter Logger
        {
            get
            {
                if (this.logger == null)
                {
                    if (this.MyInvocation.BoundParameters.ContainsKey("Debug"))
                    {
                        this.logger = ServiceLocator.Instance.Locate<IBufferingLogWriterFactory>().Create();
                    }
                    else
                    {
                        this.logger = new NullLogWriter();
                    }
                }

                return this.logger;
            }

            set { this.logger = value; }
        }

        /// <summary>
        ///     Formats an exception to be placed in the debug output.
        /// </summary>
        /// <param name="ex">
        ///     The exception.
        /// </param>
        /// <returns>
        ///     A string that represents the message to display for the exception.
        /// </returns>
        protected string FormatException(Exception ex)
        {
            var builder = new StringBuilder();
            if (ex.IsNotNull())
            {
                builder.AppendLine(ex.Message);
                builder.AppendLine(ex.StackTrace);
                var aggex = ex as AggregateException;
                if (aggex.IsNotNull())
                {
                    foreach (Exception innerException in aggex.InnerExceptions)
                    {
                        builder.AppendLine(this.FormatException(innerException));
                    }
                }
                else if (ex.InnerException.IsNotNull())
                {
                    builder.AppendLine(this.FormatException(ex.InnerException));
                }
            }
            return builder.ToString();
        }

        /// <inheritdoc />
        protected abstract override void StopProcessing();

        /// <summary>
        ///     Writes any collected log messages to the debug output.
        /// </summary>
        protected void WriteDebugLog()
        {
            var bufferingLogWriter = this.Logger as IBufferingLogWriter;
            if (bufferingLogWriter.IsNotNull())
            {
                foreach (string line in bufferingLogWriter.DequeueBuffer())
                {
                    this.WriteDebug(line);
                }
            }
        }

        protected AzureSubscription GetCurrentSubscription(string Subscription, X509Certificate2 certificate)
        {
            if (Subscription.IsNotNullOrEmpty())
            {
                this.WriteWarning("The -Subscription parameter is deprecated, Please use Select-AzureSubscription -Current to select a subscription to use.");

                ProfileClient client = new ProfileClient(new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile)));

                var subscriptionResolver =
                    ServiceLocator.Instance.Locate<IAzureHDInsightSubscriptionResolverFactory>().Create(client.Profile);
                var resolvedSubscription = subscriptionResolver.ResolveSubscription(Subscription);
                if (certificate.IsNotNull() && resolvedSubscription.Account != certificate.Thumbprint)
                {
                    AzureSession.DataStore.AddCertificate(certificate);
                }

                if (resolvedSubscription.IsNull())
                {
                    throw new ArgumentException(
                         string.Format(
                             CultureInfo.InvariantCulture,
                             "Failed to retrieve Certificate for the subscription '{0}'." +
                             "Please use Select-AzureSubscription -Current to select a subscription.",
                             Subscription));
                }

                return resolvedSubscription;
            }
            else
            {
#if DEBUG
                // we need this for the tests to mock out the current subscription.
                if (Profile.Context.Subscription != null)
                {
                    return this.Profile.Context.Subscription;
                }

                return testSubscription;
#else
                return this.Profile.Context.Subscription;
#endif
            }
        }
    }
}
