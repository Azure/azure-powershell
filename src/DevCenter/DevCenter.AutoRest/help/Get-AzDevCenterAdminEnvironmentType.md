---
external help file:
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteradminenvironmenttype
schema: 2.0.0
---

# Get-AzDevCenterAdminEnvironmentType

## SYNOPSIS
Gets an environment type.

## SYNTAX

### List (Default)
```
Get-AzDevCenterAdminEnvironmentType -DevCenterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDevCenterAdminEnvironmentType -DevCenterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterAdminEnvironmentType -InputObject <IDevCenterIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets an environment type.

## EXAMPLES

### Example 1: List environment types in a dev center
```powershell
Get-AzDevCenterAdminEnvironmentType -ResourceGroupName testRg -DevCenterName Contoso
```

This command lists the environment types in the dev center "Contoso" under the resource group "testRg".

### Example 2: Get a dev center environment type 
```powershell

```

```powershell
 Get-AzDevCenterAdminEnvironmentType -ResourceGroupName testRg -DevCenterName Contoso -Name DevTest
 ```
This command gets the environment type named "DevTest" in the dev center "Contoso" under the resource group "testRg".

### Example 3: Get a dev center environment type using InputObject
```powershell

```

```powershell
$envType = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "EnvironmentTypeName" = "DevTest"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Get-AzDevCenterAdminEnvironmentType -InputObject $envType
 ```
This command gets the environment type named "DevTest" in the dev center "Contoso" under the resource group "testRg".

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

### -DevCenterName
The name of the devcenter.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the environment type.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: EnvironmentTypeName

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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20240501Preview.IEnvironmentType

## NOTES

## RELATED LINKS

