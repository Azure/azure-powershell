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
        protected virtual string Scope
        {
            get
            {
                return String.Format("{0}:{1}:{2}", Resource, Name, Permission);
            }
            set
            {

            }
        }

        protected virtual string Resource
        {
            get
            {
                return "registry";
            }
        }

        protected virtual string Name
        {
            get
            {
                return "catalog";
            }
        }

        protected virtual string Permission
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
            _client.Authenticate(Scope);
            return SendRequest();
        }

        public abstract T SendRequest();

        //sample link: </acr/v1/_catalog?last=test%2Fbusybox99&n=100&orderby=>; rel="next"
        //repository should be in between of first appeartance of '=' and '&'
        protected string GetLastListed(string nextLink)
        {
            int startOfParam = nextLink.IndexOf('<') + 1;
            int endOfParam = nextLink.IndexOf('>') - startOfParam - 1;
            string param = nextLink.Substring(startOfParam, endOfParam).Substring(nextLink.IndexOf('?') + 1);
            string last = param.Split('&')[0].Split('=')[1];
            return HttpUtility.UrlDecode(last);
        }
    }
}
