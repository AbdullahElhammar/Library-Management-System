using LibraryManagementSystem.DAL.Data.Context;

namespace LibraryManagementSystem.DAL;

public class BorrRecordRepo : IBorrRecordRepo
{
    private readonly SystemContext context;
    public BorrRecordRepo(SystemContext context)
    {
        this.context = context;
    }
    public void Borrow(BorrowingRecord BorrowingData)
    {
        context.Set<BorrowingRecord>().Add(BorrowingData);
    }

    public BorrowingRecord? GetBorrowingProcess(int BookId, int PatronId)
    {
        return context.Set<BorrowingRecord>().FirstOrDefault(b => b.BookId == BookId && b.PatronId == PatronId);
    }

    public int SaveChanges()
    {
        return context.SaveChanges();
    }
}
