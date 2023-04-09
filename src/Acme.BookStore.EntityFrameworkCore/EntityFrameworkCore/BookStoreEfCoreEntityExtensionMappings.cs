using Microsoft.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace Acme.BookStore.EntityFrameworkCore;

public static class BookStoreEfCoreEntityExtensionMappings
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        BookStoreGlobalFeatureConfigurator.Configure();
        BookStoreModuleExtensionConfigurator.Configure();

        OneTimeRunner.Run(() =>
        {
            /* 您可以配置额外的属性
                 * 实体中定义应用程序所使用的模块。
                 *
                 * 这个类可以使用这些额外的属性映射到数据库中的表字段。
                 *
                 * 使用这个类只配置EF核心相关的映射。
                 * USE BookStoreModuleExtensionConfigurator CLASS (in the Domain.Shared project)
                 * 对于高水平API定义额外的属性的实体使用模块
                 *
                 * 例子:一个属性映射到一个表字段:

                     ObjectExtensionManager.Instance
                         .MapEfCoreProperty<IdentityUser, string>(
                             "MyProperty",
                             (entityBuilder, propertyBuilder) =>
                             {
                                 propertyBuilder.HasMaxLength(128);
                             }
                         );

                 * 看到更多的文档:看到更多的文档:
                 * https://docs.abp.io/en/abp/latest/Customizing-Application-Modules-Extending-Entities
                 */

            /* You can configure extra properties for the
             * entities defined in the modules used by your application.
             *
             * This class can be used to map these extra properties to table fields in the database.
             *
             * USE THIS CLASS ONLY TO CONFIGURE EF CORE RELATED MAPPING.
             * USE BookStoreModuleExtensionConfigurator CLASS (in the Domain.Shared project)
             * FOR A HIGH LEVEL API TO DEFINE EXTRA PROPERTIES TO ENTITIES OF THE USED MODULES
             *
             * Example: Map a property to a table field:

                 ObjectExtensionManager.Instance
                     .MapEfCoreProperty<IdentityUser, string>(
                         "MyProperty",
                         (entityBuilder, propertyBuilder) =>
                         {
                             propertyBuilder.HasMaxLength(128);
                         }
                     );

             * See the documentation for more:
             * https://docs.abp.io/en/abp/latest/Customizing-Application-Modules-Extending-Entities
             */
        });
    }
}
