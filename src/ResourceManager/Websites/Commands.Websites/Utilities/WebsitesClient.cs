﻿// ----------------------------------------------------------------------------------
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
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Threading;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Commands;
using Microsoft.Azure.Management.WebSites;
using System.Net;
using Hyak.Common;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Management.WebSites.Models;

namespace Microsoft.Azure.Commands.Websites.Utilities
{
    public class WebsitesClient
    {
        public Action<string> VerboseLogger { get; set; }

        public WebsitesClient(AzureContext context)
        {
            this.WrappedWebsitesClient = AzureSession.ClientFactory.CreateClient<WebSiteManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);

        }
        public WebSiteManagementClient WrappedWebsitesClient
        {
            get;
            private set;
        }


        public WebSite CreateWebsite(string resourceGroupName, string webSiteName, string slotName, string location, string webHostingPlan)
        {
            var createdWebSite = WrappedWebsitesClient.WebSites.CreateOrUpdate(
                        resourceGroupName, webSiteName, slotName,
                        new WebSiteCreateOrUpdateParameters
                        {
                            WebSite = new WebSiteBase
                            {
                                Name = webSiteName,
                                Location = location,
                                Properties = new WebSiteBaseProperties(webHostingPlan)
                            }
                        });
           // VerboseLogger(string.Format("Created website '{0}' in resource group '{1}' at location '{2}'", webSiteName, resourceGroupName, location));

            return createdWebSite.WebSite;
        }

        public System.Net.HttpStatusCode StartWebsite(string resourceGroupName, string webSiteName, string slotName)
        {
                 var startedWebsite =  WrappedWebsitesClient.WebSites.Start(resourceGroupName, webSiteName, slotName);
                 return startedWebsite.StatusCode;
        }
        public System.Net.HttpStatusCode StopWebsite(string resourceGroupName, string webSiteName, string slotName)
        {
            var stoppedWebsite = WrappedWebsitesClient.WebSites.Stop(resourceGroupName, webSiteName, slotName);
            return stoppedWebsite.StatusCode;
        }
        public System.Net.HttpStatusCode RestartWebsite(string resourceGroupName, string webSiteName, string slotName)
        {
            var restartedWebsite = WrappedWebsitesClient.WebSites.Restart(resourceGroupName, webSiteName, slotName);
            return restartedWebsite.StatusCode;
        }

        public System.Net.HttpStatusCode RemoveWebsite(string resourceGroupName, string webSiteName, string slotName, bool deleteEmptyServerFarmBydefault, bool deleteMetricsBydefault, bool deleteSlotsBydefault)
        {
            WebSiteDeleteParameters webSiteDelParams = new WebSiteDeleteParameters(deleteEmptyServerFarmBydefault, deleteMetricsBydefault, deleteSlotsBydefault);
            
            var removedWebsite = WrappedWebsitesClient.WebSites.Delete(resourceGroupName, webSiteName, slotName, webSiteDelParams);
            return removedWebsite.StatusCode;
        }

        public WebSite GetWebsite(string resourceGroupName, string webSiteName, string slotName)
        {
            WebSiteGetParameters webSiteGetParams = new WebSiteGetParameters();

            var getWebsite = WrappedWebsitesClient.WebSites.Get(resourceGroupName, webSiteName, slotName, webSiteGetParams);
            return getWebsite.WebSite;
        }


        public WebHostingPlanCreateOrUpdateResponse CreateWebHostingPlan(string resourceGroupName, string whpName, string location, string adminSiteName, int numberOfWorkers, SkuOptions sku, WorkerSizeOptions workerSize)
        {


            WebHostingPlanProperties webHostingPlanProperties = new WebHostingPlanProperties();
            webHostingPlanProperties.Sku = sku;
            webHostingPlanProperties.AdminSiteName = adminSiteName;
            webHostingPlanProperties.NumberOfWorkers = numberOfWorkers;
            webHostingPlanProperties.WorkerSize = workerSize;

            WebHostingPlan webHostingPlan = new WebHostingPlan();
            
            WebHostingPlanCreateOrUpdateParameters webHostingPlanCreateOrUpdateParameters = new WebHostingPlanCreateOrUpdateParameters(webHostingPlan);
            webHostingPlanCreateOrUpdateParameters.WebHostingPlan.Location = location;
            webHostingPlanCreateOrUpdateParameters.WebHostingPlan.Name = whpName;
            webHostingPlanCreateOrUpdateParameters.WebHostingPlan.Properties = webHostingPlanProperties;

            var createdWHP = WrappedWebsitesClient.WebHostingPlans.CreateOrUpdate(resourceGroupName, webHostingPlanCreateOrUpdateParameters);

            //proper return type need to be discussed
            return createdWHP;
        }

        public AzureOperationResponse RemoveWebHostingPlan(string resourceGroupName, string whpName)
        {

            var response = WrappedWebsitesClient.WebHostingPlans.Delete(resourceGroupName, whpName);

            //proper return type need to be discussed
            return response;
        }

        public WebHostingPlanGetResponse GetWebHostingPlan(string resourceGroupName, string whpName)
        {

            var response = WrappedWebsitesClient.WebHostingPlans.Get(resourceGroupName, whpName);

            //proper return type need to be discussed
            return response;
        }

        public WebHostingPlanListResponse ListWebHostingPlan(string resourceGroupName)
        {
        
            var response = WrappedWebsitesClient.WebHostingPlans.List(resourceGroupName);

            //proper return type need to be discussed
            return response;
        }
    }
}
