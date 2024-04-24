---
external help file: Az.ConnectedVMware-help.xml
Module Name: Az.ConnectedVMware
online version: https://learn.microsoft.com/powershell/module/az.connectedvmware/new-azconnectedvmwarevmguestagent
schema: 2.0.0
---

# New-AzConnectedVMwareVMGuestAgent

## SYNOPSIS
Create GuestAgent.

## SYNTAX

### CreateExpanded (Default)
```
New-AzConnectedVMwareVMGuestAgent -MachineId <String> [-CredentialsPassword <SecureString>]
 [-CredentialsUsername <String>] [-HttpProxyConfigHttpsProxy <String>] [-PrivateLinkScopeResourceId <String>]
 [-ProvisioningAction <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzConnectedVMwareVMGuestAgent -MachineId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzConnectedVMwareVMGuestAgent -MachineId <String> -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create GuestAgent.

## EXAMPLES

### Example 1: Enable Guest Agent on VM Instances
```powershell
New-AzConnectedVMwareVMGuestAgent -MachineId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine" -CredentialsUsername "test-user" -CredentialsPassword "test-pw" -ProvisioningAction "install"
```

```output
CredentialsPassword          :
CredentialsUsername          : abc
CustomResourceName           : d04a3534-2dfa-42c8-8959-83796a1bcac1
HttpProxyConfigHttpsProxy    :
Id                           : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default/guestAgents/default
Name                         : default
PrivateLinkScopeResourceId   :
ProvisioningAction           : install
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
Status                       : Enabled
Statuses                     : {{
                                 "type": "Ready",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-10-06T14:47:02.1828535Z"
                               }, {
                                 "type": "Idle",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-10-06T14:47:02.1828535Z"
                               }}
SystemDataCreatedAt          : 10/6/2023 2:45:33 PM
SystemDataCreatedBy          : xyz
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/6/2023 2:45:33 PM
SystemDataLastModifiedBy     : xyz
SystemDataLastModifiedByType : User
Type                         : microsoft.connectedvmwarevsphere/virtualmachineinstances/guestagents
Uuid                         : 6a37a700-e02c-476d-a19f-258761575c40
```

This command Enable Guest Agent of a VM Instances of machine named `test-machine`.

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

### -CredentialsPassword
Gets or sets the password to connect with the guest.

```yaml
Type: System.Security.SecureString
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CredentialsUsername
Gets or sets username to connect with the guest.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### -HttpProxyConfigHttpsProxy
Gets or sets httpsProxy url.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
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
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MachineId
The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended.

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

### -PrivateLinkScopeResourceId
The resource id of the private link scope this machine is assigned to, if any.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisioningAction
Gets or sets the guest agent provisioning action.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IGuestAgent

## NOTES

## RELATED LINKS
