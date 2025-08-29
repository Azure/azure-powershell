---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SignalR.dll-Help.xml
Module Name: Az.SignalR
online version:
schema: 2.0.0
---

# Get-AzSignalRCustomDomain

## SYNOPSIS
Get custom domain(s) for a SignalR service.

## SYNTAX

### ResourceGroupParameterSet (Default)
```
Get-AzSignalRCustomDomain [-ResourceGroupName <String>] -SignalRName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Get-AzSignalRCustomDomain -ResourceId <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Retrieves custom domains configured for a SignalR service. This can list all custom domains or get a specific domain by resource ID.

## EXAMPLES

### Example 1: Get all custom domains for a SignalR service
```powershell
Get-AzSignalRCustomDomain -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR"
```

This command gets all custom domains configured for the SignalR service "mySignalR".

### Example 2: Get a custom domain by resource ID
```powershell
Get-AzSignalRCustomDomain -ResourceId "/subscriptions/{subscription-id}/resourceGroups/myResourceGroup/providers/Microsoft.SignalRService/SignalR/mySignalR/customDomains/myDomain"
```

This command gets a specific custom domain by its resource ID.

### Example 3: Get custom domains and display their properties
```powershell
$domains = Get-AzSignalRCustomDomain -ResourceGroupName "myResourceGroup" -SignalRName "mySignalR"
$domains | Format-Table Name, DomainName, CustomCertificateId, ProvisioningState
```

This command gets all custom domains and displays their key properties in a table format.

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
The resource ID of a custom domain

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.SignalR.Models.PSCustomDomainResource

## NOTES

## RELATED LINKS
