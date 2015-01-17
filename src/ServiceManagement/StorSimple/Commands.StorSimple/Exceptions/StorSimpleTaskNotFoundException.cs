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

namespace Microsoft.WindowsAzure.Commands.StorSimple.Exceptions
{
    [Serializable]
    public class StorSimpleTaskNotFoundException : Exception
    {
        static string genericErrorMessage = "The TaskId provided does not exist. Please try with a valid task instance Id.";
        /// <summary>
        /// Create a new instance with error message
        /// </summary>
        /// <param name="message">error message</param>
        public StorSimpleTaskNotFoundException(string message)
            : base(message)
        { }

        public StorSimpleTaskNotFoundException()
            : base(genericErrorMessage)
        {

        }
    }
}
