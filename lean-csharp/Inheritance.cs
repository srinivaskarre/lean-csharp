using System;

namespace inheritance
{
    class Inheritance
    {
        public static void InheritanceMain(string[] args)
        {
            PaymentGateway paymentGateway = PaymentGatewayFactory.GetPaymentGatewayFactory().GetPaymentGateway(GatewayType.HDFC);
            paymentGateway.doPaymentWithAudit(12345, 100.98);
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
        public HDFCPaymentGateway() : base(typeof(HDFCPaymentGateway)) { }
        override public PaymentStatus doPayment(int accountNumber, double amount)
        {
            Console.WriteLine("HDFC bank " + accountNumber + " from this account, deducting " + amount);
            return PaymentStatus.SUCCESS;
        }
    }

    class PaypalPaymentGateway : PaymentGateway
    {

        public PaypalPaymentGateway() : base(typeof(PaypalPaymentGateway))
        {

        }

        override public PaymentStatus doPayment(int accountNumber, double amount)
        {
            Console.WriteLine("Paypal bank " + accountNumber + " from this account, deducting " + amount);
            return PaymentStatus.SUCCESS;
        }
    }

    abstract class PaymentGateway
    {

        public PaymentGateway(Type type)
        {
            this.type = type;
        }

        private Type type;
        public PaymentStatus doPaymentWithAudit(int accountNumber, double amount)
        {
            Console.WriteLine("making payment gateway call of "+type.Name+ "Entry >>");
            PaymentStatus paymentStatus = doPayment(accountNumber, amount);
            Console.WriteLine("making payment gateway call of " + type.Name + "Exit <<");
            return paymentStatus;
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
