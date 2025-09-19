---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SignalR.dll-Help.xml
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/remove-azsignalrcustomcertificate
schema: 2.0.0
---

# Remove-AzSignalRCustomCertificate

## SYNOPSIS
Remove a custom certificate from a SignalR service.

## SYNTAX

### ResourceGroupParameterSet (Default)
```
Remove-AzSignalRCustomCertificate [-ResourceGroupName <String>] -SignalRName <String> [-Name] <String> [-AsJob]
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### InputSignalRObjectParameterSet
```
Remove-AzSignalRCustomCertificate [-Name] <String> -SignalRInputObject <PSSignalRResource> [-AsJob] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputObjectParameterSet
```
Remove-AzSignalRCustomCertificate -InputObject <PSCustomCertificateResource> [-AsJob] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResourceIdParameterSet
```
Remove-AzSignalRCustomCertificate -ResourceId <String> [-AsJob] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Removes a custom certificate from a SignalR service. Note that you cannot remove a custom certificate that is currently being used by a custom domain.

## EXAMPLES

### Example 1: Remove a custom certificate by resource group name and SignalR service name
```powershell
Remove-AzSignalRCustomCertificate -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR" -Name "myCertificate"
```

This command removes the custom certificate named "myCertificate" from the SignalR service "mySignalR".

### Example 2: Remove a custom certificate using certificate object
```powershell
$cert = Get-AzSignalRCustomCertificate -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR" -Name "myCertificate"
$cert | Remove-AzSignalRCustomCertificate
```

This command removes a custom certificate using an existing certificate object.

### Example 3: Remove a custom certificate by resource ID
```powershell
Remove-AzSignalRCustomCertificate -ResourceId "/subscriptions/{subscription-id}/resourceGroups/myResourceGroup/providers/Microsoft.SignalRService/SignalR/mySignalR/customCertificates/myCertificate"
```

This command removes a custom certificate by its resource ID.

### Example 4: Remove a custom certificate using SignalR resource object and certificate name
```powershell
$signalr = Get-AzSignalR -ResourceGroupName "myResourceGroup" -Name "mySignalR"
$signalr | Remove-AzSignalRCustomCertificate -Name "myCertificate"
```

This command removes a custom certificate from a SignalR service represented by the `$signalr` object.

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
The SignalR custom certificate resource object.

```yaml
Type: Microsoft.Azure.Commands.SignalR.Models.PSCustomCertificateResource
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The custom certificate name.

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
The resource ID of the custom certificate

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

### -SignalRInputObject
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

### Microsoft.Azure.Commands.SignalR.Models.PSCustomCertificateResource

### Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource

### System.String

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
