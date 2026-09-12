---
external help file: Az.AppNetwork-help.xml
Module Name: Az.AppNetwork
online version: https://learn.microsoft.com/powershell/module/az.appnetwork/new-azappnetworkmember
schema: 2.0.0
---

# New-AzAppNetworkMember

## SYNOPSIS
Create an AppLinkMember.

## SYNTAX

### CreateExpanded (Default)
```
New-AzAppNetworkMember -Name <String> -AppLinkName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Location <String> [-ClusterType <String>] [-EastWestGatewayVisibility <String>]
 [-FullyManagedUpgradeProfileReleaseChannel <String>] [-MetadataResourceId <String>]
 [-PrivateConnectSubnetResourceId <String>] [-SelfManagedUpgradeProfileVersion <String>] [-Tag <Hashtable>]
 [-UpgradeProfileMode <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzAppNetworkMember -Name <String> -AppLinkName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzAppNetworkMember -Name <String> -AppLinkName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityAppLinkExpanded
```
New-AzAppNetworkMember -Name <String> -AppLinkInputObject <IAppNetworkIdentity> -Location <String>
 [-ClusterType <String>] [-EastWestGatewayVisibility <String>]
 [-FullyManagedUpgradeProfileReleaseChannel <String>] [-MetadataResourceId <String>]
 [-PrivateConnectSubnetResourceId <String>] [-SelfManagedUpgradeProfileVersion <String>] [-Tag <Hashtable>]
 [-UpgradeProfileMode <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create an AppLinkMember.

## EXAMPLES

### Example 1: Join an AKS cluster to an Application Network using fully managed upgrades
```powershell
New-AzAppNetworkMember -Name member-01 -AppLinkName appnet-test-01 -ResourceGroupName test_rg -Location westus2 `
  -ClusterType AKS `
  -MetadataResourceId '/subscriptions/bc7e0da9-5e4c-4a91-9252-9658837006cf/resourcegroups/test-rg/providers/Microsoft.ContainerService/managedClusters/test-member1' `
  -UpgradeProfileMode FullyManaged -FullyManagedUpgradeProfileReleaseChannel Stable
```

```output
Name      ClusterType ProvisioningState ResourceGroupName
----      ----------- ----------------- -----------------
member-01 AKS         Succeeded         test_rg
```

Joins an AKS cluster to the `appnet-test-01` Application Network as member `member-01`, using the fully managed upgrade mode on the `Stable` release channel.

### Example 2: Join an AKS cluster to an Application Network using self managed upgrades
```powershell
New-AzAppNetworkMember -Name member-01 -AppLinkName appnet-test-01 -ResourceGroupName test_rg -Location westus2 `
  -ClusterType AKS `
  -MetadataResourceId '/subscriptions/bc7e0da9-5e4c-4a91-9252-9658837006cf/resourcegroups/test-rg/providers/Microsoft.ContainerService/managedClusters/test-member1' `
  -UpgradeProfileMode SelfManaged -SelfManagedUpgradeProfileVersion 1.4
```

```output
Name      ClusterType ProvisioningState ResourceGroupName
----      ----------- ----------------- -----------------
member-01 AKS         Succeeded         test_rg
```

Joins an AKS cluster to the `appnet-test-01` Application Network as member `member-01`, using the self managed upgrade mode pinned to Application Network version `1.4`.

## PARAMETERS

### -AppLinkInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppNetwork.Models.IAppNetworkIdentity
Parameter Sets: CreateViaIdentityAppLinkExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateExpanded, CreateViaIdentityAppLinkExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityAppLinkExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityAppLinkExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaIdentityAppLinkExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityAppLinkExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityAppLinkExpanded
Aliases:

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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateExpanded, CreateViaIdentityAppLinkExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateExpanded, CreateViaIdentityAppLinkExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityAppLinkExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.AppNetwork.Models.IAppNetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppNetwork.Models.IAppLinkMember

## NOTES

## RELATED LINKS
