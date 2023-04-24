class OrderLogic
{
    private List<OrderModel> _orders;

    public OrderLogic()
    {
        _orders = OrderAccess.LoadAll();
    }

    public OrderModel GetById(int id)
    {
        return _orders.Find(i => i.orderId == id)!;
    }    
}