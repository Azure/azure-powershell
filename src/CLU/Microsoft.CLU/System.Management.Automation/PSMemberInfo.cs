namespace System.Management.Automation
{
    public abstract class PSMemberInfo
    {
        protected PSMemberInfo() { }

        public bool IsInstance { get; protected set; }
        public abstract PSMemberTypes MemberType { get; }
        public string Name { get; protected set; }
        public abstract string TypeNameOfValue { get; }
        public abstract object Value { get; set; }
        protected void SetMemberName(string name)
        {
            Name = name;
        }
    }
}
