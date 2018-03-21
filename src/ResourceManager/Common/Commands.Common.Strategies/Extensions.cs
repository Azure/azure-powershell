﻿// ----------------------------------------------------------------------------------
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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class Extensions
    {
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> v)
            => v ?? Enumerable.Empty<T>();

        public static TValue GetOrNull<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary, TKey key)
            where TValue : class
        {
            if (key == null)
            {
                return null;
            }
            TValue result;
            dictionary.TryGetValue(key, out result);
            return result;
        }

        public static T GetOrAddWithCast<TKey, T, TBase>(
            this ConcurrentDictionary<TKey, TBase> dictionary, TKey key, Func<T> add)
            where T : TBase
            => (T)dictionary.GetOrAdd(key, _ => add());
    }
}
