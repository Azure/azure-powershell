---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/get-azchaoscapabilitytype
schema: 2.0.0
---

# Get-AzChaosCapabilityType

## SYNOPSIS
Get a Capability Type resource for given Target Type and location.

## SYNTAX

### List (Default)
```
Get-AzChaosCapabilityType -LocationName <String> -TargetTypeName <String> [-SubscriptionId <String[]>]
 [-ContinuationToken <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzChaosCapabilityType -LocationName <String> -Name <String> -TargetTypeName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzChaosCapabilityType -InputObject <IChaosIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityLocation
```
Get-AzChaosCapabilityType -LocationInputObject <IChaosIdentity> -Name <String> -TargetTypeName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityTargetType
```
Get-AzChaosCapabilityType -Name <String> -TargetTypeInputObject <IChaosIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Capability Type resource for given Target Type and location.

## EXAMPLES

### Example 1: Get a Capability Type resource for given Target Type and location.
```powershell
Get-AzChaosCapabilityType -LocationName eastus -TargetTypeName microsoft-virtualmachine
```

```output
Name         Location ResourceGroupName
----         -------- -----------------
Redeploy-1.0 eastus
Shutdown-1.0 eastus
```

Get a Capability Type resource for given Target Type and location.

### Example 2: Get a Capability Type resource for given Target Type and location.
```powershell
Get-AzChaosCapabilityType -LocationName eastus -TargetTypeName microsoft-virtualmachine -Name Shutdown-1.0
```

```output
AzureRbacAction              : {Microsoft.Compute/virtualMachines/poweroff/action, Microsoft.Compute/virtualMachines/start/action, Microsoft.Compute/virtualMachines/instanceView/read, Microsoft.Compute/virtua
                               lMachines/read…}
AzureRbacDataAction          :
Description                  :
DisplayName                  :
Id                           : /subscriptions/{subId}/providers/Microsoft.Chaos/locations/eastus/targetTypes/virtualmachine/capabilityTypes/Shutdown-1.0
Kind                         : Fault
Location                     : eastus
Name                         : Shutdown-1.0
ParametersSchema             : https://schema-tc.eastus.chaos-prod.azure.com/targetTypes/Microsoft-VirtualMachine/capabilityTypes/Shutdown-1.0/parametersSchema.json
Publisher                    : Microsoft
ResourceGroupName            :
RuntimePropertyKind          : Continuous
SystemDataCreatedAt          : 2024-03-08 06:57:59 PM
SystemDataCreatedBy          :
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 2024-03-08 06:57:59 PM
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TargetType                   : VirtualMachine
Type                         : Microsoft.Chaos/locations/targetTypes/capabilityTypes
Urn                          : urn:csci:microsoft:virtualMachine:shutdown/1.0
```

Get a Capability Type resource for given Target Type and location.

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
String that represents a Capability Type resource name.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityLocation, GetViaIdentityTargetType
Aliases: CapabilityTypeName

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

### -TargetTypeInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: GetViaIdentityTargetType
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -TargetTypeName
String that represents a Target Type resource name.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityLocation, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.ICapabilityType

## NOTES

## RELATED LINKS

