---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azactiongroupazurefunctionreceiverobject
schema: 2.0.0
---

# New-AzActionGroupAzureFunctionReceiverObject

## SYNOPSIS
Create an in-memory object for AzureFunctionReceiver.

## SYNTAX

```
New-AzActionGroupAzureFunctionReceiverObject -FunctionAppResourceId <String> -FunctionName <String>
 -HttpTriggerUrl <String> -Name <String> [-UseCommonAlertSchema <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureFunctionReceiver.

## EXAMPLES

### Example 1: create action group azure function receiver
```powershell
New-AzActionGroupAzureFunctionReceiverObject -FunctionAppResourceId "/subscriptions/5def922a-3ed4-49c1-b9fd-05ec533819a3/resourceGroups/aznsTest/providers/Microsoft.Web/sites/testFunctionApp" -FunctionName HttpTriggerCSharp1 -HttpTriggerUrl "http://test.me" -Name "sample azure function" -UseCommonAlertSchema $true
```

```output
FunctionAppResourceId : /subscriptions/5def922a-3ed4-49c1-b9fd-05ec533819a3/resourceGroups/aznsTest/providers/Microsoft.Web/sites/testFunctionApp
FunctionName          : HttpTriggerCSharp1
HttpTriggerUrl        : http://test.me
Name                  : sample azure function
UseCommonAlertSchema  : True
```

This command creates action group azure function receiver object.

## PARAMETERS

### -FunctionAppResourceId
The azure resource id of the function app.

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

### -FunctionName
The function name in the function app.

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

### -HttpTriggerUrl
The http trigger url where http request sent to.

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

### -Name
The name of the azure function receiver.
Names must be unique across all receivers within an action group.

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

### -UseCommonAlertSchema
Indicates whether to use common alert schema.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.AzureFunctionReceiver

## NOTES

## RELATED LINKS

