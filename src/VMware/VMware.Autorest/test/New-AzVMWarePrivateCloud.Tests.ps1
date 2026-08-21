if(($null -eq $TestName) -or ($TestName -contains 'New-AzVMwarePrivateCloud'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVMwarePrivateCloud.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzVMwarePrivateCloud' {
    # These tests validate that the -VcfLicense parameter is wired through to the request body.
    # They run fully offline (no Azure resources are created).

    It 'exposes the -VcfLicense parameter of type IVcfLicense' {
        $param = (Get-Command New-AzVMwarePrivateCloud).Parameters['VcfLicense']
        $param | Should -Not -BeNullOrEmpty
        $param.ParameterType.Name | Should -Be 'IVcfLicense'
    }

    It 'serializes -VcfLicense into the request body as a vcf5 license' {
        $ns = 'Microsoft.Azure.PowerShell.Cmdlets.VMware.Models'
        $license = New-AzVMwareVcf5LicenseObject -Core 16 -EndDate (Get-Date '2027-01-01Z').ToUniversalTime() -BroadcomSiteId 'site123' -BroadcomContractNumber 'contract123'
        $license | Should -BeOfType "$ns.Vcf5License"

        # Build the request body exactly as the cmdlet does and assign the license.
        $body = New-Object "$ns.PrivateCloud"
        $body.VcfLicense = $license

        $mode = [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode]::IncludeCreate
        $json = $body.ToJson($null, $mode).ToString()

        $json | Should -Match '"vcfLicense"'
        $json | Should -Match '"kind"\s*:\s*"vcf5"'
        $json | Should -Match '"cores"\s*:\s*16'
        $json | Should -Match '"broadcomSiteId"\s*:\s*"site123"'
        $json | Should -Match '"broadcomContractNumber"\s*:\s*"contract123"'
    }

    # Live end-to-end capture: intercepts the outgoing HTTP request and asserts the body
    # contains vcfLicense, then short-circuits so nothing is actually created.
    # Skipped automatically unless an Azure context is available (e.g. after Connect-AzAccount).
    $noAzContext = $null -eq (Get-Command Get-AzContext -ErrorAction SilentlyContinue) -or $null -eq (Get-AzContext -ErrorAction SilentlyContinue)
    It 'sends vcfLicense in the outgoing CreateExpanded request body' -Skip:$noAzContext {
        $script:capturedBody = $null
        $inspect = {
            param($request, $callback, $next)
            $script:capturedBody = $request.Content.ReadAsStringAsync().GetAwaiter().GetResult()
            throw [System.OperationCanceledException]::new('vcflicense-test-stop-before-send')
        }

        $license = New-AzVMwareVcf5LicenseObject -Core 16 -EndDate (Get-Date '2027-01-01Z').ToUniversalTime()

        New-AzVMwarePrivateCloud -Name 'test-pc' -ResourceGroupName 'test-rg' -Location 'eastus' `
            -Sku 'av36' -ManagementClusterSize 3 -NetworkBlock '192.168.48.0/22' `
            -VcfLicense $license -AcceptEULA `
            -HttpPipelinePrepend $inspect -ErrorAction SilentlyContinue | Out-Null

        $script:capturedBody | Should -Not -BeNullOrEmpty
        $script:capturedBody | Should -Match '"vcfLicense"'
        $script:capturedBody | Should -Match '"kind"\s*:\s*"vcf5"'
    }
}
