---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/invoke-azhdinsightonaksmanageclusterlibrary
schema: 2.0.0
---

# Invoke-AzHdInsightOnAksManageClusterLibrary

## SYNOPSIS
Library management operations on HDInsight on AKS cluster.

## SYNTAX

### ManageViaIdentity (Default)
```
Invoke-AzHdInsightOnAksManageClusterLibrary -InputObject <IHdInsightOnAksIdentity>
 -Operation <IClusterLibraryManagementOperation> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Manage
```
Invoke-AzHdInsightOnAksManageClusterLibrary -ClusterName <String> -ClusterPoolName <String>
 -ResourceGroupName <String> -Operation <IClusterLibraryManagementOperation> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ManageExpanded
```
Invoke-AzHdInsightOnAksManageClusterLibrary -ClusterName <String> -ClusterPoolName <String>
 -ResourceGroupName <String> -Action <String> -Library <IClusterLibrary[]> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ManageViaIdentityClusterpool
```
Invoke-AzHdInsightOnAksManageClusterLibrary -ClusterName <String>
 -ClusterpoolInputObject <IHdInsightOnAksIdentity> -Operation <IClusterLibraryManagementOperation>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ManageViaIdentityClusterpoolExpanded
```
Invoke-AzHdInsightOnAksManageClusterLibrary -ClusterName <String>
 -ClusterpoolInputObject <IHdInsightOnAksIdentity> -Action <String> -Library <IClusterLibrary[]>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ManageViaIdentityExpanded
```
Invoke-AzHdInsightOnAksManageClusterLibrary -InputObject <IHdInsightOnAksIdentity> -Action <String>
 -Library <IClusterLibrary[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ManageViaJsonFilePath
```
Invoke-AzHdInsightOnAksManageClusterLibrary -ClusterName <String> -ClusterPoolName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ManageViaJsonString
```
Invoke-AzHdInsightOnAksManageClusterLibrary -ClusterName <String> -ClusterPoolName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Library management operations on HDInsight on AKS cluster.

## EXAMPLES

### Example 1: Install maven library to cluster.
```powershell
$libObj=New-AzHdInsightOnAksClusterMavenLibraryObject -GroupId "com.azure.resourcemanager" -Name "azure-resourcemanager-hdinsight-containers" -Version "1.0.0-beta.2" -Remark "Maven lib"
Invoke-AzHdInsightOnAksManageClusterLibrary -ResourceGroupName hilocli-test -ClusterPoolName hilopoolwus3 -ClusterName cluster2024521155147  -Action Install -Library $libObj -AsJob
```

```output
Id     Name            PSJobTypeName   State         HasMoreData     Location             Command
--     ----            -------------   -----         -----------     --------             -------
1      Invoke-AzHdIns…                 Running       True            localhost            Invoke-AzHdInsightOnAksM…
```

Install azure-resourcemanager-hdinsight-containers library to the cluster.

### Example 2: Uninstall pypi library to cluster.
```powershell
$libObj=New-AzHdInsightOnAksClusterPyPiLibraryObject -Name pandas -Version 2.2.2 
Invoke-AzHdInsightOnAksManageClusterLibrary -ResourceGroupName hilocli-test -ClusterPoolName hilopoolwus3 -ClusterName cluster2024521155147  -Action Uninstall -Library $libObj -AsJob
```

```output
Id     Name            PSJobTypeName   State         HasMoreData     Location             Command
--     ----            -------------   -----         -----------     --------             -------
1      Invoke-AzHdIns…                 Running       True            localhost            Invoke-AzHdInsightOnAksM…
```

Uninstall the pandas library on the cluster.

## PARAMETERS

### -Action
The library management action.

```yaml
Type: System.String
Parameter Sets: ManageExpanded, ManageViaIdentityClusterpoolExpanded, ManageViaIdentityExpanded
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

### -ClusterName
The name of the HDInsight cluster.

```yaml
Type: System.String
Parameter Sets: Manage, ManageExpanded, ManageViaIdentityClusterpool, ManageViaIdentityClusterpoolExpanded, ManageViaJsonFilePath, ManageViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterpoolInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity
Parameter Sets: ManageViaIdentityClusterpool, ManageViaIdentityClusterpoolExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterPoolName
The name of the cluster pool.

```yaml
Type: System.String
Parameter Sets: Manage, ManageExpanded, ManageViaJsonFilePath, ManageViaJsonString
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
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity
Parameter Sets: ManageViaIdentity, ManageViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Manage operation

```yaml
Type: System.String
Parameter Sets: ManageViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Manage operation

```yaml
Type: System.String
Parameter Sets: ManageViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Library
The libraries to be installed/updated/uninstalled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterLibrary[]
Parameter Sets: ManageExpanded, ManageViaIdentityClusterpoolExpanded, ManageViaIdentityExpanded
Aliases:

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

### -Operation
Library management operation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterLibraryManagementOperation
Parameter Sets: Manage, ManageViaIdentity, ManageViaIdentityClusterpool
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
Parameter Sets: Manage, ManageExpanded, ManageViaJsonFilePath, ManageViaJsonString
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
Parameter Sets: Manage, ManageExpanded, ManageViaJsonFilePath, ManageViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterLibraryManagementOperation

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

