using System.ComponentModel.DataAnnotations;

namespace CreditCardChallenge.Api.Models
{
    public class CardDto
    {
        [Required]
        [CreditCard]
        public string CardNumber { get; set; }

        [Required]
        public string CardName { get; set; }

        [StringLength(2)]
        public string Month { get; set; }

        [StringLength(2)]
        public string Year { get; set; }

        [StringLength(4)]
        public string Cvv { get; set; }

        public CardType CardType { get; set; }
    }
    // Extension to convert CardDto to CardDetails
    public static class CardDetailsExtension
    {
        public static CardDetails ToCardDetails(this CardDto card)
        {
            return new CardDetails
            {
                CardName = card.CardName,
                CardNumber = card.CardNumber,
                Month = card.Month,
                Year = card.Year,
                Cvv = card.Cvv,
                CardType = card.CardType
            };
        }
    }
}