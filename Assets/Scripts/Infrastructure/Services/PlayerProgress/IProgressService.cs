using MoneyBank;

namespace Infrastructure.Services.PlayerProgress
{
    public interface IProgressService : IService
    {
        MoneyData Money { get; set; }
    }
}