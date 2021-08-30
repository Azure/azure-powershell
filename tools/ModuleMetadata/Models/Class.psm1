# ----------------------------------------------------------------------------------
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

class MethodSignature
{
    [System.String] $Name = ""
    [System.Collections.Generic.List[MethodParameterMetadata]] $Parameters
    [System.String] $ReturnType
}
class MethodMetadata : MethodSignature { }
class ConstructorMetadata : MethodSignature { }
class MethodParameterMetadata
{
    [System.String] $Name
    [System.String] $Type
}

class BaseMetadata {
    [System.String] ToJsonString()
    {
        $NonEmptyProperties = $this.psobject.Properties | Where-Object {$_.Value} | Select-Object -ExpandProperty Name
        return $this | Select-Object -Property $NonEmptyProperties | ConvertTo-Json -Depth 100
    }
}

class OutputMetadata : BaseMetadata
{
    [TypeMetadata] $Type
    [System.Collections.Generic.List[System.String]] $ParameterSets

    OutputMetadata()
    {
        $this.ParameterSets = [System.Collections.Generic.List[System.String]]::New()
    }
}

class ParameterMetadata : BaseMetadata
{
    [System.String] $Name
    [System.Collections.Generic.List[System.String]] $AliasList
    [TypeMetadata] $Type
    [System.Collections.Generic.List[System.String]] $ValidateSet
    [Nullable[System.Int64]] $ValidateRangeMin
    [Nullable[System.Int64]] $ValidateRangeMax
    [System.Boolean] $ValidateNotNullOrEmpty

    ParameterMetadata()
    {
        $this.AliasList = [System.Collections.Generic.List[System.String]]::New()
        $this.ValidateSet = [System.Collections.Generic.List[System.String]]::New()
    }
}

class ParameterSetMetadata : BaseMetadata
{
    [System.String] $Name
    [System.Collections.Generic.List[ParameterMetadataInParameterSet]] $Parameters

    ParameterSetMetadata()
    {
        $this.Parameters = [System.Collections.Generic.List[ParameterMetadataInParameterSet]]::New()
    }
}

class ParameterMetadataInParameterSet : BaseMetadata
{
    [ParameterMetadata] $ParameterMetadata
    [System.Boolean] $Mandatory
    [System.Int32] $Position
    [System.Boolean] $ValueFromPipeline
    [System.Boolean] $ValueFromPipelineByPropertyName
}

class CmdletMetadata : BaseMetadata
{
    [System.String] $VerbName
    [System.String] $NounName
    [System.String] $Name
    [System.String] $ClassName
    [System.Boolean] $SupportsShouldProcess
    [System.Management.Automation.ConfirmImpact] $ConfirmImpact
    [Nullable[System.Boolean]] $HasForceSwitch
    [System.Boolean] $SupportsPaging
    [System.String] $DefaultParameterSetName
    [System.Collections.Generic.List[OutputMetadata]] $OutputTypes
    [System.Collections.Generic.List[ParameterMetadata]] $Parameters
    [System.Collections.Generic.List[ParameterSetMetadata]] $ParameterSets
    [System.Collections.Generic.List[System.String]] $AliasList

    CmdletMetadata()
    {
        $this.OutputTypes = [System.Collections.Generic.List[OutputMetadata]]::New()
        $this.Parameters = [System.Collections.Generic.List[ParameterMetadata]]::New()
        $this.ParameterSets = [System.Collections.Generic.List[ParameterSetMetadata]]::New()
        $this.AliasList = [System.Collections.Generic.List[System.String]]::New()
    }
}

class ModuleMetadata : BaseMetadata
{
    [System.Collections.Generic.Dictionary[string, System.Boolean]] $ProcessedTypes
    [System.Collections.Generic.List[CmdletMetadata]] $Cmdlets
    [System.Collections.Generic.Dictionary[string, TypeMetadata]] $TypeDictionary
    
    ModuleMetadata()
    {
        $this.TypeDictionary = [System.Collections.Generic.Dictionary[string, TypeMetadata]]::New()
        $this.TypeDictionary.Add("System.String",  [TypeMetadata]::New("System.String"))
        $this.TypeDictionary.Add("System.Boolean", [TypeMetadata]::New("System.Boolean"))
        $this.TypeDictionary.Add("System.Byte",    [TypeMetadata]::New("System.Byte"))
        $this.TypeDictionary.Add("System.SByte",   [TypeMetadata]::New("System.SByte"))
        $this.TypeDictionary.Add("System.Int16",   [TypeMetadata]::New("System.Int16"))
        $this.TypeDictionary.Add("System.UInt16",  [TypeMetadata]::New("System.UInt16"))
        $this.TypeDictionary.Add("System.Int32",   [TypeMetadata]::New("System.Int32"))
        $this.TypeDictionary.Add("System.UInt32",  [TypeMetadata]::New("System.UInt32"))
        $this.TypeDictionary.Add("System.Int64",   [TypeMetadata]::New("System.Int64"))
        $this.TypeDictionary.Add("System.UInt64",  [TypeMetadata]::New("System.UInt64"))
        $this.TypeDictionary.Add("System.Single",  [TypeMetadata]::New("System.Single"))
        $this.TypeDictionary.Add("System.Double",  [TypeMetadata]::New("System.Double"))
        $this.TypeDictionary.Add("System.Decimal", [TypeMetadata]::New("System.Decimal"))
        $this.TypeDictionary.Add("System.Char",    [TypeMetadata]::New("System.Char"))
        $this.ProcessedTypes = [System.Collections.Generic.Dictionary[string, System.Boolean]]::New()
        $this.Cmdlets = [System.Collections.Generic.List[CmdletMetadata]]::New()
    }
}


class TypeMetadata : BaseMetadata
{
    [System.String] $Namespace
    [System.String] $Name
    [System.String] $AssemblyQualifiedName
    [System.Collections.Generic.Dictionary[System.String, System.String]] $Properties
    [System.String] $ElementType
    [System.Collections.Generic.List[System.String]] $GenericTypeArguments
    [System.Collections.Generic.List[MethodSignature]] $Methods
    [System.Collections.Generic.List[MethodSignature]] $Constructors

    TypeMetadata()
    {
        $this.Properties = [System.Collections.Generic.Dictionary[System.String, System.String]]::New()
        $this.GenericTypeArguments = [System.Collections.Generic.List[System.String]]::New()
        $this.Methods = [System.Collections.Generic.List[MethodSignature]]::New()
        $this.Constructors = [System.Collections.Generic.List[MethodSignature]]::New()
    }

    TypeMetadata([System.String] $Name)
    {
        $this.Name = $Name
        $this.Properties = [System.Collections.Generic.Dictionary[System.String, System.String]]::New()
        $this.GenericTypeArguments = [System.Collections.Generic.List[System.String]]::New()
        $this.Methods = [System.Collections.Generic.List[MethodSignature]]::New()
        $this.Constructors = [System.Collections.Generic.List[MethodSignature]]::New()
    }

    TypeMetadata([Type] $InputType, [ModuleMetadata] $ModuleMetadata)
    {
        $this.LoadType($InputType, $ModuleMetadata, $False)
    }

    TypeMetadata([Type] $InputType, [ModuleMetadata] $ModuleMetadata, [Switch]$ExcludeMethod)
    {
        $this.LoadType($InputType, $ModuleMetadata, $ExcludeMethod)
    }

    hidden LoadType([Type] $InputType, [ModuleMetadata] $ModuleMetadata, [Switch]$ExcludeMethod)
    {

        $this.Namespace = $InputType.Namespace
        $this.Name = $InputType.ToString()
        $this.AssemblyQualifiedName = $InputType.AssemblyQualifiedName
        $this.Properties = [System.Collections.Generic.Dictionary[System.String, System.String]]::New()
        $this.GenericTypeArguments = [System.Collections.Generic.List[System.String]]::New()
        $this.Methods = [System.Collections.Generic.List[MethodSignature]]::New()
        $this.Constructors = [System.Collections.Generic.List[MethodSignature]]::New()

        $_Properties = $InputType.GetProperties() | Sort-Object -Property PropertyType
        $_Methods = @()
        $_Constructors = @()
        if ($ExcludeMethod -ne $true) {
            $_Methods = $InputType.GetMethods() | Where-Object { -not $_.IsSpecialName }
            $_Constructors = $InputType.GetConstructors()
        }

        if ($InputType.HasElementType)
        {
            $this.ElementType = $InputType.GetElementType().ToString()
            if (-not $ModuleMetadata.TypeDictionary.ContainsKey($this.ElementType))
            {
                $ModuleMetadata.TypeDictionary.Add($this.ElementType, [TypeMetadata]::New($this.ElementType))
                $typeMetadata = [TypeMetadata]::New($InputType.GetElementType(), $ModuleMetadata)
                $ModuleMetadata.TypeDictionary[$this.ElementType] = $typeMetadata
            }
            return
        }
        if ($InputType.IsGenericType)
        {
            $_GenericTypeArguments = $InputType.GetGenericArguments()
            foreach ($Arg in $_GenericTypeArguments)
            {
                $this.GenericTypeArguments.Add($Arg.ToString())
                if (-not $ModuleMetadata.TypeDictionary.ContainsKey($Arg.ToString()))
                {
                    $ModuleMetadata.TypeDictionary.Add($Arg.ToString(), [TypeMetadata]::New($Arg.ToString()))
                    $typeMetadata = [TypeMetadata]::New($Arg, $ModuleMetadata)
                    $ModuleMetadata.TypeDictionary[$Arg.ToString()] = $typeMetadata
                }
            }
            return;
        }
        if ($this.Namespace.StartsWith("System"))
        {
            return
        }
        foreach ($property in $_Properties)
        {
            $propertyType = $property.PropertyType
            if (-not $ModuleMetadata.TypeDictionary.ContainsKey($propertyType.ToString()))
            {
                $ModuleMetadata.TypeDictionary.Add($propertyType.ToString(), [TypeMetadata]::New($propertyType.ToString()))
                $typeMetadata = [TypeMetadata]::New($propertyType, $ModuleMetadata)
                $ModuleMetadata.TypeDictionary[$propertyType.ToString()] = $typeMetadata
            }
            if (-not $this.Properties.ContainsKey($property.Name.ToString()))
            {
                $this.Properties.Add($property.Name, $propertyType.ToString())
            }
        }
        foreach ($method in $_Methods)
        {
            $methodParameterMetadata = [System.Collections.Generic.List[MethodParameterMetadata]]::New()
            [MethodMetadata] $methodMetadata = $Null
            $Key = $method.ReturnType.ToString()
            if ($ModuleMetadata.TypeDictionary.ContainsKey($Key))
            {
                $typeMetadata = $ModuleMetadata.TypeDictionary[$Key]
                $methodMetadata = [MethodMetadata]::New()
                $methodMetadata.Name = $method.Name
                $methodMetadata.ReturnType = $typeMetadata.Name
            }
            else
            {
                $ModuleMetadata.TypeDictionary.Add($Method.ReturnType.ToString(), [TypeMetadata]::New($Method.ReturnType.ToString()))

                $typeMetadata = [TypeMetadata]::New($Method.ReturnType, $ModuleMetadata)
                $methodMetadata = [MethodMetadata]::New()
                $methodMetadata.Name = $method.Name
                $methodMetadata.ReturnType = $Method.ReturnType.ToString()
                $ModuleMetadata.TypeDictionary[$Method.ReturnType.ToString()] = $typeMetadata
            }
            foreach ($parameter in $method.GetParameters())
            {
                $parameterMetadata = [MethodParameterMetadata]::New()
                $parameterMetadata.Name = $parameter.Name
                $parameterMetadata.Type = $parameter.ParameterType.ToString()
                $methodParameterMetadata.Add($parameterMetadata)
            }
            $methodMetadata.Parameters = $methodParameterMetadata
            $this.Methods.Add($methodMetadata)
        }
        foreach ($constructor in $_Constructors)
        {
            $constructorParameterMetadata = [System.Collections.Generic.List[MethodParameterMetadata]]::New()
            $constructorMetadata = [ConstructorMetadata]::New()
            foreach ($parameter in $constructor.GetParameters())
            {
                $parameterMetadata = [MethodParameterMetadata]::New()
                $parameterMetadata.Name = $parameter.Name
                $parameterMetadata.Type = $parameter.GetType().ToString()
                $constructorParameterMetadata.Add($parameterMetadata)
            }
            $constructorMetadata.Parameters = $constructorParameterMetadata
            $this.constructors.Add($constructorMetadata)
        }
    }
}