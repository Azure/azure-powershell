$out = "..\build\AzureRM.Compute.Experiments\"
$repository = "sergey"
$dep = @("AzureRM.Resources", "AzureRM.Network", "AzureRM.Compute")
mkdir $out
Copy-Item .\AzureRM.Compute.Experiments.psd1 $out
Copy-Item .\AzureRM.Compute.Experiments.psm1 $out
foreach ($d in $dep) {
    Install-Module $d -Repository $repository
}
Publish-Module -Path $out -Repository $repository -NuGetApiKey somekey
foreach ($d in $dep) {
    Uninstall-Module $d
}
