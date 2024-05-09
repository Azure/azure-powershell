---
external help file:
Module Name: Az.Support
online version: https://learn.microsoft.com/powershell/module/az.support/get-azsupportproblemclassification
schema: 2.0.0
---

# Get-AzSupportProblemClassification

## SYNOPSIS
Get problem classification details for a specific Azure service.

## SYNTAX

### List (Default)
```
Get-AzSupportProblemClassification -ServiceName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSupportProblemClassification -Name <String> -ServiceName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSupportProblemClassification -InputObject <ISupportIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityService
```
Get-AzSupportProblemClassification -Name <String> -ServiceInputObject <ISupportIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get problem classification details for a specific Azure service.

## EXAMPLES

### Example 1: List Azure Support Problem Classifications
```powershell
Get-AzSupportProblemClassification -ServiceName "6f16735c-b0ae-b275-ad3a-03479cfa1396"
```

```output
DisplayName                                                                                     Name                                 SecondaryConsentEnabled
-----------                                                                                     ----                                 -----------------------
Compute-VM (cores-vCPUs) subscription limit increases                                           4d78b174-3203-a3ac-9e08-41fb35de6354
Windows Update, Guest Patching and OS Upgrades / Issue with Azure Automatic VM guest patching   e565bd13-86f0-ecb3-d2b7-0a7501ae8839
Windows Update, Guest Patching and OS Upgrades / Issue with Azure Update Management patching    8d686480-ef41-5005-358e-12b9be9608fe
```

Lists all the problem classifications (categories) available for a specific Azure service.
Always use the service and problem classifications obtained programmatically.
This practice ensures that you always have the most recent set of service and problem classification Ids.

### Example 2: Get Azure Support Problem Classification
```powershell
Get-AzSupportProblemClassification -ServiceName "6f16735c-b0ae-b275-ad3a-03479cfa1396" -Name "e565bd13-86f0-ecb3-d2b7-0a7501ae8839"
```

```output
DisplayName             : Windows Update, Guest Patching and OS Upgrades / Issue with Azure Automatic VM guest patching
Id                      : /providers/Microsoft.Support/services/6f16735c-b0ae-b275-ad3a-03479cfa1396/problemClassifications/e565bd13-86f0-ecb3-d2b7-0a7501ae8839
Name                    : e565bd13-86f0-ecb3-d2b7-0a7501ae8839
ResourceGroupName       :
SecondaryConsentEnabled :
Type                    : Microsoft.Support/problemClassifications
```

Get problem classification details for a specific Azure service.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of problem classification.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityService
Aliases: ProblemClassificationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity
Parameter Sets: GetViaIdentityService
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServiceName
Name of the Azure service available for support.

```yaml
Type: System.String
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.IProblemClassification

## NOTES

## RELATED LINKS

