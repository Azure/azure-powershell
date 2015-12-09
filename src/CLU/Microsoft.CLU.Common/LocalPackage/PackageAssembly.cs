using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.CLU.Common
{
    /// <summary>
    /// Type representing loaded assembly in a package.
    /// </summary>
    internal class PackageAssembly
    {
        /// <summary>
        /// The relative path or name of the assembly.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Assembly instance identified by Name. This property can be null which indicate assembly
        /// could not be located.
        /// </summary>
        public Assembly Assembly { get; private set; }

        /// <summary>
        /// The full path to the assembly. This property can be null, which indicate that the
        /// assembly could not be located
        /// </summary>
        public string FullPath { get; private set; }

        /// <summary>
        /// Create an instance of PackageAssembly
        /// </summary>
        /// <param name="name">The relative path or name of the assembly</param>
        /// <param name="assembly">The assembly, this parameter can be null indicates assembly could not be located</param>
        public PackageAssembly(string name, Assembly assembly, string fullPath)
        {
            Name = name;
            Assembly = assembly;
        }

        /// <summary>
        /// Get MethodInfo instance of a method in the assembly.
        /// </summary>
        /// <param name="entryPointFullName">Fully qualified method name in the
        /// form Namespace.ClassName.MethodName</param>
        /// <returns>Returns null if the method does not exists</returns>
        public MethodInfo GetEntryPointMethod(string entryPointFullName)
        {
            return GetEntryPoint(entryPointFullName).Method;
        }

        /// <summary>
        /// Enumerate all the public methods of an assembly that match a given predicate.
        /// </summary>
        /// <param name="predicate">The match function</param>
        /// <returns></returns>
        public IEnumerable<MethodInfo> GetEntryPoints(Func<MethodInfo, bool> predicate)
        {
            return Assembly.GetExportedTypes().SelectMany(type => type.GetMethods()).Where(predicate);
        }

        /// <summary>
        /// Gets EntryPoint instance corrosponding to the given fully qualified entrypoint name.
        /// </summary>
        /// <param name="entryPointFullName"></param>
        /// <returns></returns>
        public EntryPoint GetEntryPoint(string entryPointFullName)
        {
            return new EntryPoint(Assembly, entryPointFullName);
        }
    }
}
