---
external help file:
Module Name: Az.HybridConnectivity
online version: https://learn.microsoft.com/powershell/module/az.hybridconnectivity/invoke-azhybridconnectivitygenerateawstemplate
schema: 2.0.0
---

# Invoke-AzHybridConnectivityGenerateAwsTemplate

## SYNOPSIS
Retrieve AWS Cloud Formation template

## SYNTAX

### PostExpanded (Default)
```
Invoke-AzHybridConnectivityGenerateAwsTemplate -ConnectorId <String> [-SubscriptionId <String>]
 [-SolutionType <ISolutionTypeSettings[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Post
```
Invoke-AzHybridConnectivityGenerateAwsTemplate -GenerateAwsTemplateRequest <IGenerateAwsTemplateRequest>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PostViaJsonFilePath
```
Invoke-AzHybridConnectivityGenerateAwsTemplate -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PostViaJsonString
```
Invoke-AzHybridConnectivityGenerateAwsTemplate -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Retrieve AWS Cloud Formation template

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

### -ConnectorId
The name of public cloud connector

```yaml
Type: System.String
Parameter Sets: PostExpanded
Aliases:

Required: True
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

### -GenerateAwsTemplateRequest
ConnectorId and SolutionTypes and their properties to Generate AWS CFT Template.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HybridConnectivity.Models.IGenerateAwsTemplateRequest
Parameter Sets: Post
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Post operation

```yaml
Type: System.String
Parameter Sets: PostViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Post operation

```yaml
Type: System.String
Parameter Sets: PostViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SolutionType
The list of solution types and their settings

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HybridConnectivity.Models.ISolutionTypeSettings[]
Parameter Sets: PostExpanded
Aliases:

Required: False
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
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.HybridConnectivity.Models.IGenerateAwsTemplateRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HybridConnectivity.Models.IAny

## NOTES

## RELATED LINKS

