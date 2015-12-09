using Microsoft.CLU.Common.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Microsoft.CLU.Common
{
    /// <summary>
    /// Type used to resolve dependent assemblies.
    /// </summary>
    public class AssemblyResolver : IDisposable
    {
        /// <summary>
        /// Creates an instance of AssemblyResolver.
        /// </summary>
        /// <param name="lookupRootDirPaths">The root directories to start assembly lookup</param>
        /// <param name="recursiveLookUp">Whether to lookup recursively or not</param>
        public AssemblyResolver(IEnumerable<string> lookupRootDirPaths, bool recursiveLookUp)
        {
            this._lookupRootDirPaths = new List<string>();
            this._lookupRootDirPaths.Add(CLUEnvironment.GetRootPath());
            this._lookupRootDirPaths.AddRange(lookupRootDirPaths);

            this._recursiveLookUp = recursiveLookUp;

#if DESKTOPCLR
            _handler = new ResolveEventHandler(ResolveAssemblyHandler);
            AppDomain.CurrentDomain.AssemblyResolve += _handler;
#else
            this._directoryAssemblyLoadContext = new DirectoryAssemblyLoadContext(this._lookupRootDirPaths.ToArray());
#endif
        }

        /// <summary>
        /// String representing the directories searched.
        /// </summary>
        public string SearchDirectoriesMessage
        {
            get
            {
                if (_lookupRootDirPaths.Count() == 0)
                {
                    return null;
                }

                var dirsAsString = (_recursiveLookUp ? Strings.AssemblyResolver_SearchDirectoriesMessage_TxtIncludingSubDirs : null) + string.Join(",", _lookupRootDirPaths);
                return dirsAsString;
            }
        }


        /// <summary>
        /// Resolve and load an assembly. The assembly will be searched only under
        /// the given collection of directories.
        /// </summary>
        /// <param name="searchDirs">The directories to search</param>
        /// <param name="assemblyName">Relative path or name of the assembly file, with extension</param>
        /// <returns>Returns path to assembly if found else null</returns>
        internal string Resolve(string[] searchDirs, string assemblyName)
        {
            return LookUpFilePath(searchDirs, assemblyName);
        }

        /// <summary>
        /// Load the assembly indicated by filePath. 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        internal Assembly Load(string filePath)
        {
            if (filePath == null)
            {
                return null;
            }
            else
            {
#if DESKTOPCLR
                return Assembly.LoadFile(filePath);
#else
                return DirectoryAssemblyLoadContext.LoadFromPath(filePath);
#endif
            }
        }

        /// <summary>
        /// Resolves an entry point given a package assembly.
        /// </summary>
        /// <param name="assembly">The package assembly, already loaded.</param>
        /// <param name="entryName">The fully qualified entry point name.</param>
        /// <returns>A reference to the method information, if it exists.</returns>
        public MethodInfo ResolveEntryPoint(Assembly assembly, string entryName)
        {
            if (assembly == null)
                throw new ArgumentNullException("assembly");
            if (string.IsNullOrEmpty(entryName))
                throw new ArgumentNullException("entryName");

            var methodNameIdx = entryName.LastIndexOf('.');
            if (methodNameIdx == -1)
                throw new ArgumentException(Strings.AssemblyResolver_ResolveEntryPoint_MethodNameMustBeFullyQualified);

            var methodName = entryName.Substring(methodNameIdx + 1);
            var className = entryName.Substring(0, methodNameIdx);

            var clss = assembly.GetType(className);
            if (clss != null)
            {
                return clss.GetMethods().Where(m => m.Name == methodName).FirstOrDefault();
            }
            return null;
        }

        /// <summary>
        /// Resolves an entry point given a set of package assemblies.
        /// </summary>
        /// <param name="assemblies">The package assemblies, already loaded.</param>
        /// <param name="entryName">The fully qualified entry point name.</param>
        /// <returns>A reference to the method information, if it exists.</returns>
        public MethodInfo ResolveEntryPoint(IEnumerable<Assembly> assemblies, string entryName)
        {
            return assemblies.Select(asm => ResolveEntryPoint(asm, entryName)).FirstOrDefault();
        }

#if DESKTOPCLR
        private Assembly ResolveAssemblyHandler(object sender, ResolveEventArgs resolveEventArgs)
        {
            var path = LookUpFilePath(_lookupRootDirPaths, new AssemblyName(resolveEventArgs.Name).Name + ".dll");
            return Load(path);
        }
#endif
        /// <summary>
        /// Search for an assembly under the given set of directories.
        /// </summary>
        /// <param name="dirPaths">The locations to be searched for the assembly</param>
        /// <param name="assemblyName">Relative path or name of the assembly file, with extension</param>
        /// <returns>Returns the path to the assembly if found else null</returns>
        private string LookUpFilePath(IEnumerable<string> dirPaths, string assemblyName)
        {
            foreach (var dirPath in dirPaths)
            {
                string assemblyFilePath = Path.Combine(dirPath, assemblyName);
                if (File.Exists(assemblyFilePath))
                {
                    return assemblyFilePath;
                }

                if (_recursiveLookUp)
                {
                    var subDirPaths = new DirectoryInfo(dirPath).GetDirectories().Select(d => d.FullName);
                    assemblyFilePath = LookUpFilePath(subDirPaths, assemblyName);
                    if (assemblyFilePath != null)
                    {
                        return assemblyFilePath;
                    }
                }
            }

            return null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
#if DESKTOPCLR
                if (disposing)
                {
                    if (_handler != null)
                    {
                        AppDomain.CurrentDomain.AssemblyResolve -= _handler;
                        _handler = null;
                    }
                }
#else
                this._directoryAssemblyLoadContext = null;
#endif
                this._disposed = true;
            }
        }

        ~AssemblyResolver()
        {
            Dispose(false);
        }

        #region Private fields

        /// <summary>
        /// The root directories to start lookup.
        /// </summary>
        private List<string> _lookupRootDirPaths;

        /// <summary>
        /// Indicate whether to perform recursive lookup or not.
        /// </summary>
        private bool _recursiveLookUp;

#if DESKTOPCLR
        /// <summary>
        /// The assembly resolve event handler.
        /// </summary>
        private ResolveEventHandler _handler;
#else
        private DirectoryAssemblyLoadContext _directoryAssemblyLoadContext;
#endif
        /// <summary>
        /// used by IDisposible::Dispose.
        /// </summary>
        private bool _disposed = false;

        #endregion

#if !DESKTOPCLR
        public class DirectoryAssemblyLoadContext : System.Runtime.Loader.AssemblyLoadContext
        {
           private static Dictionary<string, Assembly> s_loadedAssemblies = new Dictionary<string, Assembly>();
           private string[] lookupDirPaths;

            public DirectoryAssemblyLoadContext(string[] lookupDirPaths)
            {
                this.lookupDirPaths = lookupDirPaths;
            }

            public static Assembly LoadFromPath(string path)
            {
                var resolver = new DirectoryAssemblyLoadContext(new string[] { System.IO.Path.GetDirectoryName(path) });
                var an = new System.Reflection.AssemblyName(System.IO.Path.GetFileNameWithoutExtension(path));
                return resolver.LoadFromAssemblyName(an);
            }

            protected override Assembly Load(AssemblyName assemblyName)
            {
                //Console.WriteLine($"Trying to load assembly {assemblyName.FullName}");
                Assembly loadedAssembly = null;
                
                if (s_loadedAssemblies.TryGetValue(assemblyName.Name, out loadedAssembly)) 
                {
                     //Console.WriteLine($"Assembly already dynamically loaded - returning instance...");
                     return loadedAssembly;
                }

                //Console.WriteLine("Looking up...");
                foreach (var lookupDirPath in lookupDirPaths)
                {
                    //Console.WriteLine($"Searching path {lookupDirPath}");
                    foreach (var file in System.IO.Directory.EnumerateFiles(lookupDirPath, assemblyName.Name + ".dll", System.IO.SearchOption.AllDirectories))
                    {
                        //Console.WriteLine($"Loading from file {file}");
                        loadedAssembly = LoadFromAssemblyPath(file);
                    }
                }

                if (loadedAssembly == null) 
                {
                    //Console.WriteLine($"Falling back to default loader...");
                    loadedAssembly = System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromAssemblyName(assemblyName);
                }

                if (loadedAssembly != null) 
                {
                    //Console.WriteLine($"Caching loaded assembly...");
                    s_loadedAssemblies[loadedAssembly.GetName().Name] = loadedAssembly;
                }

                return loadedAssembly;
            }
        }
#endif
    }
}