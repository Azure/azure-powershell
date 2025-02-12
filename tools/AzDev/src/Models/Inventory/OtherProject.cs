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

using System.IO.Abstractions;

namespace AzDev.Models.Inventory
{
    internal class OtherProject : Project
    {
        protected OtherProject(IFileSystem fs, string path) : base(fs, path) { }
        internal OtherProject() { }
        public new static OtherProject FromFileSystem(IFileSystem fs, string path)
        {
            return new OtherProject(fs, path)
            {
                Type = ProjectType.Other,
                Name = fs.Path.GetFileName(path)
            };
        }
    }
}
