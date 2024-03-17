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
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzConnectedVMwareVMGuestAgent -MachineId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzConnectedVMwareVMGuestAgent -MachineId <String> -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
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
Runthecommandasajob

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
Getsorsetsthepasswordtoconnectwiththeguest.

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
Getsorsetsusernametoconnectwiththeguest.

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
TheDefaultProfileparameterisnotfunctional.UsetheSubscriptionIdparameterwhenavailableifexecutingthecmdletagainstadifferentsubscription.

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
GetsorsetshttpsProxyurl.

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
PathofJsonfilesuppliedtotheCreateoperation

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
JsonstringsuppliedtotheCreateoperation

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
ThefullyqualifiedAzureResourcemanageridentifieroftheHybridComputemachineresourcetobeextended.

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
Runthecommandasynchronously

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
Theresourceidoftheprivatelinkscopethismachineisassignedto,ifany.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisioningAction
Getsorsetstheguestagentprovisioningaction.

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
