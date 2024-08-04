
using MyConsole;

var paymentMethod = PaymentMethod.CreditCard;
Console.WriteLine($"Payment Method: {paymentMethod} with Discount {paymentMethod.Discount:P}");

var paymentMethodFromValue = PaymentMethod.FromValue(1);
var paymentMethodFromName = PaymentMethod.FromName("Qr");
Console.WriteLine($"Payment Method From Value: {paymentMethodFromValue}, Payment Metho From Name: {paymentMethodFromName}");

var creditCardPaymentMethod = PaymentMethod.CreditCard;
Console.WriteLine($"Credit Card Payment Method has discount: {creditCardPaymentMethod.Discount}");

var qrPaymentMethod = PaymentMethod.Qr;
Console.WriteLine($"Qr Payment Method has discount: {qrPaymentMethod.Discount}");

var normalUserType = UserType.Normal;
Console.WriteLine($"Normal User Type Has Value: {normalUserType.Value}");

var premiumUserType = UserType.Premium;
Console.WriteLine($"Premium User Type Has Value: {premiumUserType.Value}");
Console.ReadLine();