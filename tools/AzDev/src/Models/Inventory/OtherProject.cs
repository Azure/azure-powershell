using System.IO.Abstractions;

namespace AzDev.Models.Inventory
{
    internal class OtherProject : Project
    {
        protected OtherProject(IFileSystem fs, string path) : base(fs, path) { }
        internal OtherProject() { }
        public new static OtherProject FromFileSystem(IFileSystem fs, string path)
        {
            return new OtherProject(fs, path)
            {
                Type = ProjectType.Other,
                Name = fs.Path.GetFileName(path)
            };
        }
    }
}
