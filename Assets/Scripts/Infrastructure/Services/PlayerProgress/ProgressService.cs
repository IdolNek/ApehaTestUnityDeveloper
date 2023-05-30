using MoneyBank;

namespace Infrastructure.Services.PlayerProgress
{
    public class ProgressService : IProgressService
    {
        public MoneyData Money { get; set; }

        public ProgressService()
        {
            Money = new MoneyData();
        }
    }
}