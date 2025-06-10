using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crypto_wallet_api.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public TransactionType Action { get; set; }

        [Required]
        public int CryptoCurrencyId { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public decimal CryptoAmount { get; set; }

        [Required]
        public decimal Money { get; set; }

        [Required]
        public DateTime Datetime { get; set; }

        [ForeignKey("CryptoCurrencyId")]
        public CryptoCurrency? CryptoCurrency { get; set; }

        [ForeignKey("ClientId")]
        public Client? Client { get; set; }
    }

    public enum TransactionType
    {
        Purchase,
        Sale
    }
}