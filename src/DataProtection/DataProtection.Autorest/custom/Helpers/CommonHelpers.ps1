
function GetDatasourceSetInfo
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDatasource]
		$DatasourceInfo,

		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$DatasourceType
	)

	process 
	{
		$DataSourceSetInfo = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.DatasourceSet]::new()
		$DataSourceSetInfo.DatasourceType = $DatasourceInfo.Type
		$DataSourceSetInfo.ObjectType = "DatasourceSet"        
		$DataSourceSetInfo.ResourceLocation = $DatasourceInfo.ResourceLocation
		
		$manifest = LoadManifest -DatasourceType $DatasourceType.ToString()
		if($manifest.enableDataSourceSetInfo -eq $true){		
			$DataSourceSetInfo.ResourceId =  $DatasourceInfo.ResourceId
			$DataSourceSetInfo.ResourceName = $DatasourceInfo.ResourceName			
			$DataSourceSetInfo.ResourceType =  $DataSourceInfo.ResourceType
			$DataSourceSetInfo.ResourceUri = $DatasourceInfo.ResourceUri
		}
		else{
			$splitResourceId = $DatasourceInfo.ResourceId.Split("/")
			$DataSourceSetInfo.ResourceId =  [System.String]::Join('/', $splitResourceId[0..($splitResourceId.Count -3)]) 			
			$DataSourceSetInfo.ResourceName = $splitResourceId[$splitResourceId.Count -3]
			$splitResourceType = $DatasourceInfo.ResourceType.Split("/")
			$DataSourceSetInfo.ResourceType =  [System.String]::Join('/', $splitResourceType[0..($splitResourceType.Count -2)])
			$DataSourceSetInfo.ResourceUri = ""
		}

		if($DataSourceSetInfo.PSObject.Properties.Name -contains "ResourceProperties")
		{
			$DataSourceSetInfo.PSObject.Properties.Remove("ResourceProperties") | Out-Null
		}

		return $DataSourceSetInfo
	}
}

function GetDatasourceInfo
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$ResourceId,

		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$ResourceLocation,

		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$DatasourceType
	)

	process
	{
		$manifest = LoadManifest -DatasourceType $DatasourceType.ToString()
		$DataSourceInfo = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Datasource]::new()
		$DataSourceInfo.ObjectType = "Datasource"
        $DataSourceInfo.ResourceId = $ResourceId
        $DataSourceInfo.ResourceLocation = $ResourceLocation
        $DataSourceInfo.ResourceName = $ResourceId.Split("/")[-1]
        $DataSourceInfo.ResourceType = $manifest.resourceType
        $DataSourceInfo.ResourceUri = ""

        if($manifest.isProxyResource -eq $false -or $manifest.enableDataSourceSetInfo -eq $true)
        {
            $DataSourceInfo.ResourceUri = $ResourceId
        }

        $DataSourceInfo.Type = $manifest.datasourceType

		return $DataSourceInfo
	}
}

function GetClientDatasourceType
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$ServiceDatasourceType
	)

	process
	{
		$datasourceTypes = GetDatasourceTypes
		foreach($datasourceInfo in $datasourceTypes.supportedDatasourceTypes)
		{
			if($datasourceInfo.serviceDatasourceType -eq $ServiceDatasourceType)
			{
				return $datasourceInfo.clientDatasourceType
			}
		}
		return ""
	}
}

function UnprotectSecureString
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory, ValueFromPipeline)]
		[System.Security.SecureString]
		${SecureString}
	)

	process
	{
		$ssPtr = [System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($SecureString)
		try {
			$plaintext = [System.Runtime.InteropServices.Marshal]::PtrToStringBSTR($ssPtr)
		} finally {
			[System.Runtime.InteropServices.Marshal]::ZeroFreeBSTR($ssPtr)
		}

		return $plaintext
	}
}

function Get-AzDataProtectionAsPerPolicyImmutabilityPipeline
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param()

	$pipelineScript = {
		param($request, $callback, $next)

		if ($null -eq $request.Content) {
			return $next.SendAsync($request, $callback)
		}

		$requestBody = $request.Content.ReadAsStringAsync().GetAwaiter().GetResult() | ConvertFrom-Json
		if ($null -eq $requestBody.properties.securitySettings.immutabilitySettings.configuration) {
			$requestBody.properties.securitySettings.immutabilitySettings |
				Add-Member -MemberType NoteProperty -Name configuration -Value ([PSCustomObject]@{})
		}

		$requestBody.properties.securitySettings.immutabilitySettings.configuration |
			Add-Member -MemberType NoteProperty -Name type -Value 'AsPerPolicy' -Force

		$jsonBody = $requestBody | ConvertTo-Json -Depth 100 -Compress
		$request.Content = [System.Net.Http.StringContent]::new($jsonBody, [System.Text.Encoding]::UTF8, 'application/json')

		return $next.SendAsync($request, $callback)
	}

	return [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep]$pipelineScript
}
