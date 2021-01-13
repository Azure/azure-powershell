---
external help file:
Module Name: Az.ActiveDirectoryB2C
online version: https://docs.microsoft.com/en-us/powershell/module/az.activedirectoryb2c/get-azadb2ctenant
schema: 2.0.0
---

# Get-AzADB2CTenant

## SYNOPSIS
Get the Azure AD B2C tenant resource.

## SYNTAX

### List1 (Default)
```
Get-AzADB2CTenant [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzADB2CTenant -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzADB2CTenant -InputObject <IActiveDirectoryB2CIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzADB2CTenant -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the Azure AD B2C tenant resource.

## EXAMPLES

### Example 1: Get all tenants of the AzureActiveDirectory under a subscription
```powershell
PS C:\> Get-AzADB2CTenant

Location      Name                            Type
--------      ----                            ----
United States klaskkdls.onmicrosoft.com       Microsoft.AzureActiveDirectory/b2cDirectories
United States asdsdsadsad.onmicrosoft.com     Microsoft.AzureActiveDirectory/b2cDirectories
```

This command gets all tenants of the AzureActiveDirectory under a subscription.

### Example 2: Get all tenants of the AzureActiveDirectory under a resource group
```powershell
PS C:\> Get-AzADB2CTenant -ResourceGroupName azure-rg-test

Location      Name                        Type
--------      ----                        ----
United States klaskkdls.onmicrosoft.com   Microsoft.AzureActiveDirectory/b2cDirectories
United States asdsdsadsad.onmicrosoft.com Microsoft.AzureActiveDirectory/b2cDirectories
```

This command gets all tenants of the AzureActiveDirectory under a resource group.

### Example 3: Get a tenant of the AzureActiveDirectory by name
```powershell
PS C:\> Get-AzADB2CTenant -ResourceGroupName azure-rg-test -Name klaskkdls.onmicrosoft.com

Location      Name                        Type
--------      ----                        ----
United States klaskkdls.onmicrosoft.com   Microsoft.AzureActiveDirectory/b2cDirectories
```

This command gets a tenant of the AzureActiveDirectory by name.

### Example 3: Get a tenant of the AzureActiveDirectory by pipeline
```powershell
PS C:\> Update-AzADB2CTenant -ResourceGroupName azure-rg-test -Name 'asdsdsadsad.onmicrosoft.com' -Tag @{"key1" = 1; "key2" = 2} |  Get-AzADB2CTenant

Location      Name                        Type
--------      ----                        ----
United States asdsdsadsad.onmicrosoft.com   Microsoft.AzureActiveDirectory/b2cDirectories
```

This command gets a tenant of the AzureActiveDirectory by pipeline.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Models.IActiveDirectoryB2CIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The initial domain name of the B2C tenant.

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

### -ResourceGroupName
The name of the resource group.

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

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Models.IActiveDirectoryB2CIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Models.Api201901Preview.IB2CTenantResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IActiveDirectoryB2CIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[OperationId <String>]`: The operation ID.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[ResourceName <String>]`: The initial domain name of the B2C tenant.
  - `[SubscriptionId <String>]`: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS

