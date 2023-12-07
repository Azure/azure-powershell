---
external help file:
Module Name: Az.Qumulo
online version: https://learn.microsoft.com/powershell/module/az.qumulo/get-azqumulofilesystem
schema: 2.0.0
---

# Get-AzQumuloFileSystem

## SYNOPSIS
Get a file system resource

## SYNTAX

### List (Default)
```
Get-AzQumuloFileSystem [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzQumuloFileSystem -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzQumuloFileSystem -InputObject <IQumuloIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzQumuloFileSystem -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a file system resource

## EXAMPLES

### Example 1: List by subscription
```powershell
Get-AzQumuloFileSystem -SubscriptionId fc35d936-3b89-41f8-8110-a24b56826c37
```

```output
Location Name               SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName  
-------- ----               -------------------  -------------------   ----------------------- ------------------------ ------------------------             ---------------------------- -----------------  
eastus   fileSystem01       6/24/2023 5:22:01 AM user@organization.com User                    6/24/2023 5:22:01 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-test      
eastus   qumulo-01          6/24/2023 5:27:12 AM user@organization.com User                    6/24/2023 5:27:12 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-test      
eastus   qumulo-02          6/24/2023 5:31:50 AM user@organization.com User                    6/24/2023 5:31:50 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-test
eastus   fileSystem         5/24/2023 7:10:01 AM user@organization.com User                    5/24/2023 7:19:16 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-joyer-test      
eastus   qumulo-resource-01 5/24/2023 7:27:12 AM user@organization.com User                    5/24/2023 7:42:17 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-joyer-test      
eastus   qumulo-resource-02 5/24/2023 9:31:50 AM user@organization.com User                    5/24/2023 9:41:10 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-joyer-test
```

Get list of file system resources by subscription

### Example 2: List by resource group
```powershell
Get-AzQumuloFileSystem -ResourceGroupName ps-joyer-test
```

```output
Location Name               SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName  
-------- ----               -------------------  -------------------   ----------------------- ------------------------ ------------------------             ---------------------------- -----------------  
eastus   fileSystem         5/24/2023 7:10:01 AM user@organization.com User                    5/24/2023 7:19:16 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-joyer-test      
eastus   qumulo-resource-01 5/24/2023 7:27:12 AM user@organization.com User                    5/24/2023 7:42:17 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-joyer-test      
eastus   qumulo-resource-02 5/24/2023 9:31:50 AM user@organization.com User                    5/24/2023 9:41:10 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-joyer-test 
```

Get list of file system resources by resource group

### Example 3: Get specific resource with specified resource group
```powershell
Get-AzQumuloFileSystem -ResourceGroupName azpstest-gp -Name fileSystem
```

```output
Location Name               SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
-------- ----               -------------------  -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
eastus   qumulo-resource-01 5/24/2023 7:27:12 AM user@organization.com User                    5/24/2023 9:58:45 AM     user@organization.com    User                         ps-joyer-test 
```

Get specific file system resource with specified resource group

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.IQumuloIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the File System resource

```yaml
Type: System.String
Parameter Sets: Get
Aliases: FileSystemName

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

### Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.IQumuloIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IQumuloIdentity>`: Identity Parameter
  - `[FileSystemName <String>]`: Name of the File System resource
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

