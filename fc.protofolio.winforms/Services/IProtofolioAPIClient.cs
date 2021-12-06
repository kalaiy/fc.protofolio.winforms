using System.Threading;
using System.Threading.Tasks;

namespace Fc.Protofolio.Winforms.Services
{
    public interface IProtofolioAPIClient
    {
  
        Task<T> GetAsync<T>(string url) where T : class;
       
        Task<T> GetAsyncWithCancellation<T>(string url, CancellationToken token) where T : class;
        Task<T> PostAsync<T>(string url, T content);
        Task<T1> PostAsync<T1, T2>(string url, T2 content);
    }
}