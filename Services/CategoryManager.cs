﻿using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;
public class CategoryManager : ICategoryService
{
    private readonly IRepositoryManager _manager;
    private ILoggerService logger;
    private IMapper mapper;
    private IBookLinks bookLinks;

    public CategoryManager(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        => await _manager.Category
                         .GetAllCategoriesAsync(trackChanges);

    public async Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges)
    {
        var category = await _manager
            .Category
            .GetOneCategoryByIdAsync(id, trackChanges);

        if (category is null)
        {
            throw new CategoryNotFoundException(id);
        }

        return category;
    }

}
