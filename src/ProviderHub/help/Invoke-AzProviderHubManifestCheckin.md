---
external help file:
Module Name: Az.ProviderHub
online version: https://docs.microsoft.com/powershell/module/az.providerhub/invoke-azproviderhubmanifestcheckin
schema: 2.0.0
---

# Invoke-AzProviderHubManifestCheckin

## SYNOPSIS
Checkin the manifest.

## SYNTAX

```
Invoke-AzProviderHubManifestCheckin -ProviderNamespace <String> -BaselineArmManifestLocation <String>
 -Environment <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Checkin the manifest.

## EXAMPLES

### Example 1: Checkin the resource provider manifest.
```powershell
PS C:\> Invoke-AzProviderHubManifestCheckin -ProviderNamespace "Microsoft.Contoso" -BaselineArmManifestLocation "NorthEurope" -Environment "Canary"

CommitId IsCheckedIn PullRequest StatusMessage
-------- ----------- ----------- -------------
         False                   Manifest is successfully merged.
```

Checkin the resource provider manifest.

### Example 2: Checkin the resource provider manifest.
```powershell
PS C:\> Invoke-AzProviderHubManifestCheckin -ProviderNamespace "Microsoft.Contoso" -BaselineArmManifestLocation "EastUS2EUAP" -Environment "Prod"

CommitId IsCheckedIn PullRequest StatusMessage
-------- ----------- ----------- -------------
         False                   Manifest is successfully merged.
```

Checkin the resource provider manifest.

## PARAMETERS

### -BaselineArmManifestLocation
The baseline ARM manifest location supplied to the checkin manifest operation.

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
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Environment
The environment supplied to the checkin manifest operation.

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

### -ProviderNamespace
The name of the resource provider hosted within ProviderHub.

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

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckinManifestInfo

## NOTES

ALIASES

## RELATED LINKS

