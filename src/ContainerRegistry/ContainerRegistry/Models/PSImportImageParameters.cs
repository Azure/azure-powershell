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

using Microsoft.Azure.Management.ContainerRegistry.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public class PSImportImageParameters
    {
        public PSImportImageParameters(PSImportSource source, IList<string> targetTags = default(IList<string>), IList<string> untaggedTargetRepositories = default(IList<string>), string mode = default(string))
        {
            Source = source;
            TargetTags = targetTags;
            UntaggedTargetRepositories = untaggedTargetRepositories;
            Mode = mode;
            Validate();
        }

        public PSImportSource Source { get; set; }

        public IList<string> TargetTags { get; set; }

        public IList<string> UntaggedTargetRepositories { get; set; }

        public string Mode { get; set; }

        private void Validate()
        {
            if (Source == null)
            {
                throw new PSArgumentNullException("Source for import image parameters cannot be null");
            }
        }

        public ImportImageParameters GetImportImageParameters()
        {
            return new ImportImageParameters
            {
                Source = this.Source?.GetImportSource(),
                TargetTags = this.TargetTags,
                UntaggedTargetRepositories = this.UntaggedTargetRepositories,
                Mode = this.Mode
            };
        }
    }
}
