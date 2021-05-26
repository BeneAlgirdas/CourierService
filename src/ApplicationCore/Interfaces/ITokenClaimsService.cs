using System.Threading.Tasks;

namespace Sula.Shipment.ApplicationCore.Interfaces
{
    public interface ITokenClaimsService
    {
        Task<string> GetTokenAsync(string userName);
    }
}
