using AndPlace.Data.Domain.DTO.Menu;
using AndPlace.Data.Domain.Models.Menu;
using AndPlace.Infrastructure.Interface.Helpers.Adapters;

namespace AndPlace.Api.Helpers.Adapters;

public class MenuSectionAdapter : IMenuSectionAdapter
{
    public MenuSection MapToMenuSection(MenuSectionModel menuSectionModel)
    {
        try
        {
            return new MenuSection()
            {
                Id = menuSectionModel.Id,
                NameSection = menuSectionModel.NameSection,
                Description = menuSectionModel.Description,
                DepartmentManufacturer = menuSectionModel.DepartmentManufacturer
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public MenuSectionModel MapToMenuSectionModel(MenuSection menuSection)
    {
        try
        {
            return new MenuSectionModel()
            {
                Id = menuSection.Id,
                NameSection = menuSection.NameSection,
                Description = menuSection.Description,
                DepartmentManufacturer = menuSection.DepartmentManufacturer
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}