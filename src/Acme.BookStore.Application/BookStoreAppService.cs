using System;
using System.Collections.Generic;
using System.Text;
using Acme.BookStore.Books;
using Acme.BookStore.Localization;
using Acme.BookStore.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore;

/* 从这个类继承您的应用程序服务。
 * Inherit your application services from this class.
 */
public abstract class BookStoreAppService : ApplicationService
{
    protected BookStoreAppService()
    {
        LocalizationResource = typeof(BookStoreResource);
    }
}

