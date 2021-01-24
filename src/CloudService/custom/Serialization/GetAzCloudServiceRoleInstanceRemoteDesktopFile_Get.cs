
namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Cmdlets
{
    public partial class GetAzCloudServiceRoleInstanceRemoteDesktopFile_Get
    {
        partial void overrideOnOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<global::System.IO.Stream> response, ref global::System.Threading.Tasks.Task<bool> returnNow)
        {
            global::System.Collections.ObjectModel.Collection<global::System.String> paths;
            try {
                paths = this.SessionState.Path.GetResolvedProviderPathFromPSPath(OutFile, out var provider);
                if (provider.Name != "FileSystem" || paths.Count == 0)
                {
                    ThrowTerminatingError( new System.Management.Automation.ErrorRecord(new global::System.Exception("Invalid output path."),string.Empty, global::System.Management.Automation.ErrorCategory.InvalidArgument, OutFile) );
                }
                if (paths.Count > 1)
                {
                    ThrowTerminatingError( new System.Management.Automation.ErrorRecord(new global::System.Exception("Multiple output paths not allowed."),string.Empty, global::System.Management.Automation.ErrorCategory.InvalidArgument, OutFile) );
                }
            } catch (global::System.Management.Automation.ItemNotFoundException) {
                paths = new global::System.Collections.ObjectModel.Collection<global::System.String>();
                paths.Add(OutFile);
            }
            var path = global::System.IO.Path.GetFullPath(paths[0]);
            using ( var stream = response.GetAwaiter().GetResult() )
            {
                using( var fileStream = global::System.IO.File.OpenWrite(path) )
                {
                    stream.CopyTo(fileStream);
                }
                if (!path.Equals(paths[0]))
                {
                    WriteObject($"OutFile: {path}");
                }
            }
            if (true == MyInvocation?.BoundParameters?.ContainsKey("PassThru"))
            {
                WriteObject(true);
            }
            returnNow = global::System.Threading.Tasks.Task.FromResult<bool>(true);
        }
    }
}