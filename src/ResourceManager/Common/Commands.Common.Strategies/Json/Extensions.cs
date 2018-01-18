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
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies.Json
{
    static class Extensions
    {
        public static bool IsGenericType(this Type t, Type genericType)
            => t.IsGenericType && t.GetGenericTypeDefinition() == genericType;

        public static Type[] GetGenericArguments(this Type t, Type genericType, Func<Type, Type[]> p)
            => new[] { t }
                .Concat(t.GetInterfaces())
                .Where(i => i.IsGenericType(genericType))
                .Select(p)
                .FirstOrDefault();
    }
}
