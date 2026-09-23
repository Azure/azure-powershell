---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Maintenance.dll-Help.xml
Module Name: Az.Maintenance
online version: https://learn.microsoft.com/powershell/module/az.maintenance/approve-azscheduledeventlist
schema: 2.0.0
---

# Approve-AzScheduledEventList

## SYNOPSIS

Approves events in the ScheduledEvents collection for a resource.

## SYNTAX

```powershell
Approve-AzScheduledEventList [-ResourceGroupName] <String> [-ResourceType] <String> [-ResourceName] <String>
 [-ScheduledEventIdList] <String[]> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

## DESCRIPTION

Approves events in the ScheduledEvents for a virtual machine, virtual machine scale set, or availability set.
For HTTP 200, the cmdlet returns a ScheduledEvents approval response.
The service can return HTTP 207 Multi-Status with per-event results, including when all requested events cannot be found.
For that response, the cmdlet returns a structured object containing `Error.Code`, `Error.Message`, and `Error.Details`. Each detail contains the service-supplied `Target`, `Code`, and `Message` for an event.
The default console view renders the multi-status response as JSON, but the pipeline receives a structured object that can be inspected or filtered.
For other non-success responses, the cmdlet returns a structured error response containing the service-defined code and message.

## EXAMPLES

### Example 1

```powershell
Approve-AzScheduledEventList -ResourceGroupName 'example-rg' -ResourceType 'virtualMachineScaleSets' -ResourceName 'example-vmss' -ScheduledEventIdList @('11111111-1111-1111-1111-111111111111', '22222222-2222-2222-2222-222222222222') -Confirm:$false
```

```output
Value
-----
Successfully approved all Scheduled Events in the list
```

Approves the specified ScheduledEvents entries and returns the service response.

### Example 2: Inspect an HTTP 207 Multi-Status response

```powershell
$response = Approve-AzScheduledEventList -ResourceGroupName 'example-rg' -ResourceType 'virtualMachineScaleSets' -ResourceName 'example-vmss' -ScheduledEventIdList @('11111111-1111-1111-1111-111111111111', '33333333-3333-3333-3333-333333333333') -Confirm:$false
$response
```

```output
{
    "Error": {
        "Code": "MultiStatusResponse",
        "Message": "The operation returned different statuses for the Scheduled Events. Review each event's result for details.",
        "Details": [
            {
                "Target": "11111111-1111-1111-1111-111111111111",
                "Code": "NotFound",
                "Message": "Scheduled event not found"
            },
            {
                "Target": "33333333-3333-3333-3333-333333333333",
                "Code": "NotFound",
                "Message": "Scheduled event not found"
            }
        ]
    }
}
```

Approves multiple ScheduledEvents entries and displays the HTTP 207 Multi-Status response as JSON.
The pipeline value remains a structured object whose overall status and per-entry results are available through `$response.Error` and `$response.Error.Details`.
Both entries report `NotFound`, but the HTTP 207 response does not raise a terminating error.

### Example 3: Inspect individual event results

```powershell
$response.Error.Details | Select-Object Target, Code, Message
```

```output
Target                               Code     Message
------                               ----     -------
11111111-1111-1111-1111-111111111111 NotFound Scheduled event not found
33333333-3333-3333-3333-333333333333 NotFound Scheduled event not found
```

Uses the response from Example 2 to inspect the service-supplied target ID, code, and message for each event without parsing the console JSON.

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

### -ScheduledEventIdList

The ScheduledEvents IDs to approve for the specified resource.
Pass multiple IDs as a comma-separated string array, for example `@('11111111-1111-1111-1111-111111111111', '22222222-2222-2222-2222-222222222222')`.
Do not separate IDs with spaces alone; PowerShell treats the next ID as a separate positional argument and reports a parameter-binding error before sending the request.

```yaml
Type: System.String[]
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

### System.String[]

## OUTPUTS

### Microsoft.Azure.Management.Maintenance.Models.ScheduledEventsApproveResponse

### Microsoft.Azure.Management.Maintenance.Models.ScheduledEventsListAcknowledgeError

## NOTES

## RELATED LINKS
