// Copyright (c) Microsoft Corporation. All rights reserved.
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
//

using Azure.Core.Diagnostics;

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace Microsoft.Azure.PowerShell.Authenticators.Identity
{
    internal abstract class AzureEventSource: EventSource
    {
        private const string SharedDataKey = "_AzureEventSourceNamesInUse";
        private static readonly HashSet<string> NamesInUse;

#pragma warning disable CA1810 // Use static initializer
        static AzureEventSource()
#pragma warning restore CA1810
        {
            // It's important for this code to run in a static constructor because runtime guarantees that
            // a single instance is executed at a time
            // This gives us a chance to store a shared hashset in the global dictionary without a race
            var namesInUse = AppDomain.CurrentDomain.GetData(SharedDataKey) as HashSet<string>;
            if (namesInUse == null)
            {
                namesInUse = new HashSet<string>();
                AppDomain.CurrentDomain.SetData(SharedDataKey, namesInUse);
            }

            NamesInUse = namesInUse;
        }

        private static readonly string[] MainEventSourceTraits =
        {
            AzureEventSourceListener.TraitName,
            AzureEventSourceListener.TraitValue
        };

        protected AzureEventSource(string eventSourceName): base(
            DeduplicateName(eventSourceName),
            EventSourceSettings.Default,
            MainEventSourceTraits
        )
        {
        }

        // The name de-duplication is required for the case where multiple versions of the same assembly are loaded
        // in different assembly load contexts
        private static string DeduplicateName(string eventSourceName)
        {
            try
            {
                lock (NamesInUse)
                {
                    // pick up existing EventSources that might not participate in this logic
                    foreach (var source in GetSources())
                    {
                        NamesInUse.Add(source.Name);
                    }

                    if (!NamesInUse.Contains(eventSourceName))
                    {
                        NamesInUse.Add(eventSourceName);
                        return eventSourceName;
                    }

                    int i = 1;
                    while (true)
                    {
                        var candidate = $"{eventSourceName}-{i}";
                        if (!NamesInUse.Contains(candidate))
                        {
                            NamesInUse.Add(candidate);
                            return candidate;
                        }

                        i++;
                    }
                }
            }
            // GetSources() is not supported on some platforms
            catch (NotImplementedException) { }

            return eventSourceName;
        }
    }
}