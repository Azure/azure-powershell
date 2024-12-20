function GenerateDefinitionFile {
    param (
        [Parameter()]
        [string] $File
    )

    $definition = [PSCustomObject]@{
        name       = "DataFlow"
        properties = [PSCustomObject]@{
            type           = "MappingDataFlow"
            typeProperties = [PSCustomObject]@{
                sources         = @()
                sinks           = @()
                transformations = @()
                scriptLines     = @("")
            }
        }
    }

    ConvertTo-Json $definition -Compress -Depth 3 | Out-File -FilePath $File -Encoding utf8 -NoNewline -Force
}

Invoke-LiveTestScenario -Name "Create synapse data flow" -Description "Test creating a synapse data flow" -PowerShellVersion "5.1", "Latest" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $wsName = New-LiveTestResourceName
    $location = "eastus"
    $saName = New-LiveTestStorageAccountName
    $fsName = New-LiveTestStorageAccountName
    $flowName = New-LiveTestResourceName
    $fileName = New-LiveTestRandomName -Option AllLetters -MaxLength 8
    $file = "$fileName.json"

    $username = "sqladmin"
    $password = ConvertTo-SecureString "Password123!" -AsPlainText -Force
    $sqlAdminCred = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $username, $password
    New-AzSynapseWorkspace -Name $wsName -ResourceGroupName $rgName -Location $location -DefaultDataLakeStorageAccountName $saName -DefaultDataLakeStorageFilesystem $fsName -SqlAdministratorLoginCredential $sqlAdminCred
    New-AzSynapseFirewallRule -WorkspaceName $wsName -AllowAllIp

    Start-Sleep -Seconds 30

    GenerateDefinitionFile($file)
    Set-AzSynapseDataFlow -Name $flowName -WorkspaceName $wsName -DefinitionFile $file

    $actual = Get-AzSynapseDataFlow -Name $flowName -WorkspaceName $wsName
    Assert-NotNull $actual
    Assert-AreEqual $wsName $actual.WorkspaceName
    Assert-AreEqual $flowName $actual.Name
}

Invoke-LiveTestScenario -Name "Remove synapse data flow" -Description "Test removing a synapse data flow" -PowerShellVersion "5.1", "Latest" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $wsName = New-LiveTestResourceName
    $location = "eastus"
    $saName = New-LiveTestStorageAccountName
    $fsName = New-LiveTestStorageAccountName
    $flowName = New-LiveTestResourceName
    $fileName = New-LiveTestRandomName -Option AllLetters -MaxLength 8
    $file = "$fileName.json"

    $username = "sqladmin"
    $password = ConvertTo-SecureString "Password123!" -AsPlainText -Force
    $sqlAdminCred = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $username, $password
    New-AzSynapseWorkspace -Name $wsName -ResourceGroupName $rgName -Location $location -DefaultDataLakeStorageAccountName $saName -DefaultDataLakeStorageFilesystem $fsName -SqlAdministratorLoginCredential $sqlAdminCred
    New-AzSynapseFirewallRule -WorkspaceName $wsName -AllowAllIp

    Start-Sleep -Seconds 60

    GenerateDefinitionFile($file)
    Set-AzSynapseDataFlow -Name $flowName -WorkspaceName $wsName -DefinitionFile $file
    Remove-AzSynapseDataFlow -Name $flowName -WorkspaceName $wsName -Force

    $actual = Get-AzSynapseDataFlow -Name $flowName -WorkspaceName $wsName -ErrorAction SilentlyContinue
    Assert-Null $actual
}
