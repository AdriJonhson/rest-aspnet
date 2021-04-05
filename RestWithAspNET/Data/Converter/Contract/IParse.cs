using System.Collections.Generic;

namespace RestWithAspNET.Data.Converter.Contract
{
    public interface IParse<I, O>
    {
        O Parse(I input);
        List<O> Parse(List<I> input);
    }
}