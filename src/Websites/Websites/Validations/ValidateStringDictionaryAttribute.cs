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

using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Validations
{
    public class ValidateStringDictionaryAttribute : ValidateArgumentsAttribute
    {
        protected override void Validate(object arguments, EngineIntrinsics engineIntrinsics)
        {
            var hashtable = arguments as Hashtable;
            if (hashtable == null)
            {
                throw new ValidationMetadataException("Argument must be of type 'System.Collections.Hashtable'");
            }

            foreach (var key in hashtable.Keys)
            {
                if (key.GetType() != typeof(string))
                {
                    throw new ValidationMetadataException(string.Format("Key '{0}' should be of type string instead of {1}", key, key.GetType()));
                }

                var value = hashtable[key];
                if (value.GetType() != typeof(string))
                {
                    throw new ValidationMetadataException(string.Format("Value '{0}' should be of type string instead of {1}", value, value.GetType()));
                }
            }
        }
    }
}
