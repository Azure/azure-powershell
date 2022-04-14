---
external help file:
Module Name: Azs.Update.Admin
online version: https://docs.microsoft.com/en-us/powershell/module/azs.update.admin/get-azsupdatelocation
schema: 2.0.0
---

# Get-AzsUpdateLocation

## SYNOPSIS
Get an update location based on name.

## SYNTAX

### Get (Default)
```
Get-AzsUpdateLocation [-Name <String>] [-ResourceGroupName <String>] [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzsUpdateLocation -InputObject <IUpdateAdminIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzsUpdateLocation [-ResourceGroupName <String>] [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get an update location based on name.

## EXAMPLES

### Example 1: Get All Updates Locations
```powershell
PS C:\> Get-AzsUpdateLocation

Name                 CurrentVersion       HardwareModel        State
----                 --------------       -----------------    -----
northwest            9.2222.0.222         ProLiantDL360Gen10   AppliedSuccessfully

CurrentOemVersion : 2.2.1907.2
CurrentVersion    : 9.2222.0.222
HardwareModel     : ProLiantDL360Gen10
Id                : /subscriptions/182830af-081a-4de2-b134-ba14d45d8dd2/resourceGroups/System.redmond/providers/Microsoft.Update.Admin/updateLocations/redmond
LastChecked       : 4/14/2022 5:46:44 PM
LastUpdated       : 
Location          : redmond
Name              : redmond
OemFamily         : 
PackageVersion    : {Microsoft.Azure.PowerShell.Cmdlets.UpdateAdmin.Models.Api20210701.PackageVersionInfo, Microsoft.Azure.PowerShell.Cmdlets.UpdateAdmin.Models.Api20210701.PackageVersionInfo, 
                    Microsoft.Azure.PowerShell.Cmdlets.UpdateAdmin.Models.Api20210701.PackageVersionInfo}
State             : UpdateFailed
Tag               : Microsoft.Azure.PowerShell.Cmdlets.UpdateAdmin.Models.Api20210701.ResourceTags
Type              : Microsoft.Update.Admin/updateLocations

```

Without any parameters, this commandlet will retrieve all update locations.

### Get All Updates Locations by Name
```powershell
PS C:\> Get-AzsUpdateLocation -Name redmond | fl *

CurrentOemVersion : 2.2.1907.2
CurrentVersion    : 9.2222.0.222
HardwareModel     : ProLiantDL360Gen10
Id                : /subscriptions/182830af-081a-4de2-b134-ba14d45d8dd2/resourceGroups/System.redmond/providers/Microsoft.Update.Admin/updateLocations/redmond
LastChecked       : 4/14/2022 5:46:44 PM
LastUpdated       : 
Location          : redmond
Name              : redmond
OemFamily         : 
PackageVersion    : {Microsoft.Azure.PowerShell.Cmdlets.UpdateAdmin.Models.Api20210701.PackageVersionInfo, Microsoft.Azure.PowerShell.Cmdlets.UpdateAdmin.Models.Api20210701.PackageVersionInfo, 
                    Microsoft.Azure.PowerShell.Cmdlets.UpdateAdmin.Models.Api20210701.PackageVersionInfo}
State             : UpdateFailed
Tag               : Microsoft.Azure.PowerShell.Cmdlets.UpdateAdmin.Models.Api20210701.ResourceTags
Type              : Microsoft.Update.Admin/updateLocations

PS C:\> (Get-AzsUpdateLocation -Name redmond).PackageVersion    

LastUpdated          PackageType     Version     
-----------          -----------     -------     
1/13/2022 3:27:34 PM  Services       9.2222.0.222
3/24/2022 7:06:21 AM  Infrastructure 9.2222.0.222
4/14/2022 5:46:51 PM  OEM            2.2.1907.2 
```

Will retrieve all update locations that matches the specified Name parameter

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
Type: Microsoft.Azure.PowerShell.Cmdlets.UpdateAdmin.Models.IUpdateAdminIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the update location.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzLocation)[0].Location
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: -join("System.",(Get-AzLocation)[0].Location)
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.UpdateAdmin.Models.IUpdateAdminIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.UpdateAdmin.Models.Api20210701.IUpdateLocation

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IUpdateAdminIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RunName <String>]`: Update run identifier.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[UpdateLocation <String>]`: The name of the update location.
  - `[UpdateName <String>]`: Name of the update.

## RELATED LINKS

