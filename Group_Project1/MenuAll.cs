using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Group_Project1
{
    class MenuAll
    {
        private List<MenuItem> MenuList = new List<MenuItem>();

        // add a menu item
        public void AddNewItem(int group, string name, double cost)
        {
            MenuList.Add(new MenuItem(group, name, cost));
        }


        public List<MenuItem> GetAll()
        {
            return MenuList;
        }
    }
}
