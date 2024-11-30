namespace examen_final.Domain.Configurations;
public class PackegeOptions {
    public int Small { get; set; }
    public int Medium { get; set; }
    public int Large { get; set; }

    public static class Fact {
        public static string SECTION_NAME => "Package";
    }
}
