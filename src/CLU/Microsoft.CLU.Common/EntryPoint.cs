using Microsoft.CLU.Common.Properties;
using System;
using System.Linq;
using System.Reflection;

namespace Microsoft.CLU.Common
{
    /// <summary>
    /// Type representing an entry point.
    /// </summary>
    internal class EntryPoint
    {
        /// <summary>
        /// The entry point fully qualified name.
        /// format: Namespace.ClassName.MethodName
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// The entrypoint class name.
        /// </summary>
        public string ClassTypeName { get; private set; }

        /// <summary>
        /// Reference to entrypoint class type.
        /// </summary>
        public Type ClassType { get; set; }

        /// <summary>
        /// The entrypoint method name.
        /// </summary>
        public string MethodName { get; private set; }

        /// <summary>
        /// Reference to entrypoint method.
        /// </summary>
        public MethodInfo Method { get; set; }

        /// <summary>
        /// Create an instance of EntryPoint.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="fullName">Fully qualified method name in the form Namespace.ClassName.MethodName</param>
        public EntryPoint(Assembly assembly, string fullName)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }
            if (string.IsNullOrEmpty(fullName))
            {
                throw new ArgumentNullException("fullName)");
            }

            _assembly = assembly;
            var methodNameIndex = fullName.LastIndexOf('.');
            if (methodNameIndex == -1)
                throw new ArgumentException(Strings.EntryPoint_Ctor_MethodNameMustBeFullyQualified);

            FullName = fullName;
            MethodName = fullName.Substring(methodNameIndex + 1);
            ClassTypeName = fullName.Substring(0, methodNameIndex);
            ClassType = _assembly.GetType(ClassTypeName);
            if (ClassType != null)
            {
                Method = ClassType.GetMethods().Where(m => m.Name == MethodName).FirstOrDefault();
            }
        }

        #region Private fields

        /// <summary>
        /// The assembly in which entry point is defined.
        /// </summary>
        private Assembly _assembly;

        #endregion
    }
}
