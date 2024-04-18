using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Shared.Config;
using Microsoft.Azure.PowerShell.Common.Config;

namespace Microsoft.Azure.Commands.Common.Authentication.Utilities
{
    static public class AzConfigReader
    {

        public static IAzureSession Session
        {
            get
            {
                return AzureSession.Instance;
            }
        }

        static public bool IsWamEnabled()
        {
            if (!Session.TryGetComponent<IConfigManager>(nameof(IConfigManager), out var config))
            {
                try
                {
                    return config.GetConfigValue<bool>(ConfigKeys.EnableLoginByWam);
                }
                catch
                {

                }
            }
            return true;
        }
    }
}
