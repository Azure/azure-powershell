---
external help file: Az.ScVmm-help.xml
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/az.scvmm/get-azscvmmvmextension
schema: 2.0.0
---

# Get-AzScVmmVMExtension

## SYNOPSIS
The operation to get the extension on a virtual machine.

## SYNTAX

### List (Default)
```
Get-AzScVmmVMExtension -vmName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Expand <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzScVmmVMExtension -vmName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -ExtensionName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
The operation to get the extension on a virtual machine.

## EXAMPLES

### Example 1: Get all extensions of a SCVMM VM
```powershell
Get-AzScVmmVMExtension -vmName 'test-vm' -ResourceGroupName 'test-rg-01'
```

```output
Name                  ResourceGroupName Location    ProvisioningState
----                  ----------------- --------    -----------------
RunCommand            test-rg-01        eastus      Succeeded
GenevaMonitoringAgent test-rg-01        eastus      Succeeded
```

Get all extensions of a SCVMM VM.

### Example 2: Get extension of a SCVMM VM
```powershell
Get-AzScVmmVMExtension -vmName 'test-vm' -ResourceGroupName 'test-rg-01' -ExtensionName 'RunCommand'
```

```output
AutoUpgradeMinorVersion        : False
EnableAutomaticUpgrade         : True
ForceUpdateTag                 :
Id                             : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.HybridCompute/machines/test-vm/extensions/RunCommand
InstanceViewName               : RunCommand
InstanceViewType               : CustomScriptExtension
InstanceViewTypeHandlerVersion : 1.10.20
Location                       : eastus
Name                           : RunCommand
PropertiesType                 : CustomScriptExtension
ProtectedSetting               : {
                                 }
ProvisioningState              : Succeeded
Publisher                      : Microsoft.Compute
ResourceGroupName              : test-rg-01
Setting                        : {
                                   "commandToExecute": "whoami"
                                 }
StatusCode                     : 0
StatusDisplayStatus            :
StatusLevel                    : Information
StatusMessage                  : Extension Message: , StdOut: nt authority\system

StatusTime                     :
SystemDataCreatedAt            :
SystemDataCreatedBy            :
SystemDataCreatedByType        :
SystemDataLastModifiedAt       :
SystemDataLastModifiedBy       :
SystemDataLastModifiedByType   :
Tag                            : {
                                 }
Type                           : Microsoft.HybridCompute/machines/extensions
TypeHandlerVersion             : 1.10.20
```

Get extension of a SCVMM VM.

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

### -Expand
The expand expression to apply on the operation.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtensionName
The name of the machine extension.

```yaml
Type: System.String
Parameter Sets: Get
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
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -vmName
The name of the machine containing the extension.

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

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IMachineExtension

## NOTES

## RELATED LINKS
