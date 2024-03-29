﻿namespace GameKeyShop.Server.Services.CategoryService
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
                var categories = await _context.Categories.Where(c => !c.Deleted && c.Visible).ToListAsync();
                response.Data = categories;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }
            
            return response;
        }

        public async Task<ServiceResponse<List<Category>>> GetAdminCategories()
        {
            var response = new ServiceResponse<List<Category>>();

            try
            {
                var categories = await _context.Categories.Where(c => !c.Deleted).ToListAsync();
                response.Data = categories;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Category>>> AddCategory(Category category)
        {
            try
            {
                category.Editing = category.IsNew = false;
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return await GetAdminCategories();
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<Category>>
                {
                    Data = null,
                    Success = false,
                    Message = $"Could not add category. Error: {e.Message}"
                };
            }
        }

        public async Task<ServiceResponse<List<Category>>> UpdateCategory(Category category)
        {
            try
            {
                var dbCategory = await GetCategoryById(category.Id);
                if (dbCategory == null)
                {
                    return new ServiceResponse<List<Category>>
                    {
                        Success = false,
                        Message = "Category not found."
                    };
                }

                dbCategory.Name = category.Name;
                dbCategory.Url = category.Url;
                dbCategory.Visible = category.Visible;

                await _context.SaveChangesAsync();

                return await GetAdminCategories();
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<Category>>
                {
                    Data = null, 
                    Success = false, 
                    Message = $"Could not update category. Error: {e.Message}"
                };
            }
        }

        public async Task<ServiceResponse<List<Category>>> DeleteCategory(int id)
        {
            try
            {
                var category = await GetCategoryById(id);
                if (category == null)
                {
                    return new ServiceResponse<List<Category>>
                    {
                        Success = false,
                        Message = "Category not found."
                    };
                }

                category.Deleted = true;
                await _context.SaveChangesAsync();

                return await GetAdminCategories();
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<Category>>
                {
                    Data = null,
                    Success = false,
                    Message = $"Could not delete category. Error: {e.Message}"
                };
            }
        }

        private async Task<Category?> GetCategoryById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
