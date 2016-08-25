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
using System.Management.Automation;


namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ValidateUnc : ValidateArgumentsAttribute
    {
        protected override void Validate(object arguments, EngineIntrinsics engineIntrinsics)
        {
            if (arguments == null)
            {
                return;
            }
            var uri = arguments as Uri;

            if (uri == null)
            {
                throw new ValidationMetadataException(Resources.ValidateUncWrongType);
            }

            if (uri.IsUnc == false)
            {
                throw new ValidationMetadataException(Resources.ValidateUncWrongType);
            }
        }
    }
}
