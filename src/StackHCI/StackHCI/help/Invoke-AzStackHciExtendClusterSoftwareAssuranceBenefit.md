---
external help file: Az.StackHCI-help.xml
Module Name: Az.StackHCI
online version: https://learn.microsoft.com/powershell/module/az.stackhci/invoke-azstackhciextendclustersoftwareassurancebenefit
schema: 2.0.0
---

# Invoke-AzStackHciExtendClusterSoftwareAssuranceBenefit

## SYNOPSIS
Extends Software Assurance Benefit to a cluster

## SYNTAX

### ExtendExpanded (Default)
```
Invoke-AzStackHciExtendClusterSoftwareAssuranceBenefit -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-SoftwareAssuranceIntent <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ExtendViaJsonString
```
Invoke-AzStackHciExtendClusterSoftwareAssuranceBenefit -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ExtendViaJsonFilePath
```
Invoke-AzStackHciExtendClusterSoftwareAssuranceBenefit -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ExtendViaIdentityExpanded
```
Invoke-AzStackHciExtendClusterSoftwareAssuranceBenefit -InputObject <IStackHciIdentity>
 [-SoftwareAssuranceIntent <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Extends Software Assurance Benefit to a cluster

## EXAMPLES

### Example 1:
```powershell
Invoke-AzStackHciExtendClusterSoftwareAssuranceBenefit -ClusterName "test-clus" -ResourceGroupName "test-rg"
```

Enable Software Assurance on a cluster, by default the intent is "enable".

### Example 2:
```powershell
Invoke-AzStackHciExtendClusterSoftwareAssuranceBenefit -ClusterName "test-clus" -ResourceGroupName "test-rg" -SoftwareAssuranceIntent "Disable"
```

Disable Software Assurance on a cluster.

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

### -ClusterName
The name of the cluster.

```yaml
Type: System.String
Parameter Sets: ExtendExpanded, ExtendViaJsonString, ExtendViaJsonFilePath
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
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.IStackHciIdentity
Parameter Sets: ExtendViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Extend operation

```yaml
Type: System.String
Parameter Sets: ExtendViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Extend operation

```yaml
Type: System.String
Parameter Sets: ExtendViaJsonString
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: ExtendExpanded, ExtendViaJsonString, ExtendViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoftwareAssuranceIntent
Customer Intent for Software Assurance Benefit.

```yaml
Type: System.String
Parameter Sets: ExtendExpanded, ExtendViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: "Enable"
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: ExtendExpanded, ExtendViaJsonString, ExtendViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.IStackHciIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.ICluster

## NOTES

## RELATED LINKS
