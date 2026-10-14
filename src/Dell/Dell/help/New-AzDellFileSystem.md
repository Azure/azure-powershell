---
external help file: Az.Dell-help.xml
Module Name: Az.Dell
online version: https://learn.microsoft.com/powershell/module/az.dell/new-azdellfilesystem
schema: 2.0.0
---

# New-AzDellFileSystem

## SYNOPSIS
Create a FileSystemResource

## SYNTAX

### CreateExpanded (Default)
```
New-AzDellFileSystem -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -Location <String>
 [-CapacityCurrent <String>] [-CapacityIncremental <String>] [-CapacityMax <String>] [-CapacityMin <String>]
 [-DelegatedSubnetCidr <String>] [-DelegatedSubnetId <String>] [-DellReferenceNumber <String>]
 [-EnableSystemAssignedIdentity] [-EncryptionIdentityPropertyIdentityResourceId <String>]
 [-EncryptionIdentityPropertyIdentityType <String>] [-EncryptionKeyUrl <String>] [-EncryptionType <String>]
 [-FileSystemId <String>] [-MarketplaceEndDate <String>] [-MarketplaceOfferId <String>]
 [-MarketplacePlanId <String>] [-MarketplacePlanName <String>] [-MarketplacePrivateOfferId <String>]
 [-MarketplacePublisherId <String>] [-MarketplaceSubscriptionId <String>] [-MarketplaceTermUnit <String>]
 [-OneFsUrl <String>] [-SmartConnectFqdn <String>] [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>]
 [-UserEmail <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDellFileSystem -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDellFileSystem -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a FileSystemResource

## EXAMPLES

### Example 1: Create a Dell filesystem resource
```powershell
New-AzDellFileSystem -Name biswadeep-test-rss -ResourceGroupName biswadeep-test-rg -SubscriptionId fc35d936-3b89-41f8-8110-a24b56826c37 -Location "eastus" -DelegatedSubnetId "/subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/pp-test/providers/Microsoft.Network/virtualNetworks/dell-test/subnets/default" -DelegatedSubnetCidr "10.0.0.0/24" -UserEmail "dummy@example.com" -DellReferenceNumber "12345" -EncryptionType "Microsoft-managed keys (MMK)" -MarketplaceOfferId "dell-managed-powerscale-for-azure" -MarketplacePlanId "plus1" -MarketplacePublisherId "dellemc" -MarketplacePlanName "Plus Plan" -MarketplaceTermUnit "P1Y" -MarketplaceSubscriptionId "00000000-0000-0000-0000-000000000000" -Tag @{"bypassPartner"="true"}
```

```output
CapacityCurrent                              :
CapacityIncremental                          :
CapacityMax                                  :
CapacityMin                                  :
DelegatedSubnetCidr                          : 10.0.0.0/24
DelegatedSubnetId                            : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/pp-te
                                               st/providers/Microsoft.Network/virtualNetworks/dell-test/subnets/default
DellReferenceNumber                          : 12345
EncryptionIdentityPropertyIdentityResourceId :
EncryptionIdentityPropertyIdentityType       :
EncryptionKeyUrl                             :
EncryptionType                               : Microsoft-managed keys (MMK)
FileSystemId                                 : PartnerBypassed
Id                                           : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/biswa
                                               deep-test-rg/providers/Dell.Storage/filesystems/biswadeep-test-rss
IdentityPrincipalId                          :
IdentityTenantId                             :
IdentityType                                 :
IdentityUserAssignedIdentity                 : {
                                               }
Location                                     : eastus
MarketplaceEndDate                           :
MarketplaceOfferId                           : dell-managed-powerscale-for-azure
MarketplacePlanId                            : plus1
MarketplacePlanName                          : Plus Plan
MarketplacePrivateOfferId                    :
MarketplacePublisherId                       : dellemc
MarketplaceSubscriptionId                    : 44ca4cc4-327f-4490-d051-2d2a6242a886
MarketplaceSubscriptionStatus                : Subscribed
MarketplaceTermUnit                          : P1Y
Name                                         : biswadeep-test-rss
OneFsUrl                                     :
ProvisioningState                            : Succeeded
ResourceGroupName                            : biswadeep-test-rg
SmartConnectFqdn                             :
SystemDataCreatedAt                          : 7/23/2026 5:39:14 AM
SystemDataCreatedBy                          : dummy@example.com
SystemDataCreatedByType                      : User
SystemDataLastModifiedAt                     : 7/23/2026 5:39:14 AM
SystemDataLastModifiedBy                     : dummy@example.com
SystemDataLastModifiedByType                 : User
Tag                                          : {
                                                 "bypassPartner": "true"
                                               }
Type                                         : dell.storage/filesystems
UserEmail                                    :
```

Creates a new Dell filesystem resource with networking configuration.

### Example 2: Create a Dell filesystem resource using a JSON file
```powershell
New-AzDellFileSystem -Name biswadeep-test-rss-2 -ResourceGroupName biswadeep-test-rg -SubscriptionId fc35d936-3b89-41f8-8110-a24b56826c37 -JsonFilePath ".\examples\dell-filesystem.json"
```

```output
CapacityCurrent                              :
CapacityIncremental                          :
CapacityMax                                  :
CapacityMin                                  :
DelegatedSubnetCidr                          : 10.0.0.0/24
DelegatedSubnetId                            : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/pp-te
                                               st/providers/Microsoft.Network/virtualNetworks/dell-test/subnets/default
DellReferenceNumber                          : 12345
EncryptionIdentityPropertyIdentityResourceId :
EncryptionIdentityPropertyIdentityType       :
EncryptionKeyUrl                             :
EncryptionType                               : Microsoft-managed keys (MMK)
FileSystemId                                 : PartnerBypassed
Id                                           : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/biswa
                                               deep-test-rg/providers/Dell.Storage/filesystems/biswadeep-test-rss-2
IdentityPrincipalId                          :
IdentityTenantId                             :
IdentityType                                 :
IdentityUserAssignedIdentity                 : {
                                               }
Location                                     : eastus
MarketplaceEndDate                           :
MarketplaceOfferId                           : dell-managed-powerscale-for-azure
MarketplacePlanId                            : plus1
MarketplacePlanName                          : Plus Plan
MarketplacePrivateOfferId                    :
MarketplacePublisherId                       : dellemc
MarketplaceSubscriptionId                    : d52f9ff3-853c-4c5b-dd90-f08126e3b187
MarketplaceSubscriptionStatus                : Subscribed
MarketplaceTermUnit                          : P1Y
Name                                         : biswadeep-test-rss-2
OneFsUrl                                     :
ProvisioningState                            : Succeeded
ResourceGroupName                            : biswadeep-test-rg
SmartConnectFqdn                             :
SystemDataCreatedAt                          : 7/23/2026 6:03:31 AM
SystemDataCreatedBy                          : dummy@example.com
SystemDataCreatedByType                      : User
SystemDataLastModifiedAt                     : 7/23/2026 6:03:31 AM
SystemDataLastModifiedBy                     : dummy@example.com
SystemDataLastModifiedByType                 : User
Tag                                          : {
                                                 "bypassPartner": "true"
                                               }
Type                                         : dell.storage/filesystems
UserEmail                                    :
```

Creates a Dell filesystem resource from a JSON file.
See `dell-filesystem.json` in the examples folder for the expected JSON format.

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

### -CapacityCurrent
Current Capacity of the resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CapacityIncremental
Units to be increased

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CapacityMax
Maximum Capacity

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CapacityMin
Minimum Capacity

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### -DelegatedSubnetCidr
Domain range for the delegated subnet

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DelegatedSubnetId
Delegated subnet id for Vnet injection

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DellReferenceNumber
DellReferenceNumber of the resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionIdentityPropertyIdentityResourceId
User-assigned identity resource id - Only when user opts for UserAssigned identity and hence optional

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionIdentityPropertyIdentityType
Identity type - SystemAssigned/UserAssigned - Only UserAssigned is supported now

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionKeyUrl
Versioned Encryption Key Url - Only when user opts for CMK and hence optional

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionType
Encryption Type - MMK/CMK

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileSystemId
File system Id of the resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceEndDate
End Date of the subscription

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceOfferId
Offer Id

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplacePlanId
Plan Id

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplacePlanName
Plan Name

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplacePrivateOfferId
Private Offer Id

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplacePublisherId
Publisher Id

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceSubscriptionId
Marketplace Subscription Id

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceTermUnit
Term Unit

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the filesystem resource

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: FilesystemName

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

### -OneFsUrl
OneFS url

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SmartConnectFqdn
Smart Connect FQDN of the resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserEmail
User Email

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Dell.Models.ILiftrBaseStorageFileSystemResource

## NOTES

## RELATED LINKS
