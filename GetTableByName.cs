private void InitCombobox()
{
    var classes = Assembly.GetAssembly(typeof(TestConsole.directumrx1Context)).GetTypes().ToList(); //get all classes - models
    foreach (var item in classes)
    {
        MainCombobox.Items.Add(item); //add them to combobox
    }
}

private void InitDataGrid()
{
    List<object> list = new();
    using (dbContext db = new())
    {
        var tabType = (Type)MainCombobox.SelectedItem; 
        for (int i = 0; i < 1000; i++)
        {
                list.Add(db.Find(tabType, i)); //be careful by i (primary key)
        }
    }
    MainDataGrid.ItemsSource = list.Where(x => x != null);
}
