---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/move-azcdnprofiletoafd
schema: 2.0.0
---

# Move-AzCdnProfileToAFD

## SYNOPSIS
Migrate the CDN profile to Azure Frontdoor(Standard/Premium) profile.
This step prepares the profile for migration and will be followed by Commit to finalize the migration.

## SYNTAX

### MigrateExpanded (Default)
```
Move-AzCdnProfileToAFD -ProfileName <String> -ResourceGroupName <String> [-IdentityType <String>]
 [-SubscriptionId <String>] [-MigrationEndpointMapping <IMigrationEndpointMapping[]>] [-SkuName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Migrate
```
Move-AzCdnProfileToAFD -ProfileName <String> -ResourceGroupName <String>
 -MigrationParameter <ICdnMigrationToAfdParameters> [-IdentityType <String>] [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MigrateViaIdentity
```
Move-AzCdnProfileToAFD -InputObject <ICdnIdentity> -MigrationParameter <ICdnMigrationToAfdParameters>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MigrateViaIdentityExpanded
```
Move-AzCdnProfileToAFD -InputObject <ICdnIdentity> [-MigrationEndpointMapping <IMigrationEndpointMapping[]>]
 [-SkuName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MigrateViaJsonFilePath
```
Move-AzCdnProfileToAFD -ProfileName <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-IdentityType <String>] [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### MigrateViaJsonString
```
Move-AzCdnProfileToAFD -ProfileName <String> -ResourceGroupName <String> -JsonString <String>
 [-IdentityType <String>] [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Migrate the CDN profile to Azure Frontdoor(Standard/Premium) profile.
This step prepares the profile for migration and will be followed by Commit to finalize the migration.

## EXAMPLES

### Example 1: Start a migration
```powershell
$map1 = New-AzCdnMigrationEndpointMappingObject -MigratedFrom maxtestendpointcli-test-profile1.azureedge.net -MigratedTo maxtestendpointcli-test-profile2

Move-AzCdnProfileToAFD -ProfileName cli-test-profile -ResourceGroupName cli-test-rg -SkuName Premium_AzureFrontDoor -MigrationEndpointMapping @($map1)
```

```output
Start the initial progress of migration of CDN profile to Azure Front Door.

Migration of endpoint completed.

MigratedProfileResourceId
-------------------------
/subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups/cli-test-rg/providers/Microsoft.Cdn/profiles/cli-test-profile

Now you can commit the migration to finalize the migration process.
```

The MigrationEndpointMapping parameter used in situation that users want to migrate an endpoint with and old name to a new endpoint name.

### Example 2: Start a migration with managed identity settings.
```powershell
$map1 = New-AzCdnMigrationEndpointMappingObject -MigratedFrom maxtestendpointcli-test-profile1.azureedge.net -MigratedTo maxtestendpointcli-test-profile2

Move-AzCdnProfileToAFD -ProfileName cli-test-profile -ResourceGroupName cli-test-rg -SkuName Premium_AzureFrontDoor -MigrationEndpointMapping @($map1) -IdentityType "SystemAssigned"
```

```output
Start the initial progress of migration of CDN profile to Azure Front Door.

Migration of endpoint completed.
Now enabling managed identity.
MigratedProfileResourceId
-------------------------
/subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups/cli-test-rg/providers/Microsoft.Cdn/profiles/cli-test-profile

ExtendedProperty             : {
                                 "Sku": "Premium_AzureFrontDoor"
                               }
FrontDoorId                  :
Id                           : /subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourcegroups/cli-test-rg/providers/Microsoft.Cdn/profiles/cli-test-profile
IdentityPrincipalId          : 97fdf684-e1c7-431d-af54-a11c7443707d
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
IdentityUserAssignedIdentity : {
                               }
Kind                         : cdn
Location                     : Global
LogScrubbingRule             :
LogScrubbingState            :
Name                         : cli-test-profile
OriginResponseTimeoutSecond  :
ProvisioningState            : Succeeded
ResourceGroupName            : cli-test-rg
ResourceState                : Migrating
SkuName                      : Standard_Microsoft
SystemData                   : {
                               }
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.Cdn/profiles

Now you can commit the migration to finalize the migration process.
```

The MigrationEndpointMapping parameter used in situation that users want to migrate an endpoint with and old name to a new endpoint name.

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

### -IdentityType
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: Migrate, MigrateExpanded, MigrateViaJsonFilePath, MigrateViaJsonString
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: MigrateViaIdentity, MigrateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Migrate operation

```yaml
Type: System.String
Parameter Sets: MigrateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Migrate operation

```yaml
Type: System.String
Parameter Sets: MigrateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MigrationEndpointMapping
A name map between classic CDN endpoints and AFD Premium/Standard endpoints.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IMigrationEndpointMapping[]
Parameter Sets: MigrateExpanded, MigrateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MigrationParameter
Request body for Migrate operation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnMigrationToAfdParameters
Parameter Sets: Migrate, MigrateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ProfileName
Name of the Azure Front Door Standard or Azure Front Door Premium which is unique within the resource group.

```yaml
Type: System.String
Parameter Sets: Migrate, MigrateExpanded, MigrateViaJsonFilePath, MigrateViaJsonString
Aliases:

Required: True
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
Parameter Sets: Migrate, MigrateExpanded, MigrateViaJsonFilePath, MigrateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Name of the pricing tier.

```yaml
Type: System.String
Parameter Sets: MigrateExpanded, MigrateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: Migrate, MigrateExpanded, MigrateViaJsonFilePath, MigrateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnMigrationToAfdParameters

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IMigrateResult

## NOTES

## RELATED LINKS

