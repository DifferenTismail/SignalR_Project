Create Trigger DecreaseOrderTotalPrice
on OrderDetails
After Delete
as 
Declare @OrderID int 
Declare @OrderPrice decimal
SELECT @OrderID = OrderID from deleted
select @OrderPrice = TotalPrice from deleted
update Orders set TotalPrice = TotalPrice - @OrderPrice where OrderID = @OrderID