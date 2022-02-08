namespace Restbucks.Core.Models
{
    public class Receipt
    {
        public double Amount { get; set; }
        public DateTime Paid { get; set; }

        public static Receipt FromPayment(Payment payment)
        {
            return new Receipt { Amount = payment.Amount, Paid = payment.Paid };
        }
    }
}
