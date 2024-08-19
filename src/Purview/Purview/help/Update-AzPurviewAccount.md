---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/az.purview/update-azpurviewaccount
schema: 2.0.0
---

# Update-AzPurviewAccount

## SYNOPSIS
Updates an account

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzPurviewAccount -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ManagedResourceGroupName <String>] [-PublicNetworkAccess <PublicNetworkAccess>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzPurviewAccount -InputObject <IPurviewIdentity> [-ManagedResourceGroupName <String>]
 [-PublicNetworkAccess <PublicNetworkAccess>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates an account

## EXAMPLES

### Example 1: Update a purview account
```powershell
Update-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg -Tag @{"k"="v"} | Format-List
```

```output
CloudConnectorAwsExternalId      : xxxxxxxxxx-d074-4f8f-9d7f-10811b250738
CreatedAt                        : 8/17/2021 6:18:57 AM
CreatedBy                        : xxxxx.xxxxx@microsoft.com
CreatedByObjectId                : xxxxxxx-5be9-4f43-abd2-04561777c8b0
EndpointCatalog                  : https://test-pa.catalog.purview.azure.com
EndpointGuardian                 : https://test-pa.guardian.purview.azure.com
EndpointScan                     : https://test-pa.scan.purview.azure.com
FriendlyName                     : test-pa
Id                               : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/test-rg/providers/Microsoft.Purview/a 
                                   ccounts/test-pa
Identity                         : {
                                     "principalId": "xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7",
                                     "tenantId": "xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a",
                                     "type": "SystemAssigned"
                                   }
IdentityPrincipalId              : xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7
IdentityTenantId                 : xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a
IdentityType                     : SystemAssigned
Location                         : eastus
ManagedResourceEventHubNamespace : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/managed-rg-bbcpgdj/providers/Microso 
                                   ft.EventHub/namespaces/Atlas-2bb7cf0b-5348-4811-a336-759242a25d37
ManagedResourceGroup             : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/managed-rg-bbcpgdj
ManagedResourceGroupName         : managed-rg-bbcpgdj
ManagedResourceStorageAccount    : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/managed-rg-bbcpgdj/providers/Microso 
                                   ft.Storage/storageAccounts/scaneastusnkcccgc
Name                             : test-pa
PrivateEndpointConnection        : {}
ProvisioningState                : Succeeded
PublicNetworkAccess              : Enabled
ResourceGroupName                : test-rg
SkuCapacity                      : 1
SkuName                          : Standard
SystemData                       : {
                                     "createdAt": "2021-08-17T06:18:57.7274115Z",
                                     "createdBy": "xxxxx.xxxxx@microsoft.com",
                                     "createdByType": "User",
                                     "lastModifiedAt": "xxxxxx-08-17T06:18:57.7274115Z",
                                     "lastModifiedBy": "xxxxx.xxxxx@microsoft.com",
                                     "lastModifiedByType": "User"
                                   }
SystemDataCreatedAt              : 8/17/2021 6:18:57 AM
SystemDataCreatedBy              : xxxxx.xxxxx@microsoft.com
SystemDataCreatedByType          : User
SystemDataLastModifiedAt         : 8/17/2021 6:18:57 AM
SystemDataLastModifiedBy         : xxxxxx.xxxxx@microsoft.com
SystemDataLastModifiedByType     : User
Tag                              : {
                                     "k": "v"
                                   }
Type                             : Microsoft.Purview/account
```

Update the tag of a purview account named 'test-pa'

### Example 2: Update a purview account by InputObject
```powershell
$get = Get-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg 
Update-AzPurviewAccount -InputObject $get -Tag @{"k"="v"}
```

```output
CloudConnectorAwsExternalId      : xxxxxxxxxx-d074-4f8f-9d7f-10811b250738
CreatedAt                        : 8/17/2021 6:18:57 AM
CreatedBy                        : xxxxx.xxxxx@microsoft.com
CreatedByObjectId                : xxxxxxx-5be9-4f43-abd2-04561777c8b0
EndpointCatalog                  : https://test-pa.catalog.purview.azure.com
EndpointGuardian                 : https://test-pa.guardian.purview.azure.com
EndpointScan                     : https://test-pa.scan.purview.azure.com
FriendlyName                     : test-pa
Id                               : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/test-rg/providers/Microsoft.Purview/a 
                                   ccounts/test-pa
Identity                         : {
                                     "principalId": "xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7",
                                     "tenantId": "xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a",
                                     "type": "SystemAssigned"
                                   }
IdentityPrincipalId              : xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7
IdentityTenantId                 : xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a
IdentityType                     : SystemAssigned
Location                         : eastus
ManagedResourceEventHubNamespace : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/managed-rg-bbcpgdj/providers/Microso 
                                   ft.EventHub/namespaces/Atlas-2bb7cf0b-5348-4811-a336-759242a25d37
ManagedResourceGroup             : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/managed-rg-bbcpgdj
ManagedResourceGroupName         : managed-rg-bbcpgdj
ManagedResourceStorageAccount    : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/managed-rg-bbcpgdj/providers/Microso 
                                   ft.Storage/storageAccounts/scaneastusnkcccgc
Name                             : test-pa
PrivateEndpointConnection        : {}
ProvisioningState                : Succeeded
PublicNetworkAccess              : Enabled
ResourceGroupName                : test-rg
SkuCapacity                      : 1
SkuName                          : Standard
SystemData                       : {
                                     "createdAt": "2021-08-17T06:18:57.7274115Z",
                                     "createdBy": "xxxxx.xxxxx@microsoft.com",
                                     "createdByType": "User",
                                     "lastModifiedAt": "xxxxxx-08-17T06:18:57.7274115Z",
                                     "lastModifiedBy": "xxxxx.xxxxx@microsoft.com",
                                     "lastModifiedByType": "User"
                                   }
SystemDataCreatedAt              : 8/17/2021 6:18:57 AM
SystemDataCreatedBy              : xxxxx.xxxxx@microsoft.com
SystemDataCreatedByType          : User
SystemDataLastModifiedAt         : 8/17/2021 6:18:57 AM
SystemDataLastModifiedBy         : xxxxxx.xxxxx@microsoft.com
SystemDataLastModifiedByType     : User
Tag                              : {
                                     "k": "v"
                                   }
Type                             : Microsoft.Purview/account
```

Update the tag of a purview account named 'test-pa' by InputObject

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.IPurviewIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagedResourceGroupName
Gets or sets the managed resource group name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the account.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: AccountName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicNetworkAccess
Gets or sets the public network access.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.PublicNetworkAccess
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription identifier

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Tags on the azure resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.IPurviewIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccount

## NOTES

## RELATED LINKS
