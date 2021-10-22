---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkmanagerdeploymentstatuslist
schema: 2.0.0
---

# Get-AzNetworkManagerDeploymentStatusList

## SYNOPSIS
Lists Deployment Status in a network manager.

## SYNTAX

```
Get-AzNetworkManagerDeploymentStatusList -NetworkManagerName <String> -ResourceGroupName <String>
 [-Region <System.Collections.Generic.List`1[System.String]>]
 [-DeploymentType <System.Collections.Generic.List`1[System.String]>] [-SkipToken <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerDeploymentStatusList** cmdlet lists Deployment Status in a network manager.

## EXAMPLES

### Example 1
```powershell
PS C:\> [System.Collections.Generic.List[String]]$regions = @()  
PS C:\> $regions.Add("centraluseuap")
PS C:\> [System.Collections.Generic.List[String]]$DeploymentTypes = @()  
PS C:\> $DeploymentTypes.Add("SecurityAdmin")
PS C:\> Get-AzNetworkManagerDeploymentStatusList -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG" -region $regions -skipToken "FakeSkipToken" -DeploymentType $DeploymentTypes
 
Value     : [
              {
                "CommitTime": "2021-10-18T04:06:08Z",
                "Region": "centraluseuap",
                "DeploymentStatus": "Deployed",
                "ConfigurationIds": [
                  "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/securityAdminConfigurations/testAdminConfig"
                ],
                "DeploymentType": "SecurityAdmin",
                "ErrorMessage": ""
              }
            ]
SkipToken :

```


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

### -DeploymentType
List of deploymentTypes.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NetworkManagerName
The networkManager name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Region
List of regions.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkipToken
SkipToken.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Collections.Generic.List`1[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerDeploymentStatusListResult

## NOTES

## RELATED LINKS
