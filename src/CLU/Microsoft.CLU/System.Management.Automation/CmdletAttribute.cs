namespace System.Management.Automation
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class CmdletAttribute : CmdletCommonMetadataAttribute
    {
        public CmdletAttribute(string verbName, string nounName)
        {
            NounName = nounName;
            VerbName = verbName;
        }

        public string NounName { get; private set; }
        public string VerbName { get; private set; }
    }
}
