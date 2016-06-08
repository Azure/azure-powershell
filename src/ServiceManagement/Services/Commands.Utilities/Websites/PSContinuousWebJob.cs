using System;
using Microsoft.WindowsAzure.WebSitesExtensions.Models;

namespace Microsoft.WindowsAzure.Commands.Websites.WebJobs
{
    public class PSContinuousWebJob : PSWebJob<ContinuousWebJob>
    {
        public PSContinuousWebJob(ContinuousWebJob webJob)
            : base(webJob)
        {
        }

        public PSContinuousWebJob()
            : this(new ContinuousWebJob())
        {
        }

        public string DetailedStatus
        {
            get
            {
                return WebJob.DetailedStatus != null ? WebJob.DetailedStatus.Trim() : null;
            }
            set
            {
                WebJob.DetailedStatus = value;
            }
        }

        public Uri LogUrl
        {
            get
            {
                return WebJob.LogUrl;
            }
            set
            {
                WebJob.LogUrl = value;
            }
        }

        public string Status
        {
            get
            {
                return WebJob.Status;
            }
            set
            {
                WebJob.Status = value;
            }
        }
    }
}
