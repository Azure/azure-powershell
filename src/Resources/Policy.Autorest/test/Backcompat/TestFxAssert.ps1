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

######################
#
# Validate that the given code block throws the given exception
#
#    param [ScriptBlock] $script : The code to test
#    param [string] $message     : The text of the exception that should be thrown
#######################
function Assert-Throws {
  param([scriptblock] $script, [string] $message)
  try {
    & $script
  }
  catch {
    if ($message -ne "") {
      $actualMessage = $_.Exception.Message
      Write-Output ("Caught exception: '$actualMessage'")

      if ($actualMessage -eq $message) {
        return $true
      }
      else {
        throw "Expected exception '$message' was not received, the actual message is '$actualMessage'"
      }
    }
    else {
      return $true
    }
  }

  throw "No exception occurred"
}

######################
#
# Validate that the given code block throws the given exception
#
#    param [ScriptBlock] $script : The code to test
#    param [ScriptBlock] $compare     : Predicate used to determine if the message meets criteria
#######################
function Assert-ThrowsContains {
  param([scriptblock] $script, [string] $compare)
  try {
    & $script
  }
  catch {
    if ($compare -ne "") {
      $actualMessage = $_.Exception.Message
      Write-Output ("Caught exception: '$actualMessage'")

      if ($actualMessage.Contains($compare)) {
        return $true
      }
      else {
        throw "Expected exception does not contain the expected text '$compare', the actual message is '$actualMessage'"
      }
    }
    else {
      return $true
    }
  }

  throw "No exception occurred"
}

######################
#
# Validate that the given code block throws the given exception
#
#    param [ScriptBlock] $script : The code to test
#    param [ScriptBlock] $compare: Predicate used to determine if the message meets the criteria (-like)
#######################
function Assert-ThrowsLike {
  param([scriptblock] $script, [string] $compare)
  try {
    & $script
  }
  catch {
    if ($compare -ne "") {
      $actualMessage = $_.Exception.Message
      Write-Output ("Caught exception: '$actualMessage'")

      if ($actualMessage -like $compare) {
        return $true
      }
      else {
        throw "Expected exception is not like the expected text '$compare', the actual message is '$actualMessage'"
      }
    }
    else {
      return $true
    }
  }

  throw "No exception occurred"
}

<#
.SYNOPSIS
Given a list of variable names, assert that all of them are defined
#>
function Assert-Env {
  param([string[]] $vars)
  $tmp = Get-Item env:
  $env = @{}
  $tmp | ForEach-Object { $env.Add($_.Key, $_.Value) }
  $vars | ForEach-Object { Assert-True { $env.ContainsKey($_) } "Environment Variable $_ Is Required.  Please set the value before running the test" }
}

###################
#
# Verify that the given scriptblock returns true
#
#    param [ScriptBlock] $script : The script to execute
#    param [string] $message     : The message to return if the given script does not return true
####################
function Assert-True {
  param([scriptblock] $script, [string] $message)

  if (!$message) {
    $message = "Assertion failed: " + $script
  }

  $result = &$script
  if (-not $result) {
    Write-Debug "Failure: $message"
    throw $message
  }

  return $true
}

###################
#
# Verify that the given scriptblock returns false
#
#    param [ScriptBlock] $script : The script to execute
#    param [string] $message     : The message to return if the given script does not return false
####################
function Assert-False {
  param([scriptblock] $script, [string] $message)

  if (!$message) {
    $message = "Assertion failed: " + $script
  }

  $result = & $script
  if ($result) {
    throw $message
  }

  return $true
}

###################
#
# Verify that the given scriptblock does not return null
#
#    param [object] $actual  : The actual object
#    param [string] $message : The message to return if the given script does not return true
####################
function Assert-NotNull {
  param([object] $actual, [string] $message)

  if (!$message) {
    $message = "Assertion failed because the actual object is null."
  }

  if ($null -eq $actual) {
    throw $message
  }

  return $true
}

###################
#
# Verify that the given string is not null or empty
#
#    param [string] $actual  : The actual string
#    param [string] $message : The message to return if the given script does not return true
####################
function Assert-NotNullOrEmpty {
  param([string] $actual, [string] $message)

  if (!$message) {
    $message = "Assertion failed because the actual string is null or empty."
  }

  if ([string]::IsNullOrEmpty($actual)) {
    throw $message
  }

  return $true
}

######################
#
# Assert that the given file exists
#
#    param [string] $path   : The path to the file to test
#    param [string] $message: The text of the exception to throw if the file doesn't exist
######################
function Assert-Exists {
  param([string] $path, [string] $message)
  return Assert-True { Test-Path $path } $message
}

###################
#
# Verify that two given objects are equal
#
#    param [object] $expected : The expected object
#    param [object] $actual   : The actual object
#    param [string] $message  : The message to return if the given objects are not equal
####################
function Assert-AreEqual {
  param([object] $expected, [object] $actual, [string] $message)

  if (!$message) {
    $message = "Assertion failed because the expected object '$expected' does not match the actual '$actual'."
  }

  if ($expected -ne $actual) {
    throw $message
  }

  return $true
}
###################
#
# Verify that if actual falls in an acceptable range of expected
#
#    param [long] $expected : The expected number
#    param [long] $actual   : The actual number
#	 param [long] $interval : The acceptable offset either side of the expected
#    param [string] $message  : The message to return if the given objects are not equal
####################
function Assert-NumAreInRange {
  param([long] $expected, [long] $actual, [long] $interval, [string] $message)
  if (!$message) {
    $message = "Assertion failed because the expected number '$expected' does not fall in accepted range of 'interval' of the actual '$actual'."
  }

  if (!($actual -ge ($expected - $interval) -and $actual -le ($expected + $interval))) {
    throw $message
  }

  return $true
}
###################
#
# Verify that two given arrays are equal
#
#    param [array] $expected : The expected array
#    param [array] $actual   : The actual array
#    param [string] $message : The message to return if the given arrays are not equal.
####################
function Assert-AreEqualArray {
  param([object] $expected, [object] $actual, [string] $message)

  if (!$message) {
    $message = "Assertion failed because the expected object '$expected' does not match the actual '$actual'."
  }

  $diff = Compare-Object $expected $actual -PassThru

  if ($null -ne $diff) {
    throw $message
  }

  return $true
}

###################
#
# Verify that two given objects have equal properties
#
#    param [object] $expected : The expected object
#    param [object] $actual   : The actual object
#    param [string] $message : The message to return if the given objects are not equal.
####################
function Assert-AreEqualObjectProperties {
  param([object] $expected, [object] $actual, [string] $message)

  $properties = $expected | Get-Member -MemberType "Property" | Select-Object -ExpandProperty Name
  $diff = Compare-Object $expected $actual -Property $properties

  if ($null -ne $diff) {
    if (!$message) {
      $message = "Assert failed because the expected objects '$($diff[0])' does not match the actual $($diff[1])."
    }

    throw $message
  }

  return $true
}

###################
#
# Verify that the given value is null
#
#    param [object] $actual  : The actual object
#    param [string] $message : The message to return if the given object is not null
####################
function Assert-Null {
  param([object] $actual, [string] $message)

  if (!$message) {
    $message = "Assertion failed because the actual object '$actual' is not null."
  }

  if ($actual -ne $null) {
    throw $message
  }

  return $true
}

###################
#
# Verify that two given objects are not equal
#
#    param [object] $expected : The expected object
#    param [object] $actual   : The actual object
#    param [string] $message  : The message to return if the given objects are equal
####################
function Assert-AreNotEqual {
  param([object] $expected, [object] $actual, [string] $message)

  if (!$message) {
    $message = "Assertion failed because the expected object '$expected' does match the actual '$actual'."
  }

  if ($expected -eq $actual) {
    throw $message
  }

  return $true
}

###################
#
# Verify that the actual string starts with the expected prefix
#
#    param [string] $expectedPrefix : The expected prefix
#    param [string] $actual         : The actual string
#    param [string] $message        : The message to return if the actual string does not begin with the prefix
####################
function Assert-StartsWith {
  param([string] $expectedPrefix, [string] $actual, [string] $message)

  Assert-NotNullOrEmpty $actual

  if (!$message) {
    $message = "Assertion failed because the actual string '$actual' does not start with '$expectedPrefix'."
  }

  if (!$actual.StartsWith($expectedPrefix)) {
    throw $message
  }

  return $true
}

###################
#
# Verify that the actual string matches the regular expression
#
#    param [string] $regex	 : The regular expression
#    param [string] $actual	 : The actual string
#    param [string] $message : The message to return if the actual string does not match the regular expression
####################
function Assert-Match {
  param([string] $regex, [string] $actual, [string] $message)

  Assert-NotNullOrEmpty $actual

  if (!$message) {
    $message = "Assertion failed because the actual string '$actual' does not match the regular expression '$regex'."
  }

  if (!($actual -match $regex) > $null) {
    throw $message
  }

  return $true
}

###################
#
# Verify that the actual string does not match the regular expression
#
#    param [string] $regex	 : The regular expression
#    param [string] $actual	 : The actual string
#    param [string] $message : The message to return if the actual string matches the regular expression
####################
function Assert-NotMatch {
  param([string] $regex, [string] $actual, [string] $message)

  Assert-NotNullOrEmpty $actual

  if (!$message) {
    $message = "Assertion failed because the actual string '$actual' does match the regular expression '$regex'."
  }

  if ($actual -match $regex) {
    throw $message
  }

  return $true
}

###################
#
# Verify that the a space-delimited string contains an item matching a specific value.
#
#    param [string] $actual   : The actual string
#    param [string] $expected : The expected value.
#    param [string] $message  : The message to return if the actual string does not contain the expected value.
####################
function Assert-ContainsItem {
  param([string] $actual, [string] $expected, [string] $message)

  Assert-NotNullOrEmpty $actual
  Assert-NotNullOrEmpty $expected

  if (!$message) {
    $message = "Assertion failed because the actual string '$actual' does not contain an item matching '$expected'"
  }

  $split = $actual -Split ' '

  if (!$split.contains($expected)) {
    throw $message
  }

  return $true
}
