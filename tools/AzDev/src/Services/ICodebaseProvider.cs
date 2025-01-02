using AzDev.Models.Inventory;

namespace AzDev.Services
{
    internal interface ICodebaseProvider
    {
        Codebase GetCodebase();
    }
}
