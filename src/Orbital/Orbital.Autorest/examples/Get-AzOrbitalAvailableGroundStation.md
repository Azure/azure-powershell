### Example 1: Gets the specified  available ground station.
```powershell
Get-AzOrbitalAvailableGroundStation -Capability 'EarthObservation'
```

```output
Location      Name                ProviderName City
--------      ----                ------------ ----
westus2       Microsoft_Quincy    Microsoft    Quincy
westus2       KSAT_Awarua         KSAT         Awarua
westus2       KSAT_Hartebeesthoek KSAT         Hartebeesthoek
westus2       KSAT_Athens         KSAT         Athens
westus2       KSAT_Svalbard       KSAT         Svalbard
swedencentral Microsoft_Gavle     Microsoft    Gavle
southeastasia Microsoft_Singapore Microsoft    Singapore
brazilsouth   Microsoft_Longovilo Microsoft    Longovilo
```

Gets the specified  available ground station.