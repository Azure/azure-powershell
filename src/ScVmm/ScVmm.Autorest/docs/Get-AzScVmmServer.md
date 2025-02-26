---
external help file:
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/az.scvmm/get-azscvmmserver
schema: 2.0.0
---

# Get-AzScVmmServer

## SYNOPSIS
Implements VmmServer GET method.

## SYNTAX

### List (Default)
```
Get-AzScVmmServer [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzScVmmServer -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzScVmmServer -InputObject <IScVmmIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzScVmmServer -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Implements VmmServer GET method.

## EXAMPLES

### Example 1: List VMM Servers in a Subscription
```powershell
Get-AzScVmmServer -SubscriptionId "00000000-abcd-0000-abcde-000000000000"
```

```output
Name                ResourceGroupName Location ProvisioningState
----                ----------------- -------- -----------------
test-vmmserver-01   test-rg-01        eastus   Succeeded
test-vmmserver-02   test-rg-01        eastus   Succeeded
test-vmmserver-03   test-rg-02        westus   Succeeded
test-vmmserver-04   test-rg-02        eastus   Succeeded
test-vmmserver-05   test-rg-03        westus   Succeeded
```

This command lists VMM Servers in provided subscription.

### Example 2: List VMM Servers in a Resource Group
```powershell
Get-AzScVmmServer -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -ResourceGroupName "test-rg-01"
```

```output
Name                ResourceGroupName Location ProvisioningState
----                ----------------- -------- -----------------
test-vmmserver-01   test-rg-01        eastus   Succeeded
test-vmmserver-02   test-rg-01        eastus   Succeeded
```

This command lists VMM Servers in provided Resource Group.

### Example 3: Get a specific VMM Server
```powershell
Get-AzScVmmServer -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -ResourceGroupName "test-rg-01" -Name "test-vmmserver-01"
```

```output
ConnectionStatus             : Connected
CredentialsPassword          : 
CredentialsUsername          : scvmm-username
ErrorMessage                 : 
ExtendedLocationName         : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ExtendedLocation/customLocations/test-cl
ExtendedLocationType         : customLocation
Fqdn                         : vmmServerFqdn
Id                           : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmmserver-01
Location                     : eastus
Name                         : test-vmmserver-01
Port                         : 8100
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg-01
SystemDataCreatedAt          : 08-01-2024 10:04:20
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 08-01-2024 13:14:34
SystemDataLastModifiedBy     : 11111111-aaaa-2222-bbbb-333333333333
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.scvmm/vmmservers
Uuid                         : 00000000-1111-0000-2222-000000000000
Version                      : 10.22.1711.0
```

This command gets the VMM Server named `test-vmmserver-01` in a resource group named `test-rg-01`.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IScVmmIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the VmmServer.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: VmmServerName

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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IScVmmIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IVmmServer

## NOTES

## RELATED LINKS

