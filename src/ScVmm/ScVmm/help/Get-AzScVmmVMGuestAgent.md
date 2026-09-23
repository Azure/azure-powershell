---
external help file: Az.ScVmm-help.xml
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/az.scvmm/get-azscvmmvmguestagent
schema: 2.0.0
---

# Get-AzScVmmVMGuestAgent

## SYNOPSIS
Implements Azure Arc agent GET method.

## SYNTAX

```
Get-AzScVmmVMGuestAgent -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Implements Azure Arc agent GET method.

## EXAMPLES

### Example 1: Get GuestAgent
```powershell
Get-AzScVmmVMGuestAgent -Name "test-vm" -ResourceGroupName "test-rg-01"
```

```output
CredentialsPassword          :
CredentialsUsername          : testUser
CustomResourceName           :
HttpProxyConfigHttpsProxy    :
Id                           : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/M
                               icrosoft.HybridCompute/machines/test-vm/providers/Microsoft.ScVmm/virtualMachineIn
                               stances/default/guestAgents/default
Name                         : default
ProvisioningAction           : install
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg-01
Status                       : Enabled
SystemDataCreatedAt          : 08-01-2024 10:04:20
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 08-01-2024 13:14:34
SystemDataLastModifiedBy     : 11111111-aaaa-2222-bbbb-333333333333
SystemDataLastModifiedByType : Application
Type                         : microsoft.scvmm/virtualmachineinstances/guestagents
Uuid                         :
```

Gets GuestAgent resource details for the given virtual machine.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IGuestAgent

## NOTES

## RELATED LINKS
