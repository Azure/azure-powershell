using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IParameters<TModel>
        where TModel : class
    {
        string Location { get; set; }

        Task<ResourceConfig<TModel>> CreateConfigAsync();
    }
}
