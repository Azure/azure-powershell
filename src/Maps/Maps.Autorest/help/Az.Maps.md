---
Module Name: Az.Maps
Module Guid: dc0410d0-8396-4441-a4d3-fdaaa915369d
Download Help Link: https://learn.microsoft.com/powershell/module/az.maps
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Maps Module
## Description
Microsoft Azure PowerShell: Maps cmdlets

## Az.Maps Cmdlets
### [Get-AzMapsAccount](Get-AzMapsAccount.md)
Get a Maps Account.

### [Get-AzMapsAccountKey](Get-AzMapsAccountKey.md)
Get the keys to use with the Maps APIs.
A key is used to authenticate and authorize access to the Maps REST APIs.
Only one key is needed at a time; two are given to provide seamless key regeneration.

### [Get-AzMapsCreator](Get-AzMapsCreator.md)
Get a Maps Creator resource.

### [Get-AzMapsSubscriptionOperation](Get-AzMapsSubscriptionOperation.md)
List operations available for the Maps Resource Provider

### [New-AzMapsAccount](New-AzMapsAccount.md)
Create or update a Maps Account.
A Maps Account holds the keys which allow access to the Maps REST APIs.

### [New-AzMapsAccountKey](New-AzMapsAccountKey.md)
Regenerate either the primary or secondary key for use with the Maps APIs.
The old key will stop working immediately.

### [New-AzMapsCreator](New-AzMapsCreator.md)
Create or update a Maps Creator resource.
Creator resource will manage Azure resources required to populate a custom set of mapping data.
It requires an account to exist before it can be created.

### [Remove-AzMapsAccount](Remove-AzMapsAccount.md)
Delete a Maps Account.

### [Remove-AzMapsCreator](Remove-AzMapsCreator.md)
Delete a Maps Creator resource.

### [Update-AzMapsAccount](Update-AzMapsAccount.md)
Updates a Maps Account.
Only a subset of the parameters may be updated after creation, such as Sku, Tags, Properties.

### [Update-AzMapsCreator](Update-AzMapsCreator.md)
Updates the Maps Creator resource.
Only a subset of the parameters may be updated after creation, such as Tags.

