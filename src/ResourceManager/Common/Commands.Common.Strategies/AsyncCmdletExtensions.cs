namespace Microsoft.Azure.Commands.Common.Strategies
{
    public static class AsyncCmdletExtensions
    {
        public static void WriteVerbose(this IAsyncCmdlet cmdlet, string message, params object[] p)
            => cmdlet.WriteVerbose(string.Format(message, p));
    }
}