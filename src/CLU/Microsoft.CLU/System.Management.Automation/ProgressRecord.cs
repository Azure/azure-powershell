namespace System.Management.Automation
{
    public class ProgressRecord
    {
        public ProgressRecord(int activityId, string activity, string status)
        {
            ActivityId = activityId;
            Activity = activity;
            StatusDescription = status;
        }

        public string Activity { get; set; }
        public int ActivityId { get; private set; }
        public string CurrentOperation { get; set; }
        public int ParentActivityId { get; set; }
        public int PercentComplete { get; set; }
        public ProgressRecordType RecordType { get; set; }
        public int SecondsRemaining { get; set; }
        public string StatusDescription { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
