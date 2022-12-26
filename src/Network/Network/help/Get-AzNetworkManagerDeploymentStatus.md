---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkmanagerdeploymentstatus
schema: 2.0.0
---

# Get-AzNetworkManagerDeploymentStatus

## SYNOPSIS
Lists Deployment Status in a network manager.

## SYNTAX

```
Get-AzNetworkManagerDeploymentStatus -NetworkManagerName <String> -ResourceGroupName <String>
 [-Region <String[]>]
 [-DeploymentType <String[]>] [-SkipToken <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerDeploymentStatus** cmdlet lists Deployment Status in a network manager.

## EXAMPLES

### Example 1
```powershell
$regions = @("centraluseuap")  
$DeploymentTypes = @("SecurityAdmin")  
Get-AzNetworkManagerDeploymentStatus -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG" -region $regions -skipToken "FakeSkipToken" -DeploymentType $DeploymentTypes
```
```output
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
Lists Deployment Status of SecurityAdmin configurations in region centraluseuap for a network manager.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
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
Type: System.String[]	
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
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -Region
List of regions.

```yaml
Type: System.String[]	
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
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -SkipToken
SkipToken.

```yaml
Type: String
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

### System.String[]	

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerDeploymentStatusListResult

## NOTES

## RELATED LINKS
