using WebApi.Hal;

namespace OwinSelfHost
{
    public class Model : Representation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}