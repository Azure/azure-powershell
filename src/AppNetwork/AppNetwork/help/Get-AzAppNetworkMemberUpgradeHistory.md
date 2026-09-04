---
external help file: Az.AppNetwork-help.xml
Module Name: Az.AppNetwork
online version: https://learn.microsoft.com/powershell/module/az.appnetwork/get-azappnetworkmemberupgradehistory
schema: 2.0.0
---

# Get-AzAppNetworkMemberUpgradeHistory

## SYNOPSIS
List UpgradeHistory resources by AppLinkMember.

## SYNTAX

```
Get-AzAppNetworkMemberUpgradeHistory -AppLinkMemberName <String> -AppLinkName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
List UpgradeHistory resources by AppLinkMember.

## EXAMPLES

### Example 1: List the upgrade history of an Application Network member
```powershell
Get-AzAppNetworkMemberUpgradeHistory -AppLinkMemberName member-01 -AppLinkName appnet-test-01 -ResourceGroupName test_rg
```

```output
FromVersion ToVersion InitiatedBy StartTimestamp        EndTimestamp
----------- --------- ----------- --------------        ------------
1.3         1.4       Admin       2025-09-24T10:30:00Z  2025-09-25T00:00:00Z
```

Lists the upgrade history of the `member-01` member of the `appnet-test-01` Application Network resource.

## PARAMETERS

### -AppLinkMemberName
The name of the AppLinkMember

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

### -AppLinkName
The name of the AppLink

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
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

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
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppNetwork.Models.IUpgradeHistory

## NOTES

## RELATED LINKS
