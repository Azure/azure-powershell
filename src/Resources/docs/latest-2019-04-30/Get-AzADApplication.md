---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azadapplication
schema: 2.0.0
---

# Get-AzADApplication

## SYNOPSIS
Get an application by object ID.

## SYNTAX

### List2 (Default)
```
Get-AzADApplication -TenantId <String> [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get2
```
Get-AzADApplication -ObjectId <String> -TenantId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetDeleted
```
Get-AzADApplication -TenantId <String> -IncludeDeleted [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetByIdentifierUri
```
Get-AzADApplication -TenantId <String> -IdentifierUri <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetByDisplayNamePrefix
```
Get-AzADApplication -TenantId <String> -DisplayNameStartWith <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetByDisplayName
```
Get-AzADApplication -TenantId <String> -DisplayName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByApplicationId
```
Get-AzADApplication -TenantId <String> -ApplicationId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity2
```
Get-AzADApplication -InputObject <IResourcesIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get an application by object ID.

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

### -ApplicationId
The application id of the application.

```yaml
Type: System.String
Parameter Sets: GetByApplicationId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

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

### -DisplayNameStartWith
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
Parameter Sets: List2, GetDeleted
Aliases: ODataQuery

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IdentifierUri
The identifier URI of the application.

```yaml
Type: System.String
Parameter Sets: GetByIdentifierUri
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IncludeDeleted
Signals that deleted applications should be returned as well.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetDeleted
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity
Parameter Sets: GetViaIdentity2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ObjectId
Application object ID.

```yaml
Type: System.String
Parameter Sets: Get2
Aliases: ApplicationObjectId

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
Parameter Sets: List2, Get2, GetDeleted, GetByIdentifierUri, GetByDisplayNamePrefix, GetByDisplayName, GetByApplicationId
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IApplication

## ALIASES

## RELATED LINKS

