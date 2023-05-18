---
external help file:
Module Name: Az.Reservations
online version: https://learn.microsoft.com/powershell/module/az.reservations/get-azreservationcatalog
schema: 2.0.0
---

# Get-AzReservationCatalog

## SYNOPSIS
Get the regions and skus that are available for RI purchase for the specified Azure subscription.

## SYNTAX

### Get (Default)
```
Get-AzReservationCatalog [-SubscriptionId <String[]>] [-Filter <String>] [-Location <String>]
 [-OfferId <String>] [-PlanId <String>] [-PublisherId <String>] [-ReservedResourceType <String>]
 [-Skip <Single>] [-Take <Single>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzReservationCatalog -InputObject <IReservationsIdentity> [-Filter <String>] [-Location <String>]
 [-OfferId <String>] [-PlanId <String>] [-PublisherId <String>] [-ReservedResourceType <String>]
 [-Skip <Single>] [-Take <Single>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the regions and skus that are available for RI purchase for the specified Azure subscription.

## EXAMPLES

### Example 1: Get the list of reserved resource type skus with location
```powershell
Get-AzReservationCatalog -SubscriptionId "10000000-aaaa-bbbb-cccc-100000000001" -Location "westus" -ReservedResourceType "VirtualMachine"
```

```output
ResourceType    Terms           Name                   Locations
------------    -----           ----                   ---------
virtualMachines {P1Y, P3Y, P5Y} Standard_B12ms         {westus} 
virtualMachines {P1Y, P3Y, P5Y} Standard_B16ms         {westus} 
virtualMachines {P1Y, P3Y, P5Y} Standard_B1ls          {westus} 
virtualMachines {P1Y, P3Y, P5Y} Standard_B1ms          {westus} 
virtualMachines {P1Y, P3Y, P5Y} Standard_B1s           {westus} 
virtualMachines {P1Y, P3Y, P5Y} Standard_B20ms         {westus} 
virtualMachines {P1Y, P3Y, P5Y} Standard_B2ms          {westus} 
virtualMachines {P1Y, P3Y, P5Y} Standard_B2s           {westus} 
virtualMachines {P1Y, P3Y, P5Y} Standard_B4ms          {westus}
```

This command gets a catlog of reserved resource type skus with location

### Example 2: Get the list of reserved resource type skus without location
```powershell
Get-AzReservationCatalog -SubscriptionId "10000000-aaaa-bbbb-cccc-100000000001" -ReservedResourceType "SuseLinux"
```

```output
ResourceType Terms           Name                            Locations
------------ -----           ----                            ---------
SuseLinux    {P1Y, P3Y, P5Y} sles_hpc_standard_3-4_vcpu_vm   
SuseLinux    {P1Y, P3Y, P5Y} sles_hpc_standard_1-2_vcpu_vm   
SuseLinux    {P1Y, P3Y, P5Y} sles_hpc_standard_5plus_vcpu_vm 
SuseLinux    {P1Y, P3Y, P5Y} sles_hpc_priority_1-2_vcpu_vm   
SuseLinux    {P1Y, P3Y, P5Y} sles_hpc_priority_5plus_vcpu_vm 
SuseLinux    {P1Y, P3Y, P5Y} sles_hpc_priority_3-4_vcpu_vm   
SuseLinux    {P1Y, P3Y, P5Y} sles_standard_5plus_vcpu_vm     
SuseLinux    {P1Y, P3Y, P5Y} sles_standard_3-4_vcpu_vm       
SuseLinux    {P1Y, P3Y, P5Y} sles_standard_1-2_vcpu_vm       
SuseLinux    {P1Y, P3Y, P5Y} sles_priority_6_vcpu_vm
SuseLinux    {P1Y, P3Y, P5Y} sles_priority_2-4_vcpu_vm       
SuseLinux    {P1Y, P3Y, P5Y} sles_priority_1_vcpu_vm
SuseLinux    {P1Y, P3Y, P5Y} sles_priority_8plus_vcpu_vm     
SuseLinux    {P1Y, P3Y, P5Y} sles_sap_priority_5plus_vcpu_vm 
SuseLinux    {P1Y, P3Y, P5Y} sles_sap_priority_1-2_vcpu_vm   
SuseLinux    {P1Y, P3Y, P5Y} sles_sap_priority_3-4_vcpu_vm 
```

This command gets a catlog of reserved resource type skus without location

### Example 3: Get the list of eligible 3pp reserved resource type skus with publisher id, offer id, plan id
```powershell
Get-AzReservationCatalog -SubscriptionId "10000000-aaaa-bbbb-cccc-100000000001" -ReservedResourceType "VirtualMachineSoftware" -PublisherId canonical -OfferId 0001-com-ubuntu-pro-xenial -PlanId pro-16_04-lts
```

```output
ResourceType           Terms           Name                                                          Locations
------------           -----           ----                                                          ---------
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.10core     
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.416core    
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.2core      
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.36core     
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.80core
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.72core
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.sharedcore
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.20core
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.40core
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.48core
VirtualMachineSoftware {P1Y, P3Y, P5Y} canonical.0001-com-ubuntu-pro-xenial.pro-16_04-lts.4core
```

This command gets a catlog of eligible 3pp reserved resource type skus with publisher id, offer id, plan id

## PARAMETERS

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

### -Filter
May be used to filter by Catalog properties.
The filter supports 'eq', 'or', and 'and'.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IReservationsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Filters the skus based on the location specified in this parameter.
This can be an Azure region or global

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

### -OfferId
Offer id used to get the third party products

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

### -PlanId
Plan id used to get the third party products

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

### -PublisherId
Publisher id used to get the third party products

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

### -ReservedResourceType
The type of the resource for which the skus should be provided.

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

### -Skip
The number of reservations to skip from the list before returning results

```yaml
Type: System.Single
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Id of the subscription

```yaml
Type: System.String[]
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Take
To number of reservations to return

```yaml
Type: System.Single
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

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IReservationsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20221101.ICatalog

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IReservationsIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ReservationId <String>]`: Id of the reservation item
  - `[ReservationOrderId <String>]`: Order Id of the reservation
  - `[SubscriptionId <String>]`: Id of the subscription

## RELATED LINKS

