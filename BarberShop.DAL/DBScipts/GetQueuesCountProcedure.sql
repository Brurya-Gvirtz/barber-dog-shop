Alter PROC GetQueuesCount (@CustomerId nvarchar, @RowCount int OUTPUT)
AS
BEGIN
SELECT * FROM Queues
SET @RowCount = (SELECT @@ROWCOUNT)
END


exec GetQueuesCount @CustomerId='b1b1af0e-1b15-4191-94b3-ed0968df1acf' @RowCount