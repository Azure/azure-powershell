. "$PSScriptRoot\ListTestFunctions.ps1"

<#
.SYNOPSIS
Generate a powershell file with basic script to run tests.
.DESCRIPTION
Collects list of test function names that marked as AzureAutomation in dot Description section and adds them to powershell script.
.PARAMETER srcPath
Path to the solution src folder.
.PARAMETER bookName
Name of the book on Automation Account.
.PARAMETER connectionName
Name of connection to use in the runbook.
.PARAMETER outputPath
Folder path to put generated runbook to.
If not specified, the value will be '..\RunBooks'
.EXAMPLE
GenerateRunbook "e:\git\azure-powershell\src\ResourceManager\Storage\Commands.Management.Storage.Test\ScenarioTests\" "ShchBook" "ShchConn".
#>
function GenerateRunbook (
     [string] $srcPath
    ,[string] $bookName
    ,[string] $connectionName
    ,[string] $outputPath
    ) {

    if ([string]::IsNullOrEmpty($outputPath)) {
        $outputPath = Join-Path "$PSScriptRoot\..\" "RunBooks"
    }

    $bookPath = Join-Path $outputPath "$bookName.ps1"
    $bookPath
    $null = New-Item $bookPath -type file -Force

    "loginWithConnection -connectionName ""$connectionName""" | Add-Content $bookPath -ErrorAction Stop
    
    ListTestFunctions $srcPath | ForEach-Object {
        $_ | Add-Content $bookPath -ErrorAction Stop
    }
    
    "TestRunner `$testList" | Add-Content $bookPath -ErrorAction Stop
}

<#
.SYNOPSIS
Generate runbook to specified projects
.PARAMETER srcPath
Path to the solution src folder
.PARAMETER connectionName
Name of connection to use in the runbook
.PARAMETER projectList
Specifies which subfolders parse for the runbook.
Projests are azure-powershell\src\ResourceManager subfolders 
.EXAMPLE
GenerateRunbooksForProject  `
    -srcPath "e:\git\azure-powershell\src\" `
    -connectionName "AzPoshTestSpn" `
    -projectList @('Compute', 'Storage','Network', 'KeyVault', 'Sql', 'Websites')
#>
function GenerateRunbooksForProject (
    [string] $srcPath
   ,[string] $connectionName
   ,[string[]]$projectList
   ) {
    $projectList
    # test location pattern: ResourceModule/{ServiseName}/Commands.{ServiseName}.Test/ScenarioTests/{*}Tests.ps1
    $patternExeptions = @{
        "AzureBatch"="Batch";
        "Storage" = "Management.Storage";
        "TrafficManager" = "TrafficManager2"
    }

    $resourceManagerPath = Join-Path $srcPath "ResourceManager"

    #Write-Host $resourceManagerPath -ForegroundColor Green;
    Write-Host "Collecting .ps1 tests files..." -ForegroundColor Green

    $resourceManagerFolders = Get-ChildItem -Path $resourceManagerPath -ErrorAction Stop

    foreach ($folder in $resourceManagerFolders) {
       if (-not ($projectList.Contains($folder.Name))) { 
           continue
       }

       if ($patternExeptions.ContainsKey($folder.Name)) {
           $substitution = $patternExeptions.Get_Item($folder.Name)
           $testFolderPath = "$resourceManagerPath\$folder\Commands.$substitution.Test\ScenarioTests"            
       } else {
           $testFolderPath = "$resourceManagerPath\$folder\Commands.$folder.Test\ScenarioTests"
       }

       if (Test-Path $testFolderPath) {
            $bookName = "Live{0}Tests" -f $folder.Name
            $bookName
            GenerateRunbook $testFolderPath  $bookName $connectionName

       } else {
           Write-Host "folder '$testFolderPath' doesn't exist" -ForegroundColor Red      
       }
    }
}