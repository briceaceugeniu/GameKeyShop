using System.Reflection.Metadata.Ecma335;

namespace GameKeyShop.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Category>>> GetCategoriesAsync()
        {
            var response = new ServiceResponse<List<Category>>();

            try
            {
                var categories = await _context.Categories.ToListAsync();
                response.Data = categories;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }
            
            return response;
        }
    }
}
