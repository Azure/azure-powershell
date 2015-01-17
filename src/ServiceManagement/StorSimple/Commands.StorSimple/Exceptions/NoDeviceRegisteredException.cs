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
    public class NoDeviceRegisteredException : Exception
    {
        static string genericErrorMessage = "No StorSimple device is currently registered with this resource. Please register at least one device to the resource and rerun this command.";
        /// <summary>
        /// Create a new instance with error message
        /// </summary>
        /// <param name="message">error message</param>
        public NoDeviceRegisteredException(string message)
            : base(message)
        { }

        public NoDeviceRegisteredException()
            : base(genericErrorMessage)
        {

        }
    }
}
