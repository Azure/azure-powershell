# Using Microsoft.Rest.ClientRuntime.Azure.TestFramework #

- [Getting Started](#getting-started)
- [Acquiring TestFramework](#acquiring-testframework)
- [Setup prior to Record/Playback tests](#setup-prior-to-record-or-playback-of-tests)
	- [New-TestCredential](#new-testcredential)
		- [Create New Service Principal](#create-new-service-principal)
		- [Use Existing Service Principal](#use-existing-service-principal)
	- [Set-TestEnvironment](#set-testenvironment)
		- [Existing Service Principal](#existing-service-principal)
	- [Manually Set Environment Variables](#manually-set-environment-variables)
		- [Environment Variables](#environment-variables)
		- [Playback Test](#playback-test)
		- [Record Test with Interactive login using OrgId](#record-test-with-interactive-login-using-orgid)
		- [Record Test with ServicePrincipal](#record-test-with-serviceprincipal)
- [Record/Playback tests](#record-or-playback-tests)
- [Change Test Environment settings at run-time](#change-test-environment-settings-at-run-time)
- [Troubleshooting](#troubleshooting)
- [Supported Key Value pairs in ConnectionString](#supported-key-value-pairs-in-connectionstring)
- [Environment Variable Reference](#supported-environment-in-test-framework)

## Getting Started
-  Double click `.\tools\PS-VSPrompt` shortcut
	- This starts the VS Developer command prompt in PowerShell inside the `azure-powershell/tools` directory
- Import the `Repo-Tasks` module that helps to perform basic repository tasks
	- Run the command `Import-Module .\Repo-Tasks.psd1`

## Acquiring TestFramework

The `TestFramework` library is available on NuGet at https://www.nuget.org/packages/Microsoft.Rest.ClientRuntime.Azure.TestFramework/ .

Instructions on manually downloading the library are available on NuGet, however, `TestFramework` will automatically be downloaded as part of the build process, so the manual download is usually not necessary.

## Setup prior to Record or Playback of tests

In order to Record/Playback a test, you need to setup a connection string that consists of various key/value pairs that provide information to the test environment.  

You have three options to set up the connection string: 
- Run the [`New-TestCredential` cmdlet](#new-testcredential) (recommended for PowerShell development)
- Run the [`Set-TestEnvironment` cmdlet](#set-testenvironment)
- [Manually set the environment variables](#manually-set-environment-variables).

### New-TestCredential

This cmdlet, located in the [`Repo-Tasks` module](/tools/Repo-Tasks.psd1), which pulls in the [`TestFx-Tasks` module](/tools/Modules/TestFx-Tasks.psd1) and [`Build-Tasks` module](/tools/Modules/Build-Tasks.psd1), will allow you to create a credentials file (located in `C:/Users/\<currentuser\>/.azure/testcredentials.json`) that will be used to set the environment variable when scenario tests are run. This credentials file will be used in all future sessions unless it is deleted or the environment variables are manually set.  This cmdlet is not currently available for .NET SDK development.

#### Create New Service Principal

Using a service principal is the preferred option for recording tests because it works with both .NET Framework and .NET Core.  In order to create a new service principal, run this command with an unused service principal display name:

```powershell
New-TestCredential -ServicePrincipalDisplayName "ScenarioTestCredentials" -SubscriptionId `
<subscriptionId> -TenantId <tenantId> -RecordMode "Record"
```

This command will create a new service principal, set the correct role assignment for this service principal based upon the subscription provided, and place the service principal id and automatically generated secret into the credentials file.

Alternatively, to create a service principal, follow the [Azure AD guide to create a Application Service Principal](https://learn.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal#create-an-active-directory-application). The application type should be `Web app / API` and the sign-on URL value is irrelevant (you can set any value).

#### Use Existing Service Principal

If you would like to use an existing service principal, run this command with an existing service principal display name and secret:

```powershell
New-TestCredential -ServicePrincipalDisplayName "Existing Service Principal" -ServicePrincipalSecret `
"testpassword" -SubscriptionId <subscriptionId> -TenantId <tenantId> -RecordMode "Record"
```

### Set-TestEnvironment

This cmdlet, located in the [`Repo-Tasks` module](/tools/Repo-Tasks.psd1), will directly set the environment variable for the session.

#### Existing Service Principal

This is the preferred option for recording tests because it works with both .NET Framework and .NET Core.

```powershell
Set-TestEnvironment -ServicePrincipalId <servicePrincipalId> -ServicePrincipalSecret `
"testpassword" -SubscriptionId <subscriptionId> -TenantId <tenantId> -RecordMode "Record"
```

### Manually Set Environment Variables

#### Environment Variables

`TEST_CSM_ORGID_AUTHENTICATION`
* This is the connection string that determines how to connect to Azure. This includes both your authentiation and the Azure environment to connect to.

`AZURE_TEST_MODE`
* This specifies whether the test framework will `Record` test sessions or `Playback` previously recorded test sessions.

#### Playback Test

The default test mode is `Playback` mode, so setting up the connection string is not required. You can optionally set environment variables:

```
TEST_CSM_ORGID_AUTHENTICATION=
AZURE_TEST_MODE=Playback
```

#### Record Test with service principal

After the service principal is created, you will need to give it access to Azure resources. This can be done with the following PowerShell command, with the [Service Principal Application ID](https://learn.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal#get-application-id-and-authentication-key) (this is a guid, not the display name of the service principal) substituted in for `{clientId}`.

```powershell
New-AzRoleAssignment -ServicePrincipalName {clientId} -RoleDefinitionName Contributor
```

To use this option, set the following environment variable before starting Visual Studio. The following values are substituted into the below connection string:

`clientId`
* The [Service Principal Application ID](https://learn.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal#get-application-id-and-authentication-key)

`clientSecret`
* A [Service Principal Authentication Key](https://learn.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal#get-application-id-and-authentication-key)

`tenantId`
* The [AAD Tenant ID](https://learn.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal#get-tenant-id)

```
TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId={SubId};ServicePrincipal={clientId};ServicePrincipalSecret={clientSecret};AADTenant={tenantId};Environment={env};HttpRecorderMode=Record;
AZURE_TEST_MODE=Record
```

## Record or Playback Tests

- [Run the tests](https://github.com/Azure/azure-powershell/blob/master/documentation/development-docs/azure-powershell-developer-guide.md#recordingrunning-tests) and make sure that you got a generated `.json` file that matches the test name in the bin folder under the `SessionRecords` folder
- Copy the `SessionRecords` folder inside the test project and add all `*.json` files in Visual Studio setting "Copy to Output Directory" property to "Copy if newer"
- To assure that the records work fine, delete the connection string (default mode is Playback mode) OR change HttpRecorderMode within the connection string to "Playback" and run the tests

## Change Test Environment settings at run-time

#### Once you set your connection string, you can add or update key/value settings

```
Add new key/value pair
TestEnvironment.ConnectionString.KeyValuePairs.Add("Foo", "FooValue");

Update Existing key/value pair
TestEnvironment.ConnectionString.KeyValuePairs["keyName"]="new value"

Accessing/Updating TestEndpoints
TestEnvironment.Endpoints.GraphUri = new Uri("https://newGraphUri.windows.net");
```

### Note:
Changing the above properties at run-time has the potential to hard code few things in your tests. Best practice would be to use these properties to change values at run-time from immediate window at run-time and avoid hard-coding certain values.

## Troubleshooting

#### Issue: exceptions in Microsoft.Azure.Test.HttpRecorder

Ensure that the `HttpRecorderMode` in the `TEST_CSM_ORGID_AUTHENTICATION` environment variable is consistent with the value in `AZURE_TEST_MODE` environment variable.

## Supported Environments in Test Framework

#### Default Environments and associated Uri

##### Environment = Prod

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

##### Environment = Dogfood

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

##### Environment = Next

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

##### Environment = Current

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

##### Environment = Custom
When specified, test framework expect all Uri's to be provided by the user as part of the connection string.

What is also supported is as below (connections string example)
`SubscriptionId=subId;Environment=Prod;AADAuthUri=customAuthUri;ResourceManagementUri=CustomResourceMgmtUri`

Which translates to, all Uri from pre-defined Prod environment will be used, but AADAuthUri and ResourceManagementUri will be overridden by the one provided in the connection string
