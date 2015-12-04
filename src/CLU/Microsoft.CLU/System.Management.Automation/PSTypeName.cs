namespace System.Management.Automation
{
    public class PSTypeName
    {
        public PSTypeName(string name)
        {
            _type = Type.GetType(name);
        }

        public PSTypeName(Type type)
        {
            _type = type;
        }

        public string Name { get { return _type.Name; } }
        public Type Type { get { return _type; } }

        public override string ToString()
        {
            return Name;
        }

        private Type _type;
    }
}
