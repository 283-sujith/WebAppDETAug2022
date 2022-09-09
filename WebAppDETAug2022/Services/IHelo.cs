namespace WebAppDETAug2022.Services
{
    public interface IHelo
    {
        string SayHelo(string name);
    }


    public class Helo1 : IHelo
    {
        public string SayHelo(string name)
        {
            return $"Helo{name},Welcome to ASP";
        }
    }

    public class Helo2 : IHelo
    {
        public string SayHelo(string name)
        {
            return $"hai,Helo{name},how is the day";
        }
    }


    }

