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

## Version 3.1.2
* Updated the breaking change warning messages [#16805]

## Version 3.1.1
* Fixed the typo in `New-AzAksCluster` [#16733]

## Version 3.1.0
* Added support of `load balancer` and `api server access` in `New-AzAksCluster` and `Set-AzAksCluster`. [#16575]

## Version 3.0.0
* [Breaking Change] Updated parameter alias and output type of `Get-AzAksVersion`
* Added `Invoke-AzAksRunCommand` to support running a shell command (with kubectl, helm) on aks cluster. [#16104]
* Added support of `EnableNodePublicIp` and `NodePublicIPPrefixID` for `New-AzAksCluster` and `New-AzAksNodePool`. [#15656]
* Migrated the logic of creating service principal in `New-AzAksCluster` from `Azure Active Directory Graph` to `Microsoft Graph`.
* Fixed the issue that `Set-AzAksCluster` can't upgrade cluster when node pool version doesn't match cluster version. [#14583]
* Added `ResourceGroupName` in `PSKubernetesCluster`. [#15802]

## Version 2.5.0
* Added support for new parameters `NetworkPolicy`, `PodCidr`, `ServiceCidr`, `DnsServiceIP`, `DockerBridgeCidr`, `NodePoolLabel`, `AksCustomHeader` in `New-AzAksCluster`. [#13795]
* Added warnings of upcoming breaking change of migrating to Microsoft Graph.
* Added support for changing the number of nodes in a node pool. [#12379]

## Version 2.4.0
* Made `-Subscription <String>` available in all Aks cmdlets. You can manage Aks resources in other subscriptions without switching the context.

## Version 2.3.0
* Added `Start-AzAksCluster`, `Stop-AzAksCluster`, `Get-AzAksUpgradeProfile` and `Get-AzAksNodePoolUpgradeProfile`. [#14194]
* Added property `IdentityProfile` in the output of `Get-AzAksCluster`. [#12546]

## Version 2.2.0
* Added parameter `AvailabilityZone` for `New-AzAksNodePool`. [#14505]

## Version 2.1.1
* Fixed the issue that `Set-AzAks` will fail in Automation Runbook. [#15006]

## Version 2.1.0
* Added support `AcrNameToAttach` in `Set-AzAksCluster`. [#14692]
* Added support `AcrNameToDetach` in `Set-AzAksCluster`. [#14693]
* Added `Set-AzAksClusterCredential` to reset the ServicePrincipal of an existing AKS cluster.

## Version 2.0.2
* Refined error messages of cmdlet failure.
* Upgraded exception handling to use Azure PowerShell related exceptions.
* Fixed the issue that user could not use provided service principal to create Kubernetes cluster. [#13938]

## Version 2.0.1
* Fixed the issue that user cannot use service principal to create a new Kubernetes cluster. [#13012]

## Version 2.0.0
* [Breaking Change] Removed parameter alias `ClientIdAndSecret` in `New-AzAksCluster` and `Set-AzAksCluster`.
* [Breaking Change] Changed the default value of `NodeVmSetType` in `New-AzAksCluster` from `AvailabilitySet` to `VirtualMachineScaleSets`.
* [Breaking Change] Changed the default value of `NetworkPlugin` in `New-AzAksCluster` from `None` to `azure`.
* [Breaking Change] Removed parameter `NodeOsType` in `New-AzAksCluster` as it supports only one value Linux.


## Version 1.3.0
* Added client side parameter validation logic for `New-AzAksCluster`, `Set-AzAksCluster` and `New-AzAksNodePool`. [#12372]
* Added support for add-ons in `New-AzAksCluster`. [#11239]
* Added cmdlets `Enable-AzAksAddOn` and `Disable-AzAksAddOn` for add-ons. [#11239]
* Added parameter `GenerateSshKey` for `New-AzAksCluster`. [#12371]
* Updated api version to 2020-06-01.

## Version 1.2.0
* Removed `ClientIdAndSecret` to `ServicePrincipalIdAndSecret` and set `ClientIdAndSecret` as an alias [#12381].
* Removed `Get-AzAks`/`New-AzAks`/`Remove-AzAks`/`Set-AzAks` to `Get-AzAksCluster`/`New-AzAksCluster`/`Remove-AzAksCluster`/`Set-AzAksCluster` and set the original ones as alias [#12373].

## Version 1.1.3
* Fixed bug `Get-AzAks` doesn't get all clusters [#12296]

## Version 1.1.2

* Replaced usage of old [AccessProfile API](https://docs.microsoft.com/rest/api/aks/managedclusters/getaccessprofile) with calls to [ListClusterAdmin](https://docs.microsoft.com/rest/api/aks/managedclusters/listclusteradmincredentials) and [ListClusterUser](https://docs.microsoft.com/rest/api/aks/managedclusters/listclusterusercredentials) APIs

## Version 1.1.1
* Upgraded API Version to 2019-10-01
* Supported to create AKS using Windows container
* Provided new cmdlets: `New-AzAksNodePool`, `Update-AzAksNodePool`, `Remove-AzAksNodePool`,
         `Get-AzAksNodePool`, `Install-AzAksKubectl`, `Get-AzAksVersion`

## Version 1.1.0-preview
* Upgrade to API Version 2019-10-01

## Version 1.0.3
* Update references in .psd1 to use relative path

## Version 1.0.2
* Fixed miscellaneous typos across module
* Fix issue with output for `Get-AzAks`
    * More information here: https://github.com/Azure/azure-powershell/issues/9847

## Version 1.0.1
* Update incorrect online help URLs

## Version 1.0.0
* General availability of `Az.Aks` module
