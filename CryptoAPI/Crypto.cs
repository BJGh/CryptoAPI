using Microsoft.AspNetCore.Mvc;

namespace CryptoAPI
{
   public class Crypto
    {
        public int Id { get; set; }
        public string trFrom { get; set; }
        public string trTo { get; set; }
        public double cryptoAmount { get; set; }
        public string currencyType { get; set; }
        public string transferType { get; set; }
        public DateTime transferDate { get; set; }
        public double balance { get; set; }
        public string client { get; set; }
      

    }
}