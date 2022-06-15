---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-aznetworkmanagergroup
schema: 2.0.0
---

# Get-AzNetworkManagerGroup

## SYNOPSIS
Gets network group(s) in a network manager.

## SYNTAX

### NoExpand (Default)
```
Get-AzNetworkManagerGroup [-Name <String>] -NetworkManagerName <String> -ResourceGroupName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]

```

### Expand
```
Get-AzNetworkManagerGroup -NetworkManagerName <String> -ResourceGroupName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetworkManagerGroup** cmdlet gets a network group in a network manager.

## EXAMPLES

### Example 1
```powershell
Expand
PS C:\> Get-AzNetworkManagerGroup  -Name "TestGroup" -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"

Name                  : TestGroup
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsof
                        t.Network/networkManagers/TestNMName/networkGroups/TestGroup
Description           : 
Etag                  : "00000000-0000-0000-0000-000000000000"
ProvisioningState     : Succeeded
ConditionalMembership :
MemberType            :
SystemData            : {
                          "CreatedBy": "00000000-0000-0000-0000-000000000000",
                          "CreatedByType": "Application",
                          "CreatedAt": "2021-10-17T21:13:02",
                          "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                          "LastModifiedByType": "Application",
                          "LastModifiedAt": "2021-10-17T21:13:02"
                        }
```

### Example 2
```powershell
NoExpand
PS C:\> Get-AzNetworkManagerGroup -NetworkManagerName "TestNMName" -ResourceGroupName "TestRG"

Name                  : TestGroup
Id                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsof
                        t.Network/networkManagers/TestNMName/networkGroups/TestGroup 
Description           : 
Etag                  : "00000000-0000-0000-0000-000000000000"
ProvisioningState     : Succeeded
ConditionalMembership :
MemberType            :
SystemData            : {
                          "CreatedBy": "00000000-0000-0000-0000-000000000000",
                          "CreatedByType": "Application",
                          "CreatedAt": "2021-10-17T21:13:02",
                          "LastModifiedBy": "00000000-0000-0000-0000-000000000000",
                          "LastModifiedByType": "Application",
                          "LastModifiedAt": "2021-10-17T21:13:02"
                        }
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

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: NoExpand
Aliases: ResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: Expand
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NetworkManagerName
The network manager name.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerGroup

## NOTES

## RELATED LINKS
[New-AzNetworkManagerGroup](./New-AzNetworkManagerGroup.md)

[Remove-AzNetworkManagerGroup](./Remove-AzNetworkManagerGroup.md)

[Set-AzNetworkManagerGroup](./Set-AzNetworkManagerGroup.md)