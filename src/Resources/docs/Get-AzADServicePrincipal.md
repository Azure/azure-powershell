---
external help file: Az.Resources-help.xml
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
Get-AzADServicePrincipal -TenantId <String> [-Filter <String>] -ApplicationObject <IApplication>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzADServicePrincipal -ObjectId <String> -TenantId <String> -ApplicationObject <IApplication>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByApplicationId
```
Get-AzADServicePrincipal -TenantId <String> -ApplicationObject <IApplication> -ApplicationId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByDisplayName
```
Get-AzADServicePrincipal -TenantId <String> -ApplicationObject <IApplication> -DisplayName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets service principal information from the directory.
Query by objectId or pass a filter to query by appId

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -ApplicationId
{{ Fill ApplicationId Description }}

```yaml
Type: System.String
Parameter Sets: GetByApplicationId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationObject
{{ Fill ApplicationObject Description }}

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IApplication
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -DisplayName
{{ Fill DisplayName Description }}

```yaml
Type: System.String
Parameter Sets: GetByDisplayName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
The filter to apply to the operation.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IServicePrincipal
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azadserviceprincipal](https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azadserviceprincipal)

