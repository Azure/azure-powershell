# Using Azure PowerShell Test Framework

- [Using Microsoft.Rest.ClientRuntime.Azure.TestFramework](#using-microsoftrestclientruntimeazuretestframework)
  - [Getting Started](#getting-started)
  - [Azure PowerShell Test Framework](#azure-powershell-test-framework)
  - [Setup prior to Record or Playback of tests](#setup-prior-to-record-or-playback-of-tests)
    - [Run Command Set-TestFxEnvironment to Build Connection String (Recommended)](#run-command-set-testfxenvironment-to-build-connection-string-recommended)
      - [Create New Service Principal](#create-new-service-principal)
      - [Use Existing Service Principal](#use-existing-service-principal)
    - [Manually Set Environment Variables to Build Connection String](#manually-set-environment-variables-to-build-connection-string)
      - [Environment Variables](#environment-variables)
      - [Record Test with service principal](#record-test-with-service-principal)
      - [Playback Test](#playback-test)
  - [JSON Config File V.S. Environment Variables](#json-config-file-vs-environment-variables)
  - [Record or Playback Tests](#record-or-playback-tests)
  - [Change Test Environment settings at run-time](#change-test-environment-settings-at-run-time)
    - [Once you set your connection string, you can add or update key/value settings](#once-you-set-your-connection-string-you-can-add-or-update-keyvalue-settings)
      - [Note:](#note)
  - [Troubleshooting](#troubleshooting)
    - [Issue: exceptions in Microsoft.Azure.Test.HttpRecorder](#issue-exceptions-in-microsoftazuretesthttprecorder)
  - [Supported Environments in Test Framework](#supported-environments-in-test-framework)
    - [Default Environments and associated Uri](#default-environments-and-associated-uri)
      - [Environment = Prod](#environment--prod)
      - [Environment = Dogfood](#environment--dogfood)
      - [Environment = Next](#environment--next)
      - [Environment = Current](#environment--current)
      - [Environment = Custom](#environment--custom)

## Getting Started

- Install the latest `Az.Resources` from the [PSGallery](https://www.powershellgallery.com/) into PowerShell
  - Run PowerShell as administrator and execute the following command
    - `Install-Module -Name Az.Resources -Scope AllUsers -AllowClobber -Force`
- Import the `TestFx-Tasks` module that helps to configure the settings
  - Run the command `Import-Module ./tools/Modules/TestFx-Tasks.psd1`

## Azure PowerShell Test Framework

Azure PowerShell repo now has its own test framework located under `tools\TestFx`, which supports recording all the HTTP requests from behind Azure PowerShell cmdlets and then playing them back.

The target framework of test is .Net Core 3.1, please ensure .Net runtime Microsoft.NETCore.App 3.1 is installed. You can list all installed version via `dotnet --info`.

## Setup prior to Record or Playback of tests

In order to Record/Playback a test, test framework needs to setup a connection string that consists of various key/value pairs that provide necessary information.

You can choose either option to configure the settings:

- Run the [`Set-TestFxEnvironment` cmdlet](#run-command-set-testfxenvironment-to-build-connection-string) (Recommended)
- [Manually set the environment variables](#manually-set-environment-variables-to-build-connection-string)

### Run Command Set-TestFxEnvironment to Build Connection String (Recommended)

This cmdlet will allow you to create a credentials file (located in `C:/Users/<currentuser>/.Azure/testcredentials.json`) that will be used to set the connection string when scenario tests are run. This credentials file will be used in all future sessions unless it is deleted.

#### Create New Service Principal

Using a service principal is the preferred option for recording tests because it works with both .NET Framework and .NET Core.
In order to create a new service principal, run the following command with an unused service principal display name:

```powershell
Set-TestFxEnvironment -ServicePrincipalDisplayName <DisplayName> -SubscriptionId <SubscriptionId> -TenantId <TenantId> -RecordMode "Record"
```

This command will first create a new service principal. And then set the `Contributor` role assignment for this service principal based upon the subscription provided. After that, it will place the service principal application id and automatically generated secret into the credentials file.

If the display name of the service principal already exists, it will prompt if you would like to create a new one with the same name.
If the answer is "Y", the new generated application id and the secret will be saved.

Alternatively, if you prefer creating a service principal by yourself from Azure portal, follow the [Azure AD guide to create a Application Service Principal](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal#create-an-active-directory-application).

#### Use Existing Service Principal

If you would like to use an existing service principal, run the following command with an existing service principal application id and secret:

```powershell
Set-TestFxEnvironment -ServicePrincipalId <ServicePrincipalApplicationId> -ServicePrincipalSecret <ServicePrincipalSecret> -SubscriptionId <SubscriptionId> -TenantId <TenantId> -RecordMode "Record"
```

For existing service principal, this command will respect your own settings and won't assign the `Contributor` role automatically.

 

### Manually Set Environment Variables to Build Connection String

#### Environment Variables

`TEST_CSM_ORGID_AUTHENTICATION`

* This determines how to connect to Azure. It includes both your authentication and the Azure environment information.

`AZURE_TEST_MODE`

* This specifies whether the test framework will `Record` test sessions or `Playback` previously recorded test sessions.

#### Record Tests

After the service principal is created, you will need to give it access to Azure resources. This can be done with the following PowerShell command. The argument for this command is the application id (See [Service Principal Application ID](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal#get-application-id-and-authentication-key))

```powershell
New-AzRoleAssignment -ApplicationId <ApplicationId> -Scope "/subscriptions/<SubscriptionId>" -RoleDefinitionName Contributor
```

To use this option, set the following environment variable before starting Visual Studio. The following values are substituted into the below environment variable:

`ClientId`

* The [Service Principal Application ID](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal#get-application-id-and-authentication-key)

`ClientSecret`

* The [Service Principal Authentication Key](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal#get-application-id-and-authentication-key)

```
TEST_CSM_ORGID_AUTHENTICATION=Environment=Prod;SubscriptionId=<SubscriptionId>;TenantId=<TenantId>;ServicePrincipal=<ClientId>;ServicePrincipalSecret=<ClientSecret>;HttpRecorderMode=Record;
AZURE_TEST_MODE=Record
```

#### Playback Tests

The default test mode is `Playback`, so setting up the `AZURE_TEST_MODE` is not required. You can optionally set environment variables:

```
TEST_CSM_ORGID_AUTHENTICATION=Environment=Prod;SubscriptionId=<SubscriptionId>;TenantId=<TenantId>;ServicePrincipal=<ClientId>;ServicePrincipalSecret=<ClientSecret>;HttpRecorderMode=Playback;
AZURE_TEST_MODE=Playback
```

## JSON Config File V.S. Environment Variables

Opting for config file is the recommended way to build connection string because any changes you make will take effect immediately without having to restart Visual Studio. However, updating the environment variables is different. It requires rebooting Visual Studio before it can read the updated values. So following is the steps how Test Framework detects the settings.

- If JSON config file exists
  - It will be used to build the connection string. Anything set in the environment variables will be ignored
- If JSON config file does not exist
  - Test framework will first retrieve the environment variable `TEST_CSM_ORGID_AUTHENTICATION` and use its value to build the connection string except for the test mode (Record/Playback).
  - Then test framework will try to get the value of the environment variable `AZURE_TEST_MODE`
    - If `AZURE_TEST_MODE` is set, its value will be used as the test mode
    - Otherwise, the property named `HttpRecorderMode` configured in `TEST_CSM_ORGID_AUTHENTICATION` will be used
    - If the property `HttpRecorderMode` is also not set, `Playback` will be applied as the default value

If you are not sure the settings on your machine, please run command `Get-TestFxEnvironment`. It will consolidate above steps and display the ultimate result.

## Record or Playback Tests

- [Run the tests](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/azure-powershell-developer-guide.md#recordingrunning-tests) and make sure that you got a generated `.json` file that matches the test name under the `SessionRecords` folder in the test project.
- If you want to switch from Record to Playback or from Playback to Record, consider below steps.
  - If you opt for JSON config file, update the value of the property `HttpRecorderMode` in the JSON.
  - If you opt for environment variables
    - If you have `AZURE_TEST_MODE` set, update the value of this variable
    - Otherwise, update the value of the property `HttpRecorderMode` defined in the variable `TEST_CSM_ORGID_AUTHENTICATION`

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
