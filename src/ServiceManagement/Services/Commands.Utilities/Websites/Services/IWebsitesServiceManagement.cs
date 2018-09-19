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
using System.Xml.Serialization;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.GeoEntities;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services
{
    [XmlRoot(ElementName = "Error", Namespace = UriElements.ServiceNamespace)]
    public class ServiceError
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string ExtendedCode { get; set; }
        public string MessageTemplate { get; set; }

        [XmlArray("Parameters")]
        [XmlArrayItem(typeof(string), Namespace="http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public List<string> Parameters { get; set; }
    }

    /// <summary>
    /// Provides the Microsoft Azure Service Management Api for Microsoft Azure Websites. 
    /// </summary>
    [ServiceContract(Namespace = UriElements.ServiceNamespace)]
    [ServiceKnownType(typeof(SiteWithWebSpace))]
    public interface IWebsitesServiceManagement
    {
        [Description("Gets all webspaces for subscription")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = UriElements.WebSpacesRoot + "/")]
        IAsyncResult BeginGetWebSpaces(string subscriptionName, AsyncCallback callback, object state);
        WebSpaces EndGetWebSpaces(IAsyncResult asyncResult);

        [Description("Gets all webspaces for subscription")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = UriElements.WebSpacesRoot + UriElements.NameTemplateParameter)]
        IAsyncResult BeginGetWebSpace(string subscriptionName, string name, AsyncCallback callback, object state);
        WebSpace EndGetWebSpace(IAsyncResult asyncResult);

        [Description("Creates a new webspace")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(UriTemplate = UriElements.WebSpacesRoot + UriElements.AllowPendingStateParameter, Method = "POST")]
        IAsyncResult BeginCreateWebSpace(string subscriptionName, bool allowPendingState, WebSpace webSpace, AsyncCallback callback, object state);
        WebSpace EndCreateWebSpace(IAsyncResult asyncResult);

        [Description("Updates an existing webspace")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(UriTemplate = UriElements.WebSpacesRoot + UriElements.NameTemplateParameter + UriElements.AllowPendingStateParameter, Method = "PUT")]
        IAsyncResult BeginUpdateWebSpace(string subscriptionName, string name, bool allowPendingState, WebSpace webSpace, AsyncCallback callback, object state);
        WebSpace EndUpdateWebSpace(IAsyncResult asyncResult);

        [Description("Deletes a webspace")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(UriTemplate = UriElements.WebSpacesRoot + UriElements.NameTemplateParameter, Method = "DELETE")]
        IAsyncResult BeginDeleteWebSpace(string subscriptionName, string name, AsyncCallback callback, object state);
        void EndDeleteWebSpace(IAsyncResult asyncResult);

        [Description("Gets all publishing users for subscription")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = UriElements.SubscriptionPublishingUsers)]
        IAsyncResult BeginGetSubscriptionPublishingUsers(string subscriptionName,  AsyncCallback callback, object state);
        string[] EndGetSubscriptionPublishingUsers(IAsyncResult asyncResult);

        #region Site CRUD

        [Description("Returns all the sites for a given subscription and webspace.")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = UriElements.WebSitesRoot + UriElements.PropertiesToIncludeParameter)]
        IAsyncResult BeginGetSites(string subscriptionName, string webspaceName, string propertiesToInclude, AsyncCallback callback, object state);
        Sites EndGetSites(IAsyncResult asyncResult);

        [Description("Returns the details of a particular site.")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = UriElements.WebSitesRoot + UriElements.NameTemplateParameter + UriElements.PropertiesToIncludeParameter)]
        IAsyncResult BeginGetSite(string subscriptionName, string webspaceName, string name, string propertiesToInclude, AsyncCallback callback, object state);
        Site EndGetSite(IAsyncResult asyncResult);

        [Description("Adds a new site")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(UriTemplate = UriElements.WebSitesRoot, Method = "POST")]
        IAsyncResult BeginCreateSite(string subscriptionName, string webspaceName, Site site, AsyncCallback callback, object state);
        Site EndCreateSite(IAsyncResult asyncResult);

        [Description("Updates an existing site")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(UriTemplate = UriElements.WebSitesRoot + UriElements.NameTemplateParameter, Method = "PUT")]
        IAsyncResult BeginUpdateSite(string subscriptionName, string webspaceName, string name, Site site, AsyncCallback callback, object state);
        void EndUpdateSite(IAsyncResult asyncResult);

        [Description("Deletes an existing site.")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(UriTemplate = UriElements.WebSitesRoot + UriElements.NameTemplateParameter + UriElements.DeleteMetricsParameter, Method = "DELETE")]
        IAsyncResult BeginDeleteSite(string subscriptionName, string webspaceName, string name, string deleteMetrics, AsyncCallback callback, object state);
        void EndDeleteSite(IAsyncResult asyncResult);

        #endregion

        #region Site configuration settings

        [Description("Gets site's configuration settings")]
        [WebInvoke(Method = "GET", UriTemplate = UriElements.WebSiteConfig)]
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginGetSiteConfig(string subscriptionName, string webspaceName, string name, AsyncCallback callback, object state);
        SiteConfig EndGetSiteConfig(IAsyncResult asyncResult);

        [Description("Updates site's configuration settings")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(UriTemplate = UriElements.WebSiteConfig, Method = "PUT")]
        IAsyncResult BeginUpdateSiteConfig(string subscriptionName, string webspaceName, string name, SiteConfig siteConfig, AsyncCallback callback, object state);
        void EndUpdateSiteConfig(IAsyncResult asyncResult);

        #endregion

        #region Repository methods

        [Description("Creates a repository for a site")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(UriTemplate = UriElements.WebSiteRepository, Method = "POST")]
        IAsyncResult BeginCreateSiteRepository(string subscriptionName, string webspaceName, string name, AsyncCallback callback, object state);
        void EndCreateSiteRepository(IAsyncResult asyncResult);

        [Description("Gets a site's repository URI")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = UriElements.WebSiteRepository)]
        IAsyncResult BeginGetSiteRepositoryUri(string subscriptionName, string webspaceName, string name, AsyncCallback callback, object state);
        Uri EndGetSiteRepositoryUri(IAsyncResult asyncResult);

        [Description("Deletes a site's repository")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(UriTemplate = UriElements.WebSiteRepository, Method = "DELETE")]
        IAsyncResult BeginDeleteSiteRepository(string subscriptionName, string webspaceName, string name, AsyncCallback callback, object state);
        void EndDeleteSiteRepository(IAsyncResult asyncResult);

        [Description("Creates a development site in a site's repository")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(UriTemplate = UriElements.WebSiteRepositoryDev, Method = "POST")]
        IAsyncResult BeginCreateDevSite(string subscriptionName, string webspaceName, string name, AsyncCallback callback, object state);
        void EndCreateDevSite(IAsyncResult asyncResult);

        [Description("Gets a development site in a site's repository")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(Method = "GET", UriTemplate = UriElements.WebSiteRepositoryDev)]
        IAsyncResult BeginGetDevSite(string subscriptionName, string webspaceName, string name, AsyncCallback callback, object state);
        SiteRepositoryDev EndGetDevSite(IAsyncResult asyncResult);

        [Description("Updates a development site in a site's repository")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(UriTemplate = UriElements.WebSiteRepositoryDev, Method = "PUT")]
        IAsyncResult BeginUpdateDevSite(string subscriptionName, string webspaceName, string name, SiteRepositoryDev repositoryDevSite, AsyncCallback callback, object state);
        void EndUpdateDevSite(IAsyncResult asyncResult);

        [Description("Deletes a development site in a site's repository")]
        [OperationContract(AsyncPattern = true)]
        [WebInvoke(UriTemplate = UriElements.WebSiteRepositoryDev, Method = "DELETE")]
        IAsyncResult BeginDeleteDevSite(string subscriptionName, string webspaceName, string name, AsyncCallback callback, object state);
        void EndDeleteDevSite(IAsyncResult asyncResult);

        #endregion

        #region Region methods

        [Description("Returns all the geo regions.")]
        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = UriElements.GeoRegionsRoot + UriElements.ListOnlyOnlineStampsParameter)]
        IAsyncResult BeginGetRegions(bool listOnlyOnline, AsyncCallback callback, object state);
        GeoRegions EndGetRegions(IAsyncResult asyncResult);

        [Description("Returns all the geo locations.")]
        [OperationContract(AsyncPattern = true)]
        [WebGet(UriTemplate = UriElements.GeoLocationsRoot)]
        IAsyncResult BeginGetLocations(string regionName, AsyncCallback callback, object state);
        GeoLocations EndGetLocations(IAsyncResult asyncResult);

        #endregion
    }
}
