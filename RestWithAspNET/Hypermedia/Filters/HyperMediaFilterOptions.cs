using System.Collections.Generic;
using RestWithAspNET.Hypermedia.Abstract;

namespace RestWithAspNET.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnrichers { get; set; } = new List<IResponseEnricher>();
    }
}