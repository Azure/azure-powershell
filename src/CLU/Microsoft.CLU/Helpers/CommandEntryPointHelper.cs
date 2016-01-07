using Microsoft.CLU.Common;
using Microsoft.CLU.Common.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Microsoft.CLU.Helpers
{
    /// <summary>
    /// Helper class to find command entry point.
    /// </summary>
    internal static class CommandEntryPointHelper
    {
        /// <summary>
        /// Gets a Reflection::MethodInfo instance describing a command entrypoint. This method uses
        /// settings describing entrypoint in the provided commandConfiguration to idenfiy the entrypoint.
        /// </summary>
        /// <param name="commandConfiguration">Date from the command configuration file</param>
        /// <returns></returns>
        public static MethodInfo GetEntryPoint(ConfigurationDictionary commandConfiguration)
        {
            Debug.Assert(commandConfiguration != null);

            using (var resolver = new AssemblyResolver(new string[] { CLUEnvironment.GetRootPath() }, true))
            {
                return GetEntryPoint(commandConfiguration, resolver);
            }
        }

        /// <summary>
        /// Gets a Reflection::MethodInfo instance describing a command entrypoint. This method uses
        /// settings describing entrypoint in the provided commandConfiguration to idenfiy the entrypoint.
        /// </summary>
        /// <param name="commandConfiguration">Date from the command configuration file.</param>
        /// <param name="arguments">The command-line arguments array</param>
        /// <returns></returns>
        public static MethodInfo GetEntryPoint(ConfigurationDictionary commandConfiguration, AssemblyResolver resolver)
        {
            Debug.Assert(commandConfiguration != null);

            if (resolver == null)
            {
                // Create a resolver and recurse.
                using (resolver = new AssemblyResolver(new string[] { CLUEnvironment.GetRootPath() }, true))
                {
                    return GetEntryPoint(commandConfiguration, resolver);
                }
            }

            string commandPackage = commandConfiguration.Get("CommandPackage", true);
            string commandEntryPoint = commandConfiguration.Get("CommandEntryPoint", true);

            if (string.IsNullOrEmpty(commandPackage))
                throw new ArgumentException(Strings.CommandEntryPointHelper_GetEntryPoint_NoPackage);
            if (string.IsNullOrEmpty(commandEntryPoint))
                throw new ArgumentException(Strings.CommandEntryPointHelper_GetEntryPoint_NoEntryPoint);

            MethodInfo method = null;

            var package = Common.LocalPackage.Load(commandPackage);
            if (package == null)
            {
                throw new LocalPackageNotFoundException(commandPackage);
            }

            var methods = package.LoadCommandAssemblies(resolver).Select(a => a.GetEntryPointMethod(commandEntryPoint)).Where(a => a != null).ToArray();

            if (methods.Length == 0)
                throw new ArgumentException(string.Format(Strings.CommandEntryPointHelper_GetEntryPoint_NoEntryPointMethod, commandEntryPoint, commandPackage));

            if (methods.Length > 1)
                throw new ArgumentException(string.Format(Strings.CommandEntryPointHelper_GetEntryPoint_MultipleEntryPoints, commandEntryPoint, commandPackage));

            method = methods[0];

            if (!method.IsStatic || !method.IsPublic)
                throw new ArgumentException(string.Format(Strings.CommandEntryPointHelper_GetEntryPoint_EntryPointIsNotPulicOrStatic, package.Name, commandEntryPoint));

            return method;
        }
    }
}
