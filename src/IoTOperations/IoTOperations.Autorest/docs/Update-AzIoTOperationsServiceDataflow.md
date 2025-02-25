---
external help file:
Module Name: Az.IoTOperationsService
online version: https://learn.microsoft.com/powershell/module/az.iotoperationsservice/update-aziotoperationsservicedataflow
schema: 2.0.0
---

# Update-AzIoTOperationsServiceDataflow

## SYNOPSIS
update a DataflowResource

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzIoTOperationsServiceDataflow -InstanceName <String> -Name <String> -ProfileName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-Mode <String>] [-Operation <IDataflowOperation[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzIoTOperationsServiceDataflow -InstanceName <String> -Name <String> -ProfileName <String>
 -ResourceGroupName <String> -Resource <IDataflowResource> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzIoTOperationsServiceDataflow -InputObject <IIoTOperationsServiceIdentity>
 -Resource <IDataflowResource> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityDataflowProfile
```
Update-AzIoTOperationsServiceDataflow -DataflowProfileInputObject <IIoTOperationsServiceIdentity>
 -Name <String> -Resource <IDataflowResource> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityDataflowProfileExpanded
```
Update-AzIoTOperationsServiceDataflow -DataflowProfileInputObject <IIoTOperationsServiceIdentity>
 -Name <String> [-Mode <String>] [-Operation <IDataflowOperation[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzIoTOperationsServiceDataflow -InputObject <IIoTOperationsServiceIdentity> [-Mode <String>]
 [-Operation <IDataflowOperation[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityInstance
```
Update-AzIoTOperationsServiceDataflow -InstanceInputObject <IIoTOperationsServiceIdentity> -Name <String>
 -ProfileName <String> -Resource <IDataflowResource> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityInstanceExpanded
```
Update-AzIoTOperationsServiceDataflow -InstanceInputObject <IIoTOperationsServiceIdentity> -Name <String>
 -ProfileName <String> [-Mode <String>] [-Operation <IDataflowOperation[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
update a DataflowResource

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

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

### -DataflowProfileInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
Parameter Sets: UpdateViaIdentityDataflowProfile, UpdateViaIdentityDataflowProfileExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
Parameter Sets: UpdateViaIdentityInstance, UpdateViaIdentityInstanceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceName
Name of instance.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Mode
Mode for Dataflow.
Optional; defaults to Enabled.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityDataflowProfileExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityInstanceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of Instance dataflowProfile dataflow resource

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaIdentityDataflowProfile, UpdateViaIdentityDataflowProfileExpanded, UpdateViaIdentityInstance, UpdateViaIdentityInstanceExpanded
Aliases: DataflowName

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

### -Operation
List of operations including source and destination references as well as transformation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IDataflowOperation[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityDataflowProfileExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityInstanceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileName
Name of Instance dataflowProfile resource

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaIdentityInstance, UpdateViaIdentityInstanceExpanded
Aliases: DataflowProfileName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
Instance dataflowProfile dataflow resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IDataflowResource
Parameter Sets: Update, UpdateViaIdentity, UpdateViaIdentityDataflowProfile, UpdateViaIdentityInstance
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
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
Parameter Sets: Update, UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IDataflowResource

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IDataflowResource

## NOTES

## RELATED LINKS

