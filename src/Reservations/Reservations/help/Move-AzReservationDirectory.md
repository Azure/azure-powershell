---
external help file: Az.Reservations-help.xml
Module Name: Az.Reservations
online version: https://learn.microsoft.com/powershell/module/az.reservations/move-azreservationdirectory
schema: 2.0.0
---

# Move-AzReservationDirectory

## SYNOPSIS
Change directory (tenant) of `ReservationOrder` and all `Reservation` under it to specified tenant id

## SYNTAX

### ChangeExpanded (Default)
```
Move-AzReservationDirectory -ReservationOrderId <String> [-DestinationTenantId <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ChangeViaJsonString
```
Move-AzReservationDirectory -ReservationOrderId <String> -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ChangeViaJsonFilePath
```
Move-AzReservationDirectory -ReservationOrderId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ChangeViaIdentityExpanded
```
Move-AzReservationDirectory -InputObject <IReservationsIdentity> [-DestinationTenantId <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Change directory (tenant) of `ReservationOrder` and all `Reservation` under it to specified tenant id

## EXAMPLES

### Example 1: Move reservation order from one tenant to another
```powershell
Move-AzReservationDirectory -ReservationOrderId "7c31a9e8-8490-4002-88cd-3a16b71362a9" -DestinationTenantId "f65fbe9a-14b0-44c6-8c0d-2ef2c4543040"
```

```output
Reservation                 : {{
                                "id": "e2ce59da-9753-47f6-8576-2a2fab559409",
                                "name": "VM_RI_05-26-2022_16-53",
                                "isSucceeded": true
                              }, {
                                "id": "9a852181-9cec-43a4-852e-8cfd0bec11aa",
                                "name": "VM_RI_05-26-2022_16-53",
                                "isSucceeded": true
                              }, {
                                "id": "6dc205d9-8049-4179-9d60-29eb1d0082b3",
                                "name": "VM_RI_05-26-2022_16-53",
                                "isSucceeded": true
                              }}
ReservationOrderError       : 
ReservationOrderId          : 7c31a9e8-8490-4002-88cd-3a16b71362a9
ReservationOrderIsSucceeded : True
ReservationOrderName        : VM_RI_05-26-2022_16-53
```

Move reservation order from one tenant to another

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

### -DestinationTenantId
Tenant id GUID that reservation order is to be transferred to

```yaml
Type: System.String
Parameter Sets: ChangeExpanded, ChangeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IReservationsIdentity
Parameter Sets: ChangeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Change operation

```yaml
Type: System.String
Parameter Sets: ChangeViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Change operation

```yaml
Type: System.String
Parameter Sets: ChangeViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReservationOrderId
Order Id of the reservation

```yaml
Type: System.String
Parameter Sets: ChangeExpanded, ChangeViaJsonString, ChangeViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IReservationsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IChangeDirectoryResponse

## NOTES

## RELATED LINKS
