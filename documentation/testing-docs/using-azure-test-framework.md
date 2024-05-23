# Using Azure PowerShell Test Framework

- [Using Azure PowerShell Test Framework](#using-azure-powershell-test-framework)
  - [Getting Started](#getting-started)
  - [Azure PowerShell Test Framework](#azure-powershell-test-framework)
  - [Setup prior to Record or Playback of tests](#setup-prior-to-record-or-playback-of-tests)
    - [Run Command Set-TestFxEnvironment to Build Connection String](#run-command-set-testfxenvironment-to-build-connection-string)
      - [Use user account to record test cases (Recommended)](#use-user-account-to-record-test-cases-recommended)
      - [Create New Service Principal (Not Recommended)](#create-new-service-principal-not-recommended)
      - [Use Existing Service Principal (Not Recommended)](#use-existing-service-principal-not-recommended)
    - [Manually Set Environment Variables to Build Connection String](#manually-set-environment-variables-to-build-connection-string)
      - [Environment Variables](#environment-variables)
      - [Record Tests](#record-tests)
      - [Playback Tests](#playback-tests)
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

The target framework of test is .Net 6, please ensure .Net runtime Microsoft.NETCore.App 6.0 is installed. You can list all installed version via `dotnet --info`.

## Setup prior to Record or Playback of tests

To Record/Playback a test case, the test framework must establish a connection string comprising multiple key/value pairs that supply essential information.

You can choose either option to configure the settings:

- [Run the Set-TestFxEnvironment cmdlet](#use-user-account-to-record-test-cases)
- [Manually set the environment variables](#manually-set-environment-variables-to-build-connection-string)

### Run Command Set-TestFxEnvironment to Build Connection String

This cmdlet enables you to generate a credentials file (located in `C:/Users/<currentuser>/.Azure/testcredentials.json`) that sets the connection string during scenario test execution. This credentials file persists across sessions unless manually deleted.

#### Use user account to record test cases (Recommended)

Using a user account is the preferred method for recording test cases as it avoids storing secret in the local file with plain text. You can obtain the object ID of the user account either from the Azure portal or through Azure PowerShell.

```powershell
Set-TestFxEnvironment -UserId <UserId> -SubscriptionId <SubscriptionId> -TenantId <TenantId> -RecorderMode "Record"
```

#### Create New Service Principal (Not Recommended)

Using a service principal is not recommended due to security concerns, but it remains an available option for your use.
To create a new service principal, execute the following command with a brand new service principal display name:

```powershell
Set-TestFxEnvironment -ServicePrincipalDisplayName <DisplayName> -SubscriptionId <SubscriptionId> -TenantId <TenantId> -RecorderMode "Record"
```

This command will initially create a new service principal, then assign the `Contributor` role to this service principal according to the specified subscription. Subsequently, it will update the credentials file with the application ID and an automatically generated secret for the service principal.

If the display name of the service principal already exists, you will be prompted to decide whether to create a new one with the same name. If you choose "Y", the newly generated application ID and secret will be stored.

Alternatively, if you prefer to create a service principal manually through the Azure portal, you can refer to [Azure AD guide to create a Application Service Principal](https://learn.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal#create-an-active-directory-application).

#### Use Existing Service Principal (Not Recommended)

If you wish to utilize an existing service principal, execute the following command with the application ID and secret of the desired service principal:

```powershell
Set-TestFxEnvironment -ServicePrincipalId <ServicePrincipalApplicationId> -ServicePrincipalSecret <ServicePrincipalSecret> -SubscriptionId <SubscriptionId> -TenantId <TenantId> -RecorderMode "Record"
```

For an existing service principal, this command will respect your current settings and won't assign the `Contributor` role automatically.



### Manually Set Environment Variables to Build Connection String

#### Environment Variables

`TEST_CSM_ORGID_AUTHENTICATION`

* This variable determines how to connect to Azure. It encompasses both your authentication credentials and the Azure environment information.

`AZURE_TEST_MODE`

* This variable specifies whether the test framework will `Record` test sessions or `Playback` recorded test sessions.

#### Record Tests

You can use either a user account (Recommended) or a Service Principal to record test cases with appropriate permissions.

With user account, you may set the following environment variables:

```
TEST_CSM_ORGID_AUTHENTICATION=Environment=Prod;SubscriptionId=<SubscriptionId>;TenantId=<TenantId>;UserId=<UserId>;
AZURE_TEST_MODE=Record
```

For service principal, you may set the following environment variables:

```
TEST_CSM_ORGID_AUTHENTICATION=Environment=Prod;SubscriptionId=<SubscriptionId>;TenantId=<TenantId>;ServicePrincipal=<ClientId>;ServicePrincipalSecret=<ClientSecret>;
AZURE_TEST_MODE=Record
```

#### Playback Tests

The default test mode is `Playback`, so there is no need to set up the `AZURE_TEST_MODE` variable. You may optionally set the environment variables:

```
TEST_CSM_ORGID_AUTHENTICATION=Environment=Prod;SubscriptionId=<SubscriptionId>;TenantId=<TenantId>;ServicePrincipal=<ClientId>;ServicePrincipalSecret=<ClientSecret>;
AZURE_TEST_MODE=Playback
```

## JSON Config File V.S. Environment Variables

The recommended approach for building the connection string is using a config file, as any changes made will take effect immediately without needing to restart Visual Studio. However, updating environment variables is a different process and requires a restart of Visual Studio for the updated values to be recognized. Here are the steps the Test Framework follows to detect settings:

- If JSON config file exists
  - The Test Framework will use it to build the connection string, ignoring any settings from environment variables.
- If JSON config file does not exist
  - The Test Framework will check the `TEST_CSM_ORGID_AUTHENTICATION` environment variable and use its value to build the connection string.
  - The Test Framework will check the `AZURE_TEST_MODE` environment variable and use its value to build the test mode.
    - If `AZURE_TEST_MODE` is set, its value will be used as the test mode.
    - If `AZURE_TEST_MODE` is not set, the default test mode will be `Playback`.

If you are unsure about the settings on your machine, you can run the command `Get-TestFxEnvironment` to consolidate the steps mentioned above and display the final result.

## Record or Playback Tests

- [Run the tests](https://github.com/Azure/azure-powershell/blob/main/documentation/development-docs/azure-powershell-developer-guide.md#recordingrunning-tests) and make sure that you have a generated `.json` file that corresponds to the test name, and it should be located under the `SessionRecords` folder within the test project.
- If you want to switch from Record to Playback or from Playback to Record, consider below steps.
  - If you choose to use a JSON config file, update the value of the property `HttpRecorderMode` in the JSON file directly.
  - If you prefer environment variables, update the value of environment variable `AZURE_TEST_MODE`.

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

The `HttpRecorderMode` key in the `TEST_CSM_ORGID_AUTHENTICATION` environment variable has been deprecated. Please remove this key/value pair and use `AZURE_TEST_MODE` instead for recording mode.

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
