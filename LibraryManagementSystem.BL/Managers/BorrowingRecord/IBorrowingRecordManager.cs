

using LibraryManagementSystem.DAL;

namespace LibraryManagementSystem.BL;

public interface IBorrowingRecordManager
{
    bool Borrow(BorrowingRecordDto BorrowingData, int PatronId);
    BorrowingRecord? GetBorrowingProcess(int BookId, int PatronId);
}
