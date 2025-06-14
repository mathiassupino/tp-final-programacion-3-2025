﻿using System.ComponentModel.DataAnnotations;

namespace crypto_wallet_api.Models
{
    public class CryptoCurrency
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }
    }
}