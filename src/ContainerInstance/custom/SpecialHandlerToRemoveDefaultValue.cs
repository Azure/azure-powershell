namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;
/// <summary>The GPU resource.</summary>
    public partial class GpuResource
    {
        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, ref bool returnNow)
        {
            if(string.Empty.Equals(this._sku))
            {
                this._sku = null;
            }
        }
    }

    /// <summary>The resource requests.</summary>
    public partial class ResourceRequests
    {
        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, ref bool returnNow)
        {
            if(this._gpu?.Count == 0 || this._gpu?.Sku == null)
            {
                this._gpu = null;
            }
        }

    }

    /// <summary>The resource limits.</summary>
    public partial class ResourceLimits
    {     
        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, ref bool returnNow)
        {
            if(this._gpu?.Count == 0 || this._gpu?.Sku == null)
            {
                this._gpu = null;
            }
            if(this._memoryInGb == 0)
            {
                this._memoryInGb = null;
            }
            if(this._cpu == 0)
            {
                this._cpu = null;
            }
        }
    }

    /// <summary>The container Http Get settings, for liveness or readiness probe</summary>
    public partial class ContainerHttpGet
    {        
        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, ref bool returnNow)
        {
            if(string.Empty.Equals(this._httpHeader?.Name)|| string.Empty.Equals(this._httpHeader?.Value))
            {
                this._httpHeader = null;
            }

            if(string.Empty.Equals(this._scheme))
            {
                this._scheme = null;
            }

            if(string.Empty.Equals(this._path))
            {
                this._path = null;
            }
        }
    }
    
    /// <summary>The container probe, for liveness or readiness</summary>
    public partial class ContainerProbe
    {
        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, ref bool returnNow)
        {
            if(this._httpGet?.Port == 0)
            {
                this._httpGet = null;
            }
            if(this._initialDelaySecond == 0)
            {
                this._initialDelaySecond = null;
            }
            if(this._periodSecond == 0)
            {
                this._periodSecond = null;
            }
            if(this._failureThreshold == 0)
            {
                this._failureThreshold = null;
            }
            if(this._successThreshold == 0)
            {
                this._successThreshold = null;
            }
            if(this._timeoutSecond == 0)
            {
                this._timeoutSecond = null;
            }
        }

    }

    /// <summary>The container instance properties.</summary>
    public partial class ContainerProperties
    {
        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, ref bool returnNow)
        {
            if(this._readinessProbe?.ExecCommand?.Length == 0 && this._readinessProbe?.HttpGetPort == null)
            {
                this._readinessProbe = null;
            }
            if(this._livenessProbe?.ExecCommand?.Length == 0 && this._livenessProbe?.HttpGetPort == null)
            {
                this._livenessProbe = null;
            }
        }
        
    }

    /// <summary>The environment variable to set within the container instance.</summary>
    public partial class EnvironmentVariable
    {
        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, ref bool returnNow)
        {
            if(string.Empty.Equals(this._value))
            {
                this._value = null;
            }
            
            if(string.Empty.Equals(this._secureValue))
            {
                this._secureValue = null;
            }
        }
    }

    /// <summary>The port exposed on the container instance.</summary>
    public partial class ContainerPort{
        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, ref bool returnNow)
        {     
            if(string.Empty.Equals(this._protocol))
            {
                this._protocol = null;
            }
        }
  
    }


    /// <summary>The port exposed on the container group.</summary>
    public partial class Port
    {
         partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, ref bool returnNow)
        {
            if(string.Empty.Equals(this._protocol))
            {
                this._protocol = null;
            }
        }       
    }

    
    /// <summary>Image registry credential.</summary>
    public partial class ImageRegistryCredential
    {   
        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, ref bool returnNow)
        {
            if(string.Empty.Equals(this._password))
            {
                this._password = null;
            }
        }        
    }
    /// <summary>The init container definition properties.</summary>
    public partial class InitContainerPropertiesDefinition
    {
         partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, ref bool returnNow)
        {

            if(string.Empty.Equals(Image))
            {
                this._image = null;
            }
        }               
    }

    /// <summary>The init container definition.</summary>
    public partial class InitContainerDefinition
    {
         partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, ref bool returnNow)
        {
            if(this._property?.Image ==null &&　this.VolumeMount?.Length == 0 && this.EnvironmentVariable?.Length == 0 && this.Command?.Length == 0)
            {
                this._property = null;
            }
        }
    }

    /// <summary>
    /// The properties of the Azure File volume. Azure File shares are mounted as volumes.
    /// </summary>
    public partial class AzureFileVolume
    {
        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, ref bool returnNow)
        {
            if(string.Empty.Equals(this._storageAccountKey))
            {
                this._storageAccountKey = null;
            }
        }
       
    }

     /// <summary>Represents a volume that is populated with the contents of a git repository</summary>
    public partial class GitRepoVolume
    {
        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, ref bool returnNow)
        {
             if(string.Empty.Equals(this._revision))
            {
                this._revision = null;
            }
            if(string.Empty.Equals(this._directory))
            {
                this._directory = null;

            }
        }
    }

    /// <summary>The properties of the volume.</summary>
    public partial class Volume
    {
        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, ref bool returnNow)
        {
            if(string.Empty.Equals(this._azureFile?.ShareName) || string.Empty.Equals(this._azureFile?.StorageAccountName))
            {
                this._azureFile = null;
            }
            if(string.Empty.Equals(this._gitRepo?.Repository))
            {
                this._gitRepo = null;
            }
            
            this._emptyDir = null;

            this._secret = null;
        } 
    
    }
}
