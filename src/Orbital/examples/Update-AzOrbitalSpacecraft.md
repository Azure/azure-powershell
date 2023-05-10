### Example 1: Updates the specified spacecraft tags.
```powershell
Update-AzOrbitalSpacecraft -ResourceGroupName azpstest-gp -Name AQUA -Tag @{"123"="abc"}
```

```output
Name Location NoradId TitleLine ResourceGroupName
---- -------- ------- --------- -----------------
AQUA westus2  27424   AQUA      azpstest-gp
```

Updates the specified spacecraft tags.

### Example 2: Updates the specified spacecraft tags.
```powershell
$spacecraftObject = Get-AzOrbitalSpacecraft -ResourceGroupName azpstest-gp -Name AQUA
Update-AzOrbitalSpacecraft -InputObject $spacecraftObject -Tag @{"123"="abc"}
```

```output
Name Location NoradId TitleLine ResourceGroupName
---- -------- ------- --------- -----------------
AQUA westus2  27424   AQUA      azpstest-gp
```

Updates the specified spacecraft tags.