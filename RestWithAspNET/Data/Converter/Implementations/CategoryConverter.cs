using System.Collections.Generic;
using System.Linq;
using RestWithAspNET.Data.Converter.Contract;
using RestWithAspNET.Data.VO;
using RestWithAspNET.Models;

namespace RestWithAspNET.Data.Converter.Implementations
{
    public class CategoryConverter : IParse<CategoryVO, Category>, IParse<Category, CategoryVO>
    {
        public Category Parse(CategoryVO input)
        {
            if (input == null) return null;
            
            return new Category
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public List<Category> Parse(List<CategoryVO> input)
        {
            return input == null ? new List<Category>() : input.Select(item => Parse(item)).ToList();
        }

        public CategoryVO Parse(Category input)
        {
            if (input == null) return null;
            
            return new CategoryVO
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public List<CategoryVO> Parse(List<Category> input)
        {
            return input == null ? new List<CategoryVO>() : input.Select(item => Parse(item)).ToList();
        }
    }
}