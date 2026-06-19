---
external help file:
Module Name: Az.PrivateTrafficManager
online version: https://learn.microsoft.com/powershell/module/az.privatetrafficmanager/update-azprivatetrafficmanagerhealthpolicy
schema: 2.0.0
---

# Update-AzPrivateTrafficManagerHealthPolicy

## SYNOPSIS
Update a Traffic Manager health policy.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzPrivateTrafficManagerHealthPolicy -Name <String> -PrivateTrafficManagerProfileName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzPrivateTrafficManagerHealthPolicy -InputObject <IPrivateTrafficManagerIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityPrivateTrafficManagerProfileExpanded
```
Update-AzPrivateTrafficManagerHealthPolicy -Name <String>
 -PrivateTrafficManagerProfileInputObject <IPrivateTrafficManagerIdentity> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a Traffic Manager health policy.

## EXAMPLES

### Example 1: Update a health policy using a JSON string
```powershell
$jsonString = '{"kind":"Probe","properties":{"name":"hp1","probeConfig":{"protocol":"HTTPS","port":443,"path":"/health","intervalInSeconds":60,"timeoutInSeconds":15,"toleratedNumberOfFailures":5}}}'
Update-AzPrivateTrafficManagerHealthPolicy -Name "hp1" -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" -JsonString $jsonString
```

```output
Name  Kind   ProvisioningState
----  ----   -----------------
hp1   Probe  Succeeded
```

This command updates the health policy to increase the probe interval to 60 seconds and tolerated failures to 5.

### Example 2: Update a health policy using a JSON file
```powershell
Update-AzPrivateTrafficManagerHealthPolicy -Name "hp1" -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" -JsonFilePath "./updated-healthpolicy.json"
```

```output
Name  Kind   ProvisioningState
----  ----   -----------------
hp1   Probe  Succeeded
```

This command updates the health policy configuration from a JSON file.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IPrivateTrafficManagerIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Traffic Manager health policy.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityPrivateTrafficManagerProfileExpanded
Aliases: HealthPolicyName

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

### -PrivateTrafficManagerProfileInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IPrivateTrafficManagerIdentity
Parameter Sets: UpdateViaIdentityPrivateTrafficManagerProfileExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateTrafficManagerProfileName
The name of the Private Traffic Manager profile.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IPrivateTrafficManagerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PrivateTrafficManager.Models.IHealthPolicy

## NOTES

## RELATED LINKS

