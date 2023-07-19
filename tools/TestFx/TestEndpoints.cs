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

namespace Microsoft.Azure.Commands.TestFx
{
    public class TestEndpoints
    {
        public TestEnvironmentName Name { get; set; }

        public Uri ServiceManagementUri { get; set; }

        public Uri ResourceManagementUri { get; set; }

        public Uri AADAuthUri { get; set; }

        public Uri AADTokenAudienceUri { get; set; }

        public Uri GraphUri { get; set; }

        public Uri GraphTokenAudienceUri { get; set; }

        public Uri GalleryUri { get; set; }

        public Uri RdfePortalUri { get; set; }

        public Uri IbizaPortalUri { get; set; }

        public Uri DataLakeStoreServiceUri { get; set; }

        public Uri DataLakeAnalyticsJobAndCatalogServiceUri { get; set; }

        public Uri PublishingSettingsFileUri { get; set; }

        private TestEndpoints()
        {

        }

        internal TestEndpoints(TestEndpoints testEndpoint, ConnectionString connStr) : this(testEndpoint)
        {
            UpdateEnvironmentEndpoint(connStr);
        }

        private void UpdateEnvironmentEndpoint(ConnectionString connStr)
        {
            if (connStr.HasNonEmptyValue(ConnectionStringKeys.AADTokenAudienceUriKey))
            {
                AADTokenAudienceUri = new Uri(connStr.GetValue(ConnectionStringKeys.AADTokenAudienceUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.GraphTokenAudienceUriKey))
            {
                GraphTokenAudienceUri = new Uri(connStr.GetValue(ConnectionStringKeys.GraphTokenAudienceUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.GraphUriKey))
            {
                GraphUri = new Uri(connStr.GetValue(ConnectionStringKeys.GraphUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.GalleryUriKey))
            {
                GalleryUri = new Uri(connStr.GetValue(ConnectionStringKeys.GalleryUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.IbizaPortalUriKey))
            {
                IbizaPortalUri = new Uri(connStr.GetValue(ConnectionStringKeys.IbizaPortalUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.RdfePortalUriKey))
            {
                RdfePortalUri = new Uri(connStr.GetValue(ConnectionStringKeys.RdfePortalUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.DataLakeStoreServiceUriKey))
            {
                DataLakeStoreServiceUri = new Uri(connStr.GetValue(ConnectionStringKeys.DataLakeStoreServiceUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.DataLakeAnalyticsJobAndCatalogServiceUriKey))
            {
                DataLakeAnalyticsJobAndCatalogServiceUri = new Uri(connStr.GetValue(ConnectionStringKeys.DataLakeAnalyticsJobAndCatalogServiceUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.AADAuthUriKey))
            {
                AADAuthUri = new Uri(connStr.GetValue(ConnectionStringKeys.AADAuthUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.PublishSettingsFileUriKey))
            {
                PublishingSettingsFileUri = new Uri(connStr.GetValue(ConnectionStringKeys.PublishSettingsFileUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.ServiceManagementUriKey))
            {
                ServiceManagementUri = new Uri(connStr.GetValue(ConnectionStringKeys.ServiceManagementUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.ResourceManagementUriKey))
            {
                ResourceManagementUri = new Uri(connStr.GetValue(ConnectionStringKeys.ResourceManagementUriKey));
            }
        }

        internal TestEndpoints(TestEnvironmentName testEnvNames)
        {
            string defaultAADTokenAudienceUri = "https://management.core.windows.net/";
            string defaultGraphTokenAudienceUri = "https://graph.windows.net/";
            string defaultPPEGraphTokenAudienceUri = "https://graph.ppe.windows.net/";

            switch (testEnvNames)
            {
                case TestEnvironmentName.Prod:
                    Name = TestEnvironmentName.Prod;
                    GraphUri = new Uri("https://graph.windows.net/");
                    AADAuthUri = new Uri("https://login.microsoftonline.com/");
                    IbizaPortalUri = new Uri("https://portal.azure.com/");
                    RdfePortalUri = new Uri("https://manage.windowsazure.com/");
                    ResourceManagementUri = new Uri("https://management.azure.com/");
                    ServiceManagementUri = new Uri("https://management.core.windows.net");
                    AADTokenAudienceUri = new Uri(defaultAADTokenAudienceUri);
                    GraphTokenAudienceUri = new Uri(defaultGraphTokenAudienceUri);
                    DataLakeStoreServiceUri = new Uri("https://azuredatalakestore.net");
                    DataLakeAnalyticsJobAndCatalogServiceUri = new Uri("https://azuredatalakeanalytics.net");
                    break;
                case TestEnvironmentName.Dogfood:
                    Name = TestEnvironmentName.Dogfood;
                    GraphUri = new Uri("https://graph.ppe.windows.net/");
                    AADAuthUri = new Uri("https://login.windows-ppe.net");
                    IbizaPortalUri = new Uri("http://df.onecloud.azure-test.net");
                    RdfePortalUri = new Uri("https://windows.azure-test.net");
                    ResourceManagementUri = new Uri("https://api-dogfood.resources.windows-int.net/");
                    ServiceManagementUri = new Uri("https://management-preview.core.windows-int.net");
                    AADTokenAudienceUri = new Uri(defaultAADTokenAudienceUri);
                    GraphTokenAudienceUri = new Uri(defaultPPEGraphTokenAudienceUri);
                    DataLakeStoreServiceUri = new Uri("https://caboaccountdogfood.net");
                    DataLakeAnalyticsJobAndCatalogServiceUri = new Uri("https://konaaccountdogfood.net");
                    break;
                case TestEnvironmentName.Next:
                    Name = TestEnvironmentName.Next;
                    AADAuthUri = new Uri("https://login.windows-ppe.net");
                    GraphUri = new Uri("https://graph.ppe.windows.net/");
                    IbizaPortalUri = new Uri("http://next.onecloud.azure-test.net");
                    RdfePortalUri = new Uri("https://auxnext.windows.azure-test.net");
                    ResourceManagementUri = new Uri("https://api-next.resources.windows-int.net/");
                    ServiceManagementUri = new Uri("https://managementnext.rdfetest.dnsdemo4.com");
                    AADTokenAudienceUri = new Uri(defaultAADTokenAudienceUri);
                    GraphTokenAudienceUri = new Uri(defaultPPEGraphTokenAudienceUri);
                    DataLakeStoreServiceUri = new Uri("https://caboaccountdogfood.net");
                    DataLakeAnalyticsJobAndCatalogServiceUri = new Uri("https://konaaccountdogfood.net");
                    break;
                case TestEnvironmentName.Current:
                    Name = TestEnvironmentName.Current;
                    AADAuthUri = new Uri("https://login.windows-ppe.net");
                    GraphUri = new Uri("https://graph.ppe.windows.net/");
                    IbizaPortalUri = new Uri("http://current.onecloud.azure-test.net");
                    RdfePortalUri = new Uri("https://auxcurrent.windows.azure-test.net");
                    ResourceManagementUri = new Uri("https://api-current.resources.windows-int.net/");
                    ServiceManagementUri = new Uri("https://management.rdfetest.dnsdemo4.com");
                    AADTokenAudienceUri = new Uri(defaultAADTokenAudienceUri);
                    GraphTokenAudienceUri = new Uri(defaultPPEGraphTokenAudienceUri);
                    DataLakeStoreServiceUri = new Uri("https://caboaccountdogfood.net");
                    DataLakeAnalyticsJobAndCatalogServiceUri = new Uri("https://konaaccountdogfood.net");
                    break;
                case TestEnvironmentName.Custom:
                    Name = TestEnvironmentName.Custom;
                    break;
            }
        }

        private TestEndpoints(TestEndpoints testEndpoint)
        {
            Name = testEndpoint.Name;
            GraphUri = testEndpoint.GraphUri;
            AADAuthUri = testEndpoint.AADAuthUri;
            GalleryUri = testEndpoint.GalleryUri;
            IbizaPortalUri = testEndpoint.IbizaPortalUri;
            RdfePortalUri = testEndpoint.RdfePortalUri;
            ResourceManagementUri = testEndpoint.ResourceManagementUri;
            ServiceManagementUri = testEndpoint.ServiceManagementUri;
            AADTokenAudienceUri = testEndpoint.AADTokenAudienceUri;
            GraphTokenAudienceUri = testEndpoint.GraphTokenAudienceUri;
            DataLakeStoreServiceUri = testEndpoint.DataLakeStoreServiceUri;
            DataLakeAnalyticsJobAndCatalogServiceUri = testEndpoint.DataLakeAnalyticsJobAndCatalogServiceUri;
            PublishingSettingsFileUri = testEndpoint.PublishingSettingsFileUri;
        }
    }
}
