namespace System.Management.Automation
{
    public class PSNoteProperty : PSPropertyInfo
    {
        public PSNoteProperty(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public override bool IsGettable { get { return true; } }
        public override bool IsSettable { get { return true; } }
        public override PSMemberTypes MemberType { get { return PSMemberTypes.Property; } }
        public override string TypeNameOfValue { get { return (Value != null) ? Value.GetType().FullName : null; } }
        public override object Value { get; set; }
        public override string ToString() { return (Value ?? "null").ToString(); }
    }
}