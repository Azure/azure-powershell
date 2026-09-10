---
external help file: Az.Resilience-help.xml
Module Name: Az.Resilience
online version: https://learn.microsoft.com/powershell/module/az.resilience/get-azresilienceoperationstatus
schema: 2.0.0
---

# Get-AzResilienceOperationStatus

## SYNOPSIS
Returns the current status of an async operation.

## SYNTAX

### Get (Default)
```
Get-AzResilienceOperationStatus -Location <String> -OperationId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityLocation
```
Get-AzResilienceOperationStatus -OperationId <String> -LocationInputObject <IResilienceIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzResilienceOperationStatus -InputObject <IResilienceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns the current status of an async operation.

## EXAMPLES

### Example 1: Get the status of an asynchronous operation
```powershell
Get-AzResilienceOperationStatus `
  -Location 'eastus' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41'
```

Returns the current status of a long-running operation.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The name of the Azure region.

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

### -LocationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: GetViaIdentityLocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OperationId
The ID of an ongoing async operation.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityLocation
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

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IOperationStatusResult

## NOTES

## RELATED LINKS
