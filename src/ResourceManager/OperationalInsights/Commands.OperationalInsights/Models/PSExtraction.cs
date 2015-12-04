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
using Microsoft.Azure.Management.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSExtraction
    {
        public PSExtraction()
        {
        }

        public PSExtraction(Extraction extraction)
        {
            if (extraction != null)
            {
                this.Type = extraction.Type;
                this.XmlProgram = extraction.XmlProgram;
                this.ReadableProgram = extraction.ReadableProgram;
                this.SourceType = extraction.SourceType;
                this.SourceField = extraction.SourceField;
            }
        }
        public string Type { get; set; }
        public string XmlProgram { get; set; }
        public string ReadableProgram { get; set; }
        public string SourceType { get; set; }
        public string SourceField { get; set; }
    }
}
