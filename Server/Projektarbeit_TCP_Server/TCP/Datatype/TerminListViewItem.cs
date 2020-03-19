using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client
{
    class TerminListViewItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string EndDate { get; set; }
        public string Id { get; set; }


        public TerminListViewItem()
        {
            Random rand = new Random();
            Id = rand.Next(0, 999999).ToString();
        }

    }
}
