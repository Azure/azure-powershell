---
external help file:
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
Reset-AzLabServicesVMPassword -Password <SecureString> -ResourceId <String> [-SubscriptionId <String>]
 [-Username <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [<CommonParameters>]
```

### ResetExpanded
```
Reset-AzLabServicesVMPassword -LabName <String> -ResourceGroupName <String> -VirtualMachineName <String>
 -Password <SecureString> -Username <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ResetViaIdentityExpanded
```
Reset-AzLabServicesVMPassword -InputObject <ILabServicesIdentity> -Password <SecureString> -Username <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ResetViaIdentityLabExpanded
```
Reset-AzLabServicesVMPassword -LabInputObject <ILabServicesIdentity> -VirtualMachineName <String>
 -Password <SecureString> -Username <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ResetViaJsonFilePath
```
Reset-AzLabServicesVMPassword -LabName <String> -ResourceGroupName <String> -VirtualMachineName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ResetViaJsonString
```
Reset-AzLabServicesVMPassword -LabName <String> -ResourceGroupName <String> -VirtualMachineName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### VM
```
Reset-AzLabServicesVMPassword -Password <SecureString> -VM <VirtualMachine> [-SubscriptionId <String>]
 [-Username <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [<CommonParameters>]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.ILabServicesIdentity
Parameter Sets: ResetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Reset operation

```yaml
Type: System.String
Parameter Sets: ResetViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Reset operation

```yaml
Type: System.String
Parameter Sets: ResetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LabInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.ILabServicesIdentity
Parameter Sets: ResetViaIdentityLabExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LabName
The name of the lab that uniquely identifies it within containing lab account.
Used in resource URIs.

```yaml
Type: System.String
Parameter Sets: ResetExpanded, ResetViaJsonFilePath, ResetViaJsonString
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
Parameter Sets: ResetExpanded, ResetViaIdentityExpanded, ResetViaIdentityLabExpanded, ResourceId, VM
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
Parameter Sets: ResetExpanded, ResetViaJsonFilePath, ResetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource Id of lab service virtual machine.

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
Parameter Sets: ResetExpanded, ResetViaJsonFilePath, ResetViaJsonString, ResourceId, VM
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
Parameter Sets: ResetExpanded, ResetViaIdentityExpanded, ResetViaIdentityLabExpanded, ResourceId, VM
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
Parameter Sets: ResetExpanded, ResetViaIdentityLabExpanded, ResetViaJsonFilePath, ResetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VM
The object of lab service virtual machine.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.VirtualMachine
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

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.ILabServicesIdentity

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.VirtualMachine

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.IVirtualMachine

### System.Boolean

## NOTES

## RELATED LINKS

