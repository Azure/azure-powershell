# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

# default keywords
$CommonDefaults = @("common", "azure", "services", "data")
$RmDefaults = @("azure", "azurerm", "arm", "resource", "management", "manager")
$SmDefaults = @("azure", "azuresm", "servicemanagement", "management", "service")

# specialized Common keywords by module
$Common = @{
	"Common\Storage\Commands.Storage\Microsoft.WindowsAzure.Commands.Storage.dll-Help.xml" = @("storage", "blob", "queue", "table")
}

# specialized Resource Management keywords by module
$RM = @{
	"ResourceManager\ApiManagement\Commands.ApiManagement.ServiceManagement\Microsoft.Azure.Commands.ApiManagement.ServiceManagement.dll-help.xml" = @("api", "apimanagement", "apimgmt", "apism")
	"ResourceManager\ApiManagement\Commands.ApiManagement\Microsoft.Azure.Commands.ApiManagement.dll-help.xml" = @("api", "apimanagement", "apimgmt", "apirm")
	"ResourceManager\Automation\Commands.Automation\Microsoft.Azure.Commands.ResourceManager.Automation.dll-help.xml" = @("automation", "devops")
	"ResourceManager\AzureBackup\Commands.AzureBackup\Microsoft.Azure.Commands.AzureBackup.dll-help.xml" = @("backup")
	"ResourceManager\AzureBatch\Commands.Batch\Microsoft.Azure.Commands.Batch.dll-Help.xml" = @("batch")
	"ResourceManager\Compute\Commands.Compute\Microsoft.Azure.Commands.Compute.dll-Help.xml" = @("compute", "vm", "iaas")
	"ResourceManager\DataFactories\Commands.DataFactories\Microsoft.Azure.Commands.DataFactories.dll-Help.xml" = @("data", "factories")
	"ResourceManager\Dns\Commands.Dns\Microsoft.Azure.Commands.Dns.dll-Help.xml" = @("dns", "network", "networking")
	"ResourceManager\HDInsight\Commands.HDInsight\Microsoft.Azure.Commands.HDInsight.dll-help.xml" = @("hadoop", "hdinsight", "hd", "insight")
	"ResourceManager\Insights\Commands.Insights\Microsoft.Azure.Commands.Insights.dll-Help.xml" = @("insights")
	"ResourceManager\KeyVault\Commands.KeyVault\Microsoft.Azure.Commands.KeyVault.dll-help.xml" = @("keyvalut", "key", "secrets", "certificates", "password", "vault")
	"ResourceManager\Network\Commands.Network\Microsoft.Azure.Commands.Network.dll-Help.xml" = @("network", "networking")
	"ResourceManager\OperationalInsights\Commands.OperationalInsights\Microsoft.Azure.Commands.OperationalInsights.dll-Help.xml" = @("operational", "insights")
	"ResourceManager\Profile\Commands.Profile\Microsoft.Azure.Commands.Profile.dll-Help.xml" = @("profile", "common", "login", "account")
	"ResourceManager\RedisCache\Commands.RedisCache\Microsoft.Azure.Commands.RedisCache.dll-Help.xml" = @("redis", "cache", "web", "webapp", "website")
	"ResourceManager\Resources\Commands.ResourceManager\Cmdlets\Microsoft.Azure.Commands.ResourceManager.Cmdlets.dll-Help.xml" = @("resource", "group", "template", "deployment")
	"ResourceManager\Resources\Commands.Resources\Microsoft.Azure.Commands.Resources.dll-Help.xml" = @("resource", "group", "template", "deployment")
	"ResourceManager\SiteRecovery\Commands.SiteRecovery\Microsoft.Azure.Commands.SiteRecovery.dll-help.xml" = @("site", "recovery")
	"ResourceManager\Sql\Commands.Sql\Microsoft.Azure.Commands.Sql.dll-Help.xml" = @("sql", "database", "mssql")
	"ResourceManager\Storage\Commands.Management.Storage\Microsoft.Azure.Commands.Management.Storage.dll-Help.xml" = @("storage", "container", "account")
	"ResourceManager\StreamAnalytics\Commands.StreamAnalytics\Microsoft.Azure.Commands.StreamAnalytics.dll-Help.xml" = @("analytics", "stream")
	"ResourceManager\Tags\Commands.Tags\Microsoft.Azure.Commands.Tags.dll-help.xml" = @("tag", "tags", "resource", "group")
	"ResourceManager\TrafficManager\Commands.TrafficManager2\Microsoft.Azure.Commands.TrafficManager.dll-help.xml" = @("traffic", "trafficmanager")
	"ResourceManager\UsageAggregates\Commands.UsageAggregates\Microsoft.Azure.Commands.UsageAggregates.dll-help.xml" = @("usage", "billing", "aggregate")
	"ResourceManager\Websites\Commands.Websites\Microsoft.Azure.Commands.Websites.dll-Help.xml" = @("webapp", "website", "kudu", "paas")
}

# specialized Service Management keywords by module
$SM = @{
	"ServiceManagement\Automation\Commands.Automation\Microsoft.Azure.Commands.Automation.dll-help.xml" = @("automation", "devops")
	"ServiceManagement\Compute\Commands.ServiceManagement.PlatformImageRepository\Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.dll-help.xml" = @("image", "vm", "platform")
	"ServiceManagement\Compute\Commands.ServiceManagement.Preview\Microsoft.WindowsAzure.Commands.ServiceManagement.Preview.dll-Help.xml" = @("preview")
	"ServiceManagement\Compute\Commands.ServiceManagement\Microsoft.WindowsAzure.Commands.ServiceManagement.dll-Help.xml" = @("svc", "mgmt", "service")
	"ServiceManagement\ExpressRoute\Commands.ExpressRoute\Microsoft.WindowsAzure.Commands.ExpressRoute.dll-help.xml" = @("express", "route", "network")
	"ServiceManagement\HDInsight\Commands.HDInsight\Microsoft.WindowsAzure.Commands.HDInsight.dll-Help.xml" = @("hadoop", "hdinsight", "hd", "insight")
	"ServiceManagement\ManagedCache\Commands.ManagedCache\Microsoft.Azure.Commands.ManagedCache.dll-help.xml" = @("managed", "cache")
	"ServiceManagement\Network\Commands.Network\Microsoft.WindowsAzure.Commands.ServiceManagement.Network.dll-help.xml" = @("network", "networking")
	"ServiceManagement\Profile\Commands.Profile\Microsoft.WindowsAzure.Commands.Profile.dll-Help.xml" = @("profile", "common", "login", "account")
	"ServiceManagement\RecoveryServices\Commands.RecoveryServices\Microsoft.Azure.Commands.RecoveryServices.dll-help.xml" = @("site", "recovery")
	"ServiceManagement\RemoteApp\Commands.RemoteApp\Microsoft.WindowsAzure.Commands.RemoteApp.dll-help.xml" = @("remote", "app")
	"ServiceManagement\Services\Commands.Utilities\Microsoft.WindowsAzure.Commands.dll-Help.xml" = @("utilities")
	"ServiceManagement\Sql\Commands.SqlDatabase\Microsoft.WindowsAzure.Commands.SqlDatabase.dll-Help.xml" = @("sql", "database", "mssql")
	"ServiceManagement\StorSimple\Commands.StorSimple\Microsoft.WindowsAzure.Commands.StorSimple.dll-help.xml" = @("store", "storsimple")
	"ServiceManagement\TrafficManager\Commands.TrafficManager\Microsoft.WindowsAzure.Commands.TrafficManager.dll-help.xml" = @("traffic", "trafficmanager")
}

# default and specialized keyword pairs
$Pairs = ($CommonDefaults, $Common),($RmDefaults, $RM),($SmDefaults, $SM)

# the namespaces used in the dll-help.xml
$ns = @{
	maml = "http://schemas.microsoft.com/maml/2004/10"
	cmd = "http://schemas.microsoft.com/maml/dev/command/2004/10"
}

$totalNumberOfFiles = ($Pairs | foreach { $_[1].Keys.count } | Measure -Sum).Sum
$numProcessed = 0

write-progress -activity "Writing Keywords to help.xml files" -status "0 % Complete:" -percentcomplete 0;

$Pairs | foreach {
	$defaults = $_[0]
	$files = $_[1]
	$files.Keys | foreach {
		$key = $_
		$filePath = Resolve-Path ("..\..\src\" + $key)
		$xml = [xml](Get-Content $filePath)
		Select-Xml -Xml $xml -XPath '//cmd:command/maml:alertSet/maml:alert/maml:para[starts-with(text(),"Keywords:")]' -Namespace $ns | foreach {
			# all the commands in the help-xml that does have an alert para element that starts with Keywords
			$_.Node.RemoveAll()
			# just remove the text node and replace with the latest keywords
			$_.Node.AppendChild($xml.CreateTextNode("Keywords: " + (($defaults + $files[$key]) -join ', ')))  | Out-Null
		}

		Select-Xml -Xml $xml -XPath '//cmd:command[not(maml:alertSet/maml:alert/maml:para[starts-with(text(),"Keywords:")])]' -Namespace $ns | foreach {
			# all the commands in the help-xml that do not have an alert para element that starts with Keywords
			$para = $xml.CreateElement("maml:para", $ns["maml"])
			# build the para keywords
			$para.AppendChild($xml.CreateTextNode("Keywords: " + (($defaults + $files[$key]) -join ', ')))  | Out-Null

			# check for an alertSet and build one if needed
			$alertSet = ($_ | Select-Xml -XPath "maml:alertSet" -Namespace $ns)
			if($alertSet.count -le 0){
				$_.Node.AppendChild($xml.CreateElement("maml:alertSet", $ns["maml"]))  | Out-Null
				$alertSet = ($_ | Select-Xml -XPath "maml:alertSet" -Namespace $ns)
			}

			# check for an alert element and build if needed
			$alert = ($alertSet[0] | Select-Xml -XPath "maml:alert" -Namespace $ns)
			if($alert.count -le 0){
				$alertSet[0].Node.AppendChild($xml.CreateElement("maml:alert", $ns["maml"])) | Out-Null
				$alert = ($alertSet[0] | Select-Xml -XPath "maml:alert" -Namespace $ns)
			}

			# finally append the para to the alert to end the process
			$alert[0].Node.AppendChild($para) | Out-Null
		}
		
		# write the file back to where we read it from
		$xml.Save($filePath);
		
		$numProcessed++
		$percentComplete = ($numProcessed / $totalNumberOfFiles)
		write-progress -activity "Writing Keywords to help.xml files" -status ("{0:P0} Complete" -f $percentComplete) -percentcomplete ($percentComplete * 100);
	}
}