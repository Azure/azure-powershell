---
external help file:
Module Name: Az.GuestConfiguration
online version: https://docs.microsoft.com/en-us/powershell/module/az.guestconfiguration/new-azguestconfigurationassignment
schema: 2.0.0
---

# New-AzGuestConfigurationAssignment

## SYNOPSIS
Creates an association between a VM and guest configuration

## SYNTAX

```
New-AzGuestConfigurationAssignment -GuestConfigurationAssignmentName <String> -ResourceGroupName <String>
 -VMName <String> [-SubscriptionId <String>] [-Context <String>]
 [-GuestConfigurationAssignmentType <AssignmentType>] [-GuestConfigurationContentHash <String>]
 [-GuestConfigurationContentUri <String>] [-GuestConfigurationKind <Kind>] [-GuestConfigurationName <String>]
 [-GuestConfigurationParameter <IConfigurationParameter[]>]
 [-GuestConfigurationProtectedParameter <IConfigurationParameter[]>] [-GuestConfigurationVersion <String>]
 [-LatestAssignmentReportResource <IAssignmentReportResource[]>] [-Location <String>] [-Name <String>]
 [-VmssVMList <IVmssvmInfo[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates an association between a VM and guest configuration

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

### -Context
The source which initiated the guest configuration assignment.
Ex: Azure Policy

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

### -GuestConfigurationAssignmentName
Name of the guest configuration assignment.

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

### -GuestConfigurationAssignmentType
Specifies the assignment type and execution of the configuration.
Possible values are Audit, DeployAndAutoCorrect, ApplyAndAutoCorrect and ApplyAndMonitor.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Support.AssignmentType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GuestConfigurationContentHash
Combined hash of the guest configuration package and configuration parameters.

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

### -GuestConfigurationContentUri
Uri of the storage where guest configuration package is uploaded.

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

### -GuestConfigurationKind
Kind of the guest configuration.
For example:DSC

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Support.Kind
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GuestConfigurationName
Name of the guest configuration.

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

### -GuestConfigurationParameter
The configuration parameters for the guest configuration.
To construct, see NOTES section for GUESTCONFIGURATIONPARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.Api20220125.IConfigurationParameter[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GuestConfigurationProtectedParameter
The protected configuration parameters for the guest configuration.
To construct, see NOTES section for GUESTCONFIGURATIONPROTECTEDPARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.Api20220125.IConfigurationParameter[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GuestConfigurationVersion
Version of the guest configuration.

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

### -LatestAssignmentReportResource
The list of resources for which guest configuration assignment compliance is checked.
To construct, see NOTES section for LATESTASSIGNMENTREPORTRESOURCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.Api20220125.IAssignmentReportResource[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Region where the VM is located.

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
Name of the guest configuration assignment.

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

### -ResourceGroupName
The resource group name.

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

### -SubscriptionId
Subscription ID which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### -VMName
The name of the virtual machine.

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

### -VmssVMList
The list of VM Compliance data for VMSS

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.Api20220125.IVmssvmInfo[]
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.Api20220125.IGuestConfigurationAssignment

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


GUESTCONFIGURATIONPARAMETER <IConfigurationParameter[]>: The configuration parameters for the guest configuration.
  - `[Name <String>]`: Name of the configuration parameter.
  - `[Value <String>]`: Value of the configuration parameter.

GUESTCONFIGURATIONPROTECTEDPARAMETER <IConfigurationParameter[]>: The protected configuration parameters for the guest configuration.
  - `[Name <String>]`: Name of the configuration parameter.
  - `[Value <String>]`: Value of the configuration parameter.

LATESTASSIGNMENTREPORTRESOURCE <IAssignmentReportResource[]>: The list of resources for which guest configuration assignment compliance is checked.
  - `[Reason <IAssignmentReportResourceComplianceReason[]>]`: Compliance reason and reason code for a resource.

## RELATED LINKS

