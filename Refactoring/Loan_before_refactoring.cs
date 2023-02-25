namespace Refactoring;

public class Loan
{
    public double Commitment { get; }
    public double Outstanding { get; }
    public int RiskRating { get; }
    public Date? Maturity { get; }
    public Date? Expiry { get; }
    public CapitalStrategy? Strategy { get; }

    public Loan(double commitment, int riskRating, Date? maturity) 
        : this(commitment, outstanding: 0.00, riskRating, maturity, expiry: null)
    {
    }

    public Loan(double commitment, int riskRating, Date? maturity, Date? expiry) 
        : this(commitment, outstanding: 0.00, riskRating,
        maturity, expiry)
    {
    }


    public Loan(double commitment, double outstanding, int riskRating, Date? maturity, Date? expiry) 
        : this(capitalStrategy: null, commitment, outstanding, riskRating, maturity, expiry)
    {
    }

    public Loan(CapitalStrategy capitalStrategy, double commitment, int riskRating, Date? maturity, Date? expiry) 
        : this(capitalStrategy, commitment, outstanding: 0.00, riskRating, maturity,
        expiry)
    {
    }

    public Loan(CapitalStrategy? capitalStrategy, double commitment,
        double outstanding, int riskRating,
        Date? maturity, Date? expiry)
    {
        Commitment = commitment;
        Outstanding = outstanding;
        RiskRating = riskRating;
        Maturity = maturity;
        Expiry = expiry;
        Strategy = capitalStrategy switch
        {
            null when expiry == null => new CapitalStrategyTermLoan(),
            null when maturity == null => new CapitalStrategyRevolver(),
            null => new CapitalStrategyRctl(),
            _ => capitalStrategy
        };
    }
}
