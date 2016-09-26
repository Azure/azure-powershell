# Using Microsoft.Rest.ClientRuntime.Azure.TestFramework #

1. TestFramework version to use
2. Accquring TestFramework
3. Setup prior to Record/Playback tests
	1. Environment Variables
	2. Connection string
	3. Defaults
4. Record/Playback tests
5. Change Test Environment settings at run-time


## 1. TestFramework version to use
Current Version: [1.4.0-preview](https://www.nuget.org/packages/Microsoft.Rest.ClientRuntime.Azure.TestFramework/1.4.0-preview)

## 2. Accquring TestFramework
Nuget command to install current version

    Install-Package Microsoft.Rest.ClientRuntime.Azure.TestFramework -v 1.4.0-preview -Pre

## 3. Setup prior to Record/Playback of tests
In order to Record/Playback a test, you need to setup a connection string that consists various key/value pairs that provides information to the test environment.

#### 3.1 Environment Variables
> TEST_CSM_ORGID_AUTHENTICATION

> AZURE_TEST_MODE

    e.g.	
    TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId=<valid SubscriptionId>;ServicePrincipal=<ClientId>;ServicePrincipalSecret=<Client Secret>;AADTenant=<tenantId>;Environment=Prod;BaseUri=https://management.azure.com/;AADAuthEndpoint=https://login.windows.net/;GraphUri=https://graph.windows.net/

	AZURE_TEST_MODE=Record

#### 3.2.  Supported Keys in connection string
	* ManagementCertificate
	* SubscriptionId
	* AADTenant
	* UserId
	* Password
	* ServicePrincipal
	* ServicePrincipalSecret
	* Environment={Prod | DogFood | Next | Current}
	* RawToken
	* RawGraphToken
	* HttpRecorderMode={Record | Playback}
	* AADTokenAudienceUri
	* BaseUri
	* GraphUri
	* GalleryUri
	* IbizaProtalUri
	* DataLakeStoreServiceUri
	* DataLakeAnalyticsJobAndCatalogServiceUri
	* AADAuthEndpoint
	* GraphTokenAudienceUri

#### 3.3. Existing Defaults
	 Environment.Prod
		AADAuthUri = "https://login.microsoftonline.com"
	    GalleryUri = "https://gallery.azure.com/"
	    GraphUri = "https://graph.windows.net/"
	    IbizaPortalUri = "https://portal.azure.com/"
	    RdfePortalUri = "http://go.microsoft.com/fwlink/?LinkId=254433"
	    ResourceManagementUri = "https://management.azure.com/"
	    ServiceManagementUri = "https://management.core.windows.net"
	    AADTokenAudienceUri = "https://management.core.windows.net"
	    GraphTokenAudienceUri = "https://graph.windows.net/"
	    DataLakeStoreServiceUri = "https://azuredatalakestore.net"
	    DataLakeAnalyticsJobAndCatalogServiceUri = "https://azuredatalakeanalytics.net"

----------

	Environment.Dogfood
		AADAuthUri = "https://login.windows-ppe.net";
        GalleryUri = "https://df.gallery.azure-test.net/";
        GraphUri = "https://graph.ppe.windows.net/";
        IbizaPortalUri = "http://df.onecloud.azure-test.net";
        RdfePortalUri = "https://windows.azure-test.net";
        ResourceManagementUri = "https://api-dogfood.resources.windows-int.net/";
        ServiceManagementUri = "https://management-preview.core.windows-int.net";
        AADTokenAudienceUri = "https://management.core.windows.net";
        GraphTokenAudienceUri = "https://graph.ppe.windows.net/";
        DataLakeStoreServiceUri = "https://caboaccountdogfood.net";
        DataLakeAnalyticsJobAndCatalogServiceUri = "https://konaaccountdogfood.net";

----------

	Environment.Next
		AADAuthUri = "https://login.windows-ppe.net"
        GalleryUri = "https://next.gallery.azure-test.net/"
        GraphUri = "https://graph.ppe.windows.net/"
        IbizaPortalUri = "http://next.onecloud.azure-test.net"
        RdfePortalUri = "https://auxnext.windows.azure-test.net"
        ResourceManagementUri = "https://api-next.resources.windows-int.net/"
        ServiceManagementUri = "https://managementnext.rdfetest.dnsdemo4.com"
        AADTokenAudienceUri = "https://management.core.windows.net"
        GraphTokenAudienceUri = "https://graph.ppe.windows.net/"
        DataLakeStoreServiceUri = "https://caboaccountdogfood.net"
        DataLakeAnalyticsJobAndCatalogServiceUri = "https://konaaccountdogfood.net"

----------

	Environment.Current
		AADAuthUri = "https://login.windows-ppe.net"
        GalleryUri = "https://df.gallery.azure-test.net/"
        GraphUri = "https://graph.ppe.windows.net/"
        IbizaPortalUri = "http://df.onecloud.azure-test.net"
        RdfePortalUri = "https://windows.azure-test.net"
        ResourceManagementUri = "https://api-dogfood.resources.windows-int.net/"
        ServiceManagementUri = "https://management-preview.core.windows-int.net"
        AADTokenAudienceUri = "https://management.core.windows.net"
        GraphTokenAudienceUri = "https://graph.ppe.windows.net/"
        DataLakeStoreServiceUri = "https://caboaccountdogfood.net"
        DataLakeAnalyticsJoAbndCatalogServiceUri = "https://konaaccountdogfood.net"

## 4. Record/Playback Test
1. Make sure HttpRecorderMode=Record in connection string or set environment variable AZURE_TEST_MODE=Record
2. Run the test and make sure that you got a generated .json file that matches the test name in 	the bin folder under *SessionRecords folder
3. Copy SessionRecords folder inside the test project and add all *.json files in Visual Studio 	setting "Copy to Output Directory" property to "Copy if newer"
4. To assure that the records work fine, change AZURE_TEST_MODE to Playback and run the test which 	should be run mocked not live.

## 5. Change Test Environment settings at run-time
#### 1. Once you set your connection string, you can add or update key/value settings

	Add new key/value pair
 	TestEnvironment.ConnectionString.KeyValuePairs.Add("Foo", "FooValue");

	Update Existing key/value pair
	TestEnvironment.ConnectionString.KeyValuePairs["keyName"]="new value"

	Accessing/Updating TestEndpoints
	TestEnvironment.Endpoints.GraphUri = new Uri("https://newGraphUri.windows.net");
