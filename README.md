<meta name="google-site-verification" content="tZgbB2s-hTI0IePQQRCjHqL_Vf0j_XJmehXAHJerrn4" />
# Microsoft Azure PowerShell

This repository contains a set of PowerShell cmdlets for developers and administrators to develop, deploy and manage Microsoft Azure applications.

* For documentation on how to build and deploy applications to Microsoft Azure please see the [Microsoft Azure Documentation Center](https://azure.microsoft.com/en-us/documentation/).
* For comprehensive documentation on the developer cmdlets see [How to install and configure Azure PowerShell](https://azure.microsoft.com/en-us/documentation/articles/install-configure-powershell/).
* For comprehensive documentation on the full set of Microsoft Azure cmdlets see [Microsoft Azure Management Center](http://go.microsoft.com/fwlink/?linkID=254459&clcid=0x409).

## Features

* Account management
  * Login with Microsoft account, Organizational account, or Service Principal through Microsoft Azure Active Directory
  * Save Credentials to disk with Save-AzureRmProfile and load saved credentials using Select-AzureRmProfile
* Environment
  * Get the different out-of-box Microsoft Azure environments
  * Add/Set/Remove customized environments (like your Azure Stack or Windows Azure Pack environments)
* Management and data plane cmdlets for Azure services in ARM and RDFE
  * VM
  * Storage
  * Network
  * App Service (Websites)
  * SQL Database
  * KeyVault
  * Operational Insights
  * Automation
  * Batch
  * Backup
  * RecoveryServices and SiteRecovery
  * Stream Analytics
  * Traffic Manager
  * DataFactories
  * DNS
  * HDInsight
  * Express Route
  * Scheduler
  * StorSimple
  * Redis Cache
 
* Windows Azure Pack
  * Web Site: CRUD web site, deployment, configure and get log, start/stop/restart/show web site
  * Service Bus: CRD namespace
  * VM: CRUD VM, get OS disk, size profile and VM template, start/stop/restart/suspend/resume VM
  * VNET: CRUD VNET and subnet.
  * Cloud Service: CRUD cloud service.
* Windows Azure Stack
  * Azure Stack Administration
  * Storage Service Management
  

For detail descriptions and examples of the cmdlets, type
* ```help azure``` to get all the cmdlets.
* ```help azurerm``` to get all the Azure Resource Manager (ARM) cmdlets.
* ```help <cmdlet name>``` to get the details of a specific cmdlet.

## Supported Environments

* [Microsoft Azure](https://azure.microsoft.com)
* [Azure Stack](https://azure.microsoft.com/en-us/overview/azure-stack/)
* [Windows Azure Pack](https://www.microsoft.com/en-us/server-cloud/windows-azure-pack.aspx)
* [Microsoft Azure China](https://www.azure.cn/)
* [Microsoft Azure US Government](https://azure.microsoft.com/en-us/features/gov/)

## Installation

### Microsoft Web Platform Installer

1. Install [Microsoft Web Platform Installer](https://www.microsoft.com/web/downloads/platform.aspx).
2. Open Microsoft Web Platform Installer and search for __Microsoft Azure PowerShell__.
3. Install.

You can also find the standalone installers for all the versions at [Downloads](https://github.com/Azure/azure-powershell/releases)

### PowerShell Gallery
1. Install [Windows Management Framework 5 with PowerShellGet cmdlets](https://www.powershellgallery.com/GettingStarted?section=Get%20Started)
2. In an elevated PowerShell session, run  ```Install-Module AzureRM```
3. Run ```Install-AzureRm```
4. To install RDFE cmdlets, run ```Install-Module Azure```

### Source Code

1. Download the source code from GitHub repo
2. Follow the [Microsoft Azure PowerShell Developer Guide](https://github.com/Azure/azure-powershell/wiki/Microsoft-Azure-PowerShell-Developer-Guide)

### Supported PowerShell Versions

* [Windows Management Framework 3] (https://www.microsoft.com/en-us/download/details.aspx?id=34595)
* [Windows Management Framework 4] (https://www.microsoft.com/en-us/download/details.aspx?id=40855)
* [Windows Management Framework 5] (https://www.microsoft.com/en-us/download/details.aspx?id=50395)

## Get Started

In general, follow these steps to start using Microsoft Azure PowerShell

* Get yourself authenticated with Microsoft Azure. For details, please check out [this article](https://azure.microsoft.com/en-us/documentation/articles/install-configure-powershell/).
  * Option 1: Login with your Microsoft account or Organizational account directly from PowerShell. Microsoft Azure Active Directory authentication is used in this case. No management certificate is needed.
      * Starting from 1.0.0, you can use ```Add-AzureRmAccount -Credential``` to avoid the browser pop up for Organizational account.
      * To use RDFE cmdlets, use ```Add-AzureAccount```
* Use the cmdlets

The first step can be different for different environment you are targeting. Following are detail instructions for each supported environment.

### Microsoft Azure

If you use both mechanisms on the same subscription, Microsoft Azure Active Directory authentication always wins. If you want to go back to management certificate authentication, please use ```Remove-AzureAccount```, which will remove the Microsoft Azure Active Directory information and bring management certificate authentication back in.

#### Login directly from PowerShell (Microsoft Azure Active Directory authentication)

```powershell
# Pop up an embedded browser control for you to login
Add-AzureRmAccount

# use the cmdlets to manage your services/applications
New-AzureRmResourceGroup -Name myresourceGroup -Location "West US"
```

### Microsoft Azure China

```powershell
Add-AzureRmAccount -EnvironmentName AzureChinaCloud

# use the cmdlets to manage your services/applications
New-AzureRmResourceGroup -Name myresourceGroup -Location "China East"
```

### Microsoft Azure US Government

```powershell
Add-AzureRmAccount -EnvironmentName AzureUSGovernment

# use the cmdlets to manage your services/applications
New-AzureRmResourceGroup -Name myresourceGroup -Location "US Gov Virginia"
```

### Windows Azure Pack

```powershell
# Add your Windows Azure Pack environment to your Microsoft Azure PowerShell installation.
# You will need to know the following information of your Windows Azure Pack environment.
# 1. URL to download the publish settings file    Mandatory
# 2. Management service endpoint                  Optional
# 3. Management Portal URL                        Optional
# 4. Storage service endpoint                     Optional
Add-WAPackEnvironment -Name "MyWAPackEnv" `
    -PublishSettingsFileUrl "URL to download the publish settings file>" `
    -ServiceEndpoint "<Management service endpoint>" `
    -ManagementPortalUrl "<Storage service endpoint>" `
    -StorageEndpoint "<Management Portal URL>"

# Download a file which contains the publish settings information of your subscription.
# Use the -Environment parameter to target your Windows Azure Pack environment.
# This will open a browser window and ask you to log in to get the file.
Get-WAPackPublishSettingsFile -Environment "MyWAPackEnv"

# Import the file you just downloaded.
# Notice that the file contains credential of your subscription so you don't want to make it public
# (like check in to source control, etc.).
Import-WAPackPublishSettingsFile "<file location>"

# Use the cmdlets to manage your services/applications
New-WAPackWebsite -Name mywebsite
```

## Find Your Way

All the cmdlets can be put into 3 categories:

1. ARM management cmdlets use the 'AzureRm' prefix (New-AzureRmResourceGroup, Get-AzureRmVM)
2. Legacy RDFE management cmdlets use the 'Azure' prefix (Get-AzureVM)
3. Data plane cmdlets that work in ARM or RDFE use the 'Azure' prefix (Get-AzureBlob)


You can use the following cmdlet to find out all the cmdlets for your environment

```powershell
# Return all the cmdlets for Azure Resource Manager (ARM)
Get-Command *AzureRm*
# Return all the cmdlets for Microsoft Azure
Get-Command *Azure*

# Return all the cmdlets for Windows Azure Pack
Get-Command *WAPack*
```

If you want to migrate some scripts from Microsoft Azure to Windows Azure Pack or vice versa, as long as the cmdlets you are using are in category 1, you should be able to migrate smoothly.

## Need Help?

Be sure to check out the [Microsoft Azure Developer Forums on Stack Overflow](http://go.microsoft.com/fwlink/?LinkId=234489) if you have trouble with the provided code.

## Contribute Code or Provide Feedback

If you would like to become an active contributor to this project please follow the instructions provided in [Microsoft Azure Projects Contribution Guidelines](https://azure.github.io/guidelines/).

If you encounter any bugs with the library please file an issue in the [Issues](https://github.com/Azure/azure-powershell/issues) section of the project.

# Learn More

* [Microsoft Azure Script Center](https://azure.microsoft.com/en-us/documentation/scripts/)

---
_This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments._
