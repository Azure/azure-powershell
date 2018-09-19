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
using System.Net;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Exceptions;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.WebClient;

namespace Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations
{
    internal abstract class OperationsBase<T> where T : class
    {
        protected readonly WebClientFactory webClientFactory;
        protected readonly string uriSuffix;

        /// <summary>
        /// The constructor for the base object of all operations classes.
        /// Requires a WebClientFactory, which knows how to produce new web clients.
        /// Also requires uri suffix of the resource. e.g., "/VirtualMachines". This is to provide a common way for operations classes to avoid hardcoding the suffixes.
        /// </summary>
        /// <param name="webClientFactory"></param>
        /// <param name="uriSuffix"></param>
        protected OperationsBase(WebClientFactory webClientFactory, string uriSuffix)
        {
            this.webClientFactory = webClientFactory;
            this.uriSuffix = uriSuffix;
        }

        /// <summary>
        /// Submits request for creating object of type T. Returns "temporary" or "future" object if request is submitted successfully.
        /// Caller must wait on jobId to track the status of the operation.
        /// </summary>
        /// <param name="vmToCreate"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public virtual T Create(T vmToCreate, out Guid? jobId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves a resource by ID. 
        /// </summary>
        /// <param name="id">Unique GUID of the resource to be returned</param>
        /// <returns>Resouce object (e.g., VirtualMachine, VirtualHardDisk, etc.)</returns>
        /// TODO: CloudServices and VMRoles don't have GUID ID properties. Will need refactoring or changes
        public virtual T Read(Guid id)
        {
            var filterDict = new Dictionary<string, string>
                {
                    {"ID", id.ToString()}
                };

            var resultList = this.Read(filterDict);

            if (resultList.Count <= 0)
                throw new WAPackOperationException(string.Format(Resources.ResourceNotFound, id));

            return resultList[0];
        }

        /// <summary>
        /// Retrieves a list of all resources of type T.
        /// </summary>
        /// <returns></returns>
        public virtual List<T> Read()
        {
            var resultList = this.Read(new Dictionary<string, string>());
            return resultList;
        }

        /// <summary>
        /// Retrieves a list of all resources of type T which satisfy the complete set of key=value
        /// filters passed as an argument.
        /// </summary>
        /// <param name="equalityFilters">A dictionary of key=value filters that must be true for all returned objects</param>
        /// <returns></returns>
        internal List<T> Read(IDictionary<string, string> equalityFilters)
        {
            var client = this.webClientFactory.CreateClient(this.uriSuffix);

            foreach (var filter in equalityFilters)
                client.AddHttpFilter(filter.Key, WebFilterOptions.eq, filter.Value);

            WebHeaderCollection outHeaders;
            var resultList = client.Get<T>(out outHeaders);

            return resultList;
        }

        /// <summary>
        /// Retrieves is the list of navigation property by expanding it on the parent resource.
        /// </summary>
        /// <param name="equalityFilters">A dictionary of key=value filters that must be true for all returned objects</param>
        /// <param name="navigationProperty">The navigation property to expand.</param>
        /// <returns></returns>
        internal List<T> Read(IDictionary<string, string> equalityFilters, string navigationProperty)
        {
            var client = this.webClientFactory.CreateClient(this.uriSuffix);

            foreach (var filter in equalityFilters)
                client.AddHttpFilter(filter.Key, WebFilterOptions.eq, filter.Value);

            client.AddQueryParameters("$expand", navigationProperty);
            WebHeaderCollection outHeaders;
            var resultList = client.Get<T>(out outHeaders);

            return resultList;
        }

        /// <summary>
        /// Submits request for updating a resource (arguments's ID must match the existing resource's ID).
        /// Returns the temp object.
        /// Caller must wait on jobId to track the status of the operation.
        /// </summary>
        /// <param name="toUpdate"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public virtual T Update(T toUpdate, out Guid? jobId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Submits request for deleting resource with given Id.
        /// Caller must wait on jobId to track the status of the operation.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public virtual void Delete(Guid id, out Guid? jobId)
        {
            throw new NotImplementedException();
        }

        protected static Guid? TryGetJobIdFromHeaders(WebHeaderCollection headers)
        {
            var value = headers.Get("x-ms-request-id");

            Guid toReturn;

            if (Guid.TryParse(value, out toReturn))
                return toReturn;
            return null;
        }
    }
}
