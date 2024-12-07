using System.ComponentModel.DataAnnotations;

namespace Competency5.Client
{
    public class InvestmentCalc
    {
        // Const
        private readonly Exception negativeErr = new Exception("You may not use negative numbers as an input.");
        private readonly Exception outOfRangeErr = new Exception("Paramiter is out of range.");
        // Vars
        private int cmpPerYear;
        private double interest;
        private double principal;
        private int years;

        // Properties
        public double FutureValue { get; protected set; }
        [Range(1, 24, ErrorMessage = "Compounds must be between 1 and 24")]
        public int CmpPerYear
        {
            get { return cmpPerYear; }
            set
            {
                cmpPerYear = value;
                Calc();
            }
        }
        [Range(0, 100, ErrorMessage = "Interest must be between 0% and 100%")]
        public double Interest
        {
            get { return interest; }
            set
            {
                interest = value;
                Calc();
            }
        }
        [Range(0, double.MaxValue, ErrorMessage = "Principal must be between 0 and the maximum double value")]
        public double Principal
        {
            get { return principal; }
            set
            {
                principal = value;
                Calc();
            }
        }
        [Range(1, 30, ErrorMessage = "Years must be between 1 and 30")]
        public int Years
        {
            get { return years; }
            set
            {
                years = value;
                Calc();
            }
        }

        // Calc
        private void Calc()
        {
            // A = P(1+r/n)^nt

            // Handle negatives
            if (Principal < 0 || Interest < 0 || Years < 0 || CmpPerYear < 0) { throw negativeErr; }

            // Handle out of range errors
            if (Years > 30 && Years != 0) { throw outOfRangeErr; }              // Years
            if (CmpPerYear > 24 && CmpPerYear != 0) { throw outOfRangeErr; }    // CmpPerYear
            if (Interest > 100) { throw outOfRangeErr; }                        // Interest
            if (Principal > double.MaxValue) { throw outOfRangeErr; }           // Pricipal



            FutureValue = Principal * Math.Pow(1 + Interest / 100 / CmpPerYear, CmpPerYear * Years);
        }

        // Constructors
        public InvestmentCalc()
        {
            Principal = 1000;
            Interest = 25;
            Years = 5;
            CmpPerYear = 1;
        }

        public InvestmentCalc(double interest, double principal, int years, int numTimes)
        {
            Interest = interest;
            Principal = principal;
            Years = years;
            CmpPerYear = numTimes;
        }
    }
}

