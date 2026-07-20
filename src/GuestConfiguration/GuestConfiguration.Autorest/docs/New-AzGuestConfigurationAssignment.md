---
external help file:
Module Name: Az.GuestConfiguration
online version: https://learn.microsoft.com/powershell/module/az.guestconfiguration/new-azguestconfigurationassignment
schema: 2.0.0
---

# New-AzGuestConfigurationAssignment

## SYNOPSIS
create an association between a VM and guest configuration

## SYNTAX

### CreateExpanded (Default)
```
New-AzGuestConfigurationAssignment -GuestConfigurationAssignmentName <String> -ResourceGroupName <String>
 -VMName <String> -GuestConfigurationContentHash <String> -GuestConfigurationContentUri <String>
 -GuestConfigurationName <String> -GuestConfigurationVersion <String> [-SubscriptionId <String>]
 [-Context <String>] [-GuestConfigurationAssignmentType <String>] [-GuestConfigurationKind <String>]
 [-GuestConfigurationParameter <IConfigurationParameter[]>]
 [-GuestConfigurationProtectedParameter <IConfigurationParameter[]>] [-Location <String>] [-Name <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded1
```
New-AzGuestConfigurationAssignment -GuestConfigurationAssignmentName <String> -MachineName <String>
 -ResourceGroupName <String> -GuestConfigurationContentHash <String> -GuestConfigurationContentUri <String>
 -GuestConfigurationName <String> -GuestConfigurationVersion <String> [-SubscriptionId <String>]
 [-Context <String>] [-GuestConfigurationAssignmentType <String>] [-GuestConfigurationKind <String>]
 [-GuestConfigurationParameter <IConfigurationParameter[]>]
 [-GuestConfigurationProtectedParameter <IConfigurationParameter[]>] [-Location <String>] [-Name <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzGuestConfigurationAssignment -GuestConfigurationAssignmentName <String> -ResourceGroupName <String>
 -VMName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath1
```
New-AzGuestConfigurationAssignment -GuestConfigurationAssignmentName <String> -MachineName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzGuestConfigurationAssignment -GuestConfigurationAssignmentName <String> -ResourceGroupName <String>
 -VMName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString1
```
New-AzGuestConfigurationAssignment -GuestConfigurationAssignmentName <String> -MachineName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
create an association between a VM and guest configuration

## EXAMPLES

### Example 1: Create an association between a VM and guest configuration
```powershell
New-AzGuestConfigurationAssignment -GuestConfigurationAssignmentName test-assignment -ResourceGroupName test-rg -VMName test-vm -GuestConfigurationName test-config -GuestConfigurationVersion "1.0.0.3" -GuestConfigurationContentUri "https://thisisfake/package" -GuestConfigurationContentHash "123contenthash"
```

```output
Location      Name     ResourceGroupName
--------      ----     -----------------
westcentralus test-assignment test-rg
```

Create an association between a VM and guest configuration

### Example 2: Create an association between a ARC machine and guest configuration
```powershell
New-AzGuestConfigurationAssignment -GuestConfigurationAssignmentName test-assignment -ResourceGroupName test-rg -MachineName test-machine -GuestConfigurationName test-config -GuestConfigurationVersion "1.0.0.3" -GuestConfigurationContentUri "https://thisisfake/package" -GuestConfigurationContentHash "123contenthash"
```

```output
Location      Name     ResourceGroupName
--------      ----     -----------------
westcentralus test-assignment test-rg
```

Create an association between a ARC machine and guest configuration

## PARAMETERS

### -Context
The source which initiated the guest configuration assignment.
Ex: Azure Policy

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1
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

### -GuestConfigurationAssignmentName
Name of the guest configuration assignment.

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

### -GuestConfigurationAssignmentType
Specifies the assignment type and execution of the configuration.
Possible values are Audit, DeployAndAutoCorrect, ApplyAndAutoCorrect and ApplyAndMonitor.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GuestConfigurationContentHash
Combined hash of the guest configuration package and configuration parameters.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GuestConfigurationContentUri
Uri of the storage where guest configuration package is uploaded.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GuestConfigurationKind
Kind of the guest configuration.
For example:DSC

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GuestConfigurationName
Name of the guest configuration.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GuestConfigurationParameter
The configuration parameters for the guest configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.IConfigurationParameter[]
Parameter Sets: CreateExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GuestConfigurationProtectedParameter
The protected configuration parameters for the guest configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.IConfigurationParameter[]
Parameter Sets: CreateExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GuestConfigurationVersion
Version of the guest configuration.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath, CreateViaJsonFilePath1
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
Parameter Sets: CreateViaJsonString, CreateViaJsonString1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Region where the VM is located.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MachineName
The name of the ARC machine.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaJsonFilePath1, CreateViaJsonString1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the guest configuration assignment.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

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
Subscription ID which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### -VMName
The name of the virtual machine.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.IGuestConfigurationAssignment

## NOTES

## RELATED LINKS

