using DialCMS.Domain.Core;

namespace DialCMS.Domain.ValueObjects;

public class MoneyFieldValue: ValueObject
{
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }

    public MoneyFieldValue(decimal amount, string currency = "USD")
    {
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative.", nameof(amount));

        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("Currency cannot be null or empty.", nameof(currency));

        Amount = amount;
        Currency = currency;
    }

    public override string ToString() => $"{Currency} {Amount:F2}";
}