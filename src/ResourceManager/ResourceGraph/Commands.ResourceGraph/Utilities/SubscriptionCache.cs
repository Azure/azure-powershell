namespace Microsoft.Azure.Commands.ResourceGraph.Utilities
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Internal.Subscriptions;
    using Microsoft.Azure.Internal.Subscriptions.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Subscriptions cache
    /// </summary>
    public static class SubscriptionCache
    {
        /// <summary>
        /// The synchronize root
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// The subscriptions
        /// </summary>
        private static List<string> _subscriptions;

        /// <summary>
        /// Gets the subscriptions.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="azureContext">The azure context.</param>
        /// <returns></returns>
        public static List<string> GetSubscriptions(Cmdlet parent, IAzureContext azureContext)
        {
            if (_subscriptions == null)
            {
                lock (SyncRoot)
                {
                    if (_subscriptions == null)
                    {
                        _subscriptions = GetSubscriptionsWithProgressInternal(parent, azureContext);
                    }
                }
            }

            return _subscriptions;
        }

        /// <summary>
        /// Refreshes the subscriptions with progress.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="azureContext">The azure context.</param>
        private static List<string> GetSubscriptionsWithProgressInternal(
            Cmdlet parent, IAzureContext azureContext)
        {
            var subscriptionsClient =
                AzureSession.Instance.ClientFactory.CreateArmClient<SubscriptionClient>(
                    azureContext, AzureEnvironment.Endpoint.ResourceManager);

            var progressRecord = new ProgressRecord(0, "Fetching subscriptions", "Loading...")
            {
                RecordType = ProgressRecordType.Processing
            };
            parent.WriteProgress(progressRecord);

            var subscriptions = new List<Subscription>();
            IPage<Subscription> page = null;

            do
            {
                page = page == null
                    ? subscriptionsClient.Subscriptions.List()
                    : subscriptionsClient.Subscriptions.ListNext(page.NextPageLink);

                subscriptions.AddRange(page);

                progressRecord.StatusDescription = $"Loading... {subscriptions.Count}";
                parent.WriteProgress(progressRecord);
            }
            while (!string.IsNullOrEmpty(page.NextPageLink));
            
            // Making the total count visible
            Thread.Sleep(100);

            progressRecord.RecordType = ProgressRecordType.Completed;
            parent.WriteProgress(progressRecord);

            return subscriptions.Select(sub => sub.SubscriptionId).ToList();
        }
    }
}
