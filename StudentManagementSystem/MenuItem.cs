using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class MenuItem
    {
        public string Title { get; set; }
        public bool IsSelected { get; set; }

        public MenuItem(string title, bool isSelected)
        {
            Title = title;
            IsSelected = isSelected;
        }
    }
}
