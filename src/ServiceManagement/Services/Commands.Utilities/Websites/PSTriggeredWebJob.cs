using Microsoft.WindowsAzure.WebSitesExtensions.Models;

namespace Microsoft.WindowsAzure.Commands.Websites.WebJobs
{
    /// <summary>
    /// The purpose of the wrapping is to surface a Web Job's "Name" property as "JobName",
    /// and "Type" as "JobType". This is needed for PowerShell pipeline.
    /// </summary>
    public class PSTriggeredWebJob : PSWebJob<TriggeredWebJob>
    {
        public PSTriggeredWebJob(TriggeredWebJob webJob)
            : base(webJob)
        {
        }

        public PSTriggeredWebJob()
            : this(new TriggeredWebJob())
        {
        }

        public string HistoryUrl
        {
            get { return WebJob.HistoryUrl; }
            set { WebJob.HistoryUrl = value; }
        }

        public TriggeredWebJobRun LatestRun
        {
            get { return new PSTriggeredWebJobRun(WebJob.LatestRun); }
            set { WebJob.LatestRun = value; }
        }
    }
}
