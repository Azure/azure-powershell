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

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities
{
    internal static class Validation
    {
        public static void CheckArgument(bool argumentCondition, string message = null)
        {
            if (!argumentCondition)
            {
                throw new ArgumentException(message);
            }
        }

        public static void CheckArgument<T>(T arg, string message = null) where T : class
        {
            if (arg == null)
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void CheckArgument<TException>(bool argumentCondition, string message = null) where TException : Exception, new()
        {
            if (!argumentCondition)
            {
                Validation.Throw<TException>(message);
            }
        }

        public static void CheckInvariant(bool variantCondition, string message = null)
        {
            Validation.CheckInvariant<InvalidOperationException>(variantCondition, message);
        }

        public static void CheckInvariant<TException>(bool variantCondition, string message = null) where TException : Exception, new()
        {
            if (!variantCondition)
            {
                Validation.Throw<TException>(message);
            }
        }

        private static void Throw<TException>(string message) where TException : Exception, new()
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new TException();
            }
            else
            {
                Type exType = typeof(TException);
                Exception exception = Activator.CreateInstance(exType, message) as Exception;

                if (exception != null)
                {
                    throw exception;
                }
            }
        }
    }
}

