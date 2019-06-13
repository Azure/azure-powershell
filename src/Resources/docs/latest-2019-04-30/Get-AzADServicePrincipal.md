---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azadserviceprincipal
schema: 2.0.0
---

# Get-AzADServicePrincipal

## SYNOPSIS
Gets service principal information from the directory.
Query by objectId or pass a filter to query by appId

## SYNTAX

### List (Default)
```
Get-AzADServicePrincipal -TenantId <String> -ApplicationObject <IApplication> [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzADServicePrincipal -ObjectId <String> -TenantId <String> -ApplicationObject <IApplication>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetBySPN
```
Get-AzADServicePrincipal -TenantId <String> -ApplicationObject <IApplication> -ServicePrincipalName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByDisplayNamePrefix
```
Get-AzADServicePrincipal -TenantId <String> -ApplicationObject <IApplication> -DisplayNameBeginsWith <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByDisplayName
```
Get-AzADServicePrincipal -TenantId <String> -ApplicationObject <IApplication> -DisplayName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByApplicationId
```
Get-AzADServicePrincipal -TenantId <String> -ApplicationObject <IApplication> -ApplicationId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzADServicePrincipal -TenantId <String> -InputObject <IResourcesIdentity>
 -ApplicationObject <IApplication> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets service principal information from the directory.
Query by objectId or pass a filter to query by appId

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

### -ApplicationObject
The object representation of the application.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IApplication
Parameter Sets: (All)
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

### -DisplayNameBeginsWith
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
The object ID of the service principal to get.

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

### -ServicePrincipalName
The display name of the application.

```yaml
Type: System.String
Parameter Sets: GetBySPN
Aliases: SPN

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
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IServicePrincipal

## ALIASES

## RELATED LINKS

