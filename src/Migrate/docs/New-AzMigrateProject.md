---
external help file:
Module Name: Az.Migrate
online version: https://docs.microsoft.com/en-us/powershell/module/az.migrate/new-azmigrateproject
schema: 2.0.0
---

# New-AzMigrateProject

## SYNOPSIS
Method to create or update a migrate project.

## SYNTAX

### PutExpanded (Default)
```
New-AzMigrateProject -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AcceptLanguage <String>] [-ETag <String>] [-Location <String>] [-ProvisioningState <ProvisioningState>]
 [-RegisteredTool <String[]>] [-TagAdditionalProperty <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Put
```
New-AzMigrateProject -Name <String> -ResourceGroupName <String> -Body <IMigrateProject>
 [-SubscriptionId <String>] [-AcceptLanguage <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### PutViaIdentity
```
New-AzMigrateProject -InputObject <IMigrateIdentity> -Body <IMigrateProject> [-AcceptLanguage <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PutViaIdentityExpanded
```
New-AzMigrateProject -InputObject <IMigrateIdentity> [-AcceptLanguage <String>] [-ETag <String>]
 [-Location <String>] [-ProvisioningState <ProvisioningState>] [-RegisteredTool <String[]>]
 [-TagAdditionalProperty <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Method to create or update a migrate project.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AcceptLanguage
Standard request header.
Used by service to respond to client in appropriate language.

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

### -Body
Migrate Project REST Resource.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateProject
Parameter Sets: Put, PutViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -ETag
Gets or sets the eTag for concurrency control.

```yaml
Type: System.String
Parameter Sets: PutExpanded, PutViaIdentityExpanded
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IMigrateIdentity
Parameter Sets: PutViaIdentity, PutViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Gets or sets the Azure location in which migrate project is created.

```yaml
Type: System.String
Parameter Sets: PutExpanded, PutViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Azure Migrate project.

```yaml
Type: System.String
Parameter Sets: Put, PutExpanded
Aliases: MigrateProjectName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisioningState
Provisioning state of the migrate project.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.ProvisioningState
Parameter Sets: PutExpanded, PutViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegisteredTool
Gets or sets the list of tools registered with the migrate project.

```yaml
Type: System.String[]
Parameter Sets: PutExpanded, PutViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Azure Resource Group that migrate project is part of.

```yaml
Type: System.String
Parameter Sets: Put, PutExpanded
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
Parameter Sets: Put, PutExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TagAdditionalProperty
.

```yaml
Type: System.String
Parameter Sets: PutExpanded, PutViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateProject

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IMigrateIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateProject

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BODY <IMigrateProject>: Migrate Project REST Resource.
  - `[ETag <String>]`: Gets or sets the eTag for concurrency control.
  - `[Location <String>]`: Gets or sets the Azure location in which migrate project is created.
  - `[ProvisioningState <ProvisioningState?>]`: Provisioning state of the migrate project.
  - `[RegisteredTool <String[]>]`: Gets or sets the list of tools registered with the migrate project.
  - `[TagAdditionalProperty <String>]`: 

INPUTOBJECT <IMigrateIdentity>: Identity Parameter
  - `[AccountName <String>]`: Run as account ARM name.
  - `[AlertSettingName <String>]`: The name of the email notification configuration.
  - `[ClusterName <String>]`: Cluster ARM name.
  - `[DatabaseInstanceName <String>]`: Unique name of a database instance in Azure migration hub.
  - `[DatabaseName <String>]`: Unique name of a database in Azure migration hub.
  - `[EventName <String>]`: Unique name of an event within a migrate project.
  - `[FabricName <String>]`: Fabric unique name.
  - `[HostName <String>]`: Host ARM name.
  - `[Id <String>]`: Resource identity path
  - `[JobName <String>]`: Job identifier
  - `[LogicalNetworkName <String>]`: Logical network name.
  - `[MachineName <String>]`: Machine ARM name.
  - `[MappingName <String>]`: Protection Container mapping name.
  - `[MigrateProjectName <String>]`: Name of the Azure Migrate project.
  - `[MigrationItemName <String>]`: Migration item name.
  - `[MigrationRecoveryPointName <String>]`: The migration recovery point name.
  - `[NetworkMappingName <String>]`: Network mapping name.
  - `[NetworkName <String>]`: Primary network name.
  - `[OperationStatusName <String>]`: Operation status ARM name.
  - `[PolicyName <String>]`: Replication policy name.
  - `[ProtectableItemName <String>]`: Protectable item name.
  - `[ProtectionContainerName <String>]`: Protection container name.
  - `[ProviderName <String>]`: Recovery services provider name
  - `[RecoveryPlanName <String>]`: Name of the recovery plan.
  - `[RecoveryPointName <String>]`: The recovery point name.
  - `[ReplicatedProtectedItemName <String>]`: Replication protected item name.
  - `[ReplicationProtectedItemName <String>]`: The name of the protected item on which the agent is to be updated.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ResourceName <String>]`: The name of the recovery services vault.
  - `[SiteName <String>]`: Site name.
  - `[SolutionName <String>]`: Unique name of a migration solution within a migrate project.
  - `[StorageClassificationMappingName <String>]`: Storage classification mapping name.
  - `[StorageClassificationName <String>]`: Storage classification name.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VCenterName <String>]`: vCenter name.
  - `[VcenterName <String>]`: VCenter ARM name.

## RELATED LINKS

