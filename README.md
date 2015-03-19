# Microsoft Azure PowerShell

This repository contains a set of PowerShell cmdlets for developers and administrators to develop, deploy and manage Microsoft Azure applications.

* For documentation on how to build and deploy applications to Microsoft Azure please see the [Microsoft Azure Documentation Center](http://azure.microsoft.com/en-us/documentation/).
* For comprehensive documentation on the developer cmdlets see [How to install and configure Azure PowerShell](http://azure.microsoft.com/en-us/documentation/articles/install-configure-powershell/).
* For comprehensive documentation on the full set of Microsoft Azure cmdlets see [Microsoft Azure Management Center](http://go.microsoft.com/fwlink/?linkID=254459&clcid=0x409).

## Features

* Account
  * Get and import Azure publish settings
  * Login with Microsoft account or Organizational account through Microsoft Azure Active Directory
* Environment
  * Get the different out-of-box Microsoft Azure environments
  * Add/Set/Remove customized environments (like your Windows Azure Pack environments)
  * Get Azure publish settings for a particular environment
* Subscription
  * Manage Azure subscription
  * Manage AffinityGroup
* Website
  * Manage website, such as CRUD, start and stop.
  * Manage slot
  * Manage WebJob
  * Deploy project via WebDeploy
  * Diagnostics
      * Configure site and application diagnostics
      * Log streaming
      * Save log
* Cloud Services
  * Create scaffolding for cloud service and role. Role support includes Node.js, PHP, Django and Cache.
  * Manage cloud service and role, such as CRUD, start and stop.
  * Manage extension
  * Start/Stop Azure emulator.
  * Manage certificate.
  * Manage cloud service extensions
    * Remote desktop
    * Diagnostics
    * Microsoft Antimalware
    * Windows Azure Diagnostics
* Storage
  * Manage storage account and access key.
  * Manage storage container and blob, with paging.
  * Copy storage blob.
  * Manage storage table.
  * Manage storage queue.
  * Create SAS token.
  * Manage metrics and logging.
  * Configure timeout
* SQL Database
  * CRUD support for database server, database and firewall rule.
  * Get database server quota.
  * Get/Set database server service objective.
  * Manage database copies and active geo-replication.
  * Get dropped databases that can be restored.
  * Issue requests to restore a live or dropped database to a point in time.
  * Issue requests to recover a database from an unavailable database server.
  * Manage database and database server auditing policy.
* Service Bus
  * Manage service bus namespaces.
* VM
  * Manage VM, such as CRUD, import/export and start/stop/restart.
  * Manage VM image and VM image disks.
  * Manage disk, such as CRUD.
  * Manage VM endpoint, such as CRUD and ACL.
  * Get/Set VM sub net.
  * Manage certificate and SSH key.
  * PowerShell remoting
  * Manage extension
    * BG Info
    * Puppet
    * Custom Script
    * Access
    * Microsoft Antimalware
    * PowerShell DSC
    * Windows Azure Diagnostics
  * Public IP, reserved IP and internal load balancer
* Deployment
  * Manage deployment, such as CRUD, move, upgrade and restore.
  * Get/Create DNS settings of a deployment.
* VNet
  * Manage virtual network config, connection and gateway.
  * Manage static IP
* Azure Media Services
  * Create, read and delete Media Services Accounts
  * Generate new account keys for Media Services Accounts
* HDInsight
  * Manage clusters, such as CRUD, add/set storage
  * Manage jobs, such as CRUD, start/stop/wait/invoke
  * Manage HTTP service access. such as grant/revoke
* Store
  * View available Microsoft Azure Store Add-On plans.
  * Purchase, view, upgrade and remove Microsoft Azure Store Add-On instances.
* Utility
  * Test whether a name is available. Currently support cloud service name, storage account name and service bus namespace name.
  * Get the list of geo locations supported by Azure.
  * Get the list of OS supported by Azure.
  * Direct you to Azure portal.
* Windows Azure Pack
  * Web Site: CRUD web site, deployment, configure and get log, start/stop/restart/show web site
  * Service Bus: CRD namespace
  * VM: CRUD VM, get OS disk, size profile and VM template, start/stop/restart/suspend/resume VM
  * VNET: CRUD VNET and subnet.
  * Cloud Service: CRUD cloud service.
* ExpressRoute
  * Manage dedicated circuit
  * Manage BGP peering
* Scheduler
  * Manage job collections
  * Manage HTTP and storage queue jobs
* Resource Manager
  * Manage resource groups and deployments
  * Query and download gallery templates
  * Manage individual resources
* Traffic Manager
  * Manage profiles and endpoints
* Azure Automation
  * Manage automation accounts
  * Manage automation jobs, runbooks and schedules

For detail descriptions and examples of the cmdlets, type
* ```help azure``` to get all the cmdlets.
* ```help node-dev``` to get all Node.js development related cmdlets.
* ```help php-dev``` to get all PHP development related cmdlets.
* ```help python-dev``` to get all Python development related cmdlets.
* ```help <cmdlet name>``` to get the details of a specific cmdlet.

## Supported Environments

* [Microsoft Azure](http://www.azure.microsoft.com)
* [Windows Azure Pack](http://www.microsoft.com/en-us/server-cloud/windows-azure-pack.aspx)
* [Microsoft Azure China](http://www.windowsazure.cn/)

## Installation

### Microsoft Web Platform Installer

1. Install [Microsoft Web Platform Installer](http://www.microsoft.com/web/downloads/platform.aspx).
2. Open Microsoft Web Platform Installer and search for __Microsoft Azure PowerShell__.
3. Install.

You can also find the standalone installers for all the versions at [Downloads](https://github.com/Azure/azure-sdk-tools/releases)

### Source Code

1. Download the source code from GitHub repo
2. Follow the [Microsoft Azure PowerShell Developer Guide](https://github.com/Azure/azure-sdk-tools/wiki/Windows-Azure-PowerShell-Developer-Guide)

### Supported PowerShell Versions

* 0.6.9 or lower
  * [Windows PowerShell 2.0](http://technet.microsoft.com/en-us/scriptcenter/dd742419)
  * [Windows PowerShell 3.0](http://www.microsoft.com/en-us/download/details.aspx?id=34595)
* 0.6.10 to higher
  * [Windows PowerShell 3.0](http://www.microsoft.com/en-us/download/details.aspx?id=34595)

## Get Started

In general, following are the steps to start using Microsoft Azure PowerShell

* Get yourself authenticated with Microsoft Azure. For details, please check out [this article](http://azure.microsoft.com/en-us/documentation/articles/install-configure-powershell/).
  * Option 1: Login with your Microsoft account or Organizational account directly from PowerShell. Microsoft Azure Active Directory authentication is used in this case. No management certificate is needed.
      * Starting from 0.8.6, you can use ``Add-AzureAccount -Credential`` to avoid the browser pop up for Organizational account.
  * Option 2: Download and import a publish settings file which contains a management certificate.
* Use the cmdlets

The first step can be different for different environment you are targeting. Following are detail instructions for each supported environment.

### Microsoft Azure

If you use both mechanisms on the same subscription, Microsoft Azure Active Directory authentication always wins. If you want to go back to management certificate authentication, please use ``Remove-AzureAccount``, which will remove the Microsoft Azure Active Directory information and bring management certificate authentication back in.

#### Login directly from PowerShell (Microsoft Azure Active Directory authentication)

```powershell
# Pop up an embedded browser control for you to login
Add-AzureAccount

# use the cmdlets to manage your services/applications
New-AzureWebsite -Name mywebsite -Location "West US"
```

#### Use publish settings file (Management certificate authentication)

```powershell
# Download a file which contains the publish settings information of your subscription.
# This will open a browser window and ask you to log in to get the file.
Get-AzurePublishSettingsFile

# Import the file you just downloaded.
# Notice that the file contains credential of your subscription so you don't want to make it public
# (like check in to source control, etc.).
Import-AzurePublishSettingsFile "<file location>"

# Use the cmdlets to manage your services/applications
New-AzureWebsite -Name mywebsite -Location "West US"
```

### Microsoft Azure China

```powershell
# Check the environment supported by your Microsoft Azure PowerShell installation.
Get-AzureEnvironment

# Download a file which contains the publish settings information of your subscription.
# Use the -Environment parameter to target Microsoft Azure China.
# This will open a browser window and ask you to log in to get the file.
Get-AzurePublishSettingsFile -Environment "AzureChinaCloud"

# Import the file you just downloaded.
# Notice that the file contains credential of your subscription so you don't want to make it public
# (like check in to source control, etc.).
Import-AzurePublishSettingsFile "<file location>"

# Use the cmdlets to manage your services/applications
New-AzureWebsite -Name mywebsite -Location "China East"
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
## 2 Modes

Starting from 0.8.0, we are adding a separate mode for Resource Manager. You can use the following cmdlet to switch between the

* Service management: cmdlets using the Azure service management API
* Resource manager: cmdlets using the Azure Resource Manager API

They are not designed to work together.

```powershell
Switch-AzureMode AzureServiceManagement
Switch-AzureMode AzureResourceManager
```

## Find Your Way

All the cmdlets can be put into 3 categories:

1. Cmdlets support both Microsoft Azure and Windows Azure Pack
2. Cmdlets only support both Microsoft Azure
3. Cmdlets only support Windows Azure Pack

* For category 1, we are using an "Azure" prefix in the cmdlet name and adding an alias with "WAPack" prefix.
* For category 2, we are using an "Azure" prefix in the cmdlet name.
* For category 2, we are using an "WAPack" prefix in the cmdlet name.

So you can use the following cmdlet to find out all the cmdlets for your environment

```powershell
# Return all the cmdlets for Microsoft Azure
Get-Command *Azure*

# Return all the cmdlets for Windows Azure Pack
Get-Command *WAPack*
```

If you want to migrate some scripts from Microsoft Azure to Windows Azure Pack or vice versa, as long as the cmdlets you are using are in category 1, you should be able to migrate smoothly.

## Need Help?

Be sure to check out the [Microsoft Azure Developer Forums on Stack Overflow](http://go.microsoft.com/fwlink/?LinkId=234489) if you have trouble with the provided code.

## Contribute Code or Provide Feedback

If you would like to become an active contributor to this project please follow the instructions provided in [Microsoft Azure Projects Contribution Guidelines](http://windowsazure.github.com/guidelines.html).

If you encounter any bugs with the library please file an issue in the [Issues](https://github.com/Azure/azure-sdk-tools/issues) section of the project.

# Learn More

* [Microsoft Azure Script Center](http://www.azure.microsoft.com/en-us/documentation/scripts/)
