

namespace LibraryManagementSystem.DAL;

public interface IBorrRecordRepo
{
    void Borrow(BorrowingRecord BorrowingData);
    BorrowingRecord? GetBorrowingProcess(int BookId, int PatronId);  
    int SaveChanges();

}
