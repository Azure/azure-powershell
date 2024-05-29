---
external help file: Az.LabServices-help.xml
Module Name: Az.LabServices
online version: https://learn.microsoft.com/powershell/module/az.labservices/reset-azlabservicesvmpassword
schema: 2.0.0
---

# Reset-AzLabServicesVMPassword

## SYNOPSIS
Resets a lab virtual machine password.

## SYNTAX

### ResourceId (Default)
```
Reset-AzLabServicesVMPassword [-SubscriptionId <String>] -Password <SecureString> -Username <String>
 -ResourceId <String> [-DefaultProfile <PSObject>] [-PassThru] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Reset
```
Reset-AzLabServicesVMPassword -LabName <String> -ResourceGroupName <String> -VirtualMachineName <String>
 [-SubscriptionId <String>] -Password <SecureString> -Username <String> [-DefaultProfile <PSObject>]
 [-PassThru] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### VM
```
Reset-AzLabServicesVMPassword [-SubscriptionId <String>] -Password <SecureString> -Username <String>
 -VM <VirtualMachine> [-DefaultProfile <PSObject>] [-PassThru] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Resets a lab virtual machine password.

## EXAMPLES

### Example 1: Reset the password on the VM.
```powershell
Reset-AzLabServicesVMPassword -ResourceGroupName "Group Name" -LabName "Lab Name" -VirtualMachineName 0 -Password "New Password"
```

This changes the VM password.

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
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -LabName
The name of the lab that uniquely identifies it within containing lab account.
Used in resource URIs.

```yaml
Type: System.String
Parameter Sets: Reset
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

### -Password
The password

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: True
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
Parameter Sets: Reset
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId

```yaml
Type: System.String
Parameter Sets: ResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

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

### -Username
The user whose password is being reset

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

### -VirtualMachineName
The ID of the virtual machine that uniquely identifies it within the containing lab.
Used in resource URIs.

```yaml
Type: System.String
Parameter Sets: Reset
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VM
To construct, see NOTES section for VM properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.VirtualMachine
Parameter Sets: VM
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.VirtualMachine

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachine

### System.Boolean

## NOTES

## RELATED LINKS
