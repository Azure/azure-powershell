---
external help file: Az.Logz-help.xml
Module Name: Az.Logz
online version: https://learn.microsoft.com/powershell/module/Az.Logz/new-AzLogzVMResourcesObject
schema: 2.0.0
---

# New-AzLogzVMResourcesObject

## SYNOPSIS
Create an in-memory object for VMResources.

## SYNTAX

```
New-AzLogzVMResourcesObject [-AgentVersion <String>] [-Id <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for VMResources.

## EXAMPLES

### Example 1: Create a in-memory object for VMResources pass into parameter VMResource when updating vm host of the monitor resource
```powershell
$vmResource = New-AzLogzVMResourcesObject -AgentVersion '1.0' -Id '/SUBSCRIPTIONS/CE37D538-DFA3-49C3-B3CD-149B4B7DB48A/RESOURCEGROUPS/KOYTEST/PROVIDERS/MICROSOFT.COMPUTE/VIRTUALMACHINES/TEST-VM-1'
Update-AzLogzMonitorVMHost -ResourceGroupName logz-rg-test -Name pwsh-logz04 -State 'Install' -VMResource $vmResource
```

```output
AgentVersion Id
------------ --
1.0          /SUBSCRIPTIONS/CE37D538-DFA3-49C3-B3CD-149B4B7DB48A/RESOURCEGROUPS/KOYTEST/PROVIDERS/MICROSOFT.COMPUTE/VIRTUALMACHINES/TEST-VM-1
```

This command creates a in-memory object for VMResources pass into parameter VMResource when updating vm host of the monitor resource.

## PARAMETERS

### -AgentVersion
Version of the Logz agent installed on the VM.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Request of a list vm host update operation.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.Api20201001Preview.VMResources

## NOTES

## RELATED LINKS
