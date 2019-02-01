---
external help file: Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.dll-Help.xml
Module Name: Az.GuestConfiguration
online version: https://docs.microsoft.com/en-us/powershell/module/az.guestconfiguration/get-azvmguestpolicystatushistory
schema: 2.0.0
---

# Get-AzVMGuestPolicyStatusHistory

## SYNOPSIS
Gets guest configuration policy compliance status history for an initiative of type "Guest Configuration" that is assigned to a VM.
An initiative is a policy of definition type "Initiative".

## SYNTAX

### VmScope (Default)
```
Get-AzVMGuestPolicyStatusHistory [-ResourceGroupName] <String> [-VMName] <String> [-ShowOnlyChange]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### InitiativeIdScope
```
Get-AzVMGuestPolicyStatusHistory [-ResourceGroupName] <String> [-VMName] <String> [-InitiativeId] <String>
 [-ShowOnlyChange] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### InitiativeNameScope
```
Get-AzVMGuestPolicyStatusHistory [-ResourceGroupName] <String> [-VMName] <String> [-InitiativeName] <String>
 [-ShowOnlyChange] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzVMGuestPolicyStatusHistory cmdlet gets compliance status history of guest configuration policies for an initiative of type "Guest Configuration" that is assigned to a VM.
An initiative is a policy of definition type "Initiative".
Use Get-AzVMGuestPolicyReport cmdlet to get details of a single compliance report using reportId that can be found in output of Get-AzVMGuestPolicyStatusHistory cmdlet.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzVMGuestPolicyStatusHistory -ResourceGroupName "MyResourceGroupName" -VMName "MyVMName" -InitiativeId "/providers/Microsoft.Authorization/policySetDefinitions/3fa7cbf5-c0a4-4a59-85a5-cca4d996d5af" -ShowOnlyChanges
```

Gets compliance status history by initiative Id.
ShowOnlyChanges switch shows only historical status changes.
Skips statuses that have not changed between two compliance status audit runs.

### Example 2
```
PS C:\> Get-AzVMGuestPolicyStatusHistory -ResourceGroupName "MyResourceGroupName" -VMName "MyVMName" -InitiativeName "b5a822e0-ba98-4e54-9278-5d9833aa9b17" -ShowOnlyChanges
```

Gets compliance status history by initiative name.
ShowOnlyChanges switch shows only historical status changes.
Skips statuses that have not changed between two compliance status audit runs.

### Example 3
```
PS C:\> Get-AzVMGuestPolicyStatusHistory -ResourceGroupName "MyResourceGroupName" -VMName "MyVMName" -ShowOnlyChanges
```

Gets compliance status history for all guest configuration policies assigned to the VM.
ShowOnlyChanges switch shows only historical status changes.
Skips statuses that have not changed between two compliance status audit runs.

### Example 4
```
PS C:\> Get-AzVMGuestPolicyReport -ReportId "/subscriptions/4e6c6ed2-0bf6-41d7-9d21-a452c2cc7920/resourceGroups/MyResourceGroupName/providers/Microsoft.Compute/virtualMachines/MyVMName/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/MaximumPasswordAge/reports/c271f845-2c0a-4456-a441-e48fc332d0ac"
```

Get detailed guest configuration policy report by report Id.
The report Id is the ReportId property that can be found in the results of Get-AzVMGuestPolicyStatusHistory by initiativeId or Initiative name (please refer other examples)

### Example 5
```
PS C:\> Get-AzVMGuestPolicyStatusHistory -ResourceGroupName "MyResourceGroupName" -VMName "MyVMName" -InitiativeId "/providers/Microsoft.Authorization/policySetDefinitions/3fa7cbf5-c0a4-4a59-85a5-cca4d996d5af"
```

Gets compliance status history by initiative Id.

### Example 6
```
PS C:\> Get-AzVMGuestPolicyStatusHistory -ResourceGroupName "MyResourceGroupName" -VMName "MyVMName" -InitiativeName "b5a822e0-ba98-4e54-9278-5d9833aa9b17"
```

Gets compliance status history by initiative name.

### Example 7
```
PS C:\> Get-AzVMGuestPolicyStatusHistory -ResourceGroupName "MyResourceGroupName" -VMName "MyVMName"
```

Gets compliance status history for all guest configuration policies assigned to the VM.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InitiativeId
Definition Id of a policy where definition type is Initiative and category is Guest Configuration

```yaml
Type: System.String
Parameter Sets: InitiativeIdScope
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InitiativeName
Name of a policy where definition type is Initiative and category is Guest Configuration

```yaml
Type: System.String
Parameter Sets: InitiativeNameScope
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShowOnlyChange
Shows historical status changes only for guest configuration policies. Skips statuses that have not changed between two compliance status audit runs.

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

### -VMName
VM name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
### System.Management.Automation.SwitchParameter
## OUTPUTS

### System.Collections.Generic.IList`1[[Microsoft.Azure.Management.GuestConfiguration.Models.GuestConfigurationAssignment, Microsoft.Azure.Management.GuestConfiguration, Version=0.9.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]
### System.Collections.Generic.IList`1[[Microsoft.Azure.Management.GuestConfiguration.Models.GuestConfigurationAssignmentReport, Microsoft.Azure.Management.GuestConfiguration, Version=0.9.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]
## NOTES

## RELATED LINKS
