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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.GeoEntities;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.Websites
{
    /// <summary>
    /// Simple implementation of the <see cref="IWebsitesServiceManagement"/> interface that can be
    /// used for mocking basic interactions without involving Azure directly.
    /// </summary>
    public class SimpleWebsitesManagement : IWebsitesServiceManagement
    {
        /// <summary>
        /// Gets or sets a value indicating whether the thunk wrappers will
        /// throw an exception if the thunk is not implemented.  This is useful
        /// when debugging a test.
        /// </summary>
        public bool ThrowsIfNotImplemented { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleWebsitesManagement"/> class.
        /// </summary>
        public SimpleWebsitesManagement()
        {
            ThrowsIfNotImplemented = true;
        }

        #region Implementation Thunks

        #region GetWebspaces

        public Func<SimpleServiceManagementAsyncResult, WebSpaces> GetWebSpacesThunk { get; set; }

        public IAsyncResult BeginGetWebSpaces(string subscriptionName, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionName"] = subscriptionName;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public WebSpaces EndGetWebSpaces(IAsyncResult asyncResult)
        {
            if (GetWebSpacesThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                return GetWebSpacesThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetWebSpacesThunk is not implemented!");
            }

            return default(WebSpaces);
        }

        #endregion

        #region GetSites

        public Func<SimpleServiceManagementAsyncResult, Sites> GetSitesThunk { get; set; }

        public IAsyncResult BeginGetSites(string subscriptionName, string webspaceName, string propertiesToInclude, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionName"] = subscriptionName;
            result.Values["webspaceName"] = webspaceName;
            result.Values["propertiesToInclude"] = propertiesToInclude;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public Sites EndGetSites(IAsyncResult asyncResult)
        {
            if (GetSitesThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                return GetSitesThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetSitesThunk is not implemented!");
            }

            return default(Sites);
        }

        #endregion

        #region DeleteWebsite

        public Action<SimpleServiceManagementAsyncResult> DeleteSiteThunk { get; set; }

        public IAsyncResult BeginDeleteSite(string subscriptionName, string webspaceName, string name, string deleteMetrics, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionName"] = subscriptionName;
            result.Values["webspaceName"] = webspaceName;
            result.Values["name"] = name;
            result.Values["deleteMetrics"] = deleteMetrics;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndDeleteSite(IAsyncResult asyncResult)
        {
            if (DeleteSiteThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                DeleteSiteThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("DeleteSiteThunk is not implemented!");
            }
        }

        #endregion

        #region GetSiteConfig

        public Func<SimpleServiceManagementAsyncResult, SiteConfig> GetSiteConfigThunk { get; set; }

        public IAsyncResult BeginGetSiteConfig(string subscriptionName, string webspaceName, string name, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionName"] = subscriptionName;
            result.Values["webspaceName"] = webspaceName;
            result.Values["name"] = name;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public SiteConfig EndGetSiteConfig(IAsyncResult asyncResult)
        {
            if (GetSiteConfigThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                return GetSiteConfigThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetSiteConfigThunk is not implemented!");
            }

            return default(SiteConfig);
        }

        #endregion

        #region CreateSite

        public Func<SimpleServiceManagementAsyncResult, Site> CreateSiteThunk { get; set; }

        public IAsyncResult BeginCreateSite(string subscriptionName, string webspaceName, Site site, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionName"] = subscriptionName;
            result.Values["webspaceName"] = webspaceName;
            result.Values["site"] = site;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public Site EndCreateSite(IAsyncResult asyncResult)
        {
            if (CreateSiteThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                return CreateSiteThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("CreateSiteThunk is not implemented!");
            }

            return default(Site);
        }

        #endregion

        #region UpdateWebsite

        public Action<SimpleServiceManagementAsyncResult> UpdateSiteThunk { get; set; }

        public IAsyncResult BeginUpdateSite(string subscriptionName, string webspaceName, string name, Site site, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionName"] = subscriptionName;
            result.Values["webspaceName"] = webspaceName;
            result.Values["name"] = name;
            result.Values["site"] = site;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndUpdateSite(IAsyncResult asyncResult)
        {
            if (UpdateSiteThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                UpdateSiteThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("UpdateSiteThunk is not implemented!");
            }
        }

        #endregion

        #region UpdateSiteConfig

        public Action<SimpleServiceManagementAsyncResult> UpdateSiteConfigThunk { get; set; }

        public IAsyncResult BeginUpdateSiteConfig(string subscriptionName, string webspaceName, string name, SiteConfig siteConfig, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionName"] = subscriptionName;
            result.Values["webspaceName"] = webspaceName;
            result.Values["name"] = name;
            result.Values["siteConfig"] = siteConfig;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndUpdateSiteConfig(IAsyncResult asyncResult)
        {
            if (UpdateSiteConfigThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                UpdateSiteConfigThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("UpdateSiteConfigThunk is not implemented!");
            }
        }

        #endregion

        #region GetPublishingUsers

        public Func<SimpleServiceManagementAsyncResult, string[]> GetSubscriptionPublishingUsersThunk { get; set; }

        public IAsyncResult BeginGetSubscriptionPublishingUsers(string subscriptionName, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionName"] = subscriptionName;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public string[] EndGetSubscriptionPublishingUsers(IAsyncResult asyncResult)
        {
            if (GetSubscriptionPublishingUsersThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                return GetSubscriptionPublishingUsersThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetSubscriptionPublishingUsersThunk is not implemented!");
            }

            return default(string[]);
        }

        #endregion

        #region CreateWebsiteRepository

        public Action<SimpleServiceManagementAsyncResult> CreateSiteRepositoryThunk { get; set; }

        public IAsyncResult BeginCreateSiteRepository(string subscriptionName, string webspaceName, string name, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionName"] = subscriptionName;
            result.Values["webspaceName"] = webspaceName;
            result.Values["name"] = name;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public void EndCreateSiteRepository(IAsyncResult asyncResult)
        {
            if (CreateSiteRepositoryThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                CreateSiteRepositoryThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("CreateSiteRepositoryThunk is not implemented!");
            }
        }

        #endregion

        #region GetSite

        public Func<SimpleServiceManagementAsyncResult, Site> GetSiteThunk { get; set; }

        public IAsyncResult BeginGetSite(string subscriptionName, string webspaceName, string name, string propertiesToInclude, AsyncCallback callback, object state)
        {
            SimpleServiceManagementAsyncResult result = new SimpleServiceManagementAsyncResult();
            result.Values["subscriptionName"] = subscriptionName;
            result.Values["webspaceName"] = webspaceName;
            result.Values["name"] = name;
            result.Values["propertiesToInclude"] = propertiesToInclude;
            result.Values["callback"] = callback;
            result.Values["state"] = state;
            return result;
        }

        public Site EndGetSite(IAsyncResult asyncResult)
        {
            if (GetSiteThunk != null)
            {
                SimpleServiceManagementAsyncResult result = asyncResult as SimpleServiceManagementAsyncResult;
                Assert.IsNotNull(result, "asyncResult was not SimpleServiceManagementAsyncResult!");

                return GetSiteThunk(result);
            }
            else if (ThrowsIfNotImplemented)
            {
                throw new NotImplementedException("GetSiteThunk is not implemented!");
            }

            return default(Site);
        }

        #endregion

        #endregion

        public IAsyncResult BeginGetWebSpace(string subscriptionName, string name, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public WebSpace EndGetWebSpace(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginCreateWebSpace(string subscriptionName, bool allowPendingState, WebSpace webSpace, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public WebSpace EndCreateWebSpace(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginUpdateWebSpace(string subscriptionName, string name, bool allowPendingState, WebSpace webSpace, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public WebSpace EndUpdateWebSpace(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginDeleteWebSpace(string subscriptionName, string name, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndDeleteWebSpace(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginGetSiteRepositoryUri(string subscriptionName, string webspaceName, string name, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public Uri EndGetSiteRepositoryUri(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginDeleteSiteRepository(string subscriptionName, string webspaceName, string name, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndDeleteSiteRepository(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginCreateDevSite(string subscriptionName, string webspaceName, string name, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndCreateDevSite(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginGetDevSite(string subscriptionName, string webspaceName, string name, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public SiteRepositoryDev EndGetDevSite(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginUpdateDevSite(string subscriptionName, string webspaceName, string name, SiteRepositoryDev repositoryDevSite, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndUpdateDevSite(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginDeleteDevSite(string subscriptionName, string webspaceName, string name, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndDeleteDevSite(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }


        public IAsyncResult BeginGetRegions(bool listOnlyOnline, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public GeoRegions EndGetRegions(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginGetLocations(string regionName, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public GeoLocations EndGetLocations(IAsyncResult asyncResult)
        {
            throw new NotImplementedException();
        }
    }
}

