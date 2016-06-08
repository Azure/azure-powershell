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
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.Github.Entities;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.Github
{
    /// <summary>
    /// Provides the Github Api. 
    /// </summary>
    [ServiceContract]
    public interface IGithubServiceManagement
    {
        [Description("Creates a new authorization")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "/authorizations", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        IAsyncResult BeginCreateAuthorizationToken(GithubAuthorizationRequest request, AsyncCallback callback, object state);
        GithubAuthorization EndCreateAuthorizationToken(IAsyncResult asyncResult);

        [Description("Gets the organizations for the authenticated user")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = "/user/orgs", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        IAsyncResult BeginGetOrganizations(AsyncCallback callback, object state);
        List<GithubOrganization> EndGetOrganizations(IAsyncResult asyncResult);
        
        [Description("Gets the organizations for an user")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = "/users/{user}/orgs", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        IAsyncResult BeginGetOrganizationsFromUser(string user, AsyncCallback callback, object state);
        List<GithubOrganization> EndGetOrganizationsFromUser(IAsyncResult asyncResult);

        [Description("Gets the repositories for the authenticated user")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = "/user/repos", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        IAsyncResult BeginGetRepositories(AsyncCallback callback, object state);
        List<GithubRepository> EndGetRepositories(IAsyncResult asyncResult);

        [Description("Gets the repositories for an user")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = "/users/{user}/repos", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        IAsyncResult BeginGetRepositoriesFromUser(string user, AsyncCallback callback, object state);
        List<GithubRepository> EndGetRepositoriesFromUser(IAsyncResult asyncResult);

        [Description("Gets the repositories for an organization")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = "/orgs/{organization}/repos?sort=updated&desc=desc", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        IAsyncResult BeginGetRepositoriesFromOrg(string organization, AsyncCallback callback, object state);
        List<GithubRepository> EndGetRepositoriesFromOrg(IAsyncResult asyncResult);

        [Description("Gets the repository hooks")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = "/repos/{owner}/{repository}/hooks", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        IAsyncResult BeginGetRepositoryHooks(string owner, string repository, AsyncCallback callback, object state);
        List<GithubRepositoryHook> EndGetRepositoryHooks(IAsyncResult asyncResult);

        [Description("Creates a repository hook")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "/repos/{owner}/{repository}/hooks", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        IAsyncResult BeginCreateRepositoryHook(string owner, string repository, GithubRepositoryHook hook, AsyncCallback callback, object state);
        GithubRepositoryHook EndCreateRepositoryHook(IAsyncResult asyncResult);

        [Description("Updates a repository hook")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "PATCH", UriTemplate = "/repos/{owner}/{repository}/hooks/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        IAsyncResult BeginUpdateRepositoryHook(string owner, string repository, string id, GithubRepositoryHook hook, AsyncCallback callback, object state);
        GithubRepositoryHook EndUpdateRepositoryHook(IAsyncResult asyncResult);

        [Description("Tests a repository hook")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "POST", UriTemplate = "/repos/{owner}/{repository}/hooks/{id}/test", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        IAsyncResult BeginTestRepositoryHook(string owner, string repository, string id, AsyncCallback callback, object state);
        void EndTestRepositoryHook(IAsyncResult asyncResult);
    }
}
