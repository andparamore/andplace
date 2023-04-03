using AndPlace.Data.Domain.DTO.Menu;
using AndPlace.Data.Domain.Models.Menu;

namespace AndPlace.Infrastructure.Interface.Helpers.Adapters;

public interface IMenuSectionAdapter
{
    MenuSection MapToMenuSection(MenuSectionModel menuSectionModel);
    
    MenuSectionModel MapToMenuSectionModel(MenuSection menuSection);
}