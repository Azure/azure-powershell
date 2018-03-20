using Microsoft.Azure.Commands.Common.Strategies;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Strategies
{
    interface IParameters<TModel>
        where TModel : class
    {
        string Location { get; set; }

        Task<ResourceConfig<TModel>> CreateConfigAsync();
    }
}
