
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

function Assert-AzDataProtectionImmutabilitySetting
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[System.String]
		${ImmutabilityState},

		[System.String]
		${ImmutabilityType},

		[System.Boolean]
		${HasImmutabilityState},

		[System.Boolean]
		${HasImmutabilityType},

		[System.Boolean]
		${HasImmutabilityDurationInDay}
	)

	if ($HasImmutabilityState -and $ImmutabilityState -eq 'Disabled' -and ($HasImmutabilityType -or $HasImmutabilityDurationInDay)) {
		throw 'ImmutabilityType and ImmutabilityDurationInDay cannot be specified when ImmutabilityState is Disabled.'
	}

	if ($HasImmutabilityState -and $ImmutabilityState -ne 'Disabled' -and -not $HasImmutabilityType) {
		throw 'ImmutabilityType is required when ImmutabilityState is Unlocked or Locked.'
	}

	if (($HasImmutabilityType -or $HasImmutabilityDurationInDay) -and -not $HasImmutabilityState) {
		throw 'ImmutabilityState is required when ImmutabilityType or ImmutabilityDurationInDay is specified.'
	}

	if ($HasImmutabilityType -and $ImmutabilityType -eq 'TimeBased' -and -not $HasImmutabilityDurationInDay) {
		throw 'ImmutabilityDurationInDay is required when ImmutabilityType is TimeBased.'
	}

	if ($HasImmutabilityType -and $ImmutabilityType -eq 'AsPerPolicy' -and $HasImmutabilityDurationInDay) {
		throw 'ImmutabilityDurationInDay cannot be specified when ImmutabilityType is AsPerPolicy.'
	}
}

function Get-AzDataProtectionImmutabilityRequestPipeline
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[System.String]
		${ImmutabilityType},

		[System.Nullable[System.Double]]
		${ImmutabilityDurationInDay},

		[System.Boolean]
		${HasImmutabilityType},

		[System.Boolean]
		${HasImmutabilityDurationInDay}
	)

	$immutabilityTypeValue = $ImmutabilityType
	$immutabilityDurationValue = $ImmutabilityDurationInDay
	$includeImmutabilityType = $HasImmutabilityType
	$includeImmutabilityDuration = $HasImmutabilityDurationInDay

	$pipelineScript = {
		param($request, $callback, $next)

		if ($null -eq $request.Content) {
			return $next.SendAsync($request, $callback)
		}

		$requestBody = $request.Content.ReadAsStringAsync().GetAwaiter().GetResult() | ConvertFrom-Json
		if ($null -eq $requestBody.properties) {
			$requestBody | Add-Member -MemberType NoteProperty -Name properties -Value ([PSCustomObject]@{})
		}
		if ($null -eq $requestBody.properties.securitySettings) {
			$requestBody.properties | Add-Member -MemberType NoteProperty -Name securitySettings -Value ([PSCustomObject]@{})
		}
		if ($null -eq $requestBody.properties.securitySettings.immutabilitySettings) {
			$requestBody.properties.securitySettings | Add-Member -MemberType NoteProperty -Name immutabilitySettings -Value ([PSCustomObject]@{})
		}
		if ($null -eq $requestBody.properties.securitySettings.immutabilitySettings.configuration) {
			$requestBody.properties.securitySettings.immutabilitySettings |
				Add-Member -MemberType NoteProperty -Name configuration -Value ([PSCustomObject]@{})
		}

		if ($includeImmutabilityType) {
			$requestBody.properties.securitySettings.immutabilitySettings.configuration |
				Add-Member -MemberType NoteProperty -Name type -Value $immutabilityTypeValue -Force
		}
		if ($includeImmutabilityDuration) {
			$requestBody.properties.securitySettings.immutabilitySettings.configuration |
				Add-Member -MemberType NoteProperty -Name durationInDays -Value $immutabilityDurationValue -Force
		}

		$jsonBody = $requestBody | ConvertTo-Json -Depth 100 -Compress
		$request.Content = [System.Net.Http.StringContent]::new($jsonBody, [System.Text.Encoding]::UTF8, 'application/json')

		return $next.SendAsync($request, $callback)
	}.GetNewClosure()

	return [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep]$pipelineScript
}