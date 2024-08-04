namespace MyConsole;

public abstract class PaymentMethod : SmartEnum<PaymentMethod>
{
    public static readonly PaymentMethod Qr = new QrPaymentMethod();
    public static readonly PaymentMethod CreditCard = new CreditCardPaymentMethod();
    protected PaymentMethod(int value, string name) : base (value, name)
    {
    }

    public abstract double Discount { get; }
    private class QrPaymentMethod : PaymentMethod
    {
        public QrPaymentMethod() : base(1, "Qr")
        {
        }

        public override double Discount => 5;
    }

    private class CreditCardPaymentMethod : PaymentMethod
    {
        public CreditCardPaymentMethod() : base(2, "CreditCard")
        {
        }

        public override double Discount => 2.5;
    }
}