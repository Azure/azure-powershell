using AzDev.Models;

namespace AzDev.Services
{
    internal interface IContextProvider
    {
        string ContextPath { get; }
        DevContext LoadContext();
        void SaveContext(DevContext context);
    }
}
