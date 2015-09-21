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
using Microsoft.WindowsAzure.Commands.StorSimple.Encryption;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public static class StorSimpleContext
    {
        public static string SubscriptionId { get; set; }
        public static Uri ServiceEndPoint { get; set; }
        public static string ResourceId { get; set; }
        public static string StampId { get; set; }
        public static string CloudServiceName { get; set; }
        public static string ResourceProviderNameSpace { get; set; }
        public static string ResourceType { get; set; }
        public static string ResourceName { get; set; }
        public static StorSimpleKeyManager KeyManager { get; set; }
    }
}
