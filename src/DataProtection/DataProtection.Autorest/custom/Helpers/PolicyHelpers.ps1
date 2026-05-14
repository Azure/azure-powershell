
function GetBackupFrequencyString {
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.BackupFrequency]
		$frequency,

		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.Int32]
		$count
	)

	process {
		$freq = $frequency.ToString()
		if($freq -eq "Weekly")
		{
			return "P1W"
		}

		if($freq -eq "Daily")
		{
			return "P1D"
		}

		if($freq -eq "Hourly")
		{
			return "PT" + $count.ToString() + "H"
		}
	}
}

function GetTaggingPriority {
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$Name
	)

	process{
		$priorityMap = @{"Default"=99;"Default_OperationalStore"=99;"Daily"=25;"Weekly"=20;"Monthly"=15;"Yearly"=10}
		return $priorityMap[$Name]
	}
}

function ValidateBackupSchedule
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$DatasourceType,

		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String[]]
		$Schedule
	)

	process
	{
		$manifest = LoadManifest -DatasourceType $DatasourceType
		if($manifest.policySettings.backupScheduleSupported -eq $false)
		{
			$message = "Adding Backup Schedule is not supported for Datasource Type " + $DatasourceType
			throw $message
		}

		$backupFrequencyMap = @{"D"="Daily";"H"="Hourly";"W"="Weekly"}
		if($manifest.policySettings.supportedBackupFrequency.Contains($backupFrequencyMap[$Schedule[0][-1].ToString()]) -eq $false)
		{
			$message = $backupFrequencyMap[$Schedule[0][-1].ToString()] + " Backup Schedule is not supported for Datasource Type " + $DatasourceType
			throw $message
		}
	}
}

function GetBackupFrequenceFromTimeInterval
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String[]]
		$RepeatingTimeInterval
	)

	process
	{
		$backupFrequencyMap = @{"D"="Daily";"H"="Hourly";"W"="Weekly"}
		return "Backup" + $backupFrequencyMap[$RepeatingTimeInterval[0][-1].ToString()]
	}
}

function ValidateRetentionRuleMatchesMappedStore
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$Name,

		[Parameter(Mandatory=$true)]
		$DefaultRetentionMapping,

		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		$LifeCycles,

		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$DatasourceType
	)

	process
	{
		$mappedDefaultNames = @($DefaultRetentionMapping.PSObject.Properties.Value)
		if($mappedDefaultNames -contains $Name){
			foreach($lc in $LifeCycles){
				$store = $lc.SourceDataStoreType.ToString()
				$expectedName = $null
				if($DefaultRetentionMapping.PSObject.Properties.Name -contains $store){
					$expectedName = $DefaultRetentionMapping.$store
				}
				if($null -ne $expectedName -and $expectedName -ne $Name){
					$reservedStores = @($DefaultRetentionMapping.PSObject.Properties | Where-Object { $_.Value -eq $Name } | ForEach-Object { $_.Name })
					$reservedFor = $reservedStores -join ", "
					throw "Retention rule '$Name' is reserved for source store '$reservedFor' on datasource type $DatasourceType. For source store '$store' use -Name $expectedName. See Get-Help Edit-AzDataProtectionPolicyRetentionRuleClientObject -Examples."
				}
			}
		}
		return $mappedDefaultNames
	}
}

function ValidateExclusiveSourceStoreAssignment
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$Name,

		[Parameter(Mandatory=$true)]
		$Manifest,

		[Parameter(Mandatory=$true)]
		$DefaultRetentionMapping,

		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		$LifeCycles,

		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$DatasourceType
	)

	process
	{
		$exclusiveStores = @()
		if($null -ne $Manifest.policySettings -and ($Manifest.policySettings.PSObject.Properties.Name -contains "exclusiveSourceDataStores")){
			$exclusiveStores = @($Manifest.policySettings.exclusiveSourceDataStores)
		}
		if($exclusiveStores.Count -gt 0){
			foreach($lc in $LifeCycles){
				$store = $lc.SourceDataStoreType.ToString()
				if($exclusiveStores -contains $store){
					$expectedName = $null
					if($DefaultRetentionMapping.PSObject.Properties.Name -contains $store){
						$expectedName = $DefaultRetentionMapping.$store
					}
					if($null -ne $expectedName -and $expectedName -ne $Name){
						throw "Source store '$store' on datasource type $DatasourceType is exclusive: only the '$expectedName' retention rule may carry an $store lifecycle. Use -Name $expectedName instead of -Name $Name, or remove the $store lifecycle from -LifeCycles."
					}
				}
			}
		}
	}
}