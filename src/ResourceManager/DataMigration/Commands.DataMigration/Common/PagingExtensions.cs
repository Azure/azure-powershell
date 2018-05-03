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
using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.Management.DataMigration;
using Microsoft.Azure.Management.DataMigration.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.DataMigration.Common
{
    public static partial class PagingExtensions
    {
        public static IEnumerable<DataMigrationService> EnumerateServicesByResouceGroup(
            this IServicesOperations ops, string resourceGroupName)
        {
            return new PagedEnumerable<DataMigrationService>(
                () => ops.ListByResourceGroup(resourceGroupName),
                link => ops.ListByResourceGroupNext(link));
        }

        public static IEnumerable<ProjectTask> EnumerateTaskByProjects(
            this ITasksOperations ops, string resourceGroupName, string serviceName, string projectName, string taskType = null)
        {
            return new PagedEnumerable<ProjectTask>(
                () => ops.List(resourceGroupName, serviceName, projectName, taskType),
                link => ops.ListNext(link));
        }

        public static IEnumerable<DataMigrationService> EnumerateServicesBySubcription(
            this IServicesOperations ops)
        {
            return new PagedEnumerable<DataMigrationService>(
                () => ops.List(),
                link => ops.ListNext(link));
        }


        public static IEnumerable<Project> EnumerateProjects(
            this IProjectsOperations ops, string resourceGroupName, string serviceName)
        {
            return new PagedEnumerable<Project>(
                () => ops.List(resourceGroupName, serviceName),
                link => ops.ListNext(link));
        }


        private sealed class PagedEnumerable<T> : IEnumerable<T>
        {
            private readonly Func<IPage<T>> getFirstPage;
            private readonly Func<string, IPage<T>> getNextPage;

            public PagedEnumerable(Func<IPage<T>> getFirstPage, Func<string, IPage<T>> getNextPage)
            {
                this.getFirstPage = getFirstPage;
                this.getNextPage = getNextPage;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return new PagedEnumerator(this);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            private sealed class PagedEnumerator : IEnumerator<T>
            {
                private readonly PagedEnumerable<T> owner;
                private string nextPageLink;
                private IEnumerator<T> e;

                public PagedEnumerator(PagedEnumerable<T> owner)
                {
                    this.owner = owner;
                    initialize();
                }

                public T Current
                {
                    get
                    {
                        return e.Current;
                    }
                }

                object IEnumerator.Current
                {
                    get
                    {
                        return e.Current;
                    }
                }

                public void Dispose()
                {
                    if (e != null)
                    {
                        e.Dispose();
                    }
                    e = null;
                }

                public bool MoveNext()
                {
                    if (e.MoveNext())
                    {
                        return true;
                    }

                    if (nextPageLink == null)
                    {
                        return false;
                    }

                    IPage<T> page = owner.getNextPage(nextPageLink);
                    e = page.GetEnumerator();
                    nextPageLink = page.NextPageLink;

                    return this.MoveNext();
                }

                public void Reset()
                {
                    initialize();
                }

                private void initialize()
                {
                    IPage<T> page = owner.getFirstPage();
                    e = page.GetEnumerator();
                    nextPageLink = page.NextPageLink;
                }
            }
        }
    }
}
