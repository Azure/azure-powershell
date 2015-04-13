# Microsoft Azure PowerShell

PowerShell cmdlets for developers and administrators to provision, manage and deploy infrastructure and applications in Azure.

* For more information on Azure services, see the [Microsoft Azure Documentation Center](http://azure.microsoft.com/en-us/documentation/).
* To get started, see [How to install and configure Azure PowerShell](http://azure.microsoft.com/en-us/documentation/articles/install-configure-powershell/).
* For documentation on individual cmdlets see [Microsoft Azure Powershell](http://go.microsoft.com/fwlink/?linkID=254459&clcid=0x409).

## Help

Get help and examples from inside Azure Powershell:
* ```help azure``` to list all the Azure cmdlets.
* ```help <cmdlet name>``` to get the details of a specific cmdlet.

## Supported Azure Environments

* [Microsoft Azure](http://www.azure.microsoft.com)
* [Windows Azure Pack](http://www.microsoft.com/en-us/server-cloud/windows-azure-pack.aspx)
* [Microsoft Azure China](http://www.windowsazure.cn/)

## Install Released Builds
Install using the the [Microsoft Web Platform Installer](http://go.microsoft.com/?linkid=9811175&clcid=0x409).

Or use a standalone MSI from the latest [Microsoft Azure Powershell releases](https://github.com/Azure/azure-powershell/releases)

## Build Your Own

Fork and clone the repo, and follow the [Microsoft Azure PowerShell Developer Guide](https://github.com/Azure/azure-powershell/wiki/Microsoft-Azure-PowerShell-Developer-Guide)

## Get Started Using Azure PowerShell

You must be authenticated to manage your Azure subscription with the Azure PowerShell cmdlets. For details, refer to [How to Install and Configure Azure PowerShell](http://azure.microsoft.com/en-us/documentation/articles/install-configure-powershell/).
* Option 1: Login with your Microsoft account or Organizational account directly from PowerShell. No management certificate is required. Microsoft Azure Active Directory authentication is used.
* Option 2: Download and import a publish settings file which contains a management certificate.

Authentication setup varies by environment. Details for each environment below.

### Microsoft Azure
If you configure both a credential and management certificate, the Microsoft Azure Active Directory will be used. To return to the management certificate, use ``Remove-AzureAccount`` to remove the Organizational account.

#### Login directly from PowerShell (Microsoft Azure Active Directory authentication)

```powershell
# Displays a browser window for login
Add-AzureAccount

# Interactive login without a browser window
Add-AzureAccount -Credential
```

#### Use publish settings file (Management certificate authentication)

```powershell
# Opens a browser window to login and download publish settings file.
Get-AzurePublishSettingsFile

# Import the downloaded file.
# It contains credentials for your account. Keep it safe.
Import-AzurePublishSettingsFile "<file location>"

```

### Microsoft Azure China

```powershell
# Check the environment supported by your Microsoft Azure PowerShell installation.
Get-AzureEnvironment

# Use the -Environment parameter to specify Microsoft Azure China.
# Opens a browser window to login and download publish settings file.
Get-AzurePublishSettingsFile -Environment "AzureChinaCloud"

# Import the downloaded file.
# It contains credentials for your account. Keep it safe.
Import-AzurePublishSettingsFile "<file location>"
```

### Windows Azure Pack

```powershell
# You will need the following information of your Windows Azure Pack environment.
# 1. URL to download the publish settings file    Mandatory
# 2. Management service endpoint                  Optional
# 3. Management Portal URL                        Optional
# 4. Storage service endpoint                     Optional
Add-WAPackEnvironment -Name "MyWAPackEnv" `
    -PublishSettingsFileUrl "URL to download the publish settings file>" `
    -ServiceEndpoint "<Management service endpoint>" `
    -ManagementPortalUrl "<Storage service endpoint>" `
    -StorageEndpoint "<Management Portal URL>"

# Use the -Environment parameter to specify your Windows Azure Pack environment.
# Opens a browser window to login and download publish settings file.
Get-WAPackPublishSettingsFile -Environment "MyWAPackEnv"

# Import the downloaded file.
# It contains credentials for your account. Keep it safe.
Import-WAPackPublishSettingsFile "<file location>"

```
## Switch-AzureMode

Azure Powershell has two modes. Service Management mode is for the original infrastructure and deployment model. Resource Manager mode is for the newer APIs providing templated deployments and role-based access controls.

They are not designed to work together. Switch between the two modes using ```Switch-AzureMode```.

```powershell
Switch-AzureMode AzureServiceManagement
Switch-AzureMode AzureResourceManager
```

## Environment-Specific cmdlets

Some cmdlets support both the public Microsoft Azure environment and your private Windows Azure Pack environment. Some support only one environment. Aliases are used to easily identify the environments a cmdlet supports.

```powershell
# Return all the cmdlets for Microsoft Azure
Get-Command *Azure*

# Return all the cmdlets for Windows Azure Pack
Get-Command *WAPack*
```

## Need Help?

Check out the [Microsoft Azure Developer Forums on Stack Overflow](http://go.microsoft.com/fwlink/?LinkId=234489) if you have trouble.

## Contribute Code or Provide Feedback

If you would like to contribute to this project, follow the instructions at [Microsoft Azure Open Source Contribution Guidelines](http://azure.github.io/guidelines.html).

If you encounter any bugs, please open an [issue](https://github.com/Azure/azure-powershell/issues).

