---
RFC: RFC0005
Author: Mark Cowlishaw
Status: Implemented
SupercededBy:
Version: 1.0
---

# ETag Support

Provide support for ETags in Creation and modification cmdlets, allowing the user to ensure consistency of the resource state under simultaneous update at cloud scale, including the followign functionality.

- Allow the user to get the ETag value of a resource
- Allow the user to make modifications conditional on the ETag of the resource matching the Etag of the modification request
- Allow the user to specify destructive changes that ignore ETag settings and overwrite the resource in any state

## Motivation

Explain the benefits of the change for the users.

```code
As a writer of scripts that need to maintain resource consistency across simultaneous access
I can make modifications conditional on the last ETag I saw for a resource
so that I can detect when a resource has been modified since my last view, and refresh my local copy of the resource before attempting another modification.
```

## User Experience

Example of the user experience with code sample

### Updating Cmdlets Conditionally based on ETag value

Update a resource only if the ETag value matches the last viewed ETag

```PowerShell
$etag = (Get-AzVM).ETag
Update-AzVM <parameters> -ETag <etag-value>
```

```PowerShell
Get-AzVM <parameters> | Update-AzVM <changed parameters>
```

- I would say this pipeline example is a little vague - is this using etag or not.  Or would input from pipeline use a different default behavior.



### Forcing Updates

Update a resource regardless of ETag settings

```PowerShell
Update-AzVM <parameters> -Overwrite
```

- Overwrite is pretty non-standard powershell.  -Force or -Confirm would be better (See https://stackoverflow.com/questions/34749333/powershell-guidelines-for-confirm-force-and-whatif and https://github.com/Azure/azure-powershell/issues/475)

## Comments and Questions

- Should Updates be conditional on ETag value match by default, or shoudl this be opt-in
 
- Should overwrite without regard to ETag values be an opt-in or default behavior


I believe this should be rolled  in gradually, so initial release should have etags usage as optional.  Let it bake for 6 months and then switch the default behavior. 

I could see:
Get-AzVM <parameters> | Update-AzVM <changed parameters> -UseEtag $true
 
Where UseEtag's default value changes from $false to $true after a while.  This would initally not break scripts, but after the roll-out date all new `Update-AzVM` commands would use the ETAG checking.
 
### Question 
How do etags work with sub-items i.e. network config.  Do those sub items have a separate etag and updates to them cause the parent object etag to update also?  

This is going to have to be *clearly* documented - I could see some real confusion in this path:

Get-AzVM ->  (Change Disk Size via $vm.StorageProfile.DataDisks[0].DiskSizeGB = 123 ) -> Update-AzVM 

vs

Get-AzVM ->  get-AzDataDisk -> (Change Disk Size via Set-AzDataDisk) -> Update-AzVM 
