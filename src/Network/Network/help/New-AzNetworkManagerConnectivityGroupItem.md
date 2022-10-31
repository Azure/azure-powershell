---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-aznetworkmanagerconnectivitygroupitem
schema: 2.0.0
---

# New-AzNetworkManagerConnectivityGroupItem

## SYNOPSIS
Creates a connectivity group item.

## SYNTAX

```
New-AzNetworkManagerConnectivityGroupItem -NetworkGroupId <String> [-UseHubGateway]
 [-GroupConnectivity <String>] [-IsGlobal] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerConnectivityGroupItem** cmdlet creates a connectivity group item.

## EXAMPLES

### Example 1
```powershell
$networkGroupId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/networkGroups/TestGroup"
New-AzNetworkManagerConnectivityGroupItem -NetworkGroupId $networkGroupId -UseHubGateway -GroupConnectivity "None" -IsGlobal 
```
```output
NetworkGroupId                                                                                                                                           UseHubGateway IsGlobal GroupConnectivity
--------------                                                                                                                                           ------------- -------- -----------------
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/networkGroups/TestGroup True          True     None
```
Creates a connectivity group item using hub as gateway.

### Example 2
```powershell
$networkGroupId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/networkGroups/TestGroup"
New-AzNetworkManagerConnectivityGroupItem -NetworkGroupId $networkGroupId -GroupConnectivity "DirectlyConnected" 
```
```output
NetworkGroupId                                                                                                                                           UseHubGateway IsGlobal GroupConnectivity
--------------                                                                                                                                           ------------- -------- -----------------
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestRG/providers/Microsoft.Network/networkManagers/TestNMName/networkGroups/TestGroup False         False    DirectlyConnected
```
Creates a connectivity group item with direct connectivity.

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

### -GroupConnectivity
Group Connectivity.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: None, DirectlyConnected

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IsGlobal
IsGlobal flag

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NetworkGroupId
Network Group Id

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UseHubGateway
Use hub gateway flag

```yaml
Type: SwitchParameter
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

### System.Management.Automation.SwitchParameter

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerConnectivityGroupItem

## NOTES

## RELATED LINKS
[New-AzNetworkManagerConnectivityConfiguration](./New-AzNetworkManagerConnectivityConfiguration.md)