### Example 1: List all peering service locations
```powershell
Get-AzPeeringServiceLocation
```

```output
Name                            State                           Country        AzureRegion
----                            -----                           -------        -----------
Obwalden                        Obwalden                        Switzerland    France Central
Sankt Gallen                    Sankt Gallen                    Switzerland    France Central
Schaffhausen                    Schaffhausen                    Switzerland    France Central
Schwyz                          Schwyz                          Switzerland    France Central
Solothurn                       Solothurn                       Switzerland    France Central
Thurgau                         Thurgau                         Switzerland    France Central
Ticino                          Ticino                          Switzerland    France Central
Uri                             Uri                             Switzerland    France Central
Valais                          Valais                          Switzerland    France Central
Vaud                            Vaud                            Switzerland    France Central
Zug                             Zug                             Switzerland    France Central
Zurich                          Zurich                          Switzerland    France Central
Aberdeen City                   Aberdeen City                   United Kingdom UK West
Angus                           Angus                           United Kingdom UK West
Antrim and Newtownabbey         Antrim and Newtownabbey         United Kingdom North Europe
Ards and North Down             Ards and North Down             United Kingdom North Europe
Argyll and Bute                 Argyll and Bute                 United Kingdom North Europe
Armagh, Banbridge and Craigavon Armagh, Banbridge and Craigavon United Kingdom North Europe
Barking and Dagenham            Barking and Dagenham            United Kingdom UK South
...
```

Retrieves all peering service locations

### Example 2: List all peering service
```powershell
Get-AzPeeringServiceLocation -Country Japan
```

```output
Name      State     Country AzureRegion
----      -----     ------- -----------
Aichi     Aichi     Japan   Japan West
Akita     Akita     Japan   Japan East
Aomori    Aomori    Japan   Japan East
Chiba     Chiba     Japan   Japan East
Ehime     Ehime     Japan   Japan West
Fukui     Fukui     Japan   Japan West
Fukuoka   Fukuoka   Japan   Japan West
Fukushima Fukushima Japan   Japan East
Gifu      Gifu      Japan   Japan West
Gunma     Gunma     Japan   Japan East
Hiroshima Hiroshima Japan   Japan West
Hyogo     Hyogo     Japan   Japan West
Ibaraki   Ibaraki   Japan   Japan East
Ishikawa  Ishikawa  Japan   Japan West
...
```

Retrieves all peering service locations for a specific country

