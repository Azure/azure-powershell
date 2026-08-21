---
external help file:
Module Name: Az.AppNetwork
online version: https://learn.microsoft.com/powershell/module/az.appnetwork/get-azappnetworkapplinkmember
schema: 2.0.0
---

# Get-AzAppNetworkAppLinkMember

## SYNOPSIS
Get a member of an Azure Kubernetes Application Network resource.

## SYNTAX

### List (Default)
```
Get-AzAppNetworkAppLinkMember -AppLinkName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzAppNetworkAppLinkMember -AppLinkName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAppNetworkAppLinkMember -InputObject <IAppNetworkIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityAppLink
```
Get-AzAppNetworkAppLinkMember -AppLinkInputObject <IAppNetworkIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a member of an Azure Kubernetes Application Network resource.

## EXAMPLES

### Example 1: List members of an Application Network resource
```powershell
Get-AzAppNetworkAppLinkMember -AppLinkName appnet-test-01 -ResourceGroupName test_rg
```

```output
Name      ClusterType ProvisioningState ResourceGroupName
----      ----------- ----------------- -----------------
member-01 AKS         Succeeded         test_rg
member-02 AKS         Succeeded         test_rg
```

Lists all members of the `appnet-test-01` Application Network resource.

### Example 2: Get a member of an Application Network resource
```powershell
Get-AzAppNetworkAppLinkMember -Name member-01 -AppLinkName appnet-test-01 -ResourceGroupName test_rg
```

```output
Name      ClusterType ProvisioningState ResourceGroupName
----      ----------- ----------------- -----------------
member-01 AKS         Succeeded         test_rg
```

Gets the `member-01` member of the `appnet-test-01` Application Network resource.

## PARAMETERS

### -AppLinkInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppNetwork.Models.IAppNetworkIdentity
Parameter Sets: GetViaIdentityAppLink
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AppLinkName
The name of the AppLink

```yaml
Type: System.String
Parameter Sets: Get, List
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppNetwork.Models.IAppNetworkIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the AppLinkMember

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityAppLink
Aliases: AppLinkMemberName

Required: True
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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.AppNetwork.Models.IAppNetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppNetwork.Models.IAppLinkMember

## NOTES

## RELATED LINKS

