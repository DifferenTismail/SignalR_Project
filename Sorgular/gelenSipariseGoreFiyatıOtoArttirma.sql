Create Trigger IncreaseOrderTotalPrice
on OrderDetails
After insert
as 
Declare @OrderID int 
Declare @OrderPrice decimal
SELECT @OrderID = OrderID from inserted
select @OrderPrice = TotalPrice from inserted
update Orders set TotalPrice = TotalPrice + @OrderPrice where OrderID = @OrderID