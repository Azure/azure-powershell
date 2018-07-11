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

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class Property
    {
        public static Property<TParent, TValue> Create<TParent, TValue>(
            Func<TParent, TValue> get, Action<TParent, TValue> set)
            where TParent : class
            => new Property<TParent, TValue>(get, set);
    }

    public sealed class Property<TParent, TValue>
    {
        public Func<TParent, TValue> Get { get; }

        public Action<TParent, TValue> Set { get; }

        public Property(Func<TParent, TValue> get, Action<TParent, TValue> set)
        {
            Get = get;
            Set = set;
        }
    }
}
