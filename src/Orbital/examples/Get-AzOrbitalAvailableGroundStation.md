### Example 1: Gets the specified  available ground station.
```powershell
Get-AzOrbitalAvailableGroundStation -Capability 'EarthObservation'
```

```output
Location      Name             ProviderName City
--------      ----             ------------ ----
westus2       WESTUS2_0        Microsoft    Quincy
westus2       SVALSAT          KSAT         Svalbard
westus2       AWARUA           KSAT         Awarua
westus2       HARTEBEESTHOEK   KSAT         Hartebeesthoek
westus2       LONG_BEACH       KSAT         LongBeach
westus2       WESTUS2_1        Microsoft    Quincy-preview
westus2       ATHENS           KSAT         Athens
swedencentral MICROSOFT_SWEDEN Microsoft    Gavle
swedencentral SWEDENCENTRAL_0  Microsoft    Gavle
```

Gets the specified  available ground station.