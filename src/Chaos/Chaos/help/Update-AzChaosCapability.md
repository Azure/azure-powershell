---
external help file: Az.Chaos-help.xml
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/update-azchaoscapability
schema: 2.0.0
---

# Update-AzChaosCapability

## SYNOPSIS
Update a Capability resource that extends a Target resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzChaosCapability -Name <String> -ParentProviderNamespace <String> -ParentResourceName <String>
 -ParentResourceType <String> -ResourceGroupName <String> [-SubscriptionId <String>] -TargetName <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityTargetExpanded
```
Update-AzChaosCapability -Name <String> -TargetInputObject <IChaosIdentity> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzChaosCapability -InputObject <IChaosIdentity> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a Capability resource that extends a Target resource.

## EXAMPLES

### Example 1: Create a Capability resource that extends a Target resource.
```powershell
Update-AzChaosCapability -Name Shutdown-1.0 -ParentProviderNamespace Microsoft.Compute -ParentResourceName exampleVM -ParentResourceType virtualMachines -ResourceGroupName azps_test_group_chaos -TargetName microsoft-virtualmachine
```

```output
Description                  :
Id                           : /subscriptions/{subId}/resourceGroups/azps_test_group_chaos/providers/Microsoft.Compute/virtualMachines/exampleVM/providers/Microsoft.Chaos/targets/
                               microsoft-virtualmachine/capabilities/Shutdown-1.0
Name                         : Shutdown-1.0
ParametersSchema             : https://schema-tc.eastus.chaos-prod.azure.com/targetTypes/Microsoft-VirtualMachine/capabilityTypes/Shutdown-1.0/parametersSchema.json
Publisher                    : microsoft
ResourceGroupName            : azps_test_group_chaos
SystemDataCreatedAt          : 2024-03-18 10:28:43 AM
SystemDataCreatedBy          :
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 2024-03-18 11:35:18 AM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TargetType                   : virtualmachine
Type                         : Microsoft.Chaos/targets/capabilities
Urn                          : urn:csci:microsoft:virtualMachine:shutdown/1.0
```

Create a Capability resource that extends a Target resource.

## PARAMETERS

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
String that represents a Capability resource name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityTargetExpanded
Aliases: CapabilityName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentProviderNamespace
String that represents a resource provider namespace.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentResourceName
String that represents a resource name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentResourceType
String that represents a resource type.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
String that represents an Azure resource group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
GUID that represents an Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: UpdateViaIdentityTargetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -TargetName
String that represents a Target resource name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.ICapability

## NOTES

## RELATED LINKS
