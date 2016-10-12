# Using Microsoft.Rest.ClientRuntime.Azure.TestFramework #

1. Getting Started (Another PR that reflects these changes)
2. Accquring TestFramework
3. Setup prior to Record/Playback tests
	1. Environment Variables
	2. Connection string
	3. Defaults
4. Record/Playback tests
	1. Playback Tests
	2. Record tests using interactive login (using orgId)
	3. Record tests using Service Principal
5. Change Test Environment settings at run-time


## 1. Getting Started  (Another PR that reflects these changes)
1. Launch .\tools\PS-VSPrompt shortcut
	1. This starts VS Dev command prompt in PowerShell
2. Import module that helps in performing basic repository tasks
	1. Import-Module Repo-Tasks.psm1
	2. Type Get-Commands -Module Repo-Tasks to see list of cmdlets
	3. Get-Help <CommandName> to get help on individual commands.

## 2. Accquring TestFramework
Current Version: [1.4.0-preview](https://www.nuget.org/packages/Microsoft.Rest.ClientRuntime.Azure.TestFramework/1.4.0-preview)

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
#### Playback Test
1. The default mode is Playback mode, so no setting up of connection string is required.

#### Record Test with Interactive login using OrgId
	TEST_CSM_ORGID_AUTHENTICATION=SubsctiptionId={SubId};UserId={orgId};AADTenant={tenantId};Environment={env};HttpRecorderMode=Record;

#### Record Test with ServicePrincipal
	TEST_CSM_ORGID_AUTHENTICATION=SubsctiptionId={SubId};ServicePrincipal={clientId};ServicePrincipalSecret={clientSecret};AADTenant={tenantId};Environment={env};HttpRecorderMode=Record;

2. Run the test and make sure that you got a generated .json file that matches the test name in 	the bin folder under *SessionRecords folder
3. Copy SessionRecords folder inside the test project and add all *.json files in Visual Studio 	setting "Copy to Output Directory" property to "Copy if newer"
4. To assure that the records work fine, delete the connection string (default mode is Playback mode) OR change HttpRecorderMode within the connection string to "Playback"

## 5. Change Test Environment settings at run-time
#### 1. Once you set your connection string, you can add or update key/value settings

	Add new key/value pair
 	TestEnvironment.ConnectionString.KeyValuePairs.Add("Foo", "FooValue");

	Update Existing key/value pair
	TestEnvironment.ConnectionString.KeyValuePairs["keyName"]="new value"

	Accessing/Updating TestEndpoints
	TestEnvironment.Endpoints.GraphUri = new Uri("https://newGraphUri.windows.net");

###Note:###
Changing the above properties at run-time has the potential to hard code few things in your tests. Best practice would be to use these properties to change values at run-time from immediate window at run-time and avoid hard-coding certain values.