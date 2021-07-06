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

namespace Microsoft.Azure.Commands.ResourceGraph.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class PSResourceGraphResponse<PSObject> : IList<PSObject>
    {
        [Ps1Xml(Target = ViewControl.List)]
        public string SkipToken { get; set; }

        [Ps1Xml(Target = ViewControl.List)]
        public IList<PSObject> Data { get; set; }
        public PSObject this[int index]
        {
            get => Data[index];
            set => Data[index] = value;
        }

        public IEnumerator<PSObject> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool IsReadOnly => Data.IsReadOnly;

        public int Count => Data.Count;

        public void Add(PSObject value) => Data.Add(value);

        public void Clear() => Data.Clear();

        public bool Contains(PSObject value) => Data.Contains(value);

        public void CopyTo(PSObject[] array, int index) => Data.CopyTo(array, index);

        public int IndexOf(PSObject value) => Data.IndexOf(value);

        public void Insert(int index, PSObject value) => Data.Insert(index, value);

        public void Remove(PSObject value) => Data.Remove(value);

        public void RemoveAt(int index) => Data.RemoveAt(index);

        bool ICollection<PSObject>.Remove(PSObject item) => Data.Remove(item);
    }
}
