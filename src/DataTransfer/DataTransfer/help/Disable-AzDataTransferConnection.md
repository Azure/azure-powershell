---
external help file: Az.DataTransfer-help.xml
Module Name: Az.DataTransfer
online version: https://learn.microsoft.com/powershell/module/az.datatransfer/disable-azdatatransferconnection
schema: 2.0.0
---

# Disable-AzDataTransferConnection

## SYNOPSIS
Disables Azure Data Transfer connections.

## SYNTAX

```
Disable-AzDataTransferConnection [-PipelineName] <String> [-ResourceGroupName] <String>
 [-ConnectionId] <String[]> [[-SubscriptionId] <String>] [[-Justification] <String>]
 [[-DefaultProfile] <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The Disable-AzDataTransferConnection cmdlet disables Azure Data Transfer connections.
This prevents data transfer operations on the connections and disables all flows within them.

## EXAMPLES

### EXAMPLE 1
```powershell
Disable-AzDataTransferConnection -PipelineName "corp" -ResourceGroupName "rpaas-rg" -ConnectionId "/subscriptions/389ff96a-b137-405b-a3c8-4d22514708b5/resourceGroups/rpaas-rg/providers/Private.AzureDataTransfer/connections/my-connection"
```

Disables a single connection.

### EXAMPLE 2
```powershell
$connectionIds = @(
    "/subscriptions/389ff96a-b137-405b-a3c8-4d22514708b5/resourceGroups/rpaas-rg/providers/Private.AzureDataTransfer/connections/connection1",
    "/subscriptions/389ff96a-b137-405b-a3c8-4d22514708b5/resourceGroups/rpaas-rg/providers/Private.AzureDataTransfer/connections/connection2"
)
Disable-AzDataTransferConnection -PipelineName "corp" -ResourceGroupName "rpaas-rg" -ConnectionId $connectionIds
```

Disables multiple connections.

### EXAMPLE 3
```powershell
Disable-AzDataTransferConnection -PipelineName "corp" -ResourceGroupName "rpaas-rg" -ConnectionId $connectionId -Justification "Security incident response"
```

Disables a connection with a business justification.

### EXAMPLE 4
```powershell
Disable-AzDataTransferConnection -PipelineName "corp" -ResourceGroupName "rpaas-rg" -ConnectionId $connectionId -WhatIf
```

Shows what would happen if the connection was disabled without actually disabling it.

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

### -ConnectionId
One or more connection resource IDs to disable

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases:

Required: False
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Justification
Business justification for disabling the connections

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 5
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

### -PipelineName
The name of the pipeline containing the connections

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
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

## NOTES

## RELATED LINKS
