### Example 1: Get the list of cached images for the current subscription in a region.
```powershell
PS C:\> Get-AzContainerInstanceCachedImage -Location eastus

Image                                                                                OSType
-----                                                                                ------
microsoft/dotnet-framework:4.7.2-runtime-20181211-windowsservercore-ltsc2016         Windows
microsoft/dotnet-framework:4.7.2-runtime-20190108-windowsservercore-ltsc2016         Windows
microsoft/dotnet-framework:4.7.2-runtime-20190212-windowsservercore-ltsc2016         Windows
...
```

This command gets the list of cached images for the current subscription in the region `eastus`.
