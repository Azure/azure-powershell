using System.IO.Abstractions;

namespace AzDev.Models.Inventory
{
    internal class SdkBasedProject : Project
    {
        protected SdkBasedProject(IFileSystem fs, string path) : base(fs, path) { }
        internal SdkBasedProject() { }
        public new static SdkBasedProject FromFileSystem(IFileSystem fs, string path)
        {
            return new SdkBasedProject(fs, path)
            {
                Type = ProjectType.SdkBased,
                Name = fs.Path.GetFileName(path)
            };
        }
    }
}
