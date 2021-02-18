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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using System;
    using System.Collections.Generic;

    public static class PSResourceManagerErrorFormatter
    {
        public static string Format(PSResourceManagerError error)
        {
            if (error == null)
            {
                return string.Empty;
            }

            IList<string> messages = new List<string>
            {
                $"{error.Code} - {error.Message}"
            };

            if (error.Details != null)
            {
                foreach (var innerError in error.Details)
                {
                    messages.Add(Format(innerError));
                }
            }

            return string.Join(Environment.NewLine, messages);
        }
    }
}
