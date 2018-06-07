namespace Microsoft.Azure.Commands.StorageSync.Evaluation
{
    using Interfaces;

    class AfsNamedObjectInfo : INamedObjectInfo
    {
        private static char[] Separators => new char[] { '\\', '/' };

        public AfsNamedObjectInfo(string path)
        {
            this.FullName = path;
            int index = path.LastIndexOfAny(Separators);
            this.Name = index >= 0 ? path.Substring(index + 1) : path;
        }

        public string Name { get; private set; }

        public string FullName { get; private set; }

        public static string Combine(string path, string name)
        {
            return $"{path}{Separators[0]}{name}";
        }
    }
}
