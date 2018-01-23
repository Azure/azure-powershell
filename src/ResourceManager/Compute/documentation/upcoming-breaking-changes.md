# Upcoming Breaking Changes

## Release X.0.0 - May 2018

The following cmdlets were affected this release:

**New-AzureRmAvailabilitySet**
- Switch parameter, Managed, will be replaced with Sku parameter.
In order to set a managed availability set, a user should give Sku parameter with 'Aligned' value.

```powershell
# Old
# New-AzureRmAvailabilitySet -Managed


# New
# New-AzureRmAvailabilitySet -Sku 'Aligned'