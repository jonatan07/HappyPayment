namespace HappyPayment.Application.Dtos
{
    public record PaymentData
    {
        public required PaymentCardData CardData { get; init; }
        public required string UserName { get;init; }
        public required string UserEmail { get; init; }
        public required string UserPhone { get; init; }
        public required string Currency { get; init; }
        public required decimal Amount { get; init; }
    }
    public record PaymentCardData
    {
        public required string CardNumber { get; init; }
        public string CardName { get; init; }
        public string ExpiryMonth { get; init; }
        public string ExpiryYear { get; init; }
        public string Cvv { get; init; }
    }
}
