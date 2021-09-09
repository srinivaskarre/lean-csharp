using System;

namespace inheritance
{
    class Inheritance
    {
        static void Main(string[] args)
        {
            /*for(int i=0; i<=10; i++) {
                 Console.WriteLine("Enter two number seperated by ,");
                 string line = Console.ReadLine();
                 string[] arr = line.Split(",");
                 int firstNumber = Convert.ToInt32(arr[0]);
                 int secondNumber = Convert.ToInt32(arr[1]);

                 Console.WriteLine(firstNumber + secondNumber);
             }*/
            PaymentGateway paymentGateway = PaymentGatewayFactory.GetPaymentGatewayFactory().GetPaymentGateway(GatewayType.Paypal);
            paymentGateway.doPayment(12345, 100.98);
            Console.WriteLine("Completed the payment");

            int[] someNums = { 1, 2, 3, 4, 5 };
            Console.WriteLine(someNums.ToString());


        }


    }

    class PaymentGatewayFactory
    {
        static internal PaymentGatewayFactory paymentGatewayFactory { set; get; }
        public static PaymentGatewayFactory GetPaymentGatewayFactory()
        {
            if (paymentGatewayFactory == null)
            {
                paymentGatewayFactory = new PaymentGatewayFactory();
            }

            return paymentGatewayFactory;
        }

        public PaymentGateway GetPaymentGateway(GatewayType gateway)
        {

            int type = (int)gateway;

            PaymentGateway paymentgateway;

            switch (type)
            {
                case 0:
                    paymentgateway = new HDFCPaymentGateway();
                    break;
                case 1:
                    paymentgateway = new PaypalPaymentGateway();
                    break;
                default:
                    throw new ArgumentException("Invalid Argument Exception");
            }
            return paymentgateway;
        }
    }

    class HDFCPaymentGateway : PaymentGateway
    {
        override public PaymentStatus doPayment(int accountNumber, double amount)
        {
            Console.WriteLine("HDFC bank " + accountNumber + " from this account, deducting " + amount);
            return PaymentStatus.SUCCESS;
        }
    }

    class PaypalPaymentGateway : PaymentGateway
    {

        override public PaymentStatus doPayment(int accountNumber, double amount)
        {
            Console.WriteLine("Paypal bank " + accountNumber + " from this account, deducting " + amount);
            return PaymentStatus.SUCCESS;
        }
    }

    abstract class PaymentGateway
    {
        PaymentStatus doPaymentWithAudit(int accountNumber, double amount)
        {
            return doPayment(accountNumber, amount);
        }
        public abstract PaymentStatus doPayment(int accountNumber, double amount);
    }



    enum PaymentStatus
    {
        SUCCESS,
        FAILURE
    }

    enum GatewayType
    {

        HDFC,
        Paypal
    }


}
