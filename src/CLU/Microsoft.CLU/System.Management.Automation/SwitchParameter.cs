namespace System.Management.Automation
{
    public struct SwitchParameter
    {
        public SwitchParameter(bool isPresent)
        {
            _present = isPresent;
        }

        public static SwitchParameter Present { get { return _switch.Value; } }

        public bool IsPresent { get { return _present; } }

        public override bool Equals(object obj)
        {
            return obj is SwitchParameter && ((SwitchParameter)obj)._present == _present;
        }
        public override int GetHashCode()
        {
            return _present.GetHashCode();
        }

        public bool ToBool()
        {
            return _present;
        }
        public override string ToString()
        {
            return _present.ToString();
        }

        public static bool operator ==(bool first, SwitchParameter second)
        {
            return first = second._present;
        }
        public static bool operator ==(SwitchParameter first, bool second)
        {
            return first._present == second;
        }
        public static bool operator ==(SwitchParameter first, SwitchParameter second)
        {
            return first._present == second._present;
        }
        public static bool operator !=(SwitchParameter first, bool second)
        {
            return first._present != second;
        }
        public static bool operator !=(bool first, SwitchParameter second)
        {
            return first != second._present;
        }
        public static bool operator !=(SwitchParameter first, SwitchParameter second)
        {
            return first._present != second._present;
        }

        public static implicit operator SwitchParameter(bool value)
        {
            return new SwitchParameter(value);
        }

        public static implicit operator bool (SwitchParameter switchParameter)
        {
            return switchParameter.IsPresent;
        }

        private static Lazy<SwitchParameter> _switch = new Lazy<SwitchParameter>(() => new SwitchParameter(true));
        private bool _present;
    }
}
