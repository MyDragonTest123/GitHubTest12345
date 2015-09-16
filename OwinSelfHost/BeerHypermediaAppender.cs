using System.Collections.Generic;
using WebApi.Hal;

namespace OwinSelfHost
{
    public class BeerHypermediaAppender : IHypermediaAppender<Model>
    {
        public void Append(Model resource, IEnumerable<Link> configured)
        {
            foreach (var link in configured)
            {
                switch (link.Rel)
                {
                    case "FirstName":
                        if (resource.FirstName != null)
                            resource.Links.Add(link.CreateLink(new { id = resource.FirstName }));
                        break;
                    case "LastName":
                        if (resource.LastName != null)
                            resource.Links.Add(link.CreateLink(new { id = resource.LastName }));
                        break;
                }
            }
        }
    }
}