// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagingExtensions.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Azure.Management.DataMigration;
using Microsoft.Azure.Management.DataMigration.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
