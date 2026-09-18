---
external help file: Az.Mission-help.xml
Module Name: Az.Mission
online version: https://learn.microsoft.com/powershell/module/az.mission/get-azmissionenclaveendpoint
schema: 2.0.0
---

# Get-AzMissionEnclaveEndpoint

## SYNOPSIS
Get a EnclaveEndpointResource

## SYNTAX

### List (Default)
```
Get-AzMissionEnclaveEndpoint [-SubscriptionId <String[]>] -VirtualEnclaveName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityVirtualEnclave
```
Get-AzMissionEnclaveEndpoint -Name <String> -VirtualEnclaveInputObject <IMissionIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMissionEnclaveEndpoint -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -VirtualEnclaveName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzMissionEnclaveEndpoint -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -VirtualEnclaveName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMissionEnclaveEndpoint -InputObject <IMissionIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a EnclaveEndpointResource

## EXAMPLES

### Example 1: List all enclave endpoints in a virtual enclave
```powershell
Get-AzMissionEnclaveEndpoint -VirtualEnclaveName 'contoso-enclave' -ResourceGroupName 'mission-rg'
```

```output
Name                    Location ResourceGroupName ProvisioningState
----                    -------- ----------------- -----------------
contoso-enclave-endpoint eastus  mission-rg        Succeeded
```

Lists every enclave endpoint defined under the `contoso-enclave` virtual enclave in the `mission-rg` resource group.

### Example 2: Get a single enclave endpoint by name
```powershell
Get-AzMissionEnclaveEndpoint -Name 'contoso-enclave-endpoint' -VirtualEnclaveName 'contoso-enclave' -ResourceGroupName 'mission-rg'
```

```output
Name                     Location ResourceGroupName ProvisioningState UpdateMode
----                     -------- ----------------- ----------------- ----------
contoso-enclave-endpoint eastus   mission-rg        Succeeded         Automatic
```

Retrieves the `contoso-enclave-endpoint` enclave endpoint, including its rule collection and update mode.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMissionIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Enclave Endpoint Resource

```yaml
Type: System.String
Parameter Sets: GetViaIdentityVirtualEnclave, Get
Aliases: EnclaveEndpointName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List1
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
Parameter Sets: List, Get, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualEnclaveInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMissionIdentity
Parameter Sets: GetViaIdentityVirtualEnclave
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VirtualEnclaveName
The name of the enclaveResource Resource

```yaml
Type: System.String
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IMissionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IEnclaveEndpointResource

## NOTES

## RELATED LINKS
