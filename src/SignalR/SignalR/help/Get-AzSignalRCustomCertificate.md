---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SignalR.dll-Help.xml
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/get-azsignalrcustomcertificate
schema: 2.0.0
---

# Get-AzSignalRCustomCertificate

## SYNOPSIS
Get custom certificate(s) for a SignalR service.

## SYNTAX

### ResourceGroupParameterSet (Default)
```
Get-AzSignalRCustomCertificate [-ResourceGroupName <String>] -SignalRName <String> [-Name <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Get-AzSignalRCustomCertificate [-Name <String>] -ResourceId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### InputSignalRObjectParameterSet
```
Get-AzSignalRCustomCertificate [-Name <String>] -SignalRObject <PSSignalRResource> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Retrieves custom certificates configured for a SignalR service. This can list all custom certificates or get a specific certificate by resource ID.

## EXAMPLES

### Example 1: Get a custom certificate by resource group and SignalR service name
```powershell
Get-AzSignalRCustomCertificate -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR"
```

This command get a custom certificate configured for the SignalR service "mySignalR".

### Example 2: Get a custom certificate by a custom certificate resource ID
```powershell
Get-AzSignalRCustomCertificate -ResourceId "/subscriptions/{subscription-id}/resourceGroups/myResourceGroup/providers/Microsoft.SignalRService/SignalR/mySignalR/customCertificates/myCertificate"
```

This command gets a specific custom certificate by its resource ID.

### Example 3: Get a custom certificate by SignalR resource object.
```powershell
$signalr = Get-AzSignalR -ResourceGroupName "myResourceGroup" -Name "mySignalR"
$signalr | Get-AzSignalRCustomCertificate -Name "myCertificate"
```

This command get a custom certificate configured for the SignalR service represented by the `$signalr` object.

### Example 4: List all custom certificates for a SignalR service
```powershell
Get-AzSignalRCustomCertificate -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR"
```

Without specifying a certificate name, this command lists all custom certificates configured for the SignalR service "mySignalR".

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

### -Name
The name of the custom certificate

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
The resource ID of a custom certificate

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

### -SignalRObject
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.SignalR.Models.PSCustomCertificateResource

## NOTES

## RELATED LINKS
