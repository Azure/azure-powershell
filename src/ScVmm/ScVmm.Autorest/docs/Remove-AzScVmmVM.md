---
external help file:
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/az.scvmm/remove-azscvmmvm
schema: 2.0.0
---

# Remove-AzScVmmVM

## SYNOPSIS
The operation to delete a virtual machine instance.

## SYNTAX

```
Remove-AzScVmmVM -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-DeleteFromHost]
 [-DeleteMachine] [-Force] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
The operation to delete a virtual machine instance.

`-DeleteMachine` : Deletes the Virtual Machine resource from Azure (It retains the virtual machine on SCVMM on-premises).
`-DeleteFromHost`: Deletes the virtual machine from the SCVMM host.

To remove the virtual machine resource from Azure (and not SCVMM host), use `-DeleteMachine`.

To retain the virtual machine resource in Azure and delete it from SCVMM host, use `-DeleteFromHost`.
To remove the virtual machine resource from Azure and SCVMM host, use both `-DeleteMachine` and `-DeleteFromHost`.

## EXAMPLES

### Example 2: Disable VM in Azure
```powershell
Remove-AzScVmmVM -Name "test-vm" -ResourceGroupName "test-rg-01" 
```

Disables VM resource in Azure.
Doesn't remove Extended Machine resource or VM from SCVMM host.

### Example 2: Remove Extended Machine resource for VM
```powershell
Remove-AzScVmmVM -Name "test-vm" -ResourceGroupName "test-rg-01" -DeleteMachine
```

Disables VM resource in Azure and remove Extended Machine resource for VM.
Does not remove VM from SCVMM host.
`-NoWait` or `-AsJob` does not work with `-DeleteMachine`.

### Example 3: Removes VM from VMM
```powershell
Remove-AzScVmmVM -Name "test-vm" -ResourceGroupName "test-rg-01" -DeleteFromHost
```

Disables VM resource in Azure and remove VM from SCVMM host.
Does not removes Extended Machine resource for VM and require manual cleanup from RG.

### Example 3: Removes VM from VMM and Remove Extended Machine resource for VM
```powershell
Remove-AzScVmmVM -Name "test-vm" -ResourceGroupName "test-rg-01" -DeleteFromHost -DeleteMachine
```

Disables VM resource in Azure, removes Extended Machine resource for VM and remove VM from SCVMM host.
`-NoWait` or `-AsJob` does not work with `-DeleteMachine`.

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

### -DeleteFromHost
Whether to disable the VM from azure and also delete it from Vmm.

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

### -DeleteMachine
Deletes the Hybrid Compute Machine resource associated with the virtual machine.

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

### -Force
Forces the resource to be deleted.

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

### -Name
The name of the virtual machine.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: VMName

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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

