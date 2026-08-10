---
external help file:
Module Name: Az.AppNetwork
online version: https://learn.microsoft.com/powershell/module/az.appnetwork/update-azappnetworkapplinkmember
schema: 2.0.0
---

# Update-AzAppNetworkAppLinkMember

## SYNOPSIS
Update an AppLinkMember.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzAppNetworkAppLinkMember -AppLinkName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-EastWestGatewayVisibility <String>]
 [-FullyManagedUpgradeProfileReleaseChannel <String>] [-SelfManagedUpgradeProfileVersion <String>]
 [-Tag <Hashtable>] [-UpgradeProfileMode <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityAppLinkExpanded
```
Update-AzAppNetworkAppLinkMember -AppLinkInputObject <IAppNetworkIdentity> -Name <String>
 [-EastWestGatewayVisibility <String>] [-FullyManagedUpgradeProfileReleaseChannel <String>]
 [-SelfManagedUpgradeProfileVersion <String>] [-Tag <Hashtable>] [-UpgradeProfileMode <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzAppNetworkAppLinkMember -InputObject <IAppNetworkIdentity> [-EastWestGatewayVisibility <String>]
 [-FullyManagedUpgradeProfileReleaseChannel <String>] [-SelfManagedUpgradeProfileVersion <String>]
 [-Tag <Hashtable>] [-UpgradeProfileMode <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzAppNetworkAppLinkMember -AppLinkName <String> -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzAppNetworkAppLinkMember -AppLinkName <String> -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update an AppLinkMember.

## EXAMPLES

### Example 1: Update the release channel of an Application Network member
```powershell
Update-AzAppNetworkAppLinkMember -Name member-01 -AppLinkName appnet-test-01 -ResourceGroupName test_rg -FullyManagedUpgradeProfileReleaseChannel Stable
```

```output
Name      ClusterType ProvisioningState ResourceGroupName
----      ----------- ----------------- -----------------
member-01 AKS         Succeeded         test_rg
```

Updates the fully managed release channel of the `member-01` Application Network member to `Stable`.

### Example 2: Update the Application Network version of a self managed member
```powershell
Update-AzAppNetworkAppLinkMember -Name member-01 -AppLinkName appnet-test-01 -ResourceGroupName test_rg -SelfManagedUpgradeProfileVersion 1.4
```

```output
Name      ClusterType ProvisioningState ResourceGroupName
----      ----------- ----------------- -----------------
member-01 AKS         Succeeded         test_rg
```

Updates the self managed Application Network version of the `member-01` member to `1.4`.

## PARAMETERS

### -AppLinkInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppNetwork.Models.IAppNetworkIdentity
Parameter Sets: UpdateViaIdentityAppLinkExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppLinkExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppLinkExpanded, UpdateViaIdentityExpanded
Aliases:

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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the AppLinkMember

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppLinkExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppLinkExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppLinkExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityAppLinkExpanded, UpdateViaIdentityExpanded
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

