---
external help file: Az.DisconnectedOperations-help.xml
Module Name: Az.DisconnectedOperations
online version: https://learn.microsoft.com/powershell/module/az.disconnectedoperations/remove-azdisconnectedoperationshardwaresetting
schema: 2.0.0
---

# Remove-AzDisconnectedOperationsHardwareSetting

## SYNOPSIS
Delete hardware settings

## SYNTAX

### Delete (Default)
```
Remove-AzDisconnectedOperationsHardwareSetting -HardwareSettingName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentityDisconnectedOperation
```
Remove-AzDisconnectedOperationsHardwareSetting -HardwareSettingName <String>
 -DisconnectedOperationInputObject <IDisconnectedOperationsIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzDisconnectedOperationsHardwareSetting -InputObject <IDisconnectedOperationsIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Delete hardware settings

## EXAMPLES

### Example 1: Delete a hardware setting for a specific resource with expanded parameters
```powershell
Remove-AzDisconnectedOperationsHardwareSetting -Name "winfield-ps-test" -ResourceGroupName "winfield-demo-rg-2" -HardwareSettingName "default"
```

This command deletes the hardware setting named "default" for the resource "winfield-ps-test" in the resource group "winfield-demo-rg-2".
You can specify additional parameters such as SubscriptionId if you want to target a different subscription, or use -Confirm and -WhatIf for safer execution.

### Example 2: Delete a hardware setting for a specific resource using identity.
```powershell
$inputObject = @{
  "HardwareSettingName" = "default";
  "Name" = "disconnected-operation-name";
  "ResourceGroupName" = "my-resource-group";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Remove-AzDisconnectedOperationsHardwareSetting -InputObject $inputObject
```

This command deletes the hardware setting named "default" for the resource identified by the input object, which includes the name of the disconnected operation, resource group, and subscription ID.

### Example 3: Delete a hardware setting for a specific resource using DisconnectedOperation identity
```powershell
$disconnectedOperations = @{
  "Name" = "disconnected-operation-name";
  "ResourceGroupName" = "my-resource-group";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Remove-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default" -DisconnectedOperationInputObject $disconnectedOperations
```

This command deletes the hardware setting named "default" for the resource identified by the DisconnectedOperation identity, which includes the name of the disconnected operation, resource group, and subscription ID.

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

### -DisconnectedOperationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationsIdentity
Parameter Sets: DeleteViaIdentityDisconnectedOperation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -HardwareSettingName
The name of the HardwareSetting

```yaml
Type: System.String
Parameter Sets: Delete, DeleteViaIdentityDisconnectedOperation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationsIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the resource

```yaml
Type: System.String
Parameter Sets: Delete
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

### -PassThru
Returns true when the command succeeds

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
Parameter Sets: Delete
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
Parameter Sets: Delete
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

### Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationsIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
