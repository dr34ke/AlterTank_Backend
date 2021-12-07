namespace AlterTankBackend.Models
{
    public class Station
    {
        int id { get; set; }
        string latitude { get; set; }
        string longitude { get; set; }
        string name { get; set;  }
        string description { get; set; }
        string lastPrice { get; set; }
    }
}
