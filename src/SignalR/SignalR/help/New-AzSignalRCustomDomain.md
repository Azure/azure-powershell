---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SignalR.dll-Help.xml
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/new-azsignalrcustomdomain
schema: 2.0.0
---

# New-AzSignalRCustomDomain

## SYNOPSIS
Create or replace a custom domain for a SignalR service.

## SYNTAX

### ResourceGroupParameterSet (Default)
```
New-AzSignalRCustomDomain [-ResourceGroupName <String>] -SignalRName <String> [-Name] <String>
 -DomainName <String> -CustomCertificateId <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputSignalRObjectParameterSet
```
New-AzSignalRCustomDomain [-Name] <String> -DomainName <String> -CustomCertificateId <String>
 -SignalRObject <PSSignalRResource> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or replaces a custom domain for a SignalR service. A custom certificate must be configured before creating the custom domain.

## EXAMPLES

### Example 1: Create a custom domain by resource group and SignalR service name
```powershell
$cert = Get-AzSignalRCustomCertificate -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR" -Name "myCertificate"
New-AzSignalRCustomDomain -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR" -Name "myDomain" -DomainName "signalr.contoso.com" -CustomCertificateId $cert.Id
```

This command creates a custom domain named "myDomain" for the SignalR service "mySignalR" using the specified certificate.

### Example 2: Create a custom domain using SignalR resource object
```powershell
$signalr = Get-AzSignalR -ResourceGroupName "myResourceGroup" -Name "mySignalR"
$cert = Get-AzSignalRCustomCertificate -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR" -Name "myCertificate"
$signalr | New-AzSignalRCustomDomain -Name "myDomain" -DomainName "signalr.contoso.com" -CustomCertificateId $cert.Id
```

This command creates a custom domain using a SignalR resource object as input.

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

### -CustomCertificateId
The custom certificate resource id.

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

### -DomainName
The custom domain value.

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
The custom domain name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

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

### Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource

## OUTPUTS

### Microsoft.Azure.Commands.SignalR.Models.PSCustomDomainResource

## NOTES

## RELATED LINKS
