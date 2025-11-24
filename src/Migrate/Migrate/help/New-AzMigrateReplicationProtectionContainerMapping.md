---
external help file: Az.Migrate-help.xml
Module Name: Az.Migrate
online version: https://learn.microsoft.com/powershell/module/az.migrate/new-azmigratereplicationprotectioncontainermapping
schema: 2.0.0
---

# New-AzMigrateReplicationProtectionContainerMapping

## SYNOPSIS
The operation to create a protection container mapping.

## SYNTAX

### CreateExpanded (Default)
```
New-AzMigrateReplicationProtectionContainerMapping -MappingName <String> -FabricName <String>
 -ProtectionContainerName <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] [-PolicyId <String>]
 [-ProviderSpecificInput <IReplicationProviderSpecificContainerMappingInput>]
 [-TargetProtectionContainerId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzMigrateReplicationProtectionContainerMapping -MappingName <String> -FabricName <String>
 -ProtectionContainerName <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzMigrateReplicationProtectionContainerMapping -MappingName <String> -FabricName <String>
 -ProtectionContainerName <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityReplicationFabricExpanded
```
New-AzMigrateReplicationProtectionContainerMapping -MappingName <String> -ProtectionContainerName <String>
 -ReplicationFabricInputObject <IMigrateIdentity> [-PolicyId <String>]
 [-ProviderSpecificInput <IReplicationProviderSpecificContainerMappingInput>]
 [-TargetProtectionContainerId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityReplicationProtectionContainerExpanded
```
New-AzMigrateReplicationProtectionContainerMapping -MappingName <String>
 -ReplicationProtectionContainerInputObject <IMigrateIdentity> [-PolicyId <String>]
 [-ProviderSpecificInput <IReplicationProviderSpecificContainerMappingInput>]
 [-TargetProtectionContainerId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The operation to create a protection container mapping.

## EXAMPLES

### Example 1: Create a mapping
```powershell
$providerSpecificInput = [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareCbtContainerMappingInput]::new()
$providerSpecificInput.InstanceType = "VMwareCbt"
$providerSpecificInput.KeyVaultId = "/subscriptions/xxx-xxx-xxx/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.KeyVault/vaults/migratekv846827101"
$providerSpecificInput.KeyVaultUri = "https://migratekv846827101.vault.azure.net"
$providerSpecificInput.ServiceBusConnectionStringSecretName = "ServiceBusConnectionString"
$providerSpecificInput.StorageAccountId = "/subscriptions/xxx-xxx-xxx/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.Storage/storageAccounts/migrategwsa846827101"
$providerSpecificInput.StorageAccountSasSecretName = "migrategwsa846827101-gwySas"
$providerSpecificInput.TargetLocation = "centraluseuap"

New-AzMigrateReplicationProtectionContainerMapping -FabricName "AzMigratePWSHTc8d1replicationfabric" -MappingName "containermapping" -ProtectionContainerName "AzMigratePWSHTc8d1replicationcontainer" -ResourceGroupName "azmigratepwshtestasr13072020" -ResourceName "AzMigrateTestProjectPWSH02aarsvault"  -PolicyId "/subscriptionsxxx-xxx-xxx/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.RecoveryServices/vaults/AzMigrateTestProjectPWSH02aarsvault/replicationPolicies/migrateAzMigratePWSHTc8d1sitepolicy"  -ProviderSpecificInput $providerSpecificInput -TargetProtectionContainerId  "Microsoft Azure"
```

```output
Location Name             Type
-------- ----             ----
         containermapping Microsoft.RecoveryServices/vaults/replicationFabrics/replicationProtectionContainers/replicationProtectionContainerMappings
```

Create a mapping

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

### -FabricName
Fabric name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
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

### -MappingName
Protection container mapping name.

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

### -PolicyId
Applicable policy.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityReplicationFabricExpanded, CreateViaIdentityReplicationProtectionContainerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProtectionContainerName
Protection container name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityReplicationFabricExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderSpecificInput
Provider specific input for pairing.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IReplicationProviderSpecificContainerMappingInput
Parameter Sets: CreateExpanded, CreateViaIdentityReplicationFabricExpanded, CreateViaIdentityReplicationProtectionContainerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplicationFabricInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IMigrateIdentity
Parameter Sets: CreateViaIdentityReplicationFabricExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ReplicationProtectionContainerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IMigrateIdentity
Parameter Sets: CreateViaIdentityReplicationProtectionContainerExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group where the recovery services vault is present.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The name of the recovery services vault.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription Id in which migrate project was created.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetProtectionContainerId
The target unique protection container name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityReplicationFabricExpanded, CreateViaIdentityReplicationProtectionContainerExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IMigrateIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IProtectionContainerMapping

## NOTES

## RELATED LINKS
