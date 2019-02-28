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

namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations;
    using Xunit;

    /// <summary>
    /// Class AssertExtension.
    /// </summary>
    static class AssertExtension
    {
        /// <summary>
        /// Validations the result is error.
        /// </summary>
        /// <param name="validationResult">The validation result.</param>
        /// <param name="message">The message.</param>
        public static void ValidationResultIsError(IValidationResult validationResult, string message)
        {
            Assert.StrictEqual<Result>(Result.Fail, validationResult.Result);
        }

        /// <summary>
        /// Validations the result type is.
        /// </summary>
        /// <param name="validationResult">The validation result.</param>
        /// <param name="message">The message.</param>
        public static void ValidationResultTypeIs(IValidationResult validationResult, string message)
        {
            Assert.StrictEqual<Result>(Result.Fail, validationResult.Result);
        }

        /// <summary>
        /// Validations the result is success.
        /// </summary>
        /// <param name="validationResult">The validation result.</param>
        /// <param name="message">The message.</param>
        internal static void ValidationResultIsSuccess(IValidationResult validationResult, string message)
        {
            Assert.StrictEqual<Result>(Result.Success, validationResult.Result);
        }
    }
}
