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

namespace Microsoft.Azure.Commands.HPCCache.Test.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Azure.Commands.TestFx;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit.Abstractions;

    /// <summary>
    /// Helper class.
    /// </summary>
    public static class StorageCacheTestUtilities
    {
        /// <summary>
        /// Generate a random prefix that can be ingested by Azure.
        /// </summary>
        /// <returns>The generated string.</returns>
        public static string GeneratePrefix()
        {
            StringBuilder sb = new StringBuilder(DateTime.Now.ToString("MMdd"));
            var firstFour = Guid.NewGuid().ToString().Substring(0, 4);
            sb.Append(string.Format("x{0}", firstFour));
            return sb.ToString();
        }

        /// <summary>
        /// The GenerateName.
        /// </summary>
        /// <param name="prefix">The prefix<see cref="string"/>.</param>
        /// <param name="methodName">The methodName<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateName(
            string prefix = null,
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName = "GenerateName_failed")
        {
            prefix += GeneratePrefix();
            try
            {
                return HttpMockServer.GetAssetName(methodName, prefix);
            }
            catch (KeyNotFoundException e)
            {
                throw new KeyNotFoundException(string.Format("Generated name not found for calling method: {0}", methodName), e);
            }
        }

        /// <summary>
        /// Throw expception if the given condition is satisfied.
        /// </summary>
        /// <param name="condition">Condition to verify.</param>
        /// <param name="message">Exception message to raise.</param>
        public static void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            {
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Retry on CloudErrorException with particular message.
        /// </summary>
        /// <typeparam name="TRet">Method return type.</typeparam>
        /// <param name="action">Method to execute.</param>
        /// <param name="maxRequestTries">Max retries.</param>
        /// <param name="delayBetweenTries">Delay between each retries in seconds.</param>
        /// <param name="exceptionMessage">Exception message to verify.</param>
        /// <param name="testOutputHelper">testOutputHelper.</param>
        /// <returns>Whatever action parameter returns.</returns>
        public static TRet Retry<TRet>(
            Func<TRet> action,
            int maxRequestTries,
            int delayBetweenTries,
            string exceptionMessage,
            ITestOutputHelper testOutputHelper = null)
        {
            var remainingTries = maxRequestTries;
            var exceptions = new List<Exception>();

            do
            {
                --remainingTries;
                try
                {
                    return action();
                }
                catch (CloudErrorException e)
                {
                    if (e.Body.Error.Message.Contains(exceptionMessage))
                    {
                        if (remainingTries > 0)
                        {
                            if (testOutputHelper != null)
                            {
                                testOutputHelper.WriteLine(e.Body.Error.Message);
                                testOutputHelper.WriteLine($"Sleeping for {delayBetweenTries} time before retrying.");
                            }

                            TestUtilities.Wait(new TimeSpan(0, 0, delayBetweenTries));
                        }

                        exceptions.Add(e);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            while (remainingTries > 0);
            throw AggregatedExceptions(exceptions);
        }

        /// <summary>
        /// An exception handler which returns an unique or aggregated exception.
        /// </summary>
        /// <param name="exceptions">List of an exceptions.</param>
        /// <returns>an aggregate or unique exception.</returns>
        private static Exception AggregatedExceptions(List<Exception> exceptions)
        {
            var uniqueExceptions = exceptions.Distinct(new ExceptionEqualityComparer());

            // If all the requests failed with the same exception,
            // just return one exception to represent them all.
            if (uniqueExceptions.Count() == 1)
            {
                return uniqueExceptions.First();
            }

            // If all the requests failed but for different reasons, return an AggregateException
            // with all the root-cause exceptions.
            return new AggregateException("There is a problem with the service.", uniqueExceptions);
        }

        /// <summary>
        /// Used to aggregate exceptions that occur on request retries.
        /// </summary>
        private class ExceptionEqualityComparer : IEqualityComparer<Exception>
        {
            public bool Equals(Exception e1, Exception e2)
            {
                if (e2 == null && e1 == null)
                {
                    return true;
                }
                else if (e1 == null | e2 == null)
                {
                    return false;
                }
                else if (e1.GetType().Name.Equals(e2.GetType().Name) && e1.Message.Equals(e2.Message))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public int GetHashCode(Exception e)
            {
                return (e.GetType().Name + e.Message).GetHashCode();
            }
        }
    }
}
