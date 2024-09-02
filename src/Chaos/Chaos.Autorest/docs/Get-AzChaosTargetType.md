---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/get-azchaostargettype
schema: 2.0.0
---

# Get-AzChaosTargetType

## SYNOPSIS
Get a Target Type resources for given location.

## SYNTAX

### List (Default)
```
Get-AzChaosTargetType -LocationName <String> [-SubscriptionId <String[]>] [-ContinuationToken <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzChaosTargetType -LocationName <String> -Name <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzChaosTargetType -InputObject <IChaosIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityLocation
```
Get-AzChaosTargetType -LocationInputObject <IChaosIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Target Type resources for given location.

## EXAMPLES

### Example 1: List Target Type resources for given location.
```powershell
Get-AzChaosTargetType -LocationName eastus
```

```output
Name                                      Location ResourceGroupName
----                                      -------- -----------------
Microsoft-Agent                           eastus
Microsoft-AppService                      eastus
Microsoft-KeyVault                        eastus
```

List Target Type resources for given location.

### Example 2: Get a Target Type resources for given location.
```powershell
Get-AzChaosTargetType -LocationName eastus -Name Microsoft-KeyVault
```

```output
Description                  :
DisplayName                  :
Id                           : /subscriptions/{subId}/providers/Microsoft.Chaos/locations/eastus/targetTypes/Microsoft-KeyVault
Location                     : eastus
Name                         : Microsoft-KeyVault
PropertiesSchema             : https://schema-tc.eastus.chaos-prod.azure.com/targetTypes/Microsoft-KeyVault/propertiesSchema.json
ResourceGroupName            :
ResourceType                 : {Microsoft.KeyVault/vaults}
SystemDataCreatedAt          : 2024-03-08 06:57:58 PM
SystemDataCreatedBy          :
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 2024-03-08 06:57:58 PM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Chaos/locations/targetTypes
```

Get a Target Type resources for given location.

## PARAMETERS

### -ContinuationToken
String that sets the continuation token.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LocationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: GetViaIdentityLocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LocationName
String that represents a Location resource name.

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

### -Name
String that represents a Target Type resource name.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityLocation
Aliases: TargetTypeName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
GUID that represents an Azure subscription ID.

```yaml
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.ITargetType

## NOTES

## RELATED LINKS

