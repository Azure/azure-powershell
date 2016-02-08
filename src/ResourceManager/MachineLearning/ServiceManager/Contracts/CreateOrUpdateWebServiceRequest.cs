using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.MachineLearning.Contracts
{
    public class CreateOrUpdateWebServiceRequest
    {
        public string Location { get; set; }
        public List<string> Tags { get; set; }
        public CreateOrUpdateWebServcieRequestProperties Properties { get; set; }
        public SkuProperties Sku { get; set; }
    }

    public class CreateOrUpdateWebServcieRequestProperties
    {
        public string Description { get; set; }
        public string StudioWorkspaceId { get; set; }
        public RealTimeConfigrationProperties RealTimeConfigration { get; set; }
        public bool ReadOnly { get; set; }
        public DiagnosticsProperties Diagnostics { get; set; }
        public PackageTypes PackageType { get; set; }
        public CodeWebServicePackage CodePackage { get; set; }
        public GraphWebServicePackage GraphPackage { get; set; }
    }

    public class SkuProperties
    {
        public string Name { get; set; }
        public SkuTiers Tier { get; set; }
        public uint Size { get; set; }
        public string Family { get; set; }  // Should be enum?
        public string Capacity { get; set; } // Should be enum or uint?
    }

    public class RealTimeConfigrationProperties
    {
        public int MaxConcurrentCalls { get; set; }
        public int MaxMemoryInMb { get; set; }
        public int MaxDurationInSeconds { get; set; }
    }

    public class DiagnosticsProperties
    {
        public DiagnosticLevels Level { get; set; }
        public DateTime Expiry { get; set; }
        public string StorageAccount { get; set; }
    }

    public enum PackageTypes
    {
        Code,
        Graph
    }

    public enum DiagnosticLevels
    {
        None,
        Error,
        All
    }

    public enum SkuTiers
    {
        Free,
        Premium
    }

    public class CodeWebServicePackage
    {
        public SupportedLanguages Language { get; set; }
        public string SourceCode { get; set; }
        public string ZipFileLocation { get; set; }
        public List<CodePackageSchemaColumn> InputSchema { get; set; }
        public List<CodePackageSchemaColumn> OutputSchema { get; set; }
    }

    public class GraphWebServicePackage
    {
        // TODO: Fill it up
    }

    public enum SupportedLanguages
    {
        Python27,
        R31
    }

    public class CodePackageSchemaColumn
    {
        public ObjectTypes Type { get; set; }
        public string Format { get; set; }
        public string Description { get; set; }
        public List<string> Enum { get; set; }
    }

    public enum ObjectTypes
    {
        String,
        Boolean,
        Integer,
        Number,
        Object
    }
}
