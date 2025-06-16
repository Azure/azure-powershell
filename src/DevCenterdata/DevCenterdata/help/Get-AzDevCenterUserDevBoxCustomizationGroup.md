---
external help file: Az.DevCenterdata-help.xml
Module Name: Az.DevCenterdata
online version: https://learn.microsoft.com/powershell/module/az.devcenterdata/get-azdevcenteruserdevboxcustomizationgroup
schema: 2.0.0
---

# Get-AzDevCenterUserDevBoxCustomizationGroup

## SYNOPSIS
Gets a customization group.

## SYNTAX

### List (Default)
```
Get-AzDevCenterUserDevBoxCustomizationGroup -Endpoint <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] [-Include <ListCustomizationGroupsIncludeProperty>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDevCenterUserDevBoxCustomizationGroup -Endpoint <String> -CustomizationGroupName <String>
 -DevBoxName <String> -ProjectName <String> [-UserId <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterUserDevBoxCustomizationGroup -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a customization group.

## EXAMPLES

### EXAMPLE 1
```
Get-AzDevCenterUserDevBoxCustomizationGroup -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -DevBoxName MyDevBox
```

### EXAMPLE 2
```
Get-AzDevCenterUserDevBoxCustomizationGroup -DevCenterName Contoso -ProjectName DevProject -DevBoxName MyDevBox -Include tasks
```

### EXAMPLE 3
```
Get-AzDevCenterUserDevBoxCustomizationGroup -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -CustomizationGroupName Provisioning -DevBoxName MyDevBox
```

### EXAMPLE 4
```
Get-AzDevCenterUserDevBoxCustomizationGroup -DevCenterName Contoso -ProjectName DevProject -CustomizationGroupName Provisioning -DevBoxName MyDevBox
```

### EXAMPLE 5
```
$customizationGroupInput = @{"CustomizationGroupName" = "Provisioning"; "ProjectName" ="DevProject"; "DevBoxName" = "MyDevBox"; "UserId" = "me" }
Get-AzDevCenterUserDevBoxCustomizationGroup -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $customizationGroupInput
```

### EXAMPLE 6
```
$customizationGroupInput = @{"CustomizationGroupName" = "Provisioning"; "ProjectName" = "DevProject"; "DevBoxName" = "MyDevBox"; "UserId" = "786a823c-8037-48ab-89b8-8599901e67d0" }
Get-AzDevCenterUserDevBoxCustomizationGroup -DevCenterName Contoso -InputObject $customizationGroupInput
```

## PARAMETERS

### -CustomizationGroupName
Name of the customization group.

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

### -DevBoxName
Display name for the Dev Box.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
The DevCenter-specific URI to operate on.

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

### -Include
Optional query parameter to specify what properties should be included in the response.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Support.ListCustomizationGroupsIncludeProperty
Parameter Sets: List
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProjectName
Name of the project.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserId
The AAD object id of the user.
If value is 'me', the identity is taken from the authentication context.

```yaml
Type: System.String
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.ICustomizationGroup
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IDevCenterdataIdentity\>: Identity Parameter
  \[ActionName \<String\>\]: The name of the action.
  \[AddOnName \<String\>\]: Name of the dev box addon.
  \[CatalogName \<String\>\]: Name of the catalog.
  \[CustomizationGroupName \<String\>\]: Name of the customization group.
  \[CustomizationTaskId \<String\>\]: A customization task ID.
  \[DefinitionName \<String\>\]: Name of the environment definition.
  \[DevBoxName \<String\>\]: Display name for the Dev Box.
  \[EnvironmentName \<String\>\]: Environment name.
  \[EnvironmentTypeName \<String\>\]: Name of the environment type.
  \[Id \<String\>\]: Resource identity path
  \[ImageBuildLogId \<String\>\]: An imaging build log id.
  \[OperationId \<String\>\]: Unique identifier for the Dev Box operation.
  \[PoolName \<String\>\]: Pool name.
  \[ProjectName \<String\>\]: Name of the project.
  \[ScheduleName \<String\>\]: Display name for the Schedule.
  \[SnapshotId \<String\>\]: The id of the snapshot.
Should be treated as opaque string.
  \[TaskName \<String\>\]: Full name of the task: {catalogName}/{taskName}.
  \[UserId \<String\>\]: The AAD object id of the user.
If value is 'me', the identity is taken from the authentication context.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.devcenterdata/get-azdevcenteruserdevboxcustomizationgroup](https://learn.microsoft.com/powershell/module/az.devcenterdata/get-azdevcenteruserdevboxcustomizationgroup)
