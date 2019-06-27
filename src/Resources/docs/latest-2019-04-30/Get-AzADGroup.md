---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azadgroup
schema: 2.0.0
---

# Get-AzADGroup

## SYNOPSIS
Gets group information from the directory.

## SYNTAX

### List (Default)
```
Get-AzADGroup -TenantId <String> [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzADGroup -ObjectId <String> -TenantId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByDisplayNamePrefix
```
Get-AzADGroup -TenantId <String> -DisplayNameStartsWith <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetByDisplayName
```
Get-AzADGroup -TenantId <String> -DisplayName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzADGroup -InputObject <IResourcesIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets group information from the directory.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

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
Dynamic: False
```

### -DisplayName
The display name of the application.

```yaml
Type: System.String
Parameter Sets: GetByDisplayName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DisplayNameStartsWith
The prefix of the display name of the application.

```yaml
Type: System.String
Parameter Sets: GetByDisplayNamePrefix
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Filter
The filter to apply to the operation.

```yaml
Type: System.String
Parameter Sets: List
Aliases: ODataQuery

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ObjectId
The object ID of the user for which to get group information.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TenantId
The tenant ID.

```yaml
Type: System.String
Parameter Sets: List, Get, GetByDisplayNamePrefix, GetByDisplayName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IAdGroup

## ALIASES

## RELATED LINKS

