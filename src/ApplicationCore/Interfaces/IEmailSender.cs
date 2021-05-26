using System.Threading.Tasks;

namespace Sula.Shipment.ApplicationCore.Interfaces
{

    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
