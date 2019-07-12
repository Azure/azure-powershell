# Table of Contents
1. [Summary](#summary)
2. [Breaking changes in subscriptions module](#Breaking-changes-in-subscriptions-module)
3. [Breaking changes in storage admin module](#Breaking-changes-in-storage-admin-module)

## Summary
The module version 1.3.0 of AzureStack brings in many breaking changes. Most of these breaking changes were noted with warnings in the previous releases. Please note that there are no changes in the AzureRM version of the module specific to Azure Stack.  

AzureRm.AzureStackAdmin module is replaced with Azs.Subscriptions.Admin and Azs.Subscriptions module
AzureRm.AzureStackStorage module is replaced with Azs.Storage.Admin module

## Breaking changes in subscriptions module

**Prefix Changes**<br>
 The prefix *AzureRM* has been deprecated. We have been printing warning that the prefix *AzureRm* will be replaced with *Azs*. We replaced the AzureRm prefix with Azs in the last release with alias support. Now prefix *AzureRm* has been deprecated.The following are the changes. 
   - *-AzureRmOffer is replaced with *-AzsOffer
   - *-AzureRmManagedOffer is replaced with *-AzsManagedOffer
   - *-AzureRmPlan is replaced with *-AzsPlan
   - *-AzureRmMangedSubscription is replaced with *-AzsUserSubscription
   - *-AzureRMTenantSubscription is replaced with *-AzsSubscription
   - *-AzureRmManagedLocation is replaced with *-AzsLocation

**Deprecated Cmdlets**

- ```Get-AzureStackToken``` is deprecated. If there is a need to get token, please use the Microsoft.IdentityModel.Clients.ActiveDirectory.dll directly.

- The cmdlets ```*-AzsResourceProviderManifest``` and ```*-AzsUsageConnection``` are deprecated
For any of these usages, template based resource creation is preferred.  For deletion of these resources, deleting the whole resource group is preferred. If needed, you can also use generic cmdlet *-AzureRmResource

**Parameter Changes**<br>
The previous release was printing  warnings about the deprecation of the following parameter aliases and they are deprecated now. 
- Parameter alias ```PlanName``` has been deprecated in favor of ```Name``` in Plan cmdlets
- Parameter alias ```OfferName``` has been deprecated in favor of ```Name``` in Offer cmdlets
- Parameter alias ```ResourceGroup``` has been deprecated in favor of ```ResourceGroupName``` in all the cmdlets
- Parameter ```Managed``` in Get-AzsPlan has been deprecated. It was not used before
- Parameter ```Managed``` in Get-AzsOffer has been deprecated. Please use Get-AzsManagedOffer instead

**Flattening of Properties** <br>
Properties field of the objects Plan, Offer, Subscription have been removed and the child properties are moved to the top level. If you are having any references to the Properties, this breaking change could be fixed by removing the intermediate Properties reference

**Force Parameter** <br>

Remove-* cmdlets will ask for confirmation before doing the remove action. Please use -Force to avoid the confirmation. The following are the affected cmdlets
- Remove-AzsOffer
- Remove-AzsPlan
- Remove-AzsUserSubscription
- Remove-AzsSubscription

<br>

## Breaking Changes in Storage Admin Module

**Globally Removed Parameters**<br>
The parameters ```SkipCertificateValidation``` and ```DefaultProfile``` have been removed from all cmdlets.

The parameters ```TimeGrain```, ```StartTimeInUtc```, ```EndTimInUtc```, ```MetricNames```, ```DetailedOutput```  have been removed for Get-Azs*Metric Cmdlets, please replace with Where-Object and Select-Object.

The parameters ```MetricNames```, ```DetailedOutput```  have been removed for Get-Azs*MetricDefinition Cmdlets, please replace with Where-Object and Select-Object

**New Parameters**
- The parameter ```ResourceGroupName``` is now an optional for all cmdlets.
- The parameter ```FarmName``` will be required for all Cmdlets that reference nested resources under a farm.  You can get the value using the following

```powershell
        (Get-AzsStorageFarm -ResourceGroupName $rgn).Name
```
Affected cmdlets
- Get-AzsBlobService
- Get-AzsBlobServiceMetric
- Get-AzsBlobServiceMetricDefinition
- Get-AzsStorageFarmMetric
- Get-AzsStorageFarmMetricDefinition
- Get-AzsStorageShare
- Get-AzsStorageShareMetric
- Get-AzsStorageShareMetricDefinition
- Get-AzsTableService
- Get-AzsTableServiceMetric
- Get-AzsTableServiceMetricDefinition
- Start-AzsReclaimStorageCapacity

 ```ResourceId``` parameter can be used for cmdlets that require ```Name``` . The ResourceId is same as the Id of the resource object that is returned from the Get-* cmdlets. The parameter also has an alias ```Id```. 

Affected cmdlets<br>
- Get-AzsStorageQuota
- Get-AzsStorageShare
- Remove-AzsStorageQuota
- Set-AzsStorageQuota
- Stop-AzsContainerMigration
- Restore-AzsStorageAccount 


**Get-AzsStorageAccount**<br>

The parameters ```TenantSubscriptionId```, ```PartialAccountName```, ```StorageAccountStatus``` and ```Detail``` has been removed.  A new parameter called ```Summary``` has been added.

**Get-AzsStorageAcquisition**<br>
The parameters ```TenantSubscriptionId```, ```AccountName```, ```Container```, and ```Detail``` has been removed.  A new parameter called ```Filter``` has been added, this is an ODATA filter.

**Get-AzsStorageContainer**<br>
The parameter ```Intent``` has been removed and Count has been renamed to MaxCount.

**Get-AzsStorageShare**<br>
The parameter ```SourceShareName```  has been replaced with ```FarmName```. The parameter ```Intent``` has been removed.

**Start-AzsStorageContainerMigration**<br>
The parameter ```ContainerToMigrate``` is renamed to ```ContainerName```.  The parameters ```StorageAccountName```, ```ShareName``` and ```FarmName``` have been added.

**Stop-AzsStorageContainerMigration**<br>
This cmdlet has been renamed to ```Stop-AzsContainerMigration```

**Undo-AzsDeletedStorageAccount**<br>
This cmdlet has been renamed to Restore-AzsStorageAccount. The parameters ```NewAccountName```, ```ResourceAdminApiVersion```, ```StorageAccountApiVersion```  have been deprecated.
