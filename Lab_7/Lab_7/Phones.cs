﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_7
{
    public partial class  Phones
    {
        public  Phones(int id, string name, string company, long price)
        {
            this.id = id;
            this.name = name;
            this.company = company;
            this.price = price;
        }


        public void SetId(int id)
        {
            this.id = id;
        }
        public void SetName(string name)
        {
            this.name = name;   
        }
        public void SetCompany(string company)
        {
            this.company= company;
        }
        public void SetPrice(long price)
        {
            this.price = price;
        }
    }
}
