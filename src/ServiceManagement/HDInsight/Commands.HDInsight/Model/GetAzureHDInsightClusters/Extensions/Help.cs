// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions
{
    /// <summary>
    ///     Helper class to provide some useful functions.
    /// </summary>
    internal static class Help
    {
        /// <summary>
        ///     Safely creates a disposable object with a default constructor.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of object to create.
        /// </typeparam>
        /// <returns>
        ///     The disposable object that has been safely created.
        /// </returns>
        public static T SafeCreate<T>() where T : class, IDisposable, new()
        {
            T retval = null;
            try
            {
                retval = new T();
            }
            catch (Exception)
            {
                if (retval.IsNotNull())
                {
                    retval.Dispose();
                }
                throw;
            }
            return retval;
        }

        /// <summary>
        ///     Safely creates a disposable object with a custom constructor.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of object to create.
        /// </typeparam>
        /// <param name="factory">
        ///     The factory method used to construct the object.
        /// </param>
        /// <returns>
        ///     The disposable object that has been safely created.
        /// </returns>
        public static T SafeCreate<T>(Func<T> factory) where T : class, IDisposable
        {
            if (factory.IsNull())
            {
                throw new ArgumentNullException("factory");
            }
            T retval = null;
            try
            {
                retval = factory();
            }
            catch (Exception)
            {
                if (retval.IsNotNull())
                {
                    retval.Dispose();
                }
                throw;
            }
            return retval;
        }

        /// <summary>
        ///     Performs No Action (used to make use of unused, until they are used).
        /// </summary>
        /// <param name="inputs">
        ///     The inputs to the function.
        /// </param>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "inputs",
            Justification = "This method is designed for the very purpose of moving around this warning. [tgs]")]
        public static void DoNothing(params object[] inputs)
        {
        }
    }
}
