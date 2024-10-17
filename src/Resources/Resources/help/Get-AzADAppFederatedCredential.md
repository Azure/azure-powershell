---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azadappfederatedcredential
schema: 2.0.0
---

# Get-AzADAppFederatedCredential

## SYNOPSIS
Get federatedIdentityCredentials by Id from applications.

## SYNTAX

### ListByApplicationObjectId (Default)
```
Get-AzADAppFederatedCredential -ApplicationObjectId <String> [-Expand <String[]>] [-Select <String[]>] [-Count]
 [-Filter <String>] [-Orderby <String[]>] [-Search <String>] [-First <UInt64>] [-Skip <UInt64>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByApplicationObjectId
```
Get-AzADAppFederatedCredential -ApplicationObjectId <String> -FederatedCredentialId <String>
 [-Expand <String[]>] [-Select <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetByApplicationObject
```
Get-AzADAppFederatedCredential -FederatedCredentialId <String> -ApplicationObject <MicrosoftGraphApplication>
 [-Expand <String[]>] [-Select <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ListByApplicationObject
```
Get-AzADAppFederatedCredential -ApplicationObject <MicrosoftGraphApplication> [-Expand <String[]>]
 [-Select <String[]>] [-Count] [-Filter <String>] [-Orderby <String[]>] [-Search <String>] [-First <UInt64>]
 [-Skip <UInt64>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get federatedIdentityCredentials by Id from applications.

## EXAMPLES

### Example 1: List federated identity credentials for application
```powershell
Get-AzADApplication -ObjectId $app | Get-AzADAppFederatedCredential
```

List federated identity credentials for application

### Example 2: Get federated identity credential by id
```powershell
Get-AzADAppFederatedCredential -ApplicationObjectId $appObjectId -FederatedCredentialId $credentialId
```

Get federated identity credential by id

## PARAMETERS

### -ApplicationObject
application object

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphApplication
Parameter Sets: GetByApplicationObject, ListByApplicationObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationObjectId
key: id of application

```yaml
Type: System.String
Parameter Sets: ListByApplicationObjectId, GetByApplicationObjectId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Count
Include count of items

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ListByApplicationObjectId, ListByApplicationObject
Aliases:

Required: False
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

### -Expand
Expand related entities

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FederatedCredentialId
key: id of federatedIdentityCredential

```yaml
Type: System.String
Parameter Sets: GetByApplicationObjectId, GetByApplicationObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
Filter items by property values, for more detail about filter query please see: https://learn.microsoft.com/en-us/graph/filter-query-parameter

```yaml
Type: System.String
Parameter Sets: ListByApplicationObjectId, ListByApplicationObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Orderby
Order items by property values

```yaml
Type: System.String[]
Parameter Sets: ListByApplicationObjectId, ListByApplicationObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Search
Search items by search phrases

```yaml
Type: System.String
Parameter Sets: ListByApplicationObjectId, ListByApplicationObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Select
Select properties to be returned

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Ignores the first 'n' objects and then gets the remaining objects.

```yaml
Type: System.UInt64
Parameter Sets: ListByApplicationObjectId, ListByApplicationObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -First
Gets only the first 'n' objects.

```yaml
Type: System.UInt64
Parameter Sets: ListByApplicationObjectId, ListByApplicationObject
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphFederatedIdentityCredential

## NOTES

## RELATED LINKS
