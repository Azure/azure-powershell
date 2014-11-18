﻿// ----------------------------------------------------------------------------------
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

using System.ServiceModel;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    /// <summary>
    /// Communication exception utility
    /// </summary>
    public static class CommunicationExceptionUtil
    {
        /// <summary>
        /// is not found communication exception
        /// </summary>
        /// <param name="exception">Communication Exception</param>
        /// <returns>true if exception caused by resource not found, otherwise, false</returns>
        public static bool IsNotFoundException(this CommunicationException exception)
        {
            return ErrorHelper.IsNotFoundCommunicationException(exception);
        }
    }
}
