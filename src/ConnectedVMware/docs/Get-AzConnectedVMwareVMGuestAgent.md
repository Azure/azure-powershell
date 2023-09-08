---
external help file:
Module Name: Az.ConnectedVMware
online version: https://docs.microsoft.com/powershell/module/az.connectedvmware/get-azconnectedvmwarevmguestagent
schema: 2.0.0
---

# Get-AzConnectedVMwareVMGuestAgent

## SYNOPSIS
Implements GuestAgent GET method.

## SYNTAX

### Get (Default)
```
Get-AzConnectedVMwareVMGuestAgent -ResourceUri <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzConnectedVMwareVMGuestAgent -ResourceUri <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Implements GuestAgent GET method.

## EXAMPLES

### Example 1: Get guest agent of a specific VM
```powershell
Get-AzConnectedVMwareGuestAgent -VirtualMachineName "test-vm" -ResourceGroupName "azcli-test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Name    ResourceGroupName
----    -----------------
default azcli-test-rg
```

This command gets a guest agent of a Virtaul Machine named `test-vm` in a resource group named `azcli-test-rg`.

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

### -ResourceUri
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IGuestAgent

## NOTES

## RELATED LINKS

