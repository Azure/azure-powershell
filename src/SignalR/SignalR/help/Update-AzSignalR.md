---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SignalR.dll-Help.xml
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/update-azsignalr
schema: 2.0.0
---

# Update-AzSignalR

## SYNOPSIS
Update a SignalR service.

## SYNTAX

### ResourceGroupParameterSet (Default)
```
Update-AzSignalR [-ResourceGroupName <String>] [-Name] <String> [-Sku <String>] [-UnitCount <Int32>]
 [-Tag <System.Collections.Generic.IDictionary`2[System.String,System.String]>] [-ServiceMode <String>]
 [-AllowedOrigin <String[]>] [-EnableSystemAssignedIdentity <Boolean>] [-UserAssignedIdentity <String[]>]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResourceIdParameterSet
```
Update-AzSignalR -ResourceId <String> [-Sku <String>] [-UnitCount <Int32>]
 [-Tag <System.Collections.Generic.IDictionary`2[System.String,System.String]>] [-ServiceMode <String>]
 [-AllowedOrigin <String[]>] [-EnableSystemAssignedIdentity <Boolean>] [-UserAssignedIdentity <String[]>]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputObjectParameterSet
```
Update-AzSignalR -InputObject <PSSignalRResource> [-Sku <String>] [-UnitCount <Int32>]
 [-Tag <System.Collections.Generic.IDictionary`2[System.String,System.String]>] [-ServiceMode <String>]
 [-AllowedOrigin <String[]>] [-EnableSystemAssignedIdentity <Boolean>] [-UserAssignedIdentity <String[]>]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update a SignalR service.
The following values will be used for the parameters if not specified:
* `ResourceGroupName`: the default resource group set by `Set-AzDefault -ResourceGroupName`.
* `Sku`: `Standard_S1`

## EXAMPLES

### Example 1: Update a specific SignalR service.
```powershell
Update-AzSignalR -ResourceGroupName myResourceGroup -Name mysignalr1 -UnitCount 5
```

```output
HostName                                 Location       ExternalIp      Sku         UnitCount ProvisioningState Version
--------                                 --------       ----------      ---         --------- ----------------- -------
mysignalr1.service.signalr.net           eastus         52.179.3.5      Standard_S1 5         Succeeded         1.0
```

### Example 2: Specify ServiceMode and AllowedOrigin
```powershell
Update-AzSignalR -ResourceGroupName myResourceGroup1 -Name mysignalr2 -ServiceMode Serverless -AllowedOrigin http://example1.com:12345, https://example2.cn
```

```output
HostName                                 Location       ExternalIp      Sku         UnitCount ProvisioningState Version
--------                                 --------       ----------      ---         --------- ----------------- -------
mysignalr1.service.signalr.net           eastus         52.179.3.5      Standard_S1 1         Succeeded         1.0
```

### Example 3: Enable system-assigned managed identity
```powershell
Update-AzSignalR -ResourceGroupName myResourceGroup -Name mysignalr1 -EnableSystemAssignedIdentity $true
```

```output
HostName                                 Location       ExternalIp      Sku         UnitCount ProvisioningState Version
--------                                 --------       ----------      ---         --------- ----------------- -------
mysignalr1.service.signalr.net           eastus         52.179.3.5      Standard_S1 1         Succeeded         1.0
```

This command enables system-assigned managed identity for the SignalR service. The identity can be used to access other Azure resources on behalf of the SignalR service.

### Example 4: Disable system-assigned managed identity
```powershell
Update-AzSignalR -ResourceGroupName myResourceGroup -Name mysignalr1 -EnableSystemAssignedIdentity $false
```

```output
HostName                                 Location       ExternalIp      Sku         UnitCount ProvisioningState Version
--------                                 --------       ----------      ---         --------- ----------------- -------
mysignalr1.service.signalr.net           eastus         52.179.3.5      Standard_S1 1         Succeeded         1.0
```

This command disables system-assigned managed identity for the SignalR service.

### Example 5: Switch from system-assigned to user-assigned identity
```powershell
# First create a user-assigned managed identity
$userIdentity = New-AzUserAssignedIdentity -ResourceGroupName myResourceGroup -Name myUserIdentity -Location eastus

# Switch from system-assigned to user-assigned identity
Update-AzSignalR -ResourceGroupName myResourceGroup -Name mysignalr1 -EnableSystemAssignedIdentity $false -UserAssignedIdentity $userIdentity.Id
```

```output
HostName                                 Location       ExternalIp      Sku         UnitCount ProvisioningState Version
--------                                 --------       ----------      ---         --------- ----------------- -------
mysignalr1.service.signalr.net           eastus         52.179.3.5      Standard_S1 1         Succeeded         1.0
```

This command disables system-assigned identity and enables user-assigned identity for the SignalR service. Note that SignalR does not support both system-assigned and user-assigned identities simultaneously.

### Example 6: Update user-assigned identities
```powershell
# Create multiple user-assigned managed identities
$identity1 = New-AzUserAssignedIdentity -ResourceGroupName myResourceGroup -Name myUserIdentity1 -Location eastus
$identity2 = New-AzUserAssignedIdentity -ResourceGroupName myResourceGroup -Name myUserIdentity2 -Location eastus

# Update SignalR service with new user-assigned identities
Update-AzSignalR -ResourceGroupName myResourceGroup -Name mysignalr1 -UserAssignedIdentity $identity1.Id, $identity2.Id
```

```output
HostName                                 Location       ExternalIp      Sku         UnitCount ProvisioningState Version
--------                                 --------       ----------      ---         --------- ----------------- -------
mysignalr1.service.signalr.net           eastus         52.179.3.5      Standard_S1 1         Succeeded         1.0
```

This command updates the SignalR service to use new user-assigned managed identities. Any existing user-assigned identities will be replaced with the specified ones.

### Example 7: Remove all user-assigned identities
```powershell
Update-AzSignalR -ResourceGroupName myResourceGroup -Name mysignalr1 -UserAssignedIdentity @()
```

```output
HostName                                 Location       ExternalIp      Sku         UnitCount ProvisioningState Version
--------                                 --------       ----------      ---         --------- ----------------- -------
mysignalr1.service.signalr.net           eastus         52.179.3.5      Standard_S1 1         Succeeded         1.0
```

This command removes all user-assigned managed identities from the SignalR service by providing an empty array.

### Example 8: Completely disable managed identity
```powershell
Update-AzSignalR -ResourceGroupName myResourceGroup -Name mysignalr1 -EnableSystemAssignedIdentity $false -UserAssignedIdentity @()
```

```output
HostName                                 Location       ExternalIp      Sku         UnitCount ProvisioningState Version
--------                                 --------       ----------      ---         --------- ----------------- -------
mysignalr1.service.signalr.net           eastus         52.179.3.5      Standard_S1 1         Succeeded         1.0
```

This command completely disables managed identity for the SignalR service by disabling system-assigned identity and removing all user-assigned identities.

## PARAMETERS

### -AllowedOrigin
The allowed origins for the SignalR service. To allow all, use "*" and remove all other origins from the list. Slashes are not allowed as part of domain or after TLD

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the cmdlet in background job.

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
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableSystemAssignedIdentity
Enable or disable system-assigned identity. $true enables system-assigned identity, $false disables it. If not provided, no change happens on system-assigned identity.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The SignalR resource object.

```yaml
Type: Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The SignalR service name.

```yaml
Type: System.String
Parameter Sets: ResourceGroupParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.
The default one will be used if not specified.

```yaml
Type: System.String
Parameter Sets: ResourceGroupParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The SignalR service resource ID.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServiceMode
The service mode for the SignalR service.

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

### -Sku
The SignalR service SKU.
Default to "Standard_S1".

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

### -Tag
The tags for the SignalR service.

```yaml
Type: System.Collections.Generic.IDictionary`2[System.String,System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UnitCount
The SignalR service unit count, value only from {1, 2, 5, 10, 20, 50, 100}.
Default to 1.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
Set user-assigned identities. To remove all user-assigned identities, provide an empty array @(). If not provided, user-assigned identities remain unchanged.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
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

### System.String

### Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource

## OUTPUTS

### Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource

## NOTES

## RELATED LINKS
