namespace System.Management.Automation.Host
{
    public sealed class ChoiceDescription
    {
        public ChoiceDescription(string label) { Label = label; }
        public ChoiceDescription(string label, string helpMessage) { Label = label; HelpMessage = helpMessage; }

        public string HelpMessage { get; set; }
        public string Label { get; private set; }
    }
}
