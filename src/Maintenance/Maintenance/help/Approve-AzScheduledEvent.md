---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Maintenance.dll-Help.xml
Module Name: Az.Maintenance
online version: https://learn.microsoft.com/powershell/module/az.maintenance/approve-azscheduledevent
schema: 2.0.0
---

# Approve-AzScheduledEvent

## SYNOPSIS

Approves an event in the ScheduledEvents for a resource.

## SYNTAX

```powershell
Approve-AzScheduledEvent [-ResourceGroupName] <String> [-ResourceType] <String> [-ResourceName] <String>
 [-ScheduledEventId] <String> [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION

Approves an event in the ScheduledEvents for a virtual machine, virtual machine scale set, or availability set.
On success, the cmdlet returns a ScheduledEvents approval response.
If the service rejects the request, the cmdlet returns a structured error response containing the service-defined code and message.
The default console view renders the error response as JSON, but the pipeline receives a structured object whose values are available through the `Error.Code` and `Error.Message` properties.

## EXAMPLES

### Example 1

```powershell
Approve-AzScheduledEvent -ResourceGroupName 'example-rg' -ResourceType 'virtualMachines' -ResourceName 'example-vm' -ScheduledEventId '11111111-1111-1111-1111-111111111111' -Confirm:$false
```

```output
Value
-----
Successfully approved scheduled event
```

Approves the specified ScheduledEvents entry for a virtual machine and returns the service response.

### Example 2: Inspect a non-success response

```powershell
$response = Approve-AzScheduledEvent -ResourceGroupName 'example-rg' -ResourceType 'virtualMachineScaleSets' -ResourceName 'example-vmss' -ScheduledEventId '22222222-2222-2222-2222-222222222222' -Confirm:$false
$response
```

```output
{
	"Error": {
		"Code": "InvalidScheduledEventId",
		"Message": "Scheduled event not found"
	}
}
```

Attempts to approve a ScheduledEvents entry and displays the non-success response as JSON.
The pipeline value remains a structured object whose code and message are available through `$response.Error.Code` and `$response.Error.Message`.

## PARAMETERS

### -AcquirePolicyToken

Acquire an Azure Policy token automatically for this resource operation.

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

### -ChangeReference

The change reference resource ID for this resource operation.

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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction

{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName

The resource Group Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceName

The resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceType

The Microsoft.Compute resource type that owns the ScheduledEvents.
Supported values are `virtualMachines`, `virtualMachineScaleSets`, and `availabilitySets`.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ScheduledEventId

The ScheduledEvents ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### System.String

## OUTPUTS

### Microsoft.Azure.Management.Maintenance.Models.ScheduledEventsApproveResponse

### Microsoft.Azure.Management.Maintenance.Models.MaintenanceError

## NOTES

## RELATED LINKS
