---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Search.dll-Help.xml
Module Name: Az.Search
online version: https://learn.microsoft.com/powershell/module/az.search/get-azsearchnetworksecurityperimeterconfiguration
schema: 2.0.0
---

# Get-AzSearchNetworkSecurityPerimeterConfiguration

## SYNOPSIS
Gets an Azure AI Search service network security perimeter configuration.

## SYNTAX

```
Get-AzSearchNetworkSecurityPerimeterConfiguration [-ResourceGroupName] <String> [-ServiceName] <String>
 [[-Name] <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSearchNetworkSecurityPerimeterConfiguration** cmdlet gets the specified Azure AI Search service network security perimeter configuration.

## EXAMPLES

### Example 1
```powershell
Get-AzSearchNetworkSecurityPerimeterConfiguration -ResourceGroupName rg1 -ServiceName mysearchservice -Name 00000001-2222-3333-4444-111144444444.assoc1 | ConvertTo-Json
```

```output
{
  "Name": "00000001-2222-3333-4444-111144444444.assoc1",
  "Id": "/subscriptions/subid/resourceGroups/rg1/providers/Microsoft.Search/searchServices/mysearchservice/networkSecurityPerimeterConfigurations/00000001-2222-3333-4444-111144444444.assoc1",
  "Type": "Microsoft.Search/searchServices/networkSecurityPerimeterConfigurations",
  "ProvisioningState": "Accepted",
  "NetworkSecurityPerimeter": {
    "Id": "/subscriptions/subid/resourceGroups/networkRG/providers/Microsoft.Network/networkSecurityPerimeters/perimeter1",
    "Location": "westus"
    },
  "ResourceAssociation": {
    "Name": "assoc1",
    "AccessMode": "Enforced"
  },
  "Profile": {
    "name": "profile1",
    "accessRulesVersion": 0,
    "accessRules": [
      {
        "name": "rule1",
        "properties": {
        "direction": "Inbound",
        "addressPrefixes": [
          "148.0.0.0/8",
          "152.4.6.0/24"
          ]
        }
      }
    ]
  }
}
```

Get an Azure AI Search service network security perimeter configuration with specified parameters.

## PARAMETERS

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
Azure AI Search Service network security perimeter configuration name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group name.

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

### -ServiceName
Azure AI Search Service name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Management.Search.Models.PSNetworkSecurityPerimeterConfiguration)

## NOTES

## RELATED LINKS
