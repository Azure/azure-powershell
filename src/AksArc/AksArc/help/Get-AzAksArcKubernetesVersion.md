---
external help file: Az.AksArc-help.xml
Module Name: Az.AksArc
online version: https://learn.microsoft.com/powershell/module/az.aksarc/get-azaksarckubernetesversion
schema: 2.0.0
---

# Get-AzAksArcKubernetesVersion

## SYNOPSIS
Lists the supported kubernetes versions for the specified custom location

## SYNTAX

```
Get-AzAksArcKubernetesVersion -CustomLocationResourceUri <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Lists the supported kubernetes versions for the specified custom location

## EXAMPLES

### Example 1: Get supported kubernetes versions
```powershell
Get-AzAksArcKubernetesVersion -CustomLocationResourceUri sample_cl
```

This command lists the supported kubernetes versions in the custom location.

## PARAMETERS

### -CustomLocationResourceUri
The fully qualified Azure Resource Manager identifier of the custom location resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.AksArc.Models.IKubernetesVersionProfile

## NOTES

## RELATED LINKS
