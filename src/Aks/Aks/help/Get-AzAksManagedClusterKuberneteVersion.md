---
external help file: Az.Aks-help.xml
Module Name: Az.Aks
online version: https://learn.microsoft.com/powershell/module/az.aks/get-azaksmanagedclusterkuberneteversion
schema: 2.0.0
---

# Get-AzAksManagedClusterKuberneteVersion

## SYNOPSIS
Contains extra metadata on the version, including supported patch versions, capabilities, available upgrades, and details on preview status of the version

## SYNTAX

```
Get-AzAksManagedClusterKuberneteVersion -Location <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Contains extra metadata on the version, including supported patch versions, capabilities, available upgrades, and details on preview status of the version

## EXAMPLES

### Example 1: Get AKS Kubernete Version
```powershell
Get-AzAksManagedClusterKuberneteVersion -Location eastus
```

```output
IsDefault IsPreview Version
--------- --------- -------
          True      1.34
                    1.33
True                1.32
                    1.31
                    1.30
                    1.29
                    1.28
```

Get extra metadata on the version, including supported patch versions, capabilities, available upgrades, and details on preview status of the version

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

### -Location
The name of the Azure region.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IKubernetesVersionListResult

## NOTES

## RELATED LINKS
