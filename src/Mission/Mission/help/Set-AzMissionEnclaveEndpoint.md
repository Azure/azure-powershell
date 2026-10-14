---
external help file: Az.Mission-help.xml
Module Name: Az.Mission
online version: https://learn.microsoft.com/powershell/module/az.mission/set-azmissionenclaveendpoint
schema: 2.0.0
---

# Set-AzMissionEnclaveEndpoint

## SYNOPSIS
Update a EnclaveEndpointResource

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzMissionEnclaveEndpoint -Name <String> -ResourceGroupName <String> -VirtualEnclaveName <String>
 [-SubscriptionId <String>] -Location <String> [-RuleCollection <IEnclaveEndpointDestinationRule[]>]
 [-Tag <Hashtable>] [-UpdateMode <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Set-AzMissionEnclaveEndpoint -Name <String> -ResourceGroupName <String> -VirtualEnclaveName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Set-AzMissionEnclaveEndpoint -Name <String> -ResourceGroupName <String> -VirtualEnclaveName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a EnclaveEndpointResource

## EXAMPLES

### Example 1: Replace an enclave endpoint's rule collection (PUT)
```powershell
$rule = @{ destinationType = 'FQDNTag'; destination = 'api.contoso.com'; ports = '443'; protocols = @('TCP') }
Set-AzMissionEnclaveEndpoint -Name 'contoso-enclave-endpoint' -VirtualEnclaveName 'contoso-enclave' -ResourceGroupName 'mission-rg' -Location 'eastus' -RuleCollection $rule -UpdateMode 'Manual'
```

```output
Name                     Location ResourceGroupName ProvisioningState UpdateMode
----                     -------- ----------------- ----------------- ----------
contoso-enclave-endpoint eastus   mission-rg        Succeeded         Manual
```

Replaces the full definition of the `contoso-enclave-endpoint` enclave endpoint, swapping in a new rule permitting HTTPS traffic to `api.contoso.com` and switching to manual update mode.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
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

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Enclave Endpoint Resource

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: EnclaveEndpointName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleCollection
Enclave Endpoint Rule Collection.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IEnclaveEndpointDestinationRule[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdateMode
Whether update mode is automatic or manual.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualEnclaveName
The name of the enclaveResource Resource

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

### Microsoft.Azure.PowerShell.Cmdlets.Mission.Models.IEnclaveEndpointResource

## NOTES

## RELATED LINKS
