﻿using System.Linq.Dynamic.Core;
using Entities.Models;

namespace Repositories.EFCore.Extensions;

public static class BookRepositoryExtensions
{
    public static IQueryable<Book> FilterBooks(
        this IQueryable<Book> books,
        uint minPrice, uint maxPrice)
    {
        return books.Where(book =>
            book.Price >= minPrice
         && book.Price <= maxPrice);
    }

    public static IQueryable<Book> Search(
        this IQueryable<Book> books,
        string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return books;
        }
        else
        {
            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return books
                .Where(b => b.Title
                .ToLower()
                .Contains(searchTerm));
        }
    }

    public static IQueryable<Book> Sort(
        this IQueryable<Book> books,
        string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
        {
            return books.OrderBy(b => b.Id);
        }

        var orderQuery = OrderQueryBuilder
            .CreateOrderQuery<Book>(orderByQueryString);

        if (orderQuery is null)
        {
            return books.OrderBy(b => b.Id);
        }

        return books.OrderBy(orderQuery);
    }
}
