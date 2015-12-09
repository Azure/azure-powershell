using System.Collections.ObjectModel;

namespace System.Management.Automation
{
    public abstract class PSMethodInfo : PSMemberInfo
    {
        protected PSMethodInfo() { }

        public abstract Collection<string> OverloadDefinitions { get; }
        public sealed override object Value { get; set; }

        public abstract object Invoke(params object[] arguments);
    }
}
