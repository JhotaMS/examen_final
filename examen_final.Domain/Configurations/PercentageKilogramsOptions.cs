namespace examen_final.Domain.Configurations;

public class PercentageKilogramsOptions {
    public Balancer BalancerOne { get; set; } = new();
    public Balancer BalancerTwo { get; set; } = new();
    public Balancer BalancerThree { get; set; } = new();

    public class Balancer {
        public int Kilograms { get; set; }
        public int Percentage { get; set; }
    }
    public static class Fact {
        public static string SECTION_NAME => "PercentageKilograms";
    }
}
