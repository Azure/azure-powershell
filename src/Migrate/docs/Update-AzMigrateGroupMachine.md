---
external help file:
Module Name: Az.Migrate
online version: https://docs.microsoft.com/en-us/powershell/module/az.migrate/update-azmigrategroupmachine
schema: 2.0.0
---

# Update-AzMigrateGroupMachine

## SYNOPSIS
Update machines in group by adding or removing machines.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMigrateGroupMachine -GroupName <String> -ProjectName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AcceptLanguage <String>] [-ETag <String>] [-Machine <String[]>]
 [-OperationType <GroupUpdateOperation>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMigrateGroupMachine -InputObject <IMigrateIdentity> [-AcceptLanguage <String>] [-ETag <String>]
 [-Machine <String[]>] [-OperationType <GroupUpdateOperation>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update machines in group by adding or removing machines.

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
Dynamic: False
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
Dynamic: False
```

### -ETag
For optimistic concurrency control.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GroupName
Unique name of a group within a project.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IMigrateIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Machine
List of machine names that are part of this group.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OperationType
Whether to add or remove the machines.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.GroupUpdateOperation
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ProjectName
Name of the Azure Migrate project.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the Azure Resource Group that project is part of.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Azure Subscription Id in which project was created.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IMigrateIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20191001.IGroup

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### INPUTOBJECT <IMigrateIdentity>: Identity Parameter
  - `[AccountName <String>]`: Run as account ARM name.
  - `[AssessedMachineName <String>]`: Unique name of an assessed machine evaluated as part of an assessment.
  - `[AssessmentName <String>]`: Unique name of an assessment within a project.
  - `[AssessmentOptionsName <String>]`: Name of the assessment options. The only name accepted in default.
  - `[ClusterName <String>]`: Cluster ARM name.
  - `[GroupName <String>]`: Unique name of a group within a project.
  - `[HostName <String>]`: Host ARM name.
  - `[HyperVCollectorName <String>]`: Unique name of a Hyper-V collector within a project.
  - `[Id <String>]`: Resource identity path
  - `[JobName <String>]`: Job ARM name.
  - `[MachineName <String>]`: Machine ARM name.
  - `[OperationStatusName <String>]`: Operation status ARM name.
  - `[ProjectName <String>]`: Name of the Azure Migrate project.
  - `[ResourceGroupName <String>]`: Name of the Azure Resource Group that project is part of.
  - `[SiteName <String>]`: Site name.
  - `[SubscriptionId <String>]`: Azure Subscription Id in which project was created.
  - `[VMWareCollectorName <String>]`: Unique name of a VMware collector within a project.
  - `[VcenterName <String>]`: VCenter ARM name.

## RELATED LINKS

