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

namespace Microsoft.Azure.Commands.ManagedCache
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ManagedCache.Models;

    [Cmdlet(VerbsCommon.Get, "AzureManagedCache"), OutputType(typeof(List<PSCacheService>))]
    public class GetAzureManagedCache : ManagedCacheCmdletBase
    {
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set;}

        public override void ExecuteCmdlet()
        {
            WriteWarning(CacheClient.GetManagedCacheRetirementMessage());

            List<PSCacheService> cacheServices = CacheClient.GetCacheServices(Name);
            if (!string.IsNullOrEmpty(Name) && cacheServices.Count == 0)
            {
                throw new ArgumentException(string.Format(Properties.Resources.CacheServiceNotFound, Name));
            }
            WriteObject(cacheServices);
        }      
    }
}