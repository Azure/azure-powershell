$runtimeUrl = $args[0]
$overrideUrl = $args[1]
$current = [string] (Get-Location -PSProvider FileSystem)
$client = New-Object System.Net.WebClient

function downloadWithRetry {
	param([string]$url, [string]$dest, [int]$retry) 
	Write-Host
	Write-Host "Attempt: $retry"
    Write-Host
    trap {
    	Write-Host $_.Exception.ToString()
	    if ($retry -lt 5) {
	    	$retry=$retry+1
	    	Write-Host
	    	Write-Host "Waiting 5 seconds and retrying"
	    	Write-Host
	    	Start-Sleep -s 5
	    	downloadWithRetry $url $dest $retry $client
	    }
	    else {
	    	Write-Host "Download failed"
	   		throw "Max number of retries downloading [5] exceeded" 	
	    }
    }
    $client.downloadfile($url, $dest)
}

function download($url, $dest) {
	Write-Host "Downloading $url"
	downloadWithRetry $url $dest 1
}

function copyOnVerify($file, $output) {
  Write-Host "Verifying $file"
  $verify = Get-AuthenticodeSignature $file
  Out-Host -InputObject $verify
  if ($verify.Status -ne "Valid") {
     throw "Invalid signature for runtime package $file"
  }
  else {
    mv $file $output
  }
}

if ($overrideUrl) {
    Write-Host "Using override url: $overrideUrl"
	$url = $overrideUrl
}
else {
	$url = $runtimeUrl
}

foreach($singleUrl in $url -split ";") 
{
    $suffix = Get-Random
    $downloaddir = $current + "\sandbox" + $suffix
    mkdir $downloaddir
    $dest = $downloaddir + "\sandbox.exe"
    download $singleUrl $dest
    $final = $downloaddir + "\runtime.exe"
    copyOnVerify $dest $final
    if (Test-Path -LiteralPath $final)
    {
      cd $downloaddir
      if ($host.Version.Major -eq 3)
      {
        .\runtime.exe -y | Out-Null
        .\setup.cmd
      }
      else
      {
        Start-Process -FilePath $final -ArgumentList -y -Wait 
        $cmd = $downloaddir + "\setup.cmd"
        Start-Process -FilePath $cmd -Wait
      }
    }
    else
    {
       throw "Unable to verify package"
    }
    cd $current
    if (Test-Path -LiteralPath $downloaddir)
    {
       Remove-Item -LiteralPath $downloaddir -Force -Recurse
    }
}
