---
external help file:
Module Name: Az.FileShare
online version: https://learn.microsoft.com/powershell/module/az.fileshare/get-azfileshareinformationaloperationprovisioningrecommendation
schema: 2.0.0
---

# Get-AzFileShareInformationalOperationProvisioningRecommendation

## SYNOPSIS
Get file shares provisioning parameters recommendation.

## SYNTAX

### GetExpanded (Default)
```
Get-AzFileShareInformationalOperationProvisioningRecommendation -Location <String>
 -ProvisionedStorageGiB <Int32> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Get
```
Get-AzFileShareInformationalOperationProvisioningRecommendation -Location <String>
 -Body <IFileShareProvisioningRecommendationRequest> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzFileShareInformationalOperationProvisioningRecommendation -InputObject <IFileShareIdentity>
 -Body <IFileShareProvisioningRecommendationRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### GetViaIdentityExpanded
```
Get-AzFileShareInformationalOperationProvisioningRecommendation -InputObject <IFileShareIdentity>
 -ProvisionedStorageGiB <Int32> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaJsonFilePath
```
Get-AzFileShareInformationalOperationProvisioningRecommendation -Location <String> -JsonFilePath <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaJsonString
```
Get-AzFileShareInformationalOperationProvisioningRecommendation -Location <String> -JsonString <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Get file shares provisioning parameters recommendation.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -Body
Request structure for file share provisioning parameters recommendation API.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationRequest
Parameter Sets: Get, GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareIdentity
Parameter Sets: GetViaIdentity, GetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Get operation

```yaml
Type: System.String
Parameter Sets: GetViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Get operation

```yaml
Type: System.String
Parameter Sets: GetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The name of the Azure region.

```yaml
Type: System.String
Parameter Sets: Get, GetExpanded, GetViaJsonFilePath, GetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisionedStorageGiB
The desired provisioned storage size of the share in GiB.
Will be use to calculate the values of remaining provisioning parameters.

```yaml
Type: System.Int32
Parameter Sets: GetExpanded, GetViaIdentityExpanded
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
Parameter Sets: Get, GetExpanded, GetViaJsonFilePath, GetViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareIdentity

### Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareProvisioningRecommendationResponse

## NOTES

## RELATED LINKS

