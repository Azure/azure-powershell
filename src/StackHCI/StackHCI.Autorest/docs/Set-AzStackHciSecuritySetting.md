---
external help file:
Module Name: Az.StackHCI
online version: https://learn.microsoft.com/powershell/module/az.stackhci/set-azstackhcisecuritysetting
schema: 2.0.0
---

# Set-AzStackHciSecuritySetting

## SYNOPSIS
Create a security setting

## SYNTAX

```
Set-AzStackHciSecuritySetting -ClusterName <String> -ResourceGroupName <String> -SName <String>
 [-SubscriptionId <String>] [-ProvisioningState <ProvisioningState>]
 [-SecuredCoreComplianceAssignment <ComplianceAssignmentType>]
 [-SmbEncryptionForIntraClusterTrafficComplianceAssignment <ComplianceAssignmentType>]
 [-WdacComplianceAssignment <ComplianceAssignmentType>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a security setting

## EXAMPLES

### Example 1:
```powershell
Set-AzStackHciSecuritySetting -ClusterName 'test-cluster' -ResourceGroupName 'test-rg'
```

```output
Name    ResourceGroupName
----    ----------------- .....
default test-rg
```

Sets the Security Setting

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

### -ProvisioningState
The status of the last operation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Support.ProvisioningState
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecuredCoreComplianceAssignment
Secured Core Compliance Assignment

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Support.ComplianceAssignmentType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SmbEncryptionForIntraClusterTrafficComplianceAssignment
SMB encryption for intra-cluster traffic Compliance Assignment

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Support.ComplianceAssignmentType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SName
Name of security setting

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SecuritySettingsName

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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WdacComplianceAssignment
WDAC Compliance Assignment

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Support.ComplianceAssignmentType
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.ISecuritySetting

## NOTES

## RELATED LINKS

