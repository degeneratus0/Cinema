using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Navigation
    {
        public Navigation(int recPerPage, int pageIndex, Cinema01Entities entities) 
        {
            this.recPerPage = recPerPage;
            this.pageIndex = pageIndex;
            this.entities = entities;
        }
        private int recPerPage { get; set; } = 3;
        private int pageIndex { get; set; } = 1;
        private Cinema01Entities entities { get; set; }
        public void Navigate(int mode)
        {
            int pageCount = entities.Bill.Count() / recPerPage;
            if (entities.Bill.Count() % recPerPage > 0) { pageCount++; }
            switch (mode)
            {
                case 1:
                    pageIndex = 1;
                    break;
                case 2:
                    if (pageIndex > 1) { pageIndex--; }
                    break;
                case 3:
                    if (pageIndex < pageCount) { pageIndex++; }
                    break;
                case 4:
                    pageIndex = pageCount;
                    break;
            }
            //DGBill.ItemsSource = entities.Bill.OrderBy(x => x.ID).Skip((pageIndex - 1) * recPerPage).Take(recPerPage).ToList();
            //Info.Text = pageIndex + " of " + pageCount;
        }
    }
}
