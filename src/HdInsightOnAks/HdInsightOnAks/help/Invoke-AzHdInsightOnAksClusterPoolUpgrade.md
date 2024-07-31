---
external help file: Az.HdInsightOnAks-help.xml
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/invoke-azhdinsightonaksclusterpoolupgrade
schema: 2.0.0
---

# Invoke-AzHdInsightOnAksClusterPoolUpgrade

## SYNOPSIS
Upgrade a cluster pool.

## SYNTAX

### UpgradeExpanded (Default)
```
Invoke-AzHdInsightOnAksClusterPoolUpgrade -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -UpgradeType <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpgradeViaJsonString
```
Invoke-AzHdInsightOnAksClusterPoolUpgrade -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpgradeViaJsonFilePath
```
Invoke-AzHdInsightOnAksClusterPoolUpgrade -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Upgrade
```
Invoke-AzHdInsightOnAksClusterPoolUpgrade -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -ClusterPoolUpgradeRequest <IClusterPoolUpgrade> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpgradeViaIdentityExpanded
```
Invoke-AzHdInsightOnAksClusterPoolUpgrade -InputObject <IHdInsightOnAksIdentity> -UpgradeType <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpgradeViaIdentity
```
Invoke-AzHdInsightOnAksClusterPoolUpgrade -InputObject <IHdInsightOnAksIdentity>
 -ClusterPoolUpgradeRequest <IClusterPoolUpgrade> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Upgrade a cluster pool.

## EXAMPLES

### Example 1: Upgrade a cluster pool(NodeOsUpgrade).
```powershell
$clusterResourceGroupName = "Group"
$clusterpoolName = "your-clusterpool"
Invoke-AzHdInsightOnAksClusterPoolUpgrade -ResourceGroupName $clusterResourceGroupName -ClusterPoolName $clusterpoolName -UpgradeType NodeOsUpgrade
```

```output
AkClusterProfileAkClusterAgentPoolIdentityProfileMsiClientId   : 
AkClusterProfileAkClusterAgentPoolIdentityProfileMsiObjectId   : 
AkClusterProfileAkClusterAgentPoolIdentityProfileMsiResourceId : 
AkClusterProfileAksClusterResourceId                           : 
AkClusterProfileAksVersion                                     : 
AksManagedResourceGroupName                                    : 
ComputeProfileCount                                            : 
ComputeProfileVMSize                                           : 
DeploymentId                                                   : 
Id                                                             : /providers/Microsoft.HDInsight/locations/WESTUS3/operationStatuses/29a21725-8fec-428a-911f-dccc6ec9a6d8*F7AC27D6EE8809127228CC9761587D363E49354C7A941A3D1D0AF885952AC245
Location                                                       : 
LogAnalyticProfileEnabled                                      : False
LogAnalyticProfileWorkspaceId                                  : 
ManagedResourceGroupName                                       : 
Name                                                           : 29a21725-8fec-428a-911f-dccc6ec9a6d8*F7AC27D6EE8809127228CC9761587D363E49354C7A941A3D1D0AF885952AC245
NetworkProfileApiServerAuthorizedIPRange                       : 
NetworkProfileEnablePrivateApiServer                           : 
NetworkProfileOutboundType                                     : 
NetworkProfileSubnetId                                         : 
ProfileClusterPoolVersion                                      : 
ProvisioningState                                              : 
ResourceGroupName                                              : 
Status                                                         : 
SystemDataCreatedAt                                            : 
SystemDataCreatedBy                                            : 
SystemDataCreatedByType                                        : 
SystemDataLastModifiedAt                                       : 
SystemDataLastModifiedBy                                       : 
SystemDataLastModifiedByType                                   : 
Tag                                                            : {}
Type                                                           :
```

Upgrade a cluster pool and upgrade type is NodeOsUpgrade.

### Example 2: Upgrade a cluster pool(AKSPatchUpgrade).
```powershell
$clusterResourceGroupName = "Group"
$clusterpoolName = "your-clusterpool"
$upgradeObj = New-AzHdInsightOnAksClusterPoolAksPatchVersionUpgradeObject -TargetAksVersion "1.27.9" -UpgradeClusterPool $true
Invoke-AzHdInsightOnAksClusterPoolUpgrade -ResourceGroupName $clusterResourceGroupName -ClusterPoolName $clusterpoolName -ClusterPoolUpgradeRequest $upgradeObj
```

```output
AkClusterProfileAkClusterAgentPoolIdentityProfileMsiClientId   : 
AkClusterProfileAkClusterAgentPoolIdentityProfileMsiObjectId   : 
AkClusterProfileAkClusterAgentPoolIdentityProfileMsiResourceId : 
AkClusterProfileAksClusterResourceId                           : 
AkClusterProfileAksVersion                                     : 
AksManagedResourceGroupName                                    : 
ComputeProfileCount                                            : 
ComputeProfileVMSize                                           : 
DeploymentId                                                   : 
Id                                                             : /providers/Microsoft.HDInsight/locations/WESTUS3/operationStatuses/0aea8755-7a43-4c4a-96ea-a2879b9cb820*F7AC27D6EE8809127228CC9761587D363E49354C7A941A3D1D0AF885952AC245
Location                                                       : 
LogAnalyticProfileEnabled                                      : False
LogAnalyticProfileWorkspaceId                                  : 
ManagedResourceGroupName                                       : 
Name                                                           : 0aea8755-7a43-4c4a-96ea-a2879b9cb820*F7AC27D6EE8809127228CC9761587D363E49354C7A941A3D1D0AF885952AC245
NetworkProfileApiServerAuthorizedIPRange                       : 
NetworkProfileEnablePrivateApiServer                           : 
NetworkProfileOutboundType                                     : 
NetworkProfileSubnetId                                         : 
ProfileClusterPoolVersion                                      : 
ProvisioningState                                              : 
ResourceGroupName                                              : 
Status                                                         : 
...
```

Upgrade a cluster pool and upgrade type is NodeOsUpgrade.

## PARAMETERS

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

### -ClusterPoolUpgradeRequest
Cluster Pool Upgrade.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterPoolUpgrade
Parameter Sets: Upgrade, UpgradeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity
Parameter Sets: UpgradeViaIdentityExpanded, UpgradeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Upgrade operation

```yaml
Type: System.String
Parameter Sets: UpgradeViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Upgrade operation

```yaml
Type: System.String
Parameter Sets: UpgradeViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the cluster pool.

```yaml
Type: System.String
Parameter Sets: UpgradeExpanded, UpgradeViaJsonString, UpgradeViaJsonFilePath, Upgrade
Aliases: ClusterPoolName

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
Parameter Sets: UpgradeExpanded, UpgradeViaJsonString, UpgradeViaJsonFilePath, Upgrade
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
Type: System.String
Parameter Sets: UpgradeExpanded, UpgradeViaJsonString, UpgradeViaJsonFilePath, Upgrade
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpgradeType
Type of upgrade.

```yaml
Type: System.String
Parameter Sets: UpgradeExpanded, UpgradeViaIdentityExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterPoolUpgrade

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterPool

## NOTES

## RELATED LINKS
