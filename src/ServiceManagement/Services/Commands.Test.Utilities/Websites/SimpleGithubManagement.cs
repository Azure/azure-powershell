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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.Github;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.Github.Entities;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.Websites
{
    public class SimpleGithubManagement : IGithubServiceManagement
    {
        /// <summary>
        /// Gets or sets a value indicating whether the thunk wrappers will
        /// throw an exception if the thunk is not implemented.  This is useful
        /// when debugging a test.
        /// </summary>
        public bool ThrowsIfNotImplemented { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleDeploymentServiceManagement"/> class.
        /// </summary>
        public SimpleGithubManagement()
        {
            ThrowsIfNotImplemented = true;
        }

        #region Implementation Thunks

        #region GetRepositories

        public Func<SimpleServiceManagementAsyncResult, List<GithubRepository>> GetRepositoriesThunk { get; set; }

        public IAsyncResult BeginGetRepositories(AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public List<GithubRepository> EndGetRepositories(IAsyncResult asyncResult)
        {
            if (GetRepositoriesThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleDeploymentServiceManagementAsyncResult!");

                return GetRepositoriesThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetRepositoriesThunk is not implemented!");
            }

            return default(List<GithubRepository>);
        }

        #endregion

        #region GetOrganizations

        public Func<SimpleServiceManagementAsyncResult, List<GithubOrganization>> GetOrganizationsThunk { get; set; }

        public IAsyncResult BeginGetOrganizations(AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public List<GithubOrganization> EndGetOrganizations(IAsyncResult asyncResult)
        {
            if (GetOrganizationsThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleDeploymentServiceManagementAsyncResult!");

                return GetOrganizationsThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetOrganizationsThunk is not implemented!");
            }

            return default(List<GithubOrganization>);
        }

        #endregion


        #region GetRepositoriesFromOrg

        public Func<SimpleServiceManagementAsyncResult, List<GithubRepository>> GetRepositoriesFromOrgThunk { get; set; }

        public IAsyncResult BeginGetRepositoriesFromOrg(string organization, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["organization"] = organization;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public List<GithubRepository> EndGetRepositoriesFromOrg(IAsyncResult asyncResult)
        {
            if (GetRepositoriesFromOrgThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleDeploymentServiceManagementAsyncResult!");

                return GetRepositoriesFromOrgThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetRepositoriesFromOrgThunk is not implemented!");
            }

            return default(List<GithubRepository>);
        }

        #endregion

        #region GetRepositoryHooks

        public Func<SimpleServiceManagementAsyncResult, List<GithubRepositoryHook>> GetRepositoryHooksThunk { get; set; }

        public IAsyncResult BeginGetRepositoryHooks(string owner, string repository, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["owner"] = owner;
            result.Values["repository"] = repository;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public List<GithubRepositoryHook> EndGetRepositoryHooks(IAsyncResult asyncResult)
        {
            if (GetRepositoryHooksThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleDeploymentServiceManagementAsyncResult!");

                return GetRepositoryHooksThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetRepositoryHooksThunk is not implemented!");
            }

            return default(List<GithubRepositoryHook>);
        }

        #endregion

        #region CreatedRepositoryHook

        public Func<SimpleServiceManagementAsyncResult, GithubRepositoryHook> CreateRepositoryHookThunk { get; set; }

        public IAsyncResult BeginCreateRepositoryHook(string owner, string repository, GithubRepositoryHook hook, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["owner"] = owner;
            result.Values["repository"] = repository;
            result.Values["hook"] = hook;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public GithubRepositoryHook EndCreateRepositoryHook(IAsyncResult asyncResult)
        {
            if (CreateRepositoryHookThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleDeploymentServiceManagementAsyncResult!");

                return CreateRepositoryHookThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("CreateRepositoryHookThunk is not implemented!");
            }

            return default(GithubRepositoryHook);
        }

        #endregion

        #region UpdateRepositoryHook

        public Func<SimpleServiceManagementAsyncResult, GithubRepositoryHook> UpdateRepositoryHookThunk { get; set; }

        public IAsyncResult BeginUpdateRepositoryHook(string owner, string repository, string id, GithubRepositoryHook hook, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["owner"] = owner;
            result.Values["repository"] = repository;
            result.Values["id"] = id;
            result.Values["hook"] = hook;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public GithubRepositoryHook EndUpdateRepositoryHook(IAsyncResult asyncResult)
        {
            if (UpdateRepositoryHookThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleDeploymentServiceManagementAsyncResult!");

                return UpdateRepositoryHookThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("UpdateRepositoryHookThunk is not implemented!");
            }

            return default(GithubRepositoryHook);
        }

        #endregion

        #region TestRepositoryHook

        public Action<SimpleServiceManagementAsyncResult> TestRepositoryHookThunk { get; set; }

        public IAsyncResult BeginTestRepositoryHook(string owner, string repository, string id, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["owner"] = owner;
            result.Values["repository"] = repository;
            result.Values["id"] = id;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndTestRepositoryHook(IAsyncResult asyncResult)
        {
            if (TestRepositoryHookThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleDeploymentServiceManagementAsyncResult!");

                TestRepositoryHookThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("TestRepositoryHookThunk is not implemented!");
            }
        }

        #endregion

        #endregion

        public IAsyncResult BeginCreateAuthorizationToken(GithubAuthorizationRequest request, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public GithubAuthorization EndCreateAuthorizationToken(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginGetOrganizationsFromUser(string user, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public List<GithubOrganization> EndGetOrganizationsFromUser(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginGetRepositoriesFromUser(string user, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public List<GithubRepository> EndGetRepositoriesFromUser(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }
    }
}
