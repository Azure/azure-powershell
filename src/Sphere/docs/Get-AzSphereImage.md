---
external help file:
Module Name: Az.Sphere
online version: https://learn.microsoft.com/powershell/module/az.sphere/get-azsphereimage
schema: 2.0.0
---

# Get-AzSphereImage

## SYNOPSIS
Get a Image

## SYNTAX

### List (Default)
```
Get-AzSphereImage -CatalogName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Filter <String>] [-Maxpagesize <Int32>] [-Skip <Int32>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzSphereImage -CatalogName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSphereImage -InputObject <ISphereIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityCatalog
```
Get-AzSphereImage -CatalogInputObject <ISphereIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Image

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
Get-AzSphereImage -CatalogName MyCatalog1 -ResourceGroupName ResourceGroup1
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDa 
                                                                                                                                                       taLastMo 
                                                                                                                                                       difiedBy 
                                                                                                                                                       Type     
----                                 ------------------- ------------------- ----------------------- ------------------------ ------------------------ -------- 
fa0bdab1-42bc-4871-84d5-fa05c8c0c895
5f05300e-b0e0-47d5-8255-e4bddb2ddd81
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
Get-AzSphereImage -CatalogName MyCatalog1 -ResourceGroupName ResourceGroup1 -Name fa0bdab1-42bc-4871-84d5-fa05c8c0c895
```

```output
ComponentId                  : d851b4e3-ee3c-4268-8aa4-d72ae48311fa
Description                  : 
Id                           : /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/ResourceGroup1/providers/Microsoft.AzureSphere/catalogs/MyCat 
                               alog1/images/fa0bdab1-42bc-4871-84d5-fa05c8c0c895
ImageId                      : fa0bdab1-42bc-4871-84d5-fa05c8c0c895
ImageName                    : 
ImageType                    : Applications
Name                         : fa0bdab1-42bc-4871-84d5-fa05c8c0c895
PropertiesImage              : Random test Image ab3d
ProvisioningState            : Succeeded
RegionalDataBoundary         : None
ResourceGroupName            : ResourceGroup1
RetryAfter                   : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/images
Uri                          : https://as3imgptint003.blob.core.windows.net/9611b24a-5064-456b-adea-c6761b858fe3/imagesaks/fa0bdab1-42bc-4871-84d5-fa05c8c0c895 
                               ?skoid=8ae308e5-766c-490c-849e-3ea5928ddb9f&sktid=72f988bf-86f1-41af-91ab-2d7cd011db47&skt=2023-08-16T09%3A36%3A31Z&ske=2023-08- 
                               16T10%3A41%3A31Z&sks=b&skv=2021-12-02&sv=2021-12-02&spr=https,http&se=2023-08-16T17%3A41%3A31Z&sr=b&sp=r&sig=fTnp%2Foi5%2FlYj6w2 
                               9dVF%2FhDp4CYr1qgBrg5eMV5OSLMw%3D
```

{{ Add description here }}

## PARAMETERS

### -CatalogInputObject
Identity Parameter
To construct, see NOTES section for CATALOGINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GetViaIdentityCatalog
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CatalogName
Name of catalog

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

### -Filter
Filter the result list using the given expression

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Maxpagesize
The maximum number of result items per page.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Image name.
Use .default for image creation.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCatalog
Aliases: ImageName

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

### -Skip
The number of result items to skip.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
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

### -Top
The number of result items to return.

```yaml
Type: System.Int32
Parameter Sets: List
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

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.IImage

## NOTES

## RELATED LINKS

