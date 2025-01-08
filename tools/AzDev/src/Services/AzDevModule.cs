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
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Tests")]

namespace AzDev.Services
{
    internal static class AzDevModule
    {
        private static readonly IDictionary<string, object> Components;

        static AzDevModule()
        {
            Components = new Dictionary<string, object>();
        }

        public static T GetComponent<T>(string key)
        {
            if (Components[key] is T t)
            {
                return t;
            }
            else
            {
                throw new ArgumentException($"Mismatching type. Expect [{typeof(T)}]. Got [{Components[key].GetType()}].");
            }
        }

        public static void SetComponent<T>(string key, T value)
        {
            Components[key] = value;
        }
    }
}
