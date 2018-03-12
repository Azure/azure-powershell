---
external help file: Microsoft.Azure.Commands.ApiManagement.ServiceManagement.dll-Help.xml
Module Name: AzureRM.ApiManagement
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.apimanagement/get-azurermapimanagementapirevision
schema: 2.0.0
---

# Get-AzureRmApiManagementApiRevision

## SYNOPSIS
Gets details of all the API Revisions of an API

## SYNTAX

```
Get-AzureRmApiManagementApiRevision -Context <PsApiManagementContext> -ApiId <String> [-ApiRevision <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmApiManagementApiRevision** cmdlet gets the details of all revisions of an API

## EXAMPLES

### Example 1: Get all API Revisions of an API
```powershell
PS C:\>$ApiMgmtContext = New-AzureRmApiManagementContext -ResourceGroupName "Api-Default-WestUS" -ServiceName "contoso"
PS C:\>Get-AzureRmApiManagementApiRevision -Context $ApiMgmtContext -ApiId "echo-api"
```

This command gets all of the API revision of specified API for particular ApiManagement Context.

## PARAMETERS

### -ApiId
API identifier whose revisions we want to list.
This parameter is required.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ApiRevision
Revision Identifier of the particular Api revision. This parameter is optional.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Context
Instance of PsApiManagementContext.
This parameter is required.

```yaml
Type: PsApiManagementContext
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementContext
System.String

## OUTPUTS

### System.Collections.Generic.IList`1[[Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementApiRevision, Microsoft.Azure.Commands.ApiManagement.ServiceManagement, Version=5.1.1.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
