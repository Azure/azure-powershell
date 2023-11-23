<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1
-->
## Upcoming Release

## Version 2.2.3
* Added support for ARC Onboarding using Cluster Managed Identity. 
* Removed previous IMDS Reg Key during Registration/Repair-Registration. 
* Removed creation of custom IMDS Reg Key during Arc Enablement.
* Improved logging experience.

## Version 2.2.2
* Reverted remove CustomIMDSHost

## Version 2.2.1
* Added changes to selectively enable ARC.

## Version 2.2.0
* Bug fixes for Attestation commands.
* Added support for installing mandatory extensions on HCI OS 22H2 and removed confirmation prompt for consent.
* Added ability to customize the location of logs generated during registration.
    - Custom log location can be specified by specifying an optional `-LogsDirectory` parameter in `Register-AzStackHCI`.
    - `Get-AzStackHCILogsDirectory` can be used to obtain the log location.
* Increased retry count for setting up ARC integration.

## Version 2.1.2
* Removed device type check and only check if service already exists.

## Version 2.1.1
* Used the correct version of cloud management service in `Register-AzStackHCI` cmdlet.
* Fixed the bugs in `Register-AzStackHCI` and `Enable-AzStackHCIAttestation` cmdlets.

## Version 2.1.0
* Updated to api-version 2023-03-01.
* Cmdlets added:
    - Invoke-AzStackHciExtendClusterSoftwareAssuranceBenefit : Enable Software Assurance for a cluster
    - Invoke-AzStackHciConsentAndInstallDefaultExtensions : Consent to installing default extensions on the cluster
## Version 2.0.0
* Made Region parameter mandatory in `Register-AzStackHCI` cmdlet.
* Removed EnableAzureArcServer parameter from `Register-AzStackHCI` cmdlet.
* Removed `Test-AzStackHCIConnection` cmdlet. Customers can use `Invoke-AzStackHciConnectivityValidation` from AzStackHCI.EnvironmentChecker module for enhanced connectivity verification tests.
* Added support for Managed Service identity (MSI) in Azure China Cloud.
* Added support for Mandatory extensions, for OS versions starting 23H2.
* Added parameter validations for `Register-AzStackHCI` cmdlet.
* Improved Error logging in Registration and Unregistration.

## Version 1.4.3
* Removed manual installation for Az.Accounts from Az.StackHCI.
* Removed verbose while importing modules.

## Version 1.4.2
* Added Remote Support terms and conditions for HCI device types.
* Unified Resource Group support for both Azure Stack HCI and Arc for server resources.
* Enhanced error feedback and logging in the Register-AzStackHCI cmdlet.
* Bug fixes and improvements in Azure Arc for servers enablement in Register-AzStackHCI cmdlet.
* Improved parameter validations in the Register-AzStackHCI cmdlet.
* Enabled Managed System Identity (MSI) for Registration in Fairfax Cloud.
* Minor bug fixes and improvements.

## Version 1.4.1
* Added support for arc extensions which depend on HCI cluster's IMDS endpoints.

## Version 1.4.0
* Enabled system-assigned identity on HCI cluster resource registration and repair registration flow.
* Added error message in the command Register-AzStackHCI if Arc is not enabled.
* Added default region confirmation prompt if the region is not mentioned in the command Register-AzStackHCI.
* Added general logging improvements.
* Added logic that skipping the Arc SPN permission check in Register-AzStackHCI if a customer doesn't have the required permissions to read Arc SPN credential.
* Added deprecation message for the command Test-AzStackHCIConnection. Customers can use Invoke-AzStackHciConnectivityValidation from the module AzStackHCI.EnvironmentChecker for connectivity verification tests.

## Version 1.3.2
* Supported WDAC compliant APIs
* Fixed module versions of dependent PS modules
* Updated Remote Support cmdlets to check device type between HCIv2 and AzureEdge

## Version 1.3.1
* Made GraphAccessToken parameter obsolete in Register-AzStackHCI, Unregister-AzStackHCI and Set-AzStackHCI cmdlets. This is because Az.StackHCI module does not depend on Azure AD anymore.
* Include API version for all Microsoft.AzStackHCI related AZ-Resource calls

## Version 1.3.0
* Added support to Stack HCI Cluster
* Added support to Stack HCI Extension
* Added support to Stack HCI Arc Settings

## Version 1.2.0
* Improved Registration process for Register-AzStackHCI cmdlet
    - All Azure AD related operations are now moved to HCI Cloud Services
    - Register-AzStackHCI and UnRegister-AzStackHCI cmdlets no more use AzureAD PS module
* Added support to register hybridConnectivity RP in Canary and Public clouds
* Added support for Region Specific ServiceEndpoints
    -Service endpoints are now specified by HCI Cloud services instead of it being hardcoded in the PS module
* Added support to specify ArcServerResourceGroupName to Register-AzStackHCI cmdlet
    - Now we can specify the resource group into which the ARC resource gets projected using 'ArcServerResourceGroupName' parameter during registration
* Check ResourceProvider is already registered before attempting to register it during Register-AzStackHCI cmdlet
    - Register-AzStackHCI cmdlet now does not take any action if required Resource Providers are already registered. This allows users with Roles who do not have permissions to register resource providers to still perform registration operation
* Supported for writing event log entries from registration cmdlets
    - Register-AzStackHCI and UnRegister-AzStackHCI flows will now write events to Node log reflecting the status  of registration. Events will be logged under source name "HCI Registration"

## Version 1.1.1
* Updated firewall rules for Attestation network to block all other traffic
* Updated cluster to ignore Attestation network

## Version 1.1.0
* Adding support cmdlet for Remote Support 
    - New cmdlets - Install-AzStackHCIRemoteSupport, Remove-AzStackHCIRemoteSupport, Enable-AzStackHCIRemoteSupport, Disable-AzStackHCIRemoteSupport, Get-AzStackHCIRemoteSupportAccess,Get-AzStackHCIRemoteSupportSessionHistory
    
## Version 1.0.0
* Promoted Az.StackHCI to GA

## Version 0.10.0
* Added Support for AzureStack HCI Attestation (Azure Benefits)
    - New cmdlets: Enable-AzStackHCIAttestation, Disable-AzStackHCIAttestation, Add-AzStackHCIVMAttestation, Remove-AzStackHCIVMAttestation, Get-AzStackHCIVMAttestation
* Added Support for Windows Server Subscription
    - New cmdlet: Set-AzStackHCI

## Version 0.9.1
* Added Support for AzureUSGovernment cloud
    - EnvironmentName parameter in Register-AzStackHCI, Unregister-AzStackHCI and Test-AzStackHCIConnection now supports a new value "AzureUSGovernment"
## Version 0.9.0
* Made changes to show Arc not supported error on 20H2 only if intent to enable Arc is specified by user.
    - Show Arc not supported error on 20H2 only if -EnableAzureArc:$true is specified in registration Cmdlet.

## Version 0.8.0
* Made changes to use FQDN while connecting to nodes and the cluster.
    - Using FQDN while connecting to cluster and the nodes.
    - Using AAD retries in Arc AAD application setup.
    - Returning ErrorDetails in PS output stream for WAC to handle the case of RegisteredButArcFailed.

## Version 0.7.0
* Made changes in the registration to onboard nodes to Azure Arc.
    - Registering On-Premises Azure Stack HCI with Azure will also make the nodes in the cluster Azure Arc enabled.   

## Version 0.6.0
* Fixed addition of assigned roles list.

## Version 0.5.0
* Made changes to registration script to add retries for AAD operations and to add AzureChinaCloud support.
    - Added retries for AAD operations for reliability.
    - Supports registration in AzureChinaCloud.
    - Supports Tag while resource creation.

## Version 0.4.1
* Fixed an issue blocking user to use cmdlets in Az.StackHCI v0.4.0.

## Version 0.4.0
* Made changes to registration script to register the GA version of On-Premises Azure Stack HCI with Azure.
    - Supports registering with user provided certificate thumbprint.
    - Supports On-Premises Azure Stack HCI OS changes to use independent certificate on cluster nodes.
    - Cleans up resource group during unregistration.
    - Improves registration output and logging.
    - Corrected invalid character in unregistration details message.
* [Breaking Change] Breaks the public preview registration of On-Premises Azure Stack HCI with Azure.
    - To register public preview On-Premises Azure Stack HCi with Azure, use 0.3.1 version of Az.StackHCI.

## Version 0.3.1
* Fixed an issue that may block Stack HCI registration.
    - Workaround for the token cache issue in Az.Accounts 2.1.0. Using AuthenticationFactory.

## Version 0.3.0
* Get the App Roles assigned correctly in case of Stack HCI registration using WAC token.

## Version 0.2.0
* Added hash table for region.

## Version 0.1.1
* Added `Core` to `CompatiblePSEditions`.

## Version 0.1.0
* Public Preview of `Az.StackHCI` module.
