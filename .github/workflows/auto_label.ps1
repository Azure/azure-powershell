$allPRNos = gh pr list -s open --limit 100 --json number,url,author --search "-label:needs-revision"| ConvertFrom-Json
Write-Host "Total open PRs without label 'needs-revision': $($allPRNos.Count)"

$allPRResults = @()

foreach($pr in $allPRNos){
	$prUrl = $pr.url
	$checkResult = gh pr checks $pr.number
	$checkResult = $checkResult -split '\n'
	
	$passCount = 0
	$failCount = 0
	$unknownCount = 0
	foreach($check in $checkResult){
		$checkPerField = $check -split '\t'
		$checkFlag = $checkPerField[1]
		if($checkFlag -eq 'pass'){
			$passCount += 1
		}elseif($checkFlag -eq 'fail'){
			$failCount += 1
		}else{
			$unknownCount += 1
		}
	}
	$prCheckResult = @{
		"prNo" = $pr.number
		"prUrl" = $prUrl
		"checkNo" = $checkResult.Count
		"passCheckCount" = $passCount
		"failCheckCount" = $failCount
		"unknownCheckCount" = $unknownCount
		"passChecks" = $checkFlag
		"author" = $pr.author.login
	}
	$allPRResults += $prCheckResult
}

$failedPRs = $allPRResults | where failCheckCount -gt 0

Write-Host "--------------------------------"

$successPRs = $allPRResults | where failCheckCount -eq 0
Write-Host "Please review the following $($successPRs.Count) PRs. They have passed all checks."
$successPRs | foreach {Write-Host $_.prUrl}

Write-Host "--------------------------------"

$failedPRs = $allPRResults | where failCheckCount -gt 0
if($failedPRs.Count -gt 0){
	Write-Host "Please check the following $($failedPRs.Count) PRs. They have failed some checks."
	$failedPRs | foreach {Write-Host $_.prUrl "failed" (($_.failCheckCount,$_.checkNo) -join '/') "checks."}

	foreach($failedPR in $failedPRs){
		gh pr edit $failedPR.prNo --add-label "needs-revision"
		gh pr comment $failedPR.prNo --body "Hi @$($failedPR.author), this PR failes in some checks. Please double check it."
	}
}else{
	Write-Host "No new failed PRs."
}
