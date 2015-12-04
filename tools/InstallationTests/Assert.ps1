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
function Assert-Throws
{
  param([ScriptBlock] $script, [string] $message)
  try 
  {
    &$script
  }
  catch 
  {
    if ($message -ne "")
    {
      $actualMessage = $_.Exception.Message
      Write-Output ("Caught exception: '$actualMessage'")

      if ($actualMessage -eq $message)
      {
        return $true;
      }
      else
      {
        throw "Expected exception not received: '$message' the actual message is '$actualMessage'";
      }
    }
    else
    {
      return $true;
    }
  }

  throw "No exception occured";
}

######################
#
# Validate that the given code block throws the given exception
#
#    param [ScriptBlock] $script : The code to test
#    param [ScriptBlock] $compare     : Predicate used to determine if the message meets criteria
#######################
function Assert-ThrowsContains
{
  param([ScriptBlock] $script, [string] $compare)
  try 
  {
    &$script
  }
  catch 
  {
    if ($message -ne "")
    {
      $actualMessage = $_.Exception.Message
      Write-Output ("Caught exception: '$actualMessage'")
      if ($actualMessage.Contains($compare))
      {
        return $true;
      }
      else
      {
        throw "Expected exception does not contain expected text '$compare', the actual message is '$actualMessage'";
      }
    }
    else
    {
      return $true;
    }
  }

  throw "No exception occured";
}

<#
.SYNOPSIS
Given a list of variable names, assert that all of them are defined
#>
function Assert-Env
{
   param([string[]] $vars)
   $tmp = Get-Item env:
   $env = @{}
   $tmp | % { $env.Add($_.Key, $_.Value)}
   $vars | % { Assert-True {$env.ContainsKey($_)} "Environment Variable $_ Is Required.  Please set the value before runnign the test"}
}

###################
#
# Verify that the given scriptblock returns true
#
#    param [ScriptBlock] $script : The script to execute
#    param [string] $message     : The message to return if the given script does not return true
####################
function Assert-True
{
  param([ScriptBlock] $script, [string] $message)
  
  if (!$message)
  {
    $message = "Assertion failed: " + $script
  }
  
  $result = &$script
  if (-not $result) 
  {
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
function Assert-False
{
  param([ScriptBlock] $script, [string] $message)
  
  if (!$message)
  {
    $message = "Assertion failed: " + $script
  }
  
  $result = &$script
  if ($result) 
  {
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
function Assert-False
{
    param([ScriptBlock] $script, [string] $message)
    
    if (!$message)
    {
        $message = "Assertion failed: " + $script
    }
    
    $result = &$script
    if ($result) 
    {
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
function Assert-NotNull
{
  param([object] $actual, [string] $message)
  
  if (!$message)
  {
    $message = "Assertion failed because the object is null: " + $actual
  }
  
  if ($actual -eq $null) 
  {
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
function Assert-Exists
{
    param([string] $path, [string] $message) 
  return Assert-True {Test-Path $path} $message
}

###################
#
# Verify that two given objects are equal
#
#    param [object] $expected : The expected object
#    param [object] $actual   : The actual object
#    param [string] $message  : The message to return if the given objects are not equal
####################
function Assert-AreEqual
{
    param([object] $expected, [object] $actual, [string] $message)
  
  if (!$message)
  {
      $message = "Assertion failed because expected '$expected' does not match actual '$actual'"
  }
  
  if ($expected -ne $actual) 
  {
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
function Assert-AreEqualArray
{
    param([object] $expected, [object] $actual, [string] $message)
  
  if (!$message)
  {
      $message = "Assertion failed because expected '$expected' does not match actual '$actual'"
  }
  
  $diff = Compare-Object $expected $actual -PassThru

  if ($diff -ne $null) 
  {
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
function Assert-AreEqualObjectProperties
{
  param([object] $expected, [object] $actual, [string] $message)
  
  $properties = $expected | Get-Member -MemberType "Property" | Select -ExpandProperty Name
  $diff = Compare-Object $expected $actual -Property $properties

  if ($diff -ne $null) 
  {
      if (!$message)
      {
          $message = "Assert failed because the objects don't match. Expected: " + $diff[0] + " Actual: " + $diff[1]
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
function Assert-Null
{
    param([object] $actual, [string] $message)
  
  if (!$message)
  {
      $message = "Assertion failed because the object is not null: " + $actual
  }
  
  if ($actual -ne $null) 
  {
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
function Assert-AreNotEqual
{
    param([object] $expected, [object] $actual, [string] $message)
  
  if (!$message)
  {
      $message = "Assertion failed because expected '$expected' does match actual '$actual'"
  }
  
  if ($expected -eq $actual) 
  {
      throw $message
  }
  
  return $true
}