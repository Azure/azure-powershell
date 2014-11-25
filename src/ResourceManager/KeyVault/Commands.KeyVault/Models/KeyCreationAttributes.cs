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
using System.Collections.ObjectModel;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class KeyCreationAttributes : KeyAttributes
    {
        public KeyCreationAttributes(bool? enabled, DateTime? expires, DateTime? notBefore, bool? hsm, string[] keyOps) :
            base(enabled, expires, notBefore, null, keyOps)
        {
            this.Hsm = hsm;           
        }

        public bool? Hsm { get; private set; }        
    }
}
