namespace System.Management.Automation
{
    public abstract class PSPropertyInfo : PSMemberInfo
    {
        protected PSPropertyInfo() { }

        public abstract bool IsGettable { get; }
        public abstract bool IsSettable { get; }
    }

    internal class CLUPropertyInfo : PSPropertyInfo
    {
        public CLUPropertyInfo(object value, Type type) : this(value, type, "")
        {}

        public CLUPropertyInfo(object value, Type type, string name)
        {
            _value = value;
            _type = type;
            base.SetMemberName(name);
        }

        public Type Type
        {
            get
            {
                return _type;
            }
        }

        public override bool IsGettable
        {
            get
            {
                return true;
            }
        }

        public override bool IsSettable
        {
            get
            {
                return true;
            }
        }

        public override PSMemberTypes MemberType
        {
            get
            {
                return PSMemberTypes.Property;
            }
        }

        public override string TypeNameOfValue
        {
            get
            {
                return _type.FullName;
            }
        }

        public override object Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
            }
        }

        private object _value;
        private Type _type;
    }
}
