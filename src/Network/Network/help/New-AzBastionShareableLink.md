---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azbastionshareablelink
schema: 2.0.0
---

# New-AzBastionShareableLink

## SYNOPSIS
The Bastion Shareable Link feature lets users connect to a target resource (virtual machine or virtual machine scale set) using Azure Bastion without accessing the Azure portal.

## SYNTAX

### ByResourceGroupNameByName (Default)
```
New-AzBastionShareableLink -ResourceGroupName <String> -Name <String>
 -TargetVmId <System.Collections.Generic.List`1[System.String]> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByResourceId
```
New-AzBastionShareableLink -ResourceId <String> -TargetVmId <System.Collections.Generic.List`1[System.String]>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByInputObject
```
New-AzBastionShareableLink -InputObject <PSBastion>
 -TargetVmId <System.Collections.Generic.List`1[System.String]> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a Bastion Shareable Links for all the VMs specified in the request.

## EXAMPLES

### Example 1
```powershell
$vm = Get-AzVM -ResourceGroupName $RgName -Name $vmName
New-AzBastionShareableLink -ResourceGroupName $RgName -Name $bastionName -TargetVmId $vm.Id
```

```output
{
  "vm": {
    "id": "/subscriptions/subid/resourceGroups/rgx/providers/Microsoft.Compute/virtualMachines/vm1"
  },
  "bsl": "http://bst-bastionhostid.bastion.com/api/shareable-url/tokenvm1",
  "createdAt": "2019-10-18T12:00:00.0000Z"
}
```

### Example 2
```powershell
$vm1 = Get-AzVM -ResourceGroupName $RgName -Name $vmName1
$vm2 = Get-AzVM -ResourceGroupName $RgName -Name $vmName2
$bastion = Get-AzBastion -ResourceGroupName $RgName -Name $bastionName
New-AzBastionShareableLink -InputObject $bastion -TargetVmId $vm1.Id, $vm2.Id
```

```output
{
  "vm": {
    "id": "/subscriptions/subid/resourceGroups/rgx/providers/Microsoft.Compute/virtualMachines/vm1"
  },
  "bsl": "http://bst-bastionhostid.bastion.com/api/shareable-url/tokenvm1",
  "createdAt": "2019-10-18T12:00:00.0000Z"
},
{
  "vm": {
    "id": "/subscriptions/subid/resourceGroups/rgx/providers/Microsoft.Compute/virtualMachines/vm2"
  },
  "bsl": "http://bst-bastionhostid.bastion.com/api/shareable-url/tokenvm2",
  "createdAt": "2019-10-17T12:00:00.0000Z"
}
```

Creates a shareable link for specified VMs on a Bastion resource.

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Bastion object

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSBastion
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The Bastion resource name

```yaml
Type: System.String
Parameter Sets: ByResourceGroupNameByName
Aliases: ResourceName, BastionName

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

### -ResourceGroupName
The resource group name where Bastion resource exists

```yaml
Type: System.String
Parameter Sets: ByResourceGroupNameByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The Bastion resource ID

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetVmId
ID of the VMs that require generation of Bastion shareable links

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
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

### System.Collections.Generic.List`1[[System.String, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### System.Management.Automation.SwitchParameter

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Network.Models.Bastion.PSBastionShareableLink, Microsoft.Azure.PowerShell.Cmdlets.Network, Version=7.5.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS

[Bastion Shareable Link](https://aka.ms/bastionshareablelink)
