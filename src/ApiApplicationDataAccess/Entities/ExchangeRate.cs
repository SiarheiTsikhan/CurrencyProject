namespace ApiApplicationDataAccess.Entities
{
    public class ExchangeRate
    {
        public int Id { get; set; }
        public decimal ExchangeRateToEUR { get; set; }

        public decimal ExchangeRateToUSD { get; set; }

        public decimal PercentageChangeToUSD { get; set; }

        public decimal PercentageChangeToEUR { get; set; }

        public Currency Currency { get; set; }

    }
}
