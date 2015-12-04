namespace System.Management.Automation
{
    public sealed class ParameterSetMetadata
    {
        public string HelpMessage { get; set; }
        public string HelpMessageBaseName { get; set; }
        public string HelpMessageResourceId { get; set; }
        public bool IsMandatory { get; set; }
        public int Position { get; set; }
        public bool ValueFromPipeline { get; set; }
        public bool ValueFromPipelineByPropertyName { get; set; }
        public bool ValueFromRemainingArguments { get; set; }
    }
}
