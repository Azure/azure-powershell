---
external help file:
Module Name: Az.MigrateV2
online version: https://docs.microsoft.com/en-us/powershell/module/az.migratev2/get-azmigratev2machine
schema: 2.0.0
---

# Get-AzMigrateV2Machine

## SYNOPSIS
Get the machine with the specified name.
Returns a json object of type 'machine' defined in Models section.

## SYNTAX

### List (Default)
```
Get-AzMigrateV2Machine -ProjectName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMigrateV2Machine -Name <String> -ProjectName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMigrateV2Machine -InputObject <IMigrateV2Identity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the machine with the specified name.
Returns a json object of type 'machine' defined in Models section.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MigrateV2.Models.IMigrateV2Identity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Unique name of a machine in private datacenter.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: MachineName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
Name of the Azure Migrate project.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Azure Resource Group that project is part of.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription Id in which project was created.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MigrateV2.Models.IMigrateV2Identity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MigrateV2.Models.Api20191001.IMachine

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IMigrateV2Identity>: Identity Parameter
  - `[AssessedMachineName <String>]`: Unique name of an assessed machine evaluated as part of an assessment.
  - `[AssessmentName <String>]`: Unique name of an assessment within a project.
  - `[AssessmentOptionsName <String>]`: Name of the assessment options. The only name accepted in default.
  - `[GroupName <String>]`: Unique name of a group within a project.
  - `[HyperVCollectorName <String>]`: Unique name of a Hyper-V collector within a project.
  - `[Id <String>]`: Resource identity path
  - `[ImportCollectorName <String>]`: Unique name of a Import collector within a project.
  - `[MachineName <String>]`: Unique name of a machine in private datacenter.
  - `[PrivateEndpointConnectionName <String>]`: Unique name of a private endpoint connection within a project.
  - `[PrivateLinkResourceName <String>]`: Unique name of a private link resource within a project.
  - `[ProjectName <String>]`: Name of the Azure Migrate project.
  - `[ResourceGroupName <String>]`: Name of the Azure Resource Group that project is part of.
  - `[ServerCollectorName <String>]`: Unique name of a Server collector within a project.
  - `[SubscriptionId <String>]`: Azure Subscription Id in which project was created.
  - `[VMWareCollectorName <String>]`: Unique name of a VMware collector within a project.

## RELATED LINKS

