

using LibraryManagementSystem.DAL;


namespace LibraryManagementSystem.BL;

public class BorrowingRecordManager : IBorrowingRecordManager
{
    private readonly IBorrRecordRepo repo;
    public BorrowingRecordManager(IBorrRecordRepo repo)
    {
        this.repo = repo;
    }

    public bool Borrow(BorrowingRecordDto BorrowingData, int PatronId)
    {
        BorrowingRecord AddRecord = new()
        {
            Id=BorrowingData.Id,
            PatronId=PatronId,
            BookId=BorrowingData.BookId,
            BorrowDate=BorrowingData.BorrowDate,
            ReturnDate=BorrowingData.ReturnDate
        };
        repo.Borrow(AddRecord);
        repo.SaveChanges();
        return true;
    }

    public BorrowingRecord? GetBorrowingProcess(int BookId, int PatronId)
    {
       return repo.GetBorrowingProcess(BookId, PatronId);
    }
}
