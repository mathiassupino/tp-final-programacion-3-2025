namespace crypto_wallet_api.DTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public int Action { get; set; }
        public string CryptoCode { get; set; }
        public decimal CryptoAmount { get; set; }
        public decimal Money { get; set; }
        public DateTime Datetime { get; set; }
    }
}