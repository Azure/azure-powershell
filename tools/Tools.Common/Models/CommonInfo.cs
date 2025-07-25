using System.Collections.Generic;

namespace VersionController.Netcore.Models
{
    public class CommonInfo
    {
        public static List<string> ExcludedParameters = new List<string>{
            "AzureRMContext", "Break", "Debug", "DefaultProfile", "EnableTestCoverage",
            "ErrorAction", "ErrorVariable", "HttpPipelineAppend", "HttpPipelinePrepend", "InformationAction",
            "InformationVariable", "OutBuffer", "OutVariable", "PipelineVariable", "Proxy",
            "ProxyCredential", "ProxyUseDefaultCredentials", "Verbose", "WarningAction", "WarningVariable",
            "ProgressAction",
            // excluded runtime dynamic parameters
            // "EnableTestCoverage", "TestCoverageLocation", "TargetName" 
        };
    }
}
