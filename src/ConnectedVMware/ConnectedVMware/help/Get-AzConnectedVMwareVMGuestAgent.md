---
external help file: Az.ConnectedVMware-help.xml
Module Name: Az.ConnectedVMware
online version: https://learn.microsoft.com/powershell/module/az.connectedvmware/get-azconnectedvmwarevmguestagent
schema: 2.0.0
---

# Get-AzConnectedVMwareVMGuestAgent

## SYNOPSIS
Implements GuestAgent GET method.

## SYNTAX

```
Get-AzConnectedVMwareVMGuestAgent -MachineId <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Implements GuestAgent GET method.

## EXAMPLES

### Example 1: Get guest agent of a specific VM
```powershell
Get-AzConnectedVMwareVMGuestAgent -MachineId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine"
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

This command gets a guest agent of a VM Instances of machine named `test-machine`.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IGuestAgent

## NOTES

## RELATED LINKS
