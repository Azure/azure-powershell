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

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Management.Automation;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities
{
    internal static class TaskEx2
    {
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Required for functionality.")]
        public static Task<TResult> FromResult<TResult>(TResult result)
        {
            var task = new Task<TResult>(() => result);
            task.RunSynchronously();
            return task;
        }

        public static IEnumerable<TEntity> ToEnumerable<TEntity>(this ICollection<PSObject> powerShellObjects) where TEntity : class
        {
            powerShellObjects.ArgumentNotNull("psObjects");
            var enumerableEntities = new List<TEntity>();
            foreach (PSObject psObject in powerShellObjects)
            {
                var entity = psObject.ImmediateBaseObject as TEntity;
                if (entity != null)
                {
                    enumerableEntities.Add(entity);
                }
            }

            return enumerableEntities;
        }
    }
}
