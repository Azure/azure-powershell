---
external help file: Az.ServiceLinker-help.xml
Module Name: Az.ServiceLinker
online version: https://learn.microsoft.com/powershell/module/az.ServiceLinker/new-azservicelinkerazureresourceobject
schema: 2.0.0
---

# New-AzServiceLinkerAzureResourceObject

## SYNOPSIS
Create an in-memory object for AzureResource.

## SYNTAX

```
New-AzServiceLinkerAzureResourceObject -Id <String> [-ConnectAsKubernetesCsiDriver <Boolean>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureResource.

## EXAMPLES

### Example 1: Create an target resource object for azure resource
```powershell
New-AzServiceLinkerAzureResourceObject -Id /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/servicelinker-test-group/providers/Microsoft.KeyVault/vaults/servicelinker-test-kv -ConnectAsKubernetesCsiDriver 1
```

```output
Id
--
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/servicelinker-test-…
```

Create an AzureResourceObject as the param of `-TargetService`

## PARAMETERS

### -ConnectAsKubernetesCsiDriver
True if connect via Kubernetes CSI Driver.
Source must be AKS and target must be KeyVault.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The Id of azure resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.Api20221101Preview.AzureResource

## NOTES

## RELATED LINKS
