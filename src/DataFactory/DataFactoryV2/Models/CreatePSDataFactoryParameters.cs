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

using Microsoft.Azure.Management.DataFactory.Models;
using System.Collections;
<<<<<<< HEAD
=======
using System.Collections.Generic;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    public class CreatePSDataFactoryParameters : DataFactoryParametersBase
    {
        public string Location { get; set; }

        public Hashtable Tags { get; set; }

        public FactoryRepoConfiguration RepoConfiguration { get; set; }
<<<<<<< HEAD
=======

        public IDictionary<string, GlobalParameterSpecification> GlobalParameters { get; set; }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
}
