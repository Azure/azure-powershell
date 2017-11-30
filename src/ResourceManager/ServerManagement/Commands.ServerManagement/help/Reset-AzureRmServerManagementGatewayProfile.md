---
external help file: Microsoft.Azure.Commands.ServerManagement.dll-Help.xml
Module Name: AzureRM
ms.assetid: 22B63259-799B-4F25-A06B-7A818D295870
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.servermanagement/reset-azurermservermanagementgatewayprofile
schema: 2.0.0
---

# Reset-AzureRmServerManagementGatewayProfile

## SYNOPSIS
Resets the profile of a Server Management gateway.

## SYNTAX

### ByName
```
Reset-AzureRmServerManagementGatewayProfile [-ResourceGroupName] <String> [-GatewayName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByObject
```
Reset-AzureRmServerManagementGatewayProfile [-Gateway] <Gateway> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Reset-AzureRmServerManagementGatewayProfile** cmdlet resets the profile for an Azure Server Management Gateway.

You will need to use the Save-AzureRmServerManagementGatewayProfile cmdlet to download the profile and then the Install-AzureRmServerManagementGatewayProfile cmdlet to save it after you reset the profile.

## EXAMPLES

### 1:
```

```

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

### -Gateway
Specifies the gateway for which the cmdlet resets the profile for.

May be specified instead of ResourceGoupName and GatewayName

```yaml
Type: Gateway
Parameter Sets: ByObject
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -GatewayName
Specifies the name of the gateway for which the cmdlet resets the profile.

```yaml
Type: String
Parameter Sets: ByName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group that the gateway belongs to.

```yaml
Type: String
Parameter Sets: ByName
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

### Gateway
Parameter 'Gateway' accepts value of type 'Gateway' from the pipeline

## OUTPUTS

## NOTES

## RELATED LINKS

[Install-AzureRmServerManagementGatewayProfile](./Install-AzureRmServerManagementGatewayProfile.md)

[Save-AzureRmServerManagementGatewayProfile](./Save-AzureRmServerManagementGatewayProfile.md)


