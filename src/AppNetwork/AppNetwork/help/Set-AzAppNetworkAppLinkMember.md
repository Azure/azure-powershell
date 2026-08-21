---
external help file: Az.AppNetwork-help.xml
Module Name: Az.AppNetwork
online version: https://learn.microsoft.com/powershell/module/az.appnetwork/set-azappnetworkapplinkmember
schema: 2.0.0
---

# Set-AzAppNetworkAppLinkMember

## SYNOPSIS
Replace a member of an Azure Kubernetes Application Network resource.

## SYNTAX

### ReplaceExpanded (Default)
```
Set-AzAppNetworkAppLinkMember -AppLinkName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Location <String> [-ClusterType <String>] [-EastWestGatewayVisibility <String>]
 [-FullyManagedUpgradeProfileReleaseChannel <String>] [-MetadataResourceId <String>]
 [-PrivateConnectSubnetResourceId <String>] [-SelfManagedUpgradeProfileVersion <String>] [-Tag <Hashtable>]
 [-UpgradeProfileMode <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Replace
```
Set-AzAppNetworkAppLinkMember -AppLinkName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Resource <IAppLinkMember> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ReplaceViaJsonFilePath
```
Set-AzAppNetworkAppLinkMember -AppLinkName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ReplaceViaJsonString
```
Set-AzAppNetworkAppLinkMember -AppLinkName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Replace a member of an Azure Kubernetes Application Network resource.

## EXAMPLES

### Example 1: Create or replace an Application Network member
```powershell
Set-AzAppNetworkAppLinkMember -Name member-01 -AppLinkName appnet-test-01 -ResourceGroupName test_rg -Location westus2 `
  -ClusterType AKS `
  -MetadataResourceId '/subscriptions/bc7e0da9-5e4c-4a91-9252-9658837006cf/resourcegroups/test-rg/providers/Microsoft.ContainerService/managedClusters/test-member1' `
  -UpgradeProfileMode FullyManaged -FullyManagedUpgradeProfileReleaseChannel Stable
```

```output
Name      ClusterType ProvisioningState ResourceGroupName
----      ----------- ----------------- -----------------
member-01 AKS         Succeeded         test_rg
```

Creates or replaces the `member-01` member of the `appnet-test-01` Application Network resource with the fully managed upgrade profile.

## PARAMETERS

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

### -AsJob
Run the command as a job

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

### -ClusterType
Cluster type

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded
Aliases:

Required: False
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

### -EastWestGatewayVisibility
East-West gateway visibility.

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FullyManagedUpgradeProfileReleaseChannel
Release channel

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Replace operation

```yaml
Type: System.String
Parameter Sets: ReplaceViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Replace operation

```yaml
Type: System.String
Parameter Sets: ReplaceViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetadataResourceId
Resource ID

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the AppLinkMember

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AppLinkMemberName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -PrivateConnectSubnetResourceId
Delegated Subnet to AppLink.

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
A member of an Azure Kubernetes Application Network resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppNetwork.Models.IAppLinkMember
Parameter Sets: Replace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -SelfManagedUpgradeProfileVersion
Istio version

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: ReplaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpgradeProfileMode
Upgrade mode.

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded
Aliases:

Required: False
Position: Named
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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### Microsoft.Azure.PowerShell.Cmdlets.AppNetwork.Models.IAppLinkMember

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppNetwork.Models.IAppLinkMember

## NOTES

## RELATED LINKS
