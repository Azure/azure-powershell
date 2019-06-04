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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.StorageSync.Interop.DataObjects
{
    /// <summary>
    /// Class HResult.
    /// </summary>
    public static class HResult
    {
        /// <summary>
        /// Determine if HResult is a success code.
        /// Definition as per Essential COM by Don Box page 42
        /// </summary>
        /// <param name="hresult">code to analyze</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Succeeded(int hresult)
        {
            return (hresult >= 0);
        }

        /// <summary>
        /// Determine if HResult is a failure code.
        /// Definition as per Essential COM by Don Box page 42
        /// </summary>
        /// <param name="hresult">code to analyze</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Failed(int hresult)
        {
            return (hresult < 0);
        }
    }
}
