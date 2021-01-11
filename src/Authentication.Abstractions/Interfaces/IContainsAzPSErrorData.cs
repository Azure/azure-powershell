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

namespace Microsoft.Azure.Commands.Common
{
    /// <summary>
    /// Represent Error Data
    /// </summary>
    public interface IContainsAzPSErrorData
    {
        /// <summary>
        /// Error Kind: User, Serivce, Internal
        /// </summary>
        ErrorKind ErrorKind { get; }

        /// <summary>
        /// Desensitized error message
        /// </summary>
        string DesensitizedErrorMessage { get; }

        /// <summary>
        /// Line number where exception is thrown
        /// </summary>
        int? ErrorLineNumber { get; }

        /// <summary>
        /// File name in which exception is thrown
        /// </summary>
        string ErrorFileName { get; }

    }

    /// <summary>
    /// Represent Error Kind
    /// </summary>
    public class ErrorKind
    {
        public string Value { get; private set; }

        private ErrorKind(string value)
        {
            Value = value;
        }

        public static implicit operator string(ErrorKind error) => error.Value;

        /// <summary>
        /// Error caused by user input
        /// </summary>
        public static ErrorKind UserError = new ErrorKind("User");

        /// <summary>
        /// Error caused by Azure services
        /// </summary>
        public static ErrorKind ServiceError = new ErrorKind("Service");

        /// <summary>
        /// Error that belongs to neither UserError nor ServiceError
        /// </summary>
        public static ErrorKind InternalError = new ErrorKind("Internal");
    }
}
