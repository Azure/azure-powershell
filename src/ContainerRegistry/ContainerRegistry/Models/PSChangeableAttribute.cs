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

using Microsoft.Azure.ContainerRegistry.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public class PSChangeableAttribute
    {
        public PSChangeableAttribute(bool? deleteEnabled = default(bool?), bool? writeEnabled = default(bool?), bool? listEnabled = default(bool?), bool? readEnabled = default(bool?))
        {
            DeleteEnabled = deleteEnabled;
            WriteEnabled = writeEnabled;
            ListEnabled = listEnabled;
            ReadEnabled = readEnabled;
        }

        public PSChangeableAttribute(ChangeableAttributes attribute)
        {
            DeleteEnabled = attribute?.DeleteEnabled;
            WriteEnabled = attribute?.WriteEnabled;
            ListEnabled = attribute?.ListEnabled;
            ReadEnabled = attribute?.ReadEnabled;
        }

        public ChangeableAttributes GetAttribute()
        {
            return new ChangeableAttributes
            {
                DeleteEnabled = this.DeleteEnabled,
                WriteEnabled = this.WriteEnabled,
                ListEnabled = this.ListEnabled,
                ReadEnabled = this.ReadEnabled
            };
        }

        public bool? DeleteEnabled { get; set; }

        public bool? WriteEnabled { get; set; }

        public bool? ListEnabled { get; set; }

        public bool? ReadEnabled { get; set; }
    }
}
