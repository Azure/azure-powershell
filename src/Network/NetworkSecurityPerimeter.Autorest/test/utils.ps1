function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}

$env = @{}
$templateVariables = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }

    $randomString = "t" + (RandomString -allChars $false -len 4)

    $envFilePath = (Join-Path $PSScriptRoot $envFile)

    $nspKeyValues = Get-Content $envFilePath  | ConvertFrom-Json -AsHashtable

    foreach ($item in $nspKeyValues.GetEnumerator()) {
        if ($env.Contains($item.Name)) {
            $env.($item.Name) = $item.Value
        }else{
            $env.Add($item.Name, $item.Value)
        }
    }
    $env.randomStr = $randomString

    #Create variable for template
    $rgname = 'psrg_' + $randomString
    $tmpNsp1 =  $randomString + 't-nsp1'
    $tmpNsp2 =  $randomString + 't-nsp2'
    $tmpNsp3 =  $randomString + 't-nsp3'
    $tmpNsp4 =  $randomString + 't-nsp4'
    $tmpNsp5 =  $randomString + 't-nsp5'
    $tmpNsp6 =  $randomString + 't-nsp6'
    $tmpNsp7 =  $randomString + 't-nsp7'
    $tmpNsp8 =  $randomString + 't-nsp8'
    $tmpNsp9 =  $randomString + 't-nsp9'
    $tmpNsp10 =  $randomString + 't-nsp10'
    $tmpNsp11 =  $randomString + 't-nsp11'
    $tmpNsp12 =  $randomString + 't-nsp12'
    $tmpNspDelBase1 =  $randomString + 't-nspDelB1'
    $tmpNspDelete1 =  $randomString + 't-nspD1'
    $tmpNspDelete2 =  $randomString + 't-nspD2'
    $tmpProfile1 = 't-profile1'
    $tmpProfile2 = 't-profile2'
    $tmpProfile3 = 't-profile3'
    $tmpProfileDelete1 = 't-profileD1'
    $tmpProfileDelete2 = 't-profileD2'
    $tmpProfileDelBase1 = 't-prDelB1'
    $tmpProfileDelBase2 = 't-prDelB2'
    $tmpAccessRule1 = 't-ar1'
    $tmpAccessRule2 = 't-ar2'
    $tmpAccessRule3 = 't-ar3'
    $tmpAccessRule4 = 't-ar4'
    $tmpAccessRuleDelete1 = 't-arD1'
    $tmpAccessRuleDelete2 = 't-arD2'
    $tmpAssociation1 = 't-asn1'
    $tmpAssociationDelete1 = 't-asnD1'
    $tmpAssociationDelete2 = 't-asnD2'
    $tmpPaas1Rp = $randomString + 't-paas1Rp'
    $tmpPaas2Rp = $randomString + 't-paas2Rp'
    $tmpPaas3Rp = $randomString + 't-paas3Rp'
    $tmpPaas4Rp = $randomString + 't-paas4Rp'
    $tmpLink1 = 't-link1'
    $tmpLink2 = 't-link2'
    $tmpLinkDelete3 = 't-linkD3'
    $tmpLinkDelete4 = 't-linkD4'

    $tmpKeys = 'rgname', 'tmpNsp1', 'tmpNsp2', 'tmpNsp3', 'tmpNsp4', 'tmpNsp5', 'tmpNsp6', 'tmpNsp7', 'tmpNsp8', 'tmpNsp9', 'tmpNsp10', 'tmpNsp11', 'tmpNsp12', 'tmpNspDelBase1', 'tmpProfile1', 'tmpProfile2', 'tmpProfile3', 'tmpProfileDelBase1', 'tmpProfileDelBase2', 'tmpAccessRule1', 'tmpAccessRule2', 'tmpAccessRule3', 'tmpAccessRule4', 'tmpAccessRuleDelete1','tmpAccessRuleDelete2', 'tmpAssociation1', 'tmpAssociationDelete1', 'tmpAssociationDelete2', 'tmpPaas1Rp', 'tmpPaas2Rp','tmpPaas3Rp', 'tmpPaas4Rp','tmpProfileDelete1', 'tmpProfileDelete2', 'tmpNspDelete1', 'tmpNspDelete2', 'tmpLink1', 'tmpLink2', 'tmpLinkDelete3', 'tmpLinkDelete4'
    $tmpValues = $rgname, $tmpNsp1, $tmpNsp2, $tmpNsp3, $tmpNsp4, $tmpNsp5, $tmpNsp6, $tmpNsp7, $tmpNsp8, $tmpNsp9, $tmpNsp10, $tmpNsp11, $tmpNsp12, $tmpNspDelBase1, $tmpProfile1, $tmpProfile2, $tmpProfile3, $tmpProfileDelBase1, $tmpProfileDelBase2, $tmpAccessRule1, $tmpAccessRule2, $tmpAccessRule3, $tmpAccessRule4, $tmpAccessRuleDelete1, $tmpAccessRuleDelete2,  $tmpAssociation1, $tmpAssociationDelete1, $tmpAssociationDelete2, $tmpPaas1Rp, $tmpPaas2Rp,$tmpPaas3Rp, $tmpPaas4Rp,  $tmpProfileDelete1, $tmpProfileDelete2, $tmpNspDelete1, $tmpNspDelete2, $tmpLink1, $tmpLink2, $tmpLinkDelete3, $tmpLinkDelete4

    for ($i = 0; $i -le ($tmpKeys.length - 1); $i += 1) {
        if ($env.Contains($tmpKeys[$i])) {
            $env.($tmpKeys[$i]) = $tmpValues[$i]
        }else{
            $env.Add($tmpKeys[$i], $tmpValues[$i])
        }
    }

    Get-Content $envFilePath  | ConvertFrom-Json -AsHashtable

    set-content -Path (Join-Path $PSScriptRoot 'env.json') -Value (ConvertTo-Json $env)

    set-content -Path (Join-Path $PSScriptRoot 'localEnv.json') -Value (ConvertTo-Json $env)
    
    Write-Host -ForegroundColor Magenta "Create resource group"

    # create resource group if it doesnt exists
    New-AzResourceGroup -Name $env.rgname -Location $env.location

    Write-Host -ForegroundColor Magenta "Deploying template"

    
    $templateInput = @{
        ResourceGroupName = $env.rgname
        TemplateFile = ".\test\NSPTemplate.json"
        nsp1Name = $env.tmpNsp1
        nsp2Name = $env.tmpNsp2
        nsp3Name = $env.tmpNsp3
        nsp4Name = $env.tmpNsp4
        nsp5Name = $env.tmpNsp5
        nsp6Name = $env.tmpNsp6
        nsp7Name = $env.tmpNsp7
        nsp8Name = $env.tmpNsp8
        nsp9Name = $env.tmpNsp9
        nsp10Name = $env.tmpNsp10
        nsp11Name = $env.tmpNsp11
        nsp12Name = $env.tmpNsp12
        nspDelBase1Name = $env.tmpNspDelBase1
        nspDelete1Name = $env.tmpNspDelete1
        nspDelete2Name = $env.tmpNspDelete2
        profile1Name = $env.tmpProfile1
        profile2Name = $env.tmpProfile2
        profile3Name = $env.tmpProfile3
        profileDelete1Name = $env.tmpProfileDelete1
        profileDelete2Name = $env.tmpProfileDelete2
        profileDelBase1Name = $env.tmpProfileDelBase1
        profileDelBase2Name = $env.tmpProfileDelBase2
        accessRule1Name = $env.tmpAccessRule1
        accessRule2Name = $env.tmpAccessRule2
        accessRule3Name = $env.tmpAccessRule3
        accessRule4Name = $env.tmpAccessRule4
        accessRuleDelete1Name = $env.tmpAccessRuleDelete1
        accessRuleDelete2Name = $env.tmpAccessRuleDelete2
        paas1Name = $env.tmpPaas1Rp
        paas2Name = $env.tmpPaas2Rp
        paas3Name = $env.tmpPaas3Rp
        paas4Name = $env.tmpPaas4Rp
        association1Name = $env.tmpAssociation1
        associationDelete1Name = $env.tmpAssociationDelete1
        associationDelete2Name = $env.tmpAssociationDelete2
        link1Name = $env.tmpLink1
        link2Name = $env.tmpLink2
        linkDelete3Name = $env.tmpLinkDelete3
        linkDelete4Name = $env.tmpLinkDelete4
       }
    
    #deploy template
    $templateOutput = New-AzResourceGroupDeployment @templateInput

    Write-Host -ForegroundColor Magenta "Template deployed"

    Write-Host "Get-AzNetworkSecurityPerimeterLinkReference -ResourceGroupName $env.rgname -SecurityPerimeterName $env.tmpNsp2 -Debug"

}

function cleanupEnv() {

    # Clean resources you create for testing
    
    Write-Host -ForegroundColor Magenta "Removing resources"

	try{
        $rg = $env.rgname

		$nsps = Get-AzNetworkSecurityPerimeter -ResourceGroupName $rg
		Write-Host "Get-AzNetworkSecurityPerimeter -ResourceGroupName $rg"
		Write-Host -ForegroundColor Green "Success list nsp"

		foreach($nspObj in $nsps){

	    	$nsp = $nspObj.Name

	    	try{

	    		Write-Host "Get-AzNetworkSecurityPerimeterLink -ResourceGroupName $rg -SecurityPerimeterName $nsp"

				$links = Get-AzNetworkSecurityPerimeterLink -ResourceGroupName $rg -SecurityPerimeterName $nsp
				Write-Host -ForegroundColor Green "Success list links"

				foreach($linkObj in $links){

					$linkName = $linkObj.Name

					try
					{
						Write-Host "Remove-AzNetworkSecurityPerimeterLink -Name $linkName -ResourceGroupName $rg -SecurityPerimeterName $nsp"
						Remove-AzNetworkSecurityPerimeterLink -Name $linkName -ResourceGroupName $rg -SecurityPerimeterName $nsp
						Write-Host -ForegroundColor Green "Success remove link"
					}
					catch{
						Write-Host -ForegroundColor Red "Error occcured with removing link"
						$_.Exception.ToString()
					}
				}
	    	}
	    	catch{
	    		Write-Host -ForegroundColor Red "Error occcured with listing link"
				$_.Exception.ToString()

	    	}

	    	try {

	    		Write-Host "Get-AzNetworkSecurityPerimeterLinkReference -ResourceGroupName $rg -SecurityPerimeterName $nsp"
	    		$linkRefs = Get-AzNetworkSecurityPerimeterLinkReference -ResourceGroupName $rg -SecurityPerimeterName $nsp
	    		Write-Host -ForegroundColor Green "Success list references"

	    		foreach($ref in $linkRefs){
	    			try{

	    				Write-Host "Remove-AzNetworkSecurityPerimeterLinkReference -Name $ref.Name -ResourceGroupName $rg -SecurityPerimeterName $nsp"
	    				Remove-AzNetworkSecurityPerimeterLinkReference -Name $ref.Name -ResourceGroupName $rg -SecurityPerimeterName $nsp
	    			Write-Host -ForegroundColor Green "Success remove reference"
	    			}catch{
	    			Write-Host -ForegroundColor Red "Error occcured with removing link reference"
	    				$_.Exception.ToString()
	    			}
	    		}

	    	}
	    	catch{
		    	Write-Host -ForegroundColor Red "Error occcured with listing link ref"
				$_.Exception.ToString()
	    	}

	    	try{
	    		Write-Host "Remove-AzNetworkSecurityPerimeter -Name $nsp -ResourceGroupName $rg"
				Remove-AzNetworkSecurityPerimeter -Name $nsp -ResourceGroupName $rg
				Write-Host -ForegroundColor Green "Success remove nsp"
	    	}
	    	catch{
		    	Write-Host -ForegroundColor Red "Error occcured with removing nsp"
	    		$_.Exception.ToString()
	    	}
	    }

    	try{
	    	Write-Host "Remove-AzResourceGroup -Name $rg" 
			Remove-AzResourceGroup -Name $rg
			Write-Host -ForegroundColor Green "Success remove resource group"
    	}
    	catch{
	    	Write-Host -ForegroundColor Red "Error occcured with removing rg"
    		$_.Exception.ToString()
    	}
    }
    catch{
        Write-Host -ForegroundColor Red "Error occcured with listing nsps"
    }

    Write-Host -ForegroundColor Magenta "Removing resources done, check previous logs for details."
}
