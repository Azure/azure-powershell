---
external help file: Microsoft.Azure.Commands.AnalysisServices.dll-Help.xml
Module Name: AzureRM.AnalysisServices
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.analysisservices/get-azurermanalysisservicesservergatewaystatus
schema: 2.0.0
---

# Get-AzureRmAnalysisServicesServer

## SYNOPSIS
Gets the status of the gateway associated to an Analysis Services server.

## SYNTAX

```
Get-AzureRmAnalysisServicesServerGatewayStatus [[-ResourceGroupName] <String>] [[-Name] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzureRmAnalysisServicesServerGatewayStatus cmdlet gets the status of the gateway associated to an Analysis Services server.

## EXAMPLES

### Example 1
```
PS C:\>Get-AzureRmAnalysisServicesServerGatewayStatus -ResourceGroupName "ResourceGroupTest" -Name "testserver"
```

This command gets the Azure Analysis Services server named testserver in the resource group named ResourceGroupTest.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Analysis Services server

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Azure resource group to which the server belongs

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.AnalysisServices.Models.AzureAnalysisServicesServerGatewayStatus

## NOTES
Alias: Get-AzureAsGateway

## RELATED LINKS

[New-AzureRmAnalysisServicesServer ](./New-AzureRmAnalysisServicesServer .md)
