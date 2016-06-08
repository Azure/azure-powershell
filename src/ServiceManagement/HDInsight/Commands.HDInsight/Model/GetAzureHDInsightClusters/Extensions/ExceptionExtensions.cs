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
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions
{
    /// <summary>
    ///     Provides a set of extension over the Exception class.
    /// </summary>
    internal static class ExceptionExtensions
    {
        /// <summary>
        ///     Gets the first usable exception for this exception.
        ///     This method undoes Target Invoke, Aggregate Exception and
        ///     Task Canceled Exceptions.
        /// </summary>
        /// <param name="ex">
        ///     The exception to be converted.
        /// </param>
        /// <returns>
        ///     The first "non wrapping" exception that can be found based
        ///     on unwrapping rules.
        /// </returns>
        public static Exception GetFirstException(this Exception ex)
        {
            var asAgg = ex as AggregateException;
            if (asAgg.IsNotNull())
            {
                AggregateException exs = asAgg.Flatten();
                if (exs.InnerException.IsNotNull())
                {
                    return exs.InnerException.GetFirstException();
                }
            }
            var asTargetOfInvoke = ex as TargetInvocationException;
            if (asTargetOfInvoke.IsNotNull())
            {
                return asTargetOfInvoke.InnerException.GetFirstException();
            }
            var asTaskCancel = ex as TaskCanceledException;
            if (asTaskCancel.IsNotNull())
            {
                if (asTaskCancel.InnerException.IsNotNull())
                {
                    return asTaskCancel.InnerException.GetFirstException();
                }
            }
            return ex;
        }

        /// <summary>
        ///     Rethrows an exception based on unwrapping rules.
        /// </summary>
        /// <param name="ex">
        ///     The exception to rethrow.
        /// </param>
        public static void Rethrow(this Exception ex)
        {
            throw ex.GetFirstException();
        }
    }
}
