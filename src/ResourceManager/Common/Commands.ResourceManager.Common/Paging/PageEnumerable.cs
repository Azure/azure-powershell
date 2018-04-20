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

using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Paging
{
    public class PageEnumerable<T> : IEnumerable<T>, IDisposable
    {
        private Func<IPage<T>> _list;
        private Func<string, IPage<T>> _listNext;
        private ulong _first;
        private ulong _skip;

        public PageEnumerable(Func<IPage<T>> list, Func<string, IPage<T>> listNext, ulong first, ulong skip)
        {
            _list = list;
            _listNext = listNext;
            _first = first;
            _skip = skip;
        }

        public void Dispose()
        {

        }

        public IEnumerator<T> GetEnumerator()
        {
            return new PageEnumerator<T>(_list, _listNext, _first, _skip);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
