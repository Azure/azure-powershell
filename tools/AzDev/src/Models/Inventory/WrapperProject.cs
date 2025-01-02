using System.IO.Abstractions;

namespace AzDev.Models.Inventory
{
    internal class WrapperProject : Project
    {
        protected WrapperProject(IFileSystem fs, string path) : base(fs, path) { }
        internal WrapperProject() { }
        public new static WrapperProject FromFileSystem(IFileSystem fs, string path)
        {
            return new WrapperProject(fs, path)
            {
                Type = ProjectType.Wrapper,
                Name = fs.Path.GetFileName(path)
            };
        }
    }
}
