using System;
using System.Globalization;
using Microsoft.WindowsAzure.WebSitesExtensions.Models;

namespace Microsoft.WindowsAzure.Commands.Websites.WebJobs
{
    public class PSTriggeredWebJobRun : TriggeredWebJobRun
    {
        public PSTriggeredWebJobRun(TriggeredWebJobRun triggeredWebJobRun)
        {
            Duration = triggeredWebJobRun.Duration;
            EndTime = triggeredWebJobRun.EndTime;
            Id = triggeredWebJobRun.Id;
            JobName = triggeredWebJobRun.JobName;
            OutputUrl = triggeredWebJobRun.OutputUrl;
            StartTime = triggeredWebJobRun.StartTime;
            Status = triggeredWebJobRun.Status;
            Url = triggeredWebJobRun.Url;
        }

        public override string ToString()
        {
            return String.Format(CultureInfo.CurrentCulture, "Started: {0}, Ended: {1}, Duration: {2}", StartTime, EndTime, Duration);
        }
    }
}
