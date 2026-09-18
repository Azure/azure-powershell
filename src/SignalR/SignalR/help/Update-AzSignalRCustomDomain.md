---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SignalR.dll-Help.xml
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/update-azsignalrcustomdomain
schema: 2.0.0
---

# Update-AzSignalRCustomDomain

## SYNOPSIS
Update a custom domain for a SignalR service.

## SYNTAX

### ResourceGroupParameterSet (Default)
```
Update-AzSignalRCustomDomain [-ResourceGroupName <String>] -SignalRName <String> [-Name] <String>
 [-DomainName <String>] [-CustomCertificateId <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputSignalRObjectParameterSet
```
Update-AzSignalRCustomDomain [-Name] <String> -SignalRResourceObject <PSSignalRResource> [-DomainName <String>]
 [-CustomCertificateId <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObjectParameterSet
```
Update-AzSignalRCustomDomain -InputObject <PSCustomDomainResource> [-DomainName <String>]
 [-CustomCertificateId <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Update-AzSignalRCustomDomain [-DomainName <String>] [-CustomCertificateId <String>] [-AsJob]
 -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates an existing custom domain for a SignalR service. This cmdlet allows you to modify the domain name or the associated custom certificate of an existing custom domain configuration.

## EXAMPLES

### Example 1: Update the domain name of a custom domain by resource group and SignalR service name
```powershell
Update-AzSignalRCustomDomain -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR" -Name "myDomain" -DomainName "newsignalr.contoso.com"
```

This command updates the domain name of the custom domain "myDomain" for the SignalR service "mySignalR" to "newsignalr.contoso.com".

### Example 2: Update the certificate of a custom domain
```powershell
$newCert = Get-AzSignalRCustomCertificate -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR" -Name "newCertificate"
Update-AzSignalRCustomDomain -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR" -Name "myDomain" -CustomCertificateId $newCert.Id
```

This command updates the custom certificate used by the custom domain "myDomain" to a different certificate.

### Example 3: Update a custom domain using a SignalR resource object
```powershell
$signalr = Get-AzSignalR -ResourceGroupName "myResourceGroup" -Name "mySignalR"
$signalr | Update-AzSignalRCustomDomain -Name "myDomain" -DomainName "updated.contoso.com"
```

This command updates a custom domain using a SignalR resource object as input.

### Example 4: Update a custom domain using the custom domain resource object
```powershell
$domain = Get-AzSignalRCustomDomain -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR" -Name "myDomain"
$domain | Update-AzSignalRCustomDomain -DomainName "updated.contoso.com"
```

This command updates a custom domain by piping in the custom domain resource object.

### Example 5: Update a custom domain by resource ID
```powershell
Update-AzSignalRCustomDomain -ResourceId "/subscriptions/{subscription-id}/resourceGroups/myResourceGroup/providers/Microsoft.SignalRService/SignalR/mySignalR/customDomains/myDomain" -DomainName "updated.contoso.com"
```

This command updates a custom domain using its resource ID.

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
The custom certificate resource ID.

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

### -DomainName
The custom domain name.

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

### Microsoft.Azure.Commands.SignalR.Models.PSCustomDomainResource

## NOTES

## RELATED LINKS
