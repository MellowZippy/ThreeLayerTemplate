class FoodLogic
{
    private List<FoodModel> _foodList;

    public FoodLogic()
    {
        _foodList = FoodAccess.LoadAll();
    }

    public FoodModel GetById(int id)
    {
        return _foodList.Find(i => i.Id == id)!;
    }    

}