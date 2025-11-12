---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SignalR.dll-Help.xml
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/remove-azsignalrcustomdomain
schema: 2.0.0
---

# Remove-AzSignalRCustomDomain

## SYNOPSIS
Remove a custom domain from a SignalR service.

## SYNTAX

### ResourceGroupParameterSet (Default)
```
Remove-AzSignalRCustomDomain [-ResourceGroupName <String>] -SignalRName <String> [-Name] <String> [-AsJob]
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### InputSignalRObjectParameterSet
```
Remove-AzSignalRCustomDomain [-Name] <String> -SignalRResourceObject <PSSignalRResource> [-AsJob] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputObjectParameterSet
```
Remove-AzSignalRCustomDomain -InputObject <PSCustomDomainResource> [-AsJob] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResourceIdParameterSet
```
Remove-AzSignalRCustomDomain -ResourceId <String> [-AsJob] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Removes a custom domain from a SignalR service. After removing the custom domain, clients will need to connect using the default Azure-provided domain.

## EXAMPLES

### Example 1: Remove a custom domain by resource group name and SignalR service name
```powershell
Remove-AzSignalRCustomDomain -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR" -Name "myDomain"
```

This command removes the custom domain named "myDomain" from the SignalR service "mySignalR".

### Example 2: Remove a custom domain using domain object
```powershell
$domain = Get-AzSignalRCustomDomain -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR" -Name "myDomain"
$domain | Remove-AzSignalRCustomDomain
```

This command removes a custom domain using an existing domain object.

### Example 3: Remove a custom domain by resource ID
```powershell
Remove-AzSignalRCustomDomain -ResourceId "/subscriptions/{subscription-id}/resourceGroups/myResourceGroup/providers/Microsoft.SignalRService/SignalR/mySignalR/customDomains/myDomain"
```

This command removes a custom domain by its resource ID.

### Example 4: Remove a custom domain using SignalR resource object
```powershell
$signalr = Get-AzSignalR -ResourceGroupName "myResourceGroup" -Name "mySignalR"
$signalr | Remove-AzSignalRCustomDomain -Name "myDomain"
```

This command removes a custom domain using a SignalR resource object as input.

## PARAMETERS

### -AsJob
Run the cmdlet in background job.

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

### -InputObject
The SignalR custom domain resource object.

```yaml
Type: Microsoft.Azure.Commands.SignalR.Models.PSCustomDomainResource
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The custom domain name.

```yaml
Type: System.String
Parameter Sets: ResourceGroupParameterSet, InputSignalRObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
{{ Fill PassThru Description }}

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

### -ResourceGroupName
The resource group name.
The default one will be used if not specified.

```yaml
Type: System.String
Parameter Sets: ResourceGroupParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource ID of the custom domain.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SignalRName
The SignalR service name.

```yaml
Type: System.String
Parameter Sets: ResourceGroupParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SignalRResourceObject
The SignalR resource object.

```yaml
Type: Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource
Parameter Sets: InputSignalRObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.Commands.SignalR.Models.PSCustomDomainResource

### Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource

### System.String

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
