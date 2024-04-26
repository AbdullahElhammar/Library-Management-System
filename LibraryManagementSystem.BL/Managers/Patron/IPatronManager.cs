using LibraryManagementSystem.DAL;

namespace LibraryManagementSystem.BL;

public interface IPatronManager
{
    IEnumerable<PatronDto> GetAll();
    PatronDto? GetById(int id);
    int Add(PatronDto patron);
    bool Update(PatronDto patron);
    bool Delete(int id);
    PatronWithDetailsDto? GetPatronWithDetails(int id);
}
