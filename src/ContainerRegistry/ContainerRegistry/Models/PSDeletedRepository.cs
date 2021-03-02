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
    public class PSDeletedRepository
    {
        public PSDeletedRepository(IList<string> manifestsDeleted = default(IList<string>), IList<string> tagsDeleted = default(IList<string>))
        {
            this.ManifestsDeleted = manifestsDeleted;
            this.TagsDeleted = tagsDeleted;
        }

        public PSDeletedRepository(DeletedRepository deleted)
        {
            this.ManifestsDeleted = deleted?.ManifestsDeleted;
            this.TagsDeleted = deleted?.TagsDeleted;
        }

        public IList<string> ManifestsDeleted { get; set; }

        public IList<string> TagsDeleted { get; set; }
    }
}
