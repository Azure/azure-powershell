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
using System.Web;

namespace Microsoft.Azure.Commands.ContainerRegistry.DataPlaneOperations
{
    public abstract class ContainerRegistryDataPlaneOperationBase<T>
    {
        protected ContainerRegistryDataPlaneClient _client;
        protected virtual string _scope
        {
            get
            {
                return String.Format("{0}:{1}:{2}", _resource, _name, _permission);
            }
            set
            {

            }
        }

        protected virtual string _resource
        {
            get
            {
                return "registry";
            }
        }

        protected virtual string _name
        {
            get
            {
                return "catalog";
            }
        }

        protected virtual string _permission
        {
            get
            {
                return "*";
            }
        }

        public ContainerRegistryDataPlaneOperationBase(ContainerRegistryDataPlaneClient client)
        {
            this._client = client;
        }

        public T ProcessRequest()
        {
            _client.Authenticate(_scope);
            return SendRequest();
        }

        public virtual T SendRequest()
        {
            throw new NotImplementedException();
        }

        //sample link: </acr/v1/_catalog?last=test%2Fbusybox99&n=100&orderby=>; rel="next"
        //repository should be in between of first appeartance of '=' and '&'
        protected string getLastListed(string nextLink)
        {
            int left = nextLink.IndexOf('=');
            int right = nextLink.IndexOf('&');
            return HttpUtility.UrlDecode(nextLink.Substring(left + 1, right - left - 1));
        }
    }
}
