using System.IO.Abstractions;
using AzDev.Models.Inventory;

namespace AzDev.Services
{
    internal class DefaultCodebaseProvider : ICodebaseProvider
    {
        private IContextProvider _contextProvider;
        private IFileSystem _fs;
        private Codebase _codebase;

        public DefaultCodebaseProvider(IContextProvider contextProvider)
            : this(contextProvider, new FileSystem()) { }

        public DefaultCodebaseProvider(IContextProvider contextProvider, IFileSystem fs)
        {
            _contextProvider = contextProvider;
            _fs = fs;
        }

        public Codebase GetCodebase()
        {
            if (_codebase == null)
            {
                var path = _contextProvider.LoadContext().AzurePowerShellRepositoryRoot;
                var src = _fs.Path.Combine(path, FileOrDirNames.Src);
                _codebase = _codebase ?? Codebase.FromFileSystem(_fs, src);
            }
            return _codebase;
        }
    }
}
